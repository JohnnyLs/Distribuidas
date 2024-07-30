// import React from 'react';
// import '../index.css';

// const ChatRoomUI = ({
//   userData,
//   privateChats,
//   publicChats,
//   tab,
//   setTab,
//   handleMessage,
//   sendValue,
//   sendPrivateValue,
//   handleUsername,
//   registerUser
// }) => {
//   // Maneja el evento de teclado
//   const handleKeyDown = (event) => {
//     if (event.key === 'Enter') {
//       event.preventDefault(); 
//         sendValue(); 
//       } else {
//         sendPrivateValue(); 
//     }
//   };

//   return (
//     <div className="container">
//       {userData.connected ? (
//         <div className="chat-box">
//           <div className="member-list">
//             <ul>
//               <li onClick={() => { setTab("CHATROOM") }} className={`member ${tab === "CHATROOM" && "active"}`}>CHAT4FUN</li>
//               {[...privateChats.keys()].map((name, index) => (
//                 <li onClick={() => { setTab(name) }} className={`member ${tab === name && "active"}`} key={index}>{name}</li>
//               ))}
//             </ul>
//           </div>
//           {tab === "CHATROOM" && <div className="chat-content">
//             <ul className="chat-messages">
//               {publicChats.map((chat, index) => (
//                 <li className={`message ${chat.senderName === userData.username ? "self" : ""}`} key={index}>
//                   <div className="sender-name">{chat.senderName}</div>
//                   <div className="message-data">{chat.message}</div>
//                 </li>
//               ))}
//             </ul>

//             <div className="send-message">
//               <input
//                 type="text"
//                 className="input-message"
//                 placeholder="Escribe un mensaje"
//                 value={userData.message}
//                 onChange={handleMessage}
//                 onKeyDown={handleKeyDown} 
//                 required
//               />
//               <button type="button" className="send-button" onClick={sendValue}>Enviar</button>
//             </div>
//           </div>}
//           {tab !== "CHATROOM" && <div className="chat-content">
//             <ul className="chat-messages">
//               {[...privateChats.get(tab)].map((chat, index) => (
//                 <li className={`message ${chat.senderName === userData.username ? "self" : ""}`} key={index}>
//                   <div className="sender-name">{chat.senderName}</div>
//                   <div className="message-data">{chat.message}</div>
//                 </li>
//               ))}
//             </ul>

//             <div className="send-message">
//               <input
//                 type="text"
//                 className="input-message"
//                 placeholder="Escribe un mensaje"
//                 value={userData.message}
//                 onChange={handleMessage}
//                 onKeyDown={handleKeyDown} // Asocia el evento de teclado
//                 required
//               />
//               <button type="button" className="send-button" onClick={sendPrivateValue}>Enviar</button>
//             </div>
//           </div>}
//         </div>
//       ) : (
//         <div className="re">
//           <h1>Bienvenido a CHAT4FUN</h1>
//           <div className="register">
//             <input
//               id="user-name"
//               placeholder="Ingresa tu nombre"
//               name="userName"
//               value={userData.username}
//               onChange={handleUsername}
//               margin="normal"
              
//               required
//             />
//           </div>
//           <button type="button" id="btn-registro" onClick={registerUser} >
//             Entrar
//           </button>
//         </div>
//       )}
//     </div>
//   );
// }

// export default ChatRoomUI;


import React from 'react';
import '../index.css';

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
  unreadMessages,
  //setUnreadMessages
}) => {

  const handleKeyDown = (event) => {
    if (event.key === 'Enter') {
      event.preventDefault(); 
      tab === "CHATROOM" ? sendValue() : sendPrivateValue();
    }
  };



  
  return (
    <div className="container">
      {userData.connected ? (
        <div className="chat-box">
          <div className="member-list">
            <ul>
              <li 
                onClick={() => setTab("CHATROOM")} 
                className={`member ${tab === "CHATROOM" && "active"}`}
              >
                CHAT4FUN
              </li>
              {[...privateChats.keys()].map((name, index) => (
                <li 
                  onClick={() => setTab(name)} 
                  className={`member ${tab === name && "active"} ${unreadMessages.get(name) ? "unread" : ""}`} 
                  key={index}
                >
                  {name} {unreadMessages.get(name) ? `(${unreadMessages.get(name)}) Nuevo Mensaje` : ''}
                </li>
              ))}
            </ul>
          </div>
          {tab === "CHATROOM" && <div className="chat-content">
            <ul className="chat-messages">
              {publicChats.map((chat, index) => (
                <li className={`message ${chat.senderName === userData.username ? "self" : ""}`} key={index}>
                  <div className="sender-name">{chat.senderName}</div>
                  <div className="message-data">{chat.message}</div>
                </li>
              ))}
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
              <button type="button" className="send-button" onClick={sendValue}>Enviar</button>
            </div>
          </div>}
          {tab !== "CHATROOM" && <div className="chat-content">
            <ul className="chat-messages">
              {[...privateChats.get(tab)].map((chat, index) => (
                <li className={`message ${chat.senderName === userData.username ? "self" : ""}`} key={index}>
                  <div className="sender-name">{chat.senderName}</div>
                  <div className="message-data">{chat.message}</div>
                </li>
              ))}
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
              <button type="button" className="send-button" onClick={sendPrivateValue}>Enviar</button>
            </div>
          </div>}
        </div>
      ) : (
        <div className="re">
          <h1>Bienvenido a CHAT4FUN</h1>
          <div className="register">
            <input
              id="user-name"
              placeholder="Ingresa tu nombre"
              name="userName"
              value={userData.username}
              onChange={handleUsername}
              margin="normal"
              required
            />
          </div>
          <button type="button" id="btn-registro" onClick={registerUser}>
            Entrar
          </button>
        </div>
      )}
    </div>
  );
}

export default ChatRoomUI;