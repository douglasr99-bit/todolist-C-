package com.example.todolist.service.exception;

public class TituloInvalidoException extends RuntimeException {
    public TituloInvalidoException(String mensagem) {
        super(mensagem);
    }
}