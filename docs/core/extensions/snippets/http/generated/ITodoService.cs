using Refit;
using Shared;

namespace GeneratedHttp.Example;

public interface ITodoService
{
    [Get("/todos?userId={userId}")]
    Task<Todo[]> GetUserTodosAsync(int userId);
}
