using System.Net.Http.Json;

internal sealed class UserService(ICompleteUserClient userClient)
{
    public async Task ProcessUsersAsync()
    {
        // Create a new user.
        HttpResponseMessage response = await userClient.CreateUserAsync(new(
            Id: null, /* Is populated upon successful HTTP POST when creating user */
            Name: "Ada Lovelace",
            Username: "ada.lovelace",
            Email: "1st-computer-programmer@example.com",
            Address: new(
                Street: "123 Engineer Lane",
                Suite: null,
                City: "London",
                ZipCode: "EC1A",
                Geo: new(
                    Lat: 51.509865m, Lng: -0.118092m)),
            Phone: "+1234567890",
            Website: "www.example.com",
            Company: new(
                Name: "Babbage, LLC.",
                CatchPhrase: "works on my machine",
                Bs: "This is the future")));

        User? createdUser = await response.Content.ReadFromJsonAsync<User>();

        Console.WriteLine($"""
            CreateUserAsync: Created user
               '{createdUser}'...

            """);

        // Get user by id.
        User receivedUser = await userClient.GetUserByIdAsync(7);
        Console.WriteLine($"""
            GetUserAsync: Received user
                '{receivedUser}'...

            """);

        // Get list of all users.
        User[] allUsers = await userClient.GetAllUsersAsync();
        Console.WriteLine($"""
            GetUsersAsync: Received a total of {allUsers.Length} users...
            """);
    }
}
