import React, { useEffect, useRef, useState } from "react";
import "../index.css";

const ChatRoomUI = ({
  userData,
  privateChats,
  publicChats,
  tab,
  setTab,
  handleMessage,
  sendValue,
  sendPrivateValue,
  handleUsername,
  registerUser,
  loginUser,
  unreadMessages,
  isRegistering,
  setIsRegistering,
  allUsers,
  searchQuery,
  setSearchQuery,
  searchUsers,
  logoutUser,
  act,
}) => {
  const [filteredUsers, setFilteredUsers] = useState(allUsers);
  const messagesEndRef = useRef(null);

  useEffect(() => {
    if (searchQuery === "") {
      setFilteredUsers(allUsers);
    } else {
      setFilteredUsers(
        allUsers.filter((user) =>
          user.username.toLowerCase().includes(searchQuery.toLowerCase())
        )
      );
    }
  }, [searchQuery, allUsers]);

  useEffect(() => {
    scrollToBottom();
  }, [publicChats, privateChats, tab]);

  const scrollToBottom = () => {
    messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
  };

  const handleKeyDown = (event) => {
    if (event.key === "Enter") {
      event.preventDefault();
      if (tab === "CHATROOM") {
        if (userData.message.trim()) {
          sendValue();
        }
      } else {
        if (userData.message.trim()) {
          sendPrivateValue();
        }
      }
    }
  };

  const handleSendClick = () => {
    if (userData.message.trim()) {
      tab === "CHATROOM" ? sendValue() : sendPrivateValue();
    }
  };

  const handleSearchChange = (event) => {
    setSearchQuery(event.target.value);
  };

  const getUserStatusIndicator = (user) => {
    return (
      <span
        className={`status-indicator ${user.online ? "online" : "offline"}`}
      ></span>
    );
  };
  const getUserStatusClass = (user) => {
    return user.online ? "online" : "offline";
  };

  const currentUser = allUsers.find(
    (user) => user.username === userData.username
  );

  return (
    <div className="container">
      {userData.connected ? (
        <div className="chat-box">
          <div className="member-list">
            <div className="search-bar">
              <input
                type="text"
                placeholder="Buscar usuarios"
                value={searchQuery}
                onChange={handleSearchChange}
              />
              <button onClick={searchUsers}>Buscar</button>
            </div>

            <ul>
              <li
                onClick={() => setTab("CHATROOM")}
                className={`member ${tab === "CHATROOM" ? "active" : ""} ${
                  unreadMessages.get("CHATROOM") ? "unread" : ""
                }`}
              >
                CHATROOM
                {unreadMessages.get("CHATROOM")
                  ? `(${unreadMessages.get("CHATROOM")}) Nuevo mensaje`
                  : ""}
              </li>
              {filteredUsers.map((user, index) => (
                <li
                  onClick={() => setTab(user.username)}
                  className={`member ${tab === user.username ? "active" : ""} ${
                    user.username === userData.username ? "current-user" : ""
                  } ${
                    unreadMessages.get(user.username) ? "unread" : ""
                  } ${getUserStatusClass(user)}`}
                  key={index}
                >
                  <span
                    className={`status-indicator ${
                      user.isConnected ? "online" : "offline"
                    }`}
                  ></span>

                  {user.username}
                  {unreadMessages.get(user.username)
                    ? `(${unreadMessages.get(user.username)}) Nuevo Mensaje`
                    : ""}
                  {user.username === userData.username && (
                    <span className="current-user-indicator">(Tú)</span>
                  )}
                </li>
              ))}
            </ul>
          </div>

          <div className="chat-content">
            <header className="chat-header">
              {tab === "CHATROOM" ? "CHATROOM" : `Chat con ${tab}`}
              <div className="chat-header">
                <span className="last-connection">
                  {allUsers.find((user) => user.username === tab)?.lastActive
                    ? `Última conexión: ${new Date(
                        allUsers.find(
                          (user) => user.username === tab
                        )?.lastActive
                      ).toLocaleString()}`
                    : "ACTIVO"}
                </span>
              </div>
            </header>

            <ul className="chat-messages">
              {(tab === "CHATROOM"
                ? publicChats
                : privateChats.get(tab) || []
              ).map((chat, index) => (
                <li
                  className={`message ${
                    chat.senderName === userData.username ? "self" : ""
                  }`}
                  key={index}
                >
                  <div className="sender-name">{chat.senderName}</div>
                  <div className="message-data">{chat.message}</div>
                </li>
              ))}
              <div ref={messagesEndRef} />
            </ul>
            <div className="send-message">
              <input
                type="text"
                className="input-message"
                placeholder="Escribe un mensaje"
                value={userData.message}
                onChange={handleMessage}
                onKeyDown={handleKeyDown}
                required
              />
              <button
                type="button"
                className="send-button"
                onClick={handleSendClick}
              >
                Enviar
              </button>
            </div>
          </div>

          <div className="contenedor">
            <button
              className="logout-button"
              onClick={() => {
                logoutUser();
                act(userData.username);
              }}
            >
              Cerrar sesión
            </button>{" "}
          </div>
        </div>
      ) : (
        <div
          className={`auth-form ${
            isRegistering ? "register-form" : "login-form"
          }`}
        >
          <h1>{isRegistering ? "Registro" : "Inicio de sesión"}</h1>
          {userData.errors && Object.keys(userData.errors).length > 0 && (
            <div className="error-messages">
              {Object.values(userData.errors).map((error, index) => (
                <p key={index} className="error">
                  {error}
                </p>
              ))}
            </div>
          )}
          {isRegistering ? (
            <>
              <input
                type="text"
                placeholder="Usuario"
                name="username"
                value={userData.username}
                onChange={handleUsername}
                required
                className="auth-input"
              />
              <input
                type="password"
                placeholder="Contraseña"
                name="password"
                value={userData.password}
                onChange={handleUsername}
                required
                className="auth-input"
              />
              <input
                type="email"
                placeholder="Email"
                name="email"
                value={userData.email}
                onChange={handleUsername}
                required
                className="auth-input"
              />
              <button
                type="button"
                onClick={registerUser}
                className="auth-button"
              >
                Registrarse
              </button>
              <p>
                ¿Ya tienes una cuenta?{" "}
                <span onClick={() => setIsRegistering(false)}>
                  Iniciar sesión
                </span>
              </p>
            </>
          ) : (
            <>
              <input
                type="text"
                placeholder="Usuario"
                name="username"
                value={userData.username}
                onChange={handleUsername}
                required
                className="auth-input"
              />
              <input
                type="password"
                placeholder="Contraseña"
                name="password"
                value={userData.password}
                onChange={handleUsername}
                required
                className="auth-input"
              />
              <button type="button" onClick={loginUser} className="auth-button">
                Iniciar sesión
              </button>
              <p>
                ¿No tienes una cuenta?{" "}
                <span onClick={() => setIsRegistering(true)}>Registrarse</span>
              </p>
            </>
          )}
        </div>
      )}
    </div>
  );
};

export default ChatRoomUI;
