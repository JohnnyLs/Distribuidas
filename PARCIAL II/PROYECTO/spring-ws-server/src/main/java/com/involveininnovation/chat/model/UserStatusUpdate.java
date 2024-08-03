package com.involveininnovation.chat.model;

public class UserStatusUpdate {
    private String status;
    private String username;

    public UserStatusUpdate(String status, String username) {
        this.status = status;
        this.username = username;
    }

    public String getStatus() {
        return status;
    }

    public String getUsername() {
        return username;
    }
}