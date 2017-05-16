using System;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Security.Permissions;

[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Stuff
{
    public sealed class Test
    {

        private Test(){}
        
        public static void Main()
        {
            string myPassword = Returnpassword();
            Console.WriteLine(myPassword);
        }
        //<snippet1>
        public static string Returnpassword()
        {
            Console.WriteLine("Provide a valid machine or domain account. [domain\\user]");
            Console.WriteLine("   Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("   Enter password:");
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    password += info.KeyChar;
                    info = Console.ReadKey(true);
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring
                        (0, password.Length - 1);
                    }
                    info = Console.ReadKey(true);
               }
            }
            for (int i = 0; i < password.Length; i++)
            Console.Write("*");
        return password;
            }
        //</snippet1>
        }
}
namespace Samples
{
    public class Test
    {
        private void AuthenticateWithUserName()
        {
            //<snippet10>
            //<snippet7>
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType = 
                MessageCredentialType.UserName;
            //</snippet7>


            //<snippet2>
            CalculatorClient client = new CalculatorClient("default");
            //</snippet2>

            //<snippet3>
            client.ClientCredentials.UserName.Password = ReturnPassword();
            //</snippet3>

            //<snippet4>
            client.ClientCredentials.UserName.UserName = ReturnUsername();
            //</snippet4>
            //</snippet10>
            //<snippet5>
            double value1 = client.Add(100, 15.99);
            //</snippet5>

            //<snippet6>
            client.Close();
            //</snippet6>



        }

        private string ReturnUsername()
        {
            return "hah";
        }

        private string ReturnPassword()
        {
            return "hah";
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute()]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/Divide", ReplyAction = "http://tempuri.org/ICalculator/DivideResponse")]
        double Divide(double a, double b);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/CalculateTax", ReplyAction = "http://tempuri.org/ICalculator/CalculateTaxResponse")]
        double Add(double a, double b);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
    {
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
    {

        public CalculatorClient()
        {
        }

        public CalculatorClient(string endpointConfigurationName)
            :
                base(endpointConfigurationName)
        {
        }

        public CalculatorClient(string endpointConfigurationName, string remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(binding, remoteAddress)
        {
        }

        public double Divide(double a, double b)
        {
            return base.Channel.Divide(a, b);
        }

        public double Add(double a, double b)
        {
            return base.Channel.Add(a, b);
        }
    }
}
