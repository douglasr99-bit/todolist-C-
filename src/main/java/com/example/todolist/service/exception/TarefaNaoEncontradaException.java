package com.example.todolist.service.exception;

public class TarefaNaoEncontradaException extends RuntimeException {
    public TarefaNaoEncontradaException(String mensagem) {
        super(mensagem);
    }
}