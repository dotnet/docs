namespace Shared;

public record class Todo(
    int UserId,
    int Id,
    string Title,
    bool Completed);
