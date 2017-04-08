// <Snippet3>
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ComponentModel;
using System.Web;

class LoginProgram
{
    static void Main(string[] args)
    {
        string username;
        string password;
        string studentid;
        string answer;
        bool result;

        Console.Write("Enter user name:");
        username = Console.ReadLine();

        Console.Write("Enter password:");
        password = Console.ReadLine();

        Console.Write("Enter student identification number:");
        studentid = Console.ReadLine();

        Console.Write("Enter name of pet:");
        answer = Console.ReadLine();

        BasicHttpBinding binding = new BasicHttpBinding();
        binding.CloseTimeout = TimeSpan.MaxValue;
        binding.OpenTimeout = TimeSpan.MaxValue;
        binding.ReceiveTimeout = TimeSpan.MaxValue;
        binding.SendTimeout = TimeSpan.MaxValue;
        binding.AllowCookies = true;

        ChannelFactory<AuthenticationService> channelFactory = new ChannelFactory<AuthenticationService>(binding, new EndpointAddress(@"https://www.fabrikam.com/AuthSvc/Service.svc"));
        AuthenticationService clientService = channelFactory.CreateChannel();

        try
        {
            result = clientService.Login(username, password, studentid + "," + answer, true);
        }
        catch (Exception e)
        {
            Console.WriteLine("Sorry, login is currently not available.");
        }

        if (result)
        {
            Console.WriteLine("Welcome " + username + ". You have logged in.");
        }
        else
        {
            Console.WriteLine("We could not validate your credentials. Please try again.");
        }
    }
}
// </Snippet3>