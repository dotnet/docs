namespace object_collection_initializers;

class Program
{
    static void Main(string[] args)
    {
        BasicObjectInitializers.ObjectInitializerExamples();
        HowToObjectInitializers.Main();
        HowToIndexInitializer.Main();
        HowToDictionaryInitializer.Main();
        ObjectInitializersExecutionOrder.Main();
        
        Console.WriteLine("\n--- Object Initializer Without New Examples ---");
        ObjectInitializerWithoutNew.Examples();
        ReadOnlyPropertyExample.Example();
    }
}
