static partial class Program
{
    // <getfromjson>
    static async Task GetFromJsonAsync(HttpClient httpClient)
    {
        var todos = await httpClient.GetFromJsonAsync<List<Todo>>(
            "todos?userId=1&completed=false");

        Console.WriteLine("GET https://jsonplaceholder.typicode.com/todos?userId=1&completed=false HTTP/1.1");
        todos?.ForEach(Console.WriteLine);
        Console.WriteLine();

        // Expected output:
        //   GET https://jsonplaceholder.typicode.com/todos?userId=1&completed=false HTTP/1.1
        //   Todo { UserId = 1, Id = 1, Title = delectus aut autem, Completed = False }
        //   Todo { UserId = 1, Id = 2, Title = quis ut nam facilis et officia qui, Completed = False }
        //   Todo { UserId = 1, Id = 3, Title = fugiat veniam minus, Completed = False }
        //   Todo { UserId = 1, Id = 5, Title = laboriosam mollitia et enim quasi adipisci quia provident illum, Completed = False }
        //   Todo { UserId = 1, Id = 6, Title = qui ullam ratione quibusdam voluptatem quia omnis, Completed = False }
        //   Todo { UserId = 1, Id = 7, Title = illo expedita consequatur quia in, Completed = False }
        //   Todo { UserId = 1, Id = 9, Title = molestiae perspiciatis ipsa, Completed = False }
        //   Todo { UserId = 1, Id = 13, Title = et doloremque nulla, Completed = False }
        //   Todo { UserId = 1, Id = 18, Title = dolorum est consequatur ea mollitia in culpa, Completed = False }
    }
    // </getfromjson>
}
