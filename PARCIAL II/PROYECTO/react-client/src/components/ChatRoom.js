import React, { useEffect, useState } from 'react';
import { over } from 'stompjs';
import SockJS from 'sockjs-client';
import ChatRoomUI from './ChatRoomUI';

var stompClient = null;

const ChatRoom = () => {
  const [privateChats, setPrivateChats] = useState(new Map());
  const [publicChats, setPublicChats] = useState([]);
  const [tab, setTab] = useState("CHATROOM");
  const [unreadMessages, setUnreadMessages] = useState(new Map());

  const [userData, setUserData] = useState({
    username: '',
    receivername: '',
    connected: false,
    message: ''
  });

  useEffect(() => {
    console.log(userData);
  }, [userData]);

  const connect = () => {
    let Sock = new SockJS('http://localhost:8080/ws');
    stompClient = over(Sock);
    stompClient.connect({}, onConnected, onError);
  }
/*
  const onConnected = () => {
    setUserData({ ...userData, "connected": true });
    stompClient.subscribe('/chatroom/public', onMessageReceived);
    stompClient.subscribe('/user/' + userData.username + '/private', onPrivateMessage);
    userJoin();
  }*/

    const onConnected = () => {
      setUserData({ ...userData, "connected": true });
      stompClient.subscribe('/chatroom/public', onMessageReceived);
      stompClient.subscribe('/user/' + userData.username + '/private', onPrivateMessage);
      stompClient.subscribe('/user/' + userData.username + '/queue/notifications', onNotificationReceived); // Nueva suscripción
      userJoin();
  }
  
  const onNotificationReceived = (payload) => {
      var notification = JSON.parse(payload.body);
      alert(notification.message); // Muestra una alerta, puedes personalizar esto para mostrar notificaciones en tu UI
  }
  

  const userJoin = () => {
    var chatMessage = {
      senderName: userData.username,
      status: "JOIN"
    };
    stompClient.send("/app/message", {}, JSON.stringify(chatMessage));
  }

  const onMessageReceived = (payload) => {
    var payloadData = JSON.parse(payload.body);
    switch (payloadData.status) {
      case "JOIN":
        if (!privateChats.get(payloadData.senderName)) {
          privateChats.set(payloadData.senderName, []);
          setPrivateChats(new Map(privateChats));
        }
        break;
      case "MESSAGE":
        publicChats.push(payloadData);
        setPublicChats([...publicChats]);
        break;
    }
  }
/*
  const onPrivateMessage = (payload) => {
    console.log(payload);
    var payloadData = JSON.parse(payload.body);
    if (privateChats.get(payloadData.senderName)) {
      privateChats.get(payloadData.senderName).push(payloadData);
      setPrivateChats(new Map(privateChats));
    } else {
      let list = [];
      list.push(payloadData);
      privateChats.set(payloadData.senderName, list);
      setPrivateChats(new Map(privateChats));
    }
  }*/

    const onPrivateMessage = (payload) => {
      var payloadData = JSON.parse(payload.body);
      if (privateChats.get(payloadData.senderName)) {
        privateChats.get(payloadData.senderName).push(payloadData);
        setPrivateChats(new Map(privateChats));
      } else {
        let list = [];
        list.push(payloadData);
        privateChats.set(payloadData.senderName, list);
        setPrivateChats(new Map(privateChats));
      }
  
      if (tab !== payloadData.senderName) {
        let count = unreadMessages.get(payloadData.senderName) || 0;
        unreadMessages.set(payloadData.senderName, count + 1);
        setUnreadMessages(new Map(unreadMessages));
      }
    }

    const handleTabChange = (name) => {
      setTab(name);
      if (unreadMessages.get(name)) {
        unreadMessages.set(name, 0);
        setUnreadMessages(new Map(unreadMessages));
      }
    };
    

  const onError = (err) => {
    console.log(err);
  }

  const handleMessage = (event) => {
    const { value } = event.target;
    setUserData({ ...userData, "message": value });
  }

  const sendValue = () => {
    if (stompClient) {
      var chatMessage = {
        senderName: userData.username,
        message: userData.message,
        status: "MESSAGE"
      };
      console.log(chatMessage);
      stompClient.send("/app/message", {}, JSON.stringify(chatMessage));
      setUserData({ ...userData, "message": "" });
    }
  }

  const sendPrivateValue = () => {
    if (stompClient) {
      var chatMessage = {
        senderName: userData.username,
        receiverName: tab,
        message: userData.message,
        status: "MESSAGE"
      };

      if (userData.username !== tab) {
        privateChats.get(tab).push(chatMessage);
        setPrivateChats(new Map(privateChats));
      }
      stompClient.send("/app/private-message", {}, JSON.stringify(chatMessage));
      setUserData({ ...userData, "message": "" });
    }
  }

  const handleUsername = (event) => {
    const { value } = event.target;
    setUserData({ ...userData, "username": value });
  }

  const registerUser = () => {
    connect();
  }
/*
  return (
    <ChatRoomUI
      userData={userData}
      privateChats={privateChats}
      publicChats={publicChats}
      tab={tab}
      setTab={setTab}
      handleMessage={handleMessage}
      sendValue={sendValue}
      sendPrivateValue={sendPrivateValue}
      handleUsername={handleUsername}
      registerUser={registerUser}
    />
  );*/

  return (
    <ChatRoomUI
      userData={userData}
      privateChats={privateChats}
      publicChats={publicChats}
      tab={tab}
      //setTab={setTab}
      setTab={handleTabChange}
      handleMessage={handleMessage}
      sendValue={sendValue}
      sendPrivateValue={sendPrivateValue}
      handleUsername={handleUsername}
      registerUser={registerUser}
      unreadMessages={unreadMessages}
      //setUnreadMessages={setUnreadMessages} // Añadir esta línea
    />
  );
  
  
}

export default ChatRoom;
