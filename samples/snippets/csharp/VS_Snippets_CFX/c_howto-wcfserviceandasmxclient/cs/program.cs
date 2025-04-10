// <snippet0>
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

[ServiceContract]
public interface IEcho
{
    [OperationContract]
    string Echo(string s);
}

public class MyService : IEcho
{
    public string Echo(string s)
    {
        return s;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string baseAddress = "http://localhost:8080/wcfselfhost/";
        ServiceHost host = new ServiceHost(typeof(MyService), new Uri(baseAddress));

        // Create a BasicHttpBinding instance
        BasicHttpBinding binding = new BasicHttpBinding();

        // Add a service endpoint using the created binding
        host.AddServiceEndpoint(typeof(IEcho), binding, "echo1");

        host.Open();
        Console.WriteLine($"Service listening on {baseAddress} . . .");
        Console.ReadLine();
        host.Close();
    }
}
// </snippet0>
