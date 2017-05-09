

//<Snippet1>
using System;
using System.Net;
using System.Net.Sockets;


public class MyNetworkStream_Sub_Class : NetworkStream
{

    public MyNetworkStream_Sub_Class(Socket socket, bool ownsSocket) :
        base(socket, ownsSocket)
    {
    }
    // You can use the Socket method to examine the underlying Socket.
    public bool IsConnected
    {
        get
        {
            return this.Socket.Connected;
        } 
    }
 
    public bool CanCommunicate
    {
        get
        {
            if (!this.Readable | !this.Writeable)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    //</Snippet1>
    public static void DoSomethingSignificant()
    {
          
    }



    public static void Main()
    {
        MyNetworkStream_Sub_Class.DoSomethingSignificant();

    }


}

