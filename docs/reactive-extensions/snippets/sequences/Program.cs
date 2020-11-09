using System;
using System.Collections.Generic;

static IEnumerable<ConsoleKeyInfo> GetInput()
{
    var input = new HashSet<ConsoleKeyInfo>();
    var keyCount = 0;
    while (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true);
        if (++ keyCount > 10) continue;

        input.Add(key);
    }

    return input;
}
