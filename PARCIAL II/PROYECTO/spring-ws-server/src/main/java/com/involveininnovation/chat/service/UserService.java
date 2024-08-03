package com.involveininnovation.chat.service;

import com.involveininnovation.chat.model.User;
import com.involveininnovation.chat.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;
import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    @Autowired
    private BCryptPasswordEncoder passwordEncoder;

    public User registerUser(User user) {
        if (userRepository.findByUsername(user.getUsername()) != null) {
            throw new RuntimeException("Username already exists");
        }
        user.setPassword(passwordEncoder.encode(user.getPassword()));
        user.setCreatedAt(new Date());
        user.setOnline(false);
        return userRepository.save(user);
    }
    public User authenticateUser(String username, String password) {
        User user = userRepository.findByUsername(username);
        if (user != null && passwordEncoder.matches(password, user.getPassword())) {
            user.setOnline(true);
            userRepository.save(user);
            return user;
        }
        return null;
    }
    public List<User> searchUsers(String query) {
        return userRepository.searchByUsername(query);
    }

    public List<User> getAllUsers() {
        return userRepository.findAll();
    }
    public void setUserOnline(String username, boolean online) {
        User user = userRepository.findByUsername(username);
        if (user != null) {
            user.setOnline(online);
            userRepository.save(user);
        }
    }

    public void updateUserStatus(String username, boolean isOnline) {
        User user = userRepository.findByUsername(username);
        if (user != null) {
            user.setOnline(isOnline);
            user.setLastActive(LocalDateTime.now());
            userRepository.save(user);
        }
    }

    public void setUserOffline(String username) {
        User user = userRepository.findByUsername(username);
        if (user!= null) {
            user.setOnline(false);
            userRepository.save(user);
        }
    }
}