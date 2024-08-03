package com.involveininnovation.chat.controller;

import com.involveininnovation.chat.model.ChatMessage;
import com.involveininnovation.chat.model.Status;
import com.involveininnovation.chat.model.User;
import com.involveininnovation.chat.repository.ChatMessageRepository;
import com.involveininnovation.chat.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.messaging.simp.user.SimpUserRegistry;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import java.security.Principal;
import java.util.*;

@RestController
@RequestMapping("/api/chat")

public class ChatController {

    @Autowired
    private SimpUserRegistry userRegistry;


    @Autowired
    private SimpMessagingTemplate simpMessagingTemplate;

    @Autowired
    private ChatMessageRepository chatMessageRepository;

    @Autowired
    private UserRepository userRepository;
    @GetMapping("/history")
    public ResponseEntity<List<ChatMessage>> getChatHistory(
            @RequestParam String senderName,
            @RequestParam String receiverName) {
        List<ChatMessage> chatHistory = new ArrayList<>();
        chatHistory.addAll(chatMessageRepository.findBySenderNameAndReceiverNameOrderByDateAsc(senderName, receiverName));
        chatHistory.addAll(chatMessageRepository.findBySenderNameAndReceiverNameOrderByDateAsc(receiverName, senderName));
        chatHistory.sort(Comparator.comparing(ChatMessage::getDate));
        return ResponseEntity.ok(chatHistory);
    }
    @MessageMapping("/message")
    @SendTo("/chatroom/public")
    public ChatMessage receivePublicMessage(@Payload ChatMessage message, Principal principal) {
        User sender = userRepository.findByUsername(principal.getName());
        if (sender == null) {
            throw new RuntimeException("User not found");
        }
        message.setSenderName(sender.getUsername());
        message.setReceiverName("ALL");
        message.setDate(new Date());
        return chatMessageRepository.save(message);
    }
    @MessageMapping("/private-message")
    public ChatMessage receivePrivateMessage(@Payload ChatMessage message, Principal principal) {
        User sender = userRepository.findByUsername(principal.getName());
        User receiver = userRepository.findByUsername(message.getReceiverName());
        if (sender == null || receiver == null) {
            throw new RuntimeException("User not found");
        }
        message.setSenderName(sender.getUsername());
        message.setDate(new Date());
        ChatMessage savedMessage = chatMessageRepository.save(message);
        simpMessagingTemplate.convertAndSendToUser(message.getReceiverName(), "/private", savedMessage);
        return savedMessage;
    }
    @MessageMapping("/join")
    @SendTo("/chatroom/public")
    public ChatMessage userJoin(Principal principal) {
        User user = userRepository.findByUsername(principal.getName());
        if (user == null) {
            throw new RuntimeException("User not found");
        }
        ChatMessage joinMessage = new ChatMessage();
        joinMessage.setSenderName(user.getUsername());
        joinMessage.setStatus(Status.valueOf("JOIN"));
        joinMessage.setDate(new Date());
        return chatMessageRepository.save(joinMessage);
    }
}




