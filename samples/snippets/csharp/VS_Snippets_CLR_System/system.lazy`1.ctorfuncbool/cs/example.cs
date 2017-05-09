//<SnippetAll>
using System;
using System.Threading;

class Program
{
    static Lazy<LargeObject> lazyLargeObject = null;

    //<SnippetFactoryFunc>
    static LargeObject InitLargeObject()
    {
        return new LargeObject();
    }
    //</SnippetFactoryFunc>


    static void Main()
    {
        // The lazy initializer is created here. LargeObject is not created until the 
        // ThreadProc method executes.
        //<SnippetNewLazy>
        lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, false);

        // The following lines show how to use other constructors to achieve exactly the
        // same result as the previous line: 
        //lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, LazyThreadSafetyMode.None);
        //</SnippetNewLazy>


        Console.WriteLine(
            "\r\nLargeObject is not created until you access the Value property of the lazy" +
            "\r\ninitializer. Press Enter to create LargeObject (three tries).");
        Console.ReadLine();

        //<SnippetValueProp>
        for (int i = 0; i < 3; i++)
        {
            try
            {
                LargeObject large = lazyLargeObject.Value;
                large.Data[11] = 89;
            }
            catch (ApplicationException aex)
            {
                Console.WriteLine("Exception: {0}", aex.Message);
            }
        }
        //</SnippetValueProp>

        Console.WriteLine("\r\nPress Enter to end the program");
        Console.ReadLine();
    }
}

class LargeObject
{
    //<SnippetLargeCtor>
    static bool pleaseThrow = true;
    public LargeObject()
    {
        if (pleaseThrow)
        {
            pleaseThrow = false;
            throw new ApplicationException("Throw only ONCE.");
        }

        Console.WriteLine("LargeObject was created on thread id {0}.", 
            Thread.CurrentThread.ManagedThreadId);
    }
    //</SnippetLargeCtor>
    public long[] Data = new long[100000000];
}

/* This example produces output similar to the following:

LargeObject is not created until you access the Value property of the lazy
initializer. Press Enter to create LargeObject (three tries).

Exception: Throw only ONCE.
Exception: Throw only ONCE.
Exception: Throw only ONCE.

Press Enter to end the program
 */
//</SnippetAll>
