//<snippet6>
using System;

public class MyEventArgs : EventArgs
{
    private string msg;
    
    public MyEventArgs(string messageArg)
    {
        msg = messageArg;
    }
    
    public string Message
    {
        get {return msg;}
    }
}

class Dummy
{
    //<snippet7>
    public event EventHandler<MyEventArgs> MyEvent;
    //</snippet7>

    public static void Main()
    {
        Dummy dummo = new Dummy();

        dummo.DoEvent();
    }

    public void DoEvent()
    {
        MyEventArgs eArgs = new MyEventArgs("My Event Message");

        // MyEvent += new EventHandler<MyEventArgs>(MyEventHandler);
        //    or ...
        MyEvent += MyEventHandler;
        MyEvent(this, eArgs);
    }

    private void MyEventHandler(object sender, MyEventArgs eArgs)
    {
        Console.WriteLine(eArgs.Message);
    }
}
//</snippet6>
