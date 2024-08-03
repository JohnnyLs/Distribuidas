import React, { useEffect, useState } from "react";
import { over } from "stompjs";
import SockJS from "sockjs-client";
import ChatRoomUI from "./ChatRoomUI";
import axios from "axios";
import DOMPurify from "dompurify";

let stompClient = null;

const ChatRoom = () => {
  const [privateChats, setPrivateChats] = useState(new Map());
  const [publicChats, setPublicChats] = useState([]);
  const [tab, setTab] = useState("CHATROOM");
  const [unreadMessages, setUnreadMessages] = useState(new Map());
  const [allUsers, setAllUsers] = useState([]);
  const [searchQuery, setSearchQuery] = useState("");

  const [userData, setUserData] = useState({
    username: "",
    password: "",
    email: "",
    receivername: "",
    connected: false,
    message: "",
    errors: {},
  });
  const [isRegistering, setIsRegistering] = useState(false);

  useEffect(() => {
    if (userData.connected) {
      connect();
      fetchAllUsers();
      loadChatHistory();
    }
  }, [userData.connected]);

  useEffect(() => {
    if (tab !== "CHATROOM" && userData.connected) {
      loadPrivateChatHistory(tab);
    }
  }, [tab]);
  useEffect(() => {
    window.addEventListener("beforeunload", () => {
      if (userData.connected) {
        stompClient.disconnect(() => {
          axios.post("/api/users/disconnect", { username: userData.username });
        });
      }
    });
  }, [userData.connected, stompClient]);

  useEffect(() => {
    window.addEventListener("unload", () => {
      if (userData.connected) {
        stompClient.disconnect(() => {
          axios.post("/api/users/disconnect", { username: userData.username });
        });
      }
    });
  }, [userData.connected, stompClient]);

  useEffect(() => {
    window.addEventListener("pagehide", () => {
      if (userData.connected) {
        stompClient.disconnect(() => {
          axios.post("/api/users/disconnect", { username: userData.username });
        });
      }
    });
  }, [userData.connected, stompClient]);

  const loadPrivateChatHistory = async (receiverName) => {
    if (receiverName === userData.username && tab === receiverName) {
      return;
    }

    try {
      const response = await axios.get(
        `http://localhost:8080/api/chat/history?senderName=${userData.username}&receiverName=${receiverName}`
      );
      const sortedMessages = response.data
        .filter((msg) => msg.message.trim() !== "") // Filtrar mensajes vacíos
        .sort((a, b) => new Date(a.date) - new Date(b.date));
      const uniqueMessages = Array.from(
        new Map(sortedMessages.map((msg) => [msg.id, msg])).values()
      );

      setPrivateChats((prevChats) => {
        const updatedChats = new Map(prevChats);
        updatedChats.set(receiverName, uniqueMessages);
        return updatedChats;
      });
    } catch (error) {
      console.error("Error loading private chat history:", error);
    }
  };

  const connect = () => {
    let Sock = new SockJS("http://localhost:8080/ws");
    stompClient = over(Sock);
    stompClient.connect({ username: userData.username }, onConnected, onError);
  };
  const onConnected = () => {
    setUserData({ ...userData, connected: true });
    stompClient.subscribe("/chatroom/public", onMessageReceived);
    stompClient.subscribe(
      "/user/" + userData.username + "/private",
      onPrivateMessage
    );
    userJoin();
    fetchAllUsers();
    loadChatHistory();
    updateUserStatus(userData.username, true);
  };

  const updateUserStatus = async (username, isOnline) => {
    try {
      await axios.post("http://localhost:8080/api/users/status", {
        username,
        isOnline,
      });
      setAllUsers((prevUsers) =>
        prevUsers.map((user) =>
          user.username === username ? { ...user, online: isOnline } : user
        )
      );
    } catch (error) {
      console.error("Error updating user status:", error);
    }
  };

  const userJoin = () => {
    var chatMessage = {
      senderName: userData.username,
      status: "JOIN",
    };
    stompClient.send("/app/message", {}, JSON.stringify(chatMessage));
  };

  const fetchAllUsers = async () => {
    try {
      const response = await axios.get("http://localhost:8080/api/users/all");
      setAllUsers(
        response.data.map((user) => ({ ...user, isConnected: user.online }))
      );
    } catch (error) {
      console.error("Failed to fetch users:", error);
    }
  };
  const sendPrivateValue = () => {
    if (stompClient) {
      const chatMessage = {
        senderName: userData.username,
        receiverName: tab, // El destinatario es el usuario del tab actual
        message: userData.message,
        status: "MESSAGE",
      };

      if (userData.username !== tab) {
        let msgs = privateChats.get(tab) || [];
        msgs.push(chatMessage);
        setPrivateChats(new Map(privateChats.set(tab, msgs)));
      }
      stompClient.send("/app/private-message", {}, JSON.stringify(chatMessage));
      setUserData({ ...userData, message: "" });
    }
  };

  const searchUsers = async () => {
    try {
      const response = await axios.get(
        `http://localhost:8080/api/users/search`,
        {
          params: { query: searchQuery },
        }
      );
      setAllUsers(response.data);
    } catch (error) {
      console.error("Error searching users:", error);
    }
  };

  const loadChatHistory = async () => {
    if (!userData.connected) {
      return;
    }
    try {
      const response = await axios.get(
        "http://localhost:8080/api/chats/history"
      );
      const sortedMessages = response.data
        .filter(
          (msg) =>
            msg.message !== null &&
            msg.message.trim() !== "" &&
            msg.receiverName === "ALL"
        )
        .sort((a, b) => new Date(a.date) - new Date(b.date));
      setPublicChats(sortedMessages);
    } catch (error) {
      console.error("Error loading chat history:", error);
    }
  };

  const onMessageReceived = (payload) => {
    const payloadData = JSON.parse(payload.body);
    switch (payloadData.status) {
      case "USER_DISCONNECTED":
        setAllUsers((prevUsers) =>
          prevUsers.map((user) => {
            if (user.username === payloadData.username) {
              return { ...user, isConnected: false };
            }
            return user;
          })
        );
        break;
      case "JOIN":
        if (!privateChats.get(payloadData.senderName)) {
          privateChats.set(payloadData.senderName, []);
          setPrivateChats(new Map(privateChats));
        }
        fetchAllUsers();
        break;

      case "MESSAGE":
        if (payloadData.receiverName === "ALL") {
          handlePublicMessage(payloadData);
          if (payloadData.senderName !== userData.username) {
            setUnreadMessages((prevUnreadMessages) => {
              const newUnreadMessages = new Map(prevUnreadMessages);
              const count = newUnreadMessages.get("CHATROOM") || 0;
              newUnreadMessages.set("CHATROOM", count + 1);
              return newUnreadMessages;
            });
            stompClient.send(
              "/app/notification",
              {},
              JSON.stringify({
                senderName: payloadData.senderName,
                message: `Nuevo mensaje`,
                status: "NOTIFICATION",
              })
            );
          }
        } else {
          handlePrivateMessage(payloadData);
        }
        break;
      case "NEW_USER":
        fetchAllUsers();
        break;
      case "NOTIFICATION":
        if (payloadData.senderName !== userData.username) {
          console.log(
            `Nuevo mensaje en el chat general de ${payloadData.senderName}`
          );
          setUnreadMessages((prevUnreadMessages) => {
            const newUnreadMessages = new Map(prevUnreadMessages);
            newUnreadMessages.set(
              "CHATROOM",
              (newUnreadMessages.get("CHATROOM") || 0) + 1
            );
            return newUnreadMessages;
          });
        }
        break;
      default:
        setAllUsers((prevAllUsers) => [...prevAllUsers, payloadData]);
        break;
    }
  };

  const handlePublicMessage = (message) => {
    if (message.receiverName === "ALL") {
      setPublicChats((prevPublicChats) => [...prevPublicChats, message]);
    }
  };

  const handlePrivateMessage = (message) => {
    setPrivateChats((prevChats) => {
      const updatedChats = new Map(prevChats);
      const currentMessages = updatedChats.get(message.senderName) || [];
      currentMessages.push(message);
      updatedChats.set(message.senderName, currentMessages);
      return updatedChats;
    });
  };

  const sanitizeInput = (input) => {
    return DOMPurify.sanitize(input);
  };

  const onPrivateMessage = (payload) => {
    const payloadData = JSON.parse(payload.body);

    if (
      payloadData.senderName === userData.username &&
      tab === userData.username
    ) {
      return;
    }

    if (payloadData.message.trim() === "") {
      return;
    }

    setPrivateChats((prevChats) => {
      const updatedChats = new Map(prevChats);
      const currentMessages = updatedChats.get(payloadData.senderName) || [];
      const isDuplicate = currentMessages.some(
        (msg) => msg.id === payloadData.id
      );
      if (!isDuplicate) {
        updatedChats.set(payloadData.senderName, [
          ...currentMessages,
          payloadData,
        ]);
      }
      return updatedChats;
    });

    if (tab !== payloadData.senderName) {
      setUnreadMessages((prevUnreadMessages) => {
        const newUnreadMessages = new Map(prevUnreadMessages);
        const count = newUnreadMessages.get(payloadData.senderName) || 0;
        newUnreadMessages.set(payloadData.senderName, count + 1);
        return newUnreadMessages;
      });
    }
  };

  const updateUserOnlineStatus = (username, online) => {
    setAllUsers((prevUsers) =>
      prevUsers.map((user) =>
        user.username === username ? { ...user, online } : user
      )
    );
  };

  const handleTabChange = (name) => {
    setTab(name);

    setUnreadMessages((prevUnreadMessages) => {
      const newUnreadMessages = new Map(prevUnreadMessages);
      newUnreadMessages.delete(name);
      return newUnreadMessages;
    });

    if (name !== "CHATROOM") {
      loadPrivateChatHistory(name);
    }
  };

  const handleSearch = (event) => {
    const query = event.target.value;
    setSearchQuery(query);
    if (query.length > 0) {
      searchUsers(query);
    } else {
      fetchAllUsers();
    }
  };

  const onError = (err) => {
    console.log(err);
  };

  const handleMessage = (event) => {
    const { value } = event.target;
    setUserData({ ...userData, message: value });
  };

  const sendValue = () => {
    if (stompClient) {
      const chatMessage = {
        senderName: userData.username,
        message: userData.message,
        status: "MESSAGE",
      };
      stompClient.send("/app/message", {}, JSON.stringify(chatMessage));
      setUserData((prevUserData) => ({ ...prevUserData, message: "" }));
    }
  };

  const handleUsername = (event) => {
    const { name, value } = event.target;
    if (name === "username") {
      const filteredValue = value.replace(/[^a-zA-Z0-9\s]/g, "");
      setUserData({ ...userData, [name]: filteredValue });
    } else {
      setUserData({ ...userData, [name]: value });
      const sanitizedValue = DOMPurify.sanitize(value);
      setUserData({ ...userData, [name]: sanitizedValue });
    }
  };

  const validateEmail = (email) => {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(String(email).toLowerCase());
  };

  const validateUsername = (username) => {
    const re = /^[a-zA-Z]+$/;
    return re.test(username);
  };

  const validateFields = () => {
    const errors = {};
    if (!userData.username || !validateUsername(userData.username)) {
      errors.username = "El nombre de usuario solo puede contener letras";
    }
    if (!userData.password) {
      errors.password = "La contraseña no puede estar vacía";
    }
    if (!userData.email || !validateEmail(userData.email)) {
      errors.email = "El email no es válido";
    }
    return errors;
  };

  const registerUser = async () => {
    const errors = validateFields();
    if (Object.keys(errors).length > 0) {
      setUserData({ ...userData, errors });
      return;
    }
    try {
      const response = await axios.post(
        "http://localhost:8080/api/auth/register",
        {
          username: userData.username,
          password: userData.password,
          email: userData.email,
        }
      );
      console.log(response.data);
      setIsRegistering(false);
    } catch (error) {
      console.error("Registration failed:", error.response.data);
    }
  };

  const validateLoginFields = () => {
    const errors = {};
    if (!userData.username) {
      errors.username = "El nombre de usuario no puede estar vacío";
    }
    if (!userData.password) {
      errors.password = "La contraseña no puede estar vacía";
    }
    return errors;
  };

  const loginUser = async () => {
    const errors = validateLoginFields();
    if (Object.keys(errors).length > 0) {
      setUserData({ ...userData, errors });
      return;
    }
    try {
      const response = await axios.post(
        "http://localhost:8080/api/auth/login",
        {
          username: userData.username.toLowerCase(),
          password: userData.password,
        }
      );
      console.log(response.data);
      setUserData({ ...userData, connected: true, errors: {} });
    } catch (error) {
      console.error("Login failed:", error.response.data);
      setUserData({
        ...userData,
        errors: {
          ...errors,
          login: "Nombre de usuario o contraseña incorrectos",
        },
      });
    }
  };

  const handleLogout = () => {
    stompClient.disconnect(() => {
      axios
        .post("/api/users/disconnect", { username: userData.username })
        .then(() => {
          handleUserDisconnect(userData.username);
          window.location.href = "/login";
        })
        .catch((error) => {
          console.error(error);
        });
    });
  };

  const handleUserDisconnect = (username) => {
    setAllUsers((prevUsers) =>
      prevUsers.filter((user) => user.username !== username)
    );
  };
  return (
    <ChatRoomUI
      userData={userData}
      privateChats={privateChats}
      publicChats={publicChats}
      tab={tab}
      setTab={handleTabChange}
      handleMessage={handleMessage}
      sendValue={sendValue}
      sendPrivateValue={sendPrivateValue}
      handleUsername={handleUsername}
      registerUser={registerUser}
      loginUser={loginUser}
      unreadMessages={unreadMessages}
      isRegistering={isRegistering}
      setIsRegistering={setIsRegistering}
      allUsers={allUsers}
      searchQuery={searchQuery}
      setSearchQuery={setSearchQuery}
      searchUsers={searchUsers}
      logoutUser={handleLogout}
      act={handleUserDisconnect}
    />
  );
};

export default ChatRoom;
