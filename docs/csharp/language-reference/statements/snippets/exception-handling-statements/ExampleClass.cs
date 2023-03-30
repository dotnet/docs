public class ExampleClass
{
    string name;

// <ThrowExpressionCoalescing>
    public string Name
    {
        get => name;
        set => name = value ??
            throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
    }
// </ThrowExpressionCoalescing>
}