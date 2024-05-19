public class FirstExample
{
    // <LeisureHours>
    public static async Task ShowTodaysInfoAsync()
    {
        string message =
            $"Today is {DateTime.Today:D}\n" +
            "Today's hours of leisure: " +
            $"{await GetLeisureHoursAsync()}";

        Console.WriteLine(message);
    }

    static async Task<int> GetLeisureHoursAsync()
    {
        DayOfWeek today = await Task.FromResult(DateTime.Now.DayOfWeek);

        int leisureHours =
            today is DayOfWeek.Saturday || today is DayOfWeek.Sunday
            ? 16 : 5;

        return leisureHours;
    }
    // Example output:
    //    Today is Wednesday, May 24, 2017
    //    Today's hours of leisure: 5
    // </LeisureHours>
}
