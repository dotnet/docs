namespace ConsoleDI.Example;

public class OperationLogger
{
    private readonly ITransientOperation _transientOperation;
    private readonly IScopedOperation _scopedOperation;
    private readonly ISingletonOperation _singletonOperation;

    public OperationLogger(
        ITransientOperation transientOperation,
        IScopedOperation scopedOperation,
        ISingletonOperation singletonOperation) =>
        (_transientOperation, _scopedOperation, _singletonOperation) =
            (transientOperation, scopedOperation, singletonOperation);

    public void LogOperations(string scope)
    {
        LogOperation(_transientOperation, scope, "Always different");
        LogOperation(_scopedOperation, scope, "Changes only with scope");
        LogOperation(_singletonOperation, scope, "Always the same");
    }


    private static void LogOperation<T>(T operation, string scope, string message)
        where T : IOperation =>
        Console.WriteLine(
            $"{scope}: {typeof(T).Name,-19} [ {operation.OperationId}...{message,-23} ]");
}
