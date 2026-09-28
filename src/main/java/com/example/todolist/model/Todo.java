package com.example.todolist.model;

public class Todo {

    private Integer id;

    private String title;

    private boolean completed;

    private String weekday;

    private String priority;


    // Construtor da classe.

    public Todo() {
        
    }

    // Metodos Gets.

    public Integer getId(){
        return id;
    }

    public String getTitle(){
        return title;
    }

    public boolean getCompleted(){
        return completed;
    }

    public String getWeekday(){
        return weekday;
    }

    public String getPriority(){
        return priority;
    }


    //Metodos Sets.

    public void setId( int id){
        this.id = id;
    }

    public void setTitle(String title){
        this.title = title;
    }

    public void setCompleted(boolean completed){
        this.completed = completed;
    }

    public void setWeekday(String weekday){
        this.weekday = weekday;
    }

    public void setPriority(String priority){
        this.priority = priority;
    }

    @Override
    public String toString() {
        return "Todo{id=" + id + ", title='" + title + "', weekday='" + weekday + "', priority='" + priority + "', completed=" + completed + "}";
    }

}