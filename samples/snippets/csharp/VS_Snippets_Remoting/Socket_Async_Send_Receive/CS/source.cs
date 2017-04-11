using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


//<Snippet11>
public class StateObject{
     public Socket workSocket = null;
     public const int BUFFER_SIZE = 1024;
     public byte[] buffer = new byte[BUFFER_SIZE];
     public StringBuilder sb = new StringBuilder();
}
//</Snippet11>

public class Async_Send_Receive{

public static ManualResetEvent allDone = new ManualResetEvent(false);

	
public static void Connect(){
//<Snippet1>
	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       try{
          
                 while(true){
                 allDone.Reset();

                 Console.WriteLine("Establishing Connection");
                 s.BeginConnect(lep, new AsyncCallback(Async_Send_Receive.Connect_Callback), s);

                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }
//</Snippet1>
}

public static void Listen(){
//<Snippet2>
	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       try{
            s.Bind(lep);
            s.Listen(1000);

            while(true){
                 allDone.Reset();

                 Console.WriteLine("Waiting for a connection...");
                 s.BeginAccept(new AsyncCallback(Async_Send_Receive.Listen_Callback), s);

                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }
//</Snippet2>
}

public static void SendTo(){
//<Snippet3>
	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       try{
          
                 while(true){
                 allDone.Reset();

                 byte[] buff = Encoding.ASCII.GetBytes("This is a test");
                 
                 Console.WriteLine("Sending Message Now..");
                 s.BeginSendTo(buff, 0, buff.Length, 0, lep, new AsyncCallback(Async_Send_Receive.SendTo_Callback), s);

                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }
//</Snippet3>
}

public static void ReceiveFrom(){

//<Snippet4>
	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Stream,
                                         ProtocolType.Tcp);
       
       IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
       EndPoint tempRemoteEP = (EndPoint)sender;
       s.Connect(sender);
       
       try{
            while(true){
                 allDone.Reset();
                 StateObject so2 = new StateObject();
                 so2.workSocket = s;
                 Console.WriteLine("Attempting to Receive data from host.contoso.com");
             
                 s.BeginReceiveFrom(so2.buffer, 0, StateObject.BUFFER_SIZE,0, ref tempRemoteEP,
	                                   new AsyncCallback(Async_Send_Receive.ReceiveFrom_Callback), so2);	
                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }
//</Snippet4>
}
public static void ReceiveFrom1(){

//<Snippet41>
	IPHostEntry lipa = Dns.Resolve("host.contoso.com");
	IPEndPoint lep = new IPEndPoint(lipa.AddressList[0], 11000);

       Socket s = new Socket(lep.Address.AddressFamily,
       	                           SocketType.Dgram,
                                         ProtocolType.Udp);
       
       IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
       EndPoint tempRemoteEP = (EndPoint)sender;
       s.Connect(sender);
       
       try{
            while(true){
                 allDone.Reset();
                 StateObject so2 = new StateObject();
                 so2.workSocket = s;
                 Console.WriteLine("Attempting to Receive data from host.contoso.com");
             
                 s.BeginReceiveFrom(so2.buffer, 0, StateObject.BUFFER_SIZE,0, ref tempRemoteEP,
	                                   new AsyncCallback(Async_Send_Receive.ReceiveFrom_Callback), so2);	
                 allDone.WaitOne();
            }
       }
       catch (Exception e){
            Console.WriteLine(e.ToString());
       }
//</Snippet41>
}

public static void Connect_Callback(IAsyncResult ar){

//<Snippet5>
     allDone.Set();
     Socket s = (Socket) ar.AsyncState;
     s.EndConnect(ar);
     StateObject so2 = new StateObject();
     so2.workSocket = s;
     byte[] buff = Encoding.ASCII.GetBytes("This is a test");
     s.BeginSend(buff, 0, buff.Length,0,
	                       new AsyncCallback(Async_Send_Receive.Send_Callback), so2);    
//</Snippet5>
}

public static void Send_Callback(IAsyncResult ar){

//<Snippet6>
	StateObject so = (StateObject) ar.AsyncState;
	Socket s = so.workSocket;

	int send = s.EndSend(ar);

       Console.WriteLine("The size of the message sent was :" + send.ToString());
	
	s.Close();
//</Snippet6>	
}

//<Snippet7>
public static void Listen_Callback(IAsyncResult ar){
     allDone.Set();
     Socket s = (Socket) ar.AsyncState;
     Socket s2 = s.EndAccept(ar);
     StateObject so2 = new StateObject();
     so2.workSocket = s2;
     s2.BeginReceive(so2.buffer, 0, StateObject.BUFFER_SIZE,0,
	                       new AsyncCallback(Async_Send_Receive.Read_Callback), so2);	
}
//</Snippet7>

//<Snippet8>
public static void Read_Callback(IAsyncResult ar){
	StateObject so = (StateObject) ar.AsyncState;
	Socket s = so.workSocket;

	int read = s.EndReceive(ar);

	if (read > 0) {
            so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read));
            s.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0, 
            	                     new AsyncCallback(Async_Send_Receive.Read_Callback), so);
	}
	else{
	     if (so.sb.Length > 1) {
	          //All of the data has been read, so displays it to the console
	          string strContent;
	          strContent = so.sb.ToString();
	          Console.WriteLine(String.Format("Read {0} byte from socket" + 
	          	               "data = {1} ", strContent.Length, strContent));
	     }
	     s.Close();
	}
}
//</Snippet8>

public static void SendTo_Callback(IAsyncResult ar){
//<Snippet9>
	StateObject so = (StateObject) ar.AsyncState;
	Socket s = so.workSocket;

	int send = s.EndSendTo(ar);

       Console.WriteLine("The size of the message sent was :" + send.ToString());
	
	s.Close();
//</Snippet9>
}

public static void ReceiveFrom_Callback(IAsyncResult ar){

//<Snippet10>
	StateObject so = (StateObject) ar.AsyncState;
	Socket s = so.workSocket;

       // Creates a temporary EndPoint to pass to EndReceiveFrom.
       IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
	EndPoint tempRemoteEP = (EndPoint)sender;

       int read = s.EndReceiveFrom(ar, ref tempRemoteEP); 


	if (read > 0) {
            so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read));
            s.BeginReceiveFrom(so.buffer, 0, StateObject.BUFFER_SIZE, 0, ref tempRemoteEP,
            	                     new AsyncCallback(Async_Send_Receive.ReceiveFrom_Callback), so);
	}
	else{
	     if (so.sb.Length > 1) {
	          //All the data has been read, so displays it to the console.
	          string strContent;
	          strContent = so.sb.ToString();
	          Console.WriteLine(String.Format("Read {0} byte from socket" + 
	          	               "data = {1} ", strContent.Length, strContent));
	     }
	     s.Close();
	     
	}
//</Snippet10>
}

public static void Main(){
}

}
