using System;

// <Snippet1>
[Serializable]
class ExampleClass
{
    [NonSerialized]
    public ExampleClass ExampleField;

    public int NormalProperty { get; set; }
}

class AnotherClass
{
    // The argument passed by could be `JsonConvert.DeserializeObject<ExampleClass>(untrustedData)`.
    public void AnotherMethod(ExampleClass ec)
    {
        while (ec != null)
        {
            Console.WriteLine(ec.ToString());
            ec = ec.ExampleField;
        }
    }
}
// </Snippet1>
