using System.Resources;

public class Example1
{
    public static void Main()
    {
        CallCtor1();
        CallCtor2();
    }

    static void CallCtor1()
    {
        // <Snippet1>
        ResourceManager rm = new ResourceManager("MyCompany.StringResources",
                                                 typeof(Example).Assembly);
        // </Snippet1>
    }

    static void CallCtor2()
    {
        // <Snippet2>
        ResourceManager rm = new ResourceManager(typeof(MyCompany.StringResources));
        // </Snippet2>
    }
}

namespace MyCompany
{
    class StringResources { }
}
