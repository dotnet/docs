using System;

// <Snippet3>
public class PingPong : MarshalByRefObject
{
    private string greetings = "PING!";

    public static void Main()
    {
        AppDomain otherDomain = AppDomain.CreateDomain("otherDomain");

        PingPong pp = new PingPong();
        pp.MyCallBack();
        pp.greetings = "PONG!";
        otherDomain.DoCallBack(new CrossAppDomainDelegate(pp.MyCallBack));

        // Output:
        //   PING! from defaultDomain
        //   PONG! from defaultDomain
    }

    // Callback will always execute within defaultDomain due to inheritance from
    // MarshalByRefObject
    public void MyCallBack()
    {
        string name = AppDomain.CurrentDomain.FriendlyName;
        if (name == AppDomain.CurrentDomain.SetupInformation.ApplicationName)
        {
            name = "defaultDomain";
        }
        Console.WriteLine(greetings + " from " + name);
    }
}
// </Snippet3>