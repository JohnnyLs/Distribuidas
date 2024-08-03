package com.involveininnovation.chat.controller;

import com.involveininnovation.chat.model.User;
import com.involveininnovation.chat.model.UserStatusUpdate;
import com.involveininnovation.chat.repository.UserRepository;
import com.involveininnovation.chat.service.UserService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/api/users")
public class UserController {

    @Autowired
    private UserService userService;

    @Autowired
    private SimpMessagingTemplate simpMessagingTemplate;

    @Autowired
    private UserRepository userRepository;
    @GetMapping("/all")
    public ResponseEntity<List<User>> getAllUsers() {
        List<User> users = userService.getAllUsers();
        return ResponseEntity.ok(users);
    }

    @GetMapping("/search")
    public ResponseEntity<List<User>> searchUsers(@RequestParam String query) {
        List<User> users = userService.searchUsers(query);
        return ResponseEntity.ok(users);
    }
    @PostMapping("/register")
    public ResponseEntity<?> registerUser(@Valid @RequestBody User user) {
        User newUser = userService.registerUser(user);
        simpMessagingTemplate.convertAndSend("/chatroom/public", newUser);
        return ResponseEntity.ok(newUser);
    }

    @GetMapping("/last-connection")
    public ResponseEntity<?> getLastConnections() {
        try {
            List<User> users = userService.getAllUsers();
            if (users == null) {
                return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("No users found");
            }
            List<User> processedUsers = users.stream()
                    .filter(user -> user != null)
                    .collect(Collectors.toList());

            if (processedUsers.isEmpty()) {
                return ResponseEntity.status(HttpStatus.NO_CONTENT).build();
            }

            return ResponseEntity.ok(processedUsers);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("An error occurred");
        }
    }

    @PostMapping("/status")
    public ResponseEntity<?> updateUserStatus(@RequestBody Map<String, Object> statusUpdate) {
        String username = (String) statusUpdate.get("username");
        Boolean isOnline = (Boolean) statusUpdate.get("isOnline");

        User user = userRepository.findByUsername(username);
        if (user != null) {
            user.setOnline(isOnline);
            userRepository.save(user);
            return ResponseEntity.ok().build();
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("User not found");
        }
    }
    @PostMapping("/disconnect")
    public ResponseEntity<?> disconnectUser(@RequestBody Map<String, Object> payload) {
        String username = (String) payload.get("username");
        userService.setUserOffline(username);
        simpMessagingTemplate.convertAndSend("/chatroom/public", new UserStatusUpdate("USER_DISCONNECTED", username));
        return ResponseEntity.ok().build();
    }

    @PostMapping("/logout")
    public ResponseEntity<?> logoutUser(@RequestBody Map<String, Object> payload) {
        String username = (String) payload.get("username");
        userService.setUserOffline(username);
        simpMessagingTemplate.convertAndSend("/chatroom/public", new UserStatusUpdate("USER_DISCONNECTED", username));
        return ResponseEntity.ok().build();
    }
}