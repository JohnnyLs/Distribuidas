package com.involveininnovation.chat.controller;

import com.involveininnovation.chat.model.ChatMessage;
import com.involveininnovation.chat.repository.ChatMessageRepository;
import com.involveininnovation.chat.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

@RestController
@RequestMapping("/api/chats")
public class ChatHistoryController {

    @Autowired
    private ChatMessageRepository chatMessageRepository;

    @Autowired
    private UserRepository userRepository;

    @GetMapping("/history")
    public ResponseEntity<List<ChatMessage>> getChatHistory(
            @RequestParam(required = false) String senderName,
            @RequestParam(required = false) String receiverName) {
        List<ChatMessage> chatHistory = new ArrayList<>();
        if (senderName != null && receiverName != null) {
            chatHistory.addAll(chatMessageRepository.findBySenderNameAndReceiverNameOrderByDateAsc(senderName, receiverName));
            chatHistory.addAll(chatMessageRepository.findBySenderNameAndReceiverNameOrderByDateAsc(receiverName, senderName));
        } else {
            chatHistory.addAll(chatMessageRepository.findAllByOrderByDateAsc());
        }
        chatHistory.sort(Comparator.comparing(ChatMessage::getDate));
        return ResponseEntity.ok(chatHistory);
    }
}
