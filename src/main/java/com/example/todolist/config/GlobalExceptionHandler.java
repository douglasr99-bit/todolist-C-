package com.example.todolist.config;

import java.util.Map;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

import com.example.todolist.service.exception.TarefaNaoEncontradaException;
import com.example.todolist.service.exception.TituloInvalidoException;

@RestControllerAdvice
public class GlobalExceptionHandler {

    @ExceptionHandler(TituloInvalidoException.class)
    public ResponseEntity<Map<String, String>> tratarTituloInvalido(TituloInvalidoException e) {
        return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(Map.of("erro", e.getMessage()));
    }

    @ExceptionHandler(TarefaNaoEncontradaException.class)
    public ResponseEntity<Map<String, String>> tratarTarefaNaoEncontrada(TarefaNaoEncontradaException e) {
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(Map.of("erro", e.getMessage()));
    }
}