namespace TodoList.Models;

public class Todo
{
    // Atributos privados (encapsulamento).

    private int? _id;

    private string? _title;

    private bool _completed;

    private string? _weekday;

    private string? _priority;


    // Construtor da classe.

    public Todo()
    {
    }

    public Todo(int? id, string? title, string? weekday, string? priority, bool completed)
    {
        _id = id;
        _title = title;
        _weekday = weekday;
        _priority = priority;
        _completed = completed;
    }

    // Propriedades (equivalente aos gets e sets do Java).

    public int? Id
    {
        get => _id;
        set => _id = value;
    }

    public string? Title
    {
        get => _title;
        set => _title = value;
    }

    public bool Completed
    {
        get => _completed;
        set => _completed = value;
    }

    public string? Weekday
    {
        get => _weekday;
        set => _weekday = value;
    }

    public string? Priority
    {
        get => _priority;
        set => _priority = value;
    }

    // Comportamentos do objeto.

    public bool PossuiTituloValido()
    {
        return !string.IsNullOrWhiteSpace(_title);
    }

    public void AlternarStatus()
    {
        _completed = !_completed;
    }

    public override string ToString()
    {
        return $"Todo{{id={_id}, title='{_title}', weekday='{_weekday}', priority='{_priority}', completed={_completed}}}";
    }
}
