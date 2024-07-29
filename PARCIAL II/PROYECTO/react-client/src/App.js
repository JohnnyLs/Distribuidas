import React from 'react'
import ChatRoom from './components/ChatRoom'
import { Footer } from './nav/footer/Footer';
import { Header } from './nav/head/Header';

const App = () => {
  return (
    <div>
      <Header />
      <ChatRoom />
      <Footer />
    </div>
    
  )
}

export default App;

