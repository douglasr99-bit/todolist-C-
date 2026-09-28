package com.example.todolist.repository;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import com.example.todolist.model.Todo;

public class TodoRepositoryMemoria implements TodoRepository{

    private List<Todo> tarefas = new ArrayList<>();

    private int proximoId = 1;


    @Override
    public Todo salvar(Todo todo) {
       todo.setId(proximoId);
       proximoId++;
       tarefas.add(todo);
       return todo;
    }

    @Override
    public List<Todo> listarTodos() {
        return tarefas;
    }

    @Override
    public void atualizarStatus(Integer id, boolean completed) {
        for (Todo todo : tarefas) {
            if (todo.getId().equals(id)) {
                todo.setCompleted(completed);
                return;
            }
        }
    }

    @Override
    public void remover(Integer id) {
        for (Todo todo : tarefas) {
            if (todo.getId().equals(id)) {
                tarefas.remove(todo);
                return;
            }
        }
    }

    @Override
    public Optional<Todo> buscarPorId(Integer id) {
       for (Todo todo : tarefas){
        if (todo.getId().equals(id)) {
            return Optional.of(todo);
        }
    }
        return Optional.empty();
    }
    
}