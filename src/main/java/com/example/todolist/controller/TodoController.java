package com.example.todolist.controller;

import java.util.List;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PatchMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.todolist.model.Todo;
import com.example.todolist.service.TodoService;

@RestController
@RequestMapping("/todos")
public class TodoController {

    private final TodoService service;

    public TodoController(TodoService service) {
        this.service = service;
    }

    @GetMapping
    public List<Todo> listar() {
        return service.listarTarefas();
    }

    @PostMapping
    public Todo criar(@RequestBody Todo todo) {
        return service.criarTarefa(todo);
    }

    @PatchMapping("/{id}/toggle")
    public void alternarStatus(@PathVariable Integer id) {
        service.alternarStatus(id);
    }

    @DeleteMapping("/{id}")
    public void remover(@PathVariable Integer id) {
        service.removerTarefa(id);
    }
}