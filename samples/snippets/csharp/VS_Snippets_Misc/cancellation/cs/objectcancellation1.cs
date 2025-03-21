// <Snippet2>
using System;
using System.Threading;

class CancelableObject
{
    public string id;

    public CancelableObject(string id)
    {
        this.id = id;
    }

    public void Cancel()
    {
        Console.WriteLine($"Object {id} Cancel callback");
        // Perform object cancellation here.
    }
}

public class Example1
{
    public static void Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        // User defined Class with its own method for cancellation
        var obj1 = new CancelableObject("1");
        var obj2 = new CancelableObject("2");
        var obj3 = new CancelableObject("3");

        // Register the object's cancel method with the token's
        // cancellation request.
        token.Register(() => obj1.Cancel());
        token.Register(() => obj2.Cancel());
        token.Register(() => obj3.Cancel());

        // Request cancellation on the token.
        cts.Cancel();
        // Call Dispose when we're done with the CancellationTokenSource.
        cts.Dispose();
    }
}
// The example displays the following output:
//       Object 3 Cancel callback
//       Object 2 Cancel callback
//       Object 1 Cancel callback
// </Snippet2>
