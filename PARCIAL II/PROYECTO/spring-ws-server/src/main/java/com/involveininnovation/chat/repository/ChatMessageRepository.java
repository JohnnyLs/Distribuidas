package com.involveininnovation.chat.repository;

import com.involveininnovation.chat.model.ChatMessage;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ChatMessageRepository extends JpaRepository<ChatMessage, Long> {
    List<ChatMessage> findBySenderNameAndReceiverName(String senderName, String receiverName);
    List<ChatMessage> findBySenderName(String senderName);
    List<ChatMessage> findBySenderNameAndReceiverNameOrderByDateAsc(String senderName, String receiverName);
    List<ChatMessage> findAllByOrderByDateAsc();

}