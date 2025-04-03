using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples;
public class HowToDeclareAndUse
{
    //<DeclareNamedDelegate>
    // Declare a delegate.
    delegate void NotifyCallback(string str);

    // Declare a method with the same signature as the delegate.
    static void Notify(string name)
    {
        Console.WriteLine($"Notification received for: {name}");
    }
    //</DeclareNamedDelegate>


    public static void Examples()
    {
        //<CreateNamedInstance>
        // Create an instance of the delegate.
        NotifyCallback del1 = new NotifyCallback(Notify);
        //</CreateNamedInstance>

        //<MethodGroup>
        NotifyCallback del2 = Notify;
        //</MethodGroup>

        //<AnonymousMethod>
        // Instantiate NotifyCallback by using an anonymous method.
        NotifyCallback del3 = delegate (string name)
        {
            Console.WriteLine($"Notification received for: {name}");
        };
        //</AnonymousMethod>

        //<LambdaExpression>
        // Instantiate NotifyCallback by using a lambda expression.
        NotifyCallback del4 = name => Console.WriteLine($"Notification received for: {name}");
        //</LambdaExpression>

    }

}
