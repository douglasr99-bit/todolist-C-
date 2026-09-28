package com.example.todolist.repository;

import java.util.List;
import java.util.Optional;

import com.example.todolist.model.Todo;

public interface TodoRepository {

    Todo salvar(Todo todo);

    List<Todo> listarTodos();

    void atualizarStatus(Integer id, boolean completed);

    void remover(Integer id);

    Optional<Todo> buscarPorId(Integer id);
}