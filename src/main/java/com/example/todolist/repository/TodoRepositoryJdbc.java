package com.example.todolist.repository;

import java.sql.PreparedStatement;
import java.util.List;
import java.util.Optional;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.GeneratedKeyHolder;
import org.springframework.jdbc.support.KeyHolder;

import com.example.todolist.model.Todo;


public class TodoRepositoryJdbc implements TodoRepository {

    private final JdbcTemplate jdbcTemplate;

    public TodoRepositoryJdbc(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public Todo salvar(Todo todo) {
        String sql = "INSERT INTO todos (title, weekday, priority, completed) VALUES (?, ?, ?, ?)";

        KeyHolder keyHolder = new GeneratedKeyHolder();

        jdbcTemplate.update(connection -> {
            PreparedStatement ps = connection.prepareStatement(sql, new String[]{"id"});
            ps.setString(1, todo.getTitle());
            ps.setString(2, todo.getWeekday());
            ps.setString(3, todo.getPriority());
            ps.setBoolean(4, todo.getCompleted());
            return ps;
        }, keyHolder);

        todo.setId(keyHolder.getKey().intValue());
        return todo;
    }

    @Override
    public List<Todo> listarTodos() {
        String sql = "SELECT * FROM todos";

        return jdbcTemplate.query(sql, (rs, rowNum) -> {
            Todo todo = new Todo();
            todo.setId(rs.getInt("id"));
            todo.setTitle(rs.getString("title"));
            todo.setWeekday(rs.getString("weekday"));
            todo.setPriority(rs.getString("priority"));
            todo.setCompleted(rs.getBoolean("completed"));
            return todo;
        });
    }

    @Override
    public void atualizarStatus(Integer id, boolean completed) {
        String sql = "UPDATE todos SET completed = ? WHERE id = ?";
        jdbcTemplate.update(sql, completed, id);
    }

    @Override
    public void remover(Integer id) {
        String sql = "DELETE FROM todos WHERE id = ?";
        jdbcTemplate.update(sql, id);
    }

    @Override
    public Optional<Todo> buscarPorId(Integer id) {
        String sql = "SELECT * FROM todos WHERE id = ?";

        List<Todo> resultados = jdbcTemplate.query(sql, (rs, rowNum) ->{
            Todo todo = new Todo();
            todo.setId(rs.getInt("id"));
            todo.setTitle(rs.getString("title"));
            todo.setWeekday(rs.getString("weekday"));
            todo.setPriority(rs.getString("priority"));
            todo.setCompleted(rs.getBoolean("completed"));
            return todo;
        }, id);

        if (resultados.isEmpty()) {
            return Optional.empty();
        }
        return Optional.of(resultados.get(0));
    }

}