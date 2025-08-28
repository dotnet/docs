public class UniqueInstance : ISingleton<UniqueInstance>
{
    public void PrintMessage()
    {
        Console.WriteLine("This is a unique instance");
    }
}
