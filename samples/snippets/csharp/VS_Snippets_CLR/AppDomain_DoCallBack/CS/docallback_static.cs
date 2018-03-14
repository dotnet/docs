using System;

public class PingPong
{
    // <Snippet1>
    static string greetings = "PONG!";

    public static void Main()
    {
        AppDomain otherDomain = AppDomain.CreateDomain("otherDomain");

        greetings = "PING!";
        MyCallBack();
        otherDomain.DoCallBack(new CrossAppDomainDelegate(MyCallBack));

        // Output:
        //   PING! from defaultDomain
        //   PONG! from otherDomain
    }

    static public void MyCallBack()
    {
        string name = AppDomain.CurrentDomain.FriendlyName;

        if (name == AppDomain.CurrentDomain.SetupInformation.ApplicationName)
        {
            name = "defaultDomain";
        }
        Console.WriteLine(greetings + " from " + name);
    }
    // </Snippet1>
}
