var week = new DayOfWeekCollection();
Console.WriteLine(week[DayOfWeek.Friday]);

try
{
    Console.WriteLine(week[(DayOfWeek)43]);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine($"Not supported input: {e.Message}");
}
