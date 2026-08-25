// <LinkedTokens>
using System.Threading;

// Create the parent CancellationTokenSource.
using var parentCts = new CancellationTokenSource();
CancellationToken parentToken = parentCts.Token;

// Create a linked child CancellationTokenSource.
// The child token is cancelled when the parent token is cancelled.
using var childCts = CancellationTokenSource.CreateLinkedTokenSource(parentToken);
CancellationToken childToken = childCts.Token;

Console.WriteLine($"Parent is cancelled: {parentToken.IsCancellationRequested}");
Console.WriteLine($"Child is cancelled: {childToken.IsCancellationRequested}");

// Cancel the parent.
parentCts.Cancel();

Console.WriteLine($"Parent is cancelled: {parentToken.IsCancellationRequested}");
Console.WriteLine($"Child is cancelled: {childToken.IsCancellationRequested}");

// Output:
// Parent is cancelled: False
// Child is cancelled: False
// Parent is cancelled: True
// Child is cancelled: True
// </LinkedTokens>
