---
uid: System.Threading.Tasks.Task`1
summary: 'This class represents a runnable task'
---

## Example

```
using System;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        Task t = Task.Run(() => {
            // Just loop.
            int ctr = 0;
            for (ctr = 0; ctr <= 1000000; ctr++)
                {}
            Console.WriteLine("Finished {0} loop iterations", ctr);
        });
        t.Wait();
    }
}
```

