using Refit;
using Shared;

namespace GeneratedHttp.Example;

public interface IJokeService
{
    [Get("/jokes/random?limitTo=[nerdy]")]
    Task<ChuckNorrisJoke> GetRandomJokeAsync();
}
