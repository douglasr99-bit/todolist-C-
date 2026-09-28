package com.example.todolist.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Profile;
import org.springframework.jdbc.core.JdbcTemplate;

import com.example.todolist.repository.TodoRepository;
import com.example.todolist.repository.TodoRepositoryJdbc;
import com.example.todolist.repository.TodoRepositoryMemoria;

@Configuration
public class RepositoryConfig {

    @Bean
    @Profile("memoria")
    public TodoRepository todoRepositoryMemoria() {
        return new TodoRepositoryMemoria();
    }

    @Bean
    @Profile("jdbc")
    public TodoRepository todoRepositoryJdbc(JdbcTemplate jdbcTemplate) {
        return new TodoRepositoryJdbc(jdbcTemplate);
    }
}