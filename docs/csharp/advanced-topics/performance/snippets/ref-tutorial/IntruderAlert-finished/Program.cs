using IntruderAlert;

Console.WriteLine("Press <return> to start simulation");
Console.ReadLine();
var room = new Room("gallery");
var r = new Random();

int counter = 0;

room.TakeMeasurements(
    () =>
    {
        ref readonly DebounceMeasurement debounce = ref room.Debounce;
        Console.WriteLine(debounce.ToString());
        ref readonly AverageMeasurement average = ref room.Average;
        Console.WriteLine(average.ToString());
        Console.WriteLine();
        counter++;
        return counter < 20000;
    });

counter = 0;
room.TakeMeasurements(
    () =>
    {
        ref readonly DebounceMeasurement debounce = ref room.Debounce;
        Console.WriteLine(debounce.ToString());
        ref readonly AverageMeasurement average = ref room.Average;
        Console.WriteLine(average.ToString());
        room.Intruders += (room.Intruders, r.Next(5)) switch
        {
            ( > 0, 0) => -1,
            ( < 3, 1) => 1,
            _ => 0
        };

        Console.WriteLine(room.ToString());
        Console.WriteLine();
        counter++;
        return counter < 200000;
    });