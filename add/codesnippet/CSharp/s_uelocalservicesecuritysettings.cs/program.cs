// Snippet for S_UELocalServiceSecuritySettings
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Security;
using System.Text;
using System.Xml;

namespace Snippets
{
    class Snippet
    {        
        private void ShowUse()
        {
            //<snippet17>
            // Create an instance of the binding to use.
            WSHttpBinding b = new WSHttpBinding();

            // Get the binding element collection.
            BindingElementCollection bec = b.CreateBindingElements();

            // Find the SymmetricSecurityBindingElement in the colllection.
            // Important: Cast to the SymmetricSecurityBindingElement when using the Find
            // method.
            SymmetricSecurityBindingElement sbe = (SymmetricSecurityBindingElement)
        bec.Find<SecurityBindingElement>();

            // Get the LocalServiceSettings from the binding element.
            LocalServiceSecuritySettings lss = sbe.LocalServiceSettings;

            // Print out values.
            Console.WriteLine("DetectReplays: {0} days", lss.DetectReplays);
            Console.WriteLine("ReplayWindow: {0} minutes", lss.ReplayWindow.Minutes);
            Console.WriteLine("MaxClockSkew: {0} minutes", lss.MaxClockSkew.Minutes);

            Console.ReadLine();
            Console.WriteLine("Press Enter to Continue");
            // Change the MaxClockSkew to 3 minutes.
            lss.MaxClockSkew = new TimeSpan(0, 0, 3, 0);

            // Print the new value.
            Console.WriteLine("New MaxClockSkew: {0} minutes", lss.MaxClockSkew.Minutes);
            Console.WriteLine("Press Enter to End");
            Console.ReadLine();

            // Create a URI for the service.
            Uri httpUri = new Uri("http://localhost/calculator");

            // Create a ServiceHost. The binding has the changed MaxClockSkew.
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);
            sh.AddServiceEndpoint(typeof(ICalculator), b, "");
            // sh.Open();
            // Console.WriteLine("Listening");
            // Console.ReadLine();
            // sh.Close();
            //</snippet17>
        }

        static void Main()
        {

            // <Snippet2>
            // <Snippet0>
            // <Snippet1>
            LocalServiceSecuritySettings settings =
                new LocalServiceSecuritySettings();
            // </Snippet1>

            bool detectReplays = settings.DetectReplays;
            // </Snippet0>
            // </Snippet2>

            // <Snippet3>
            TimeSpan inactivityTimeout = settings.InactivityTimeout;
            // </Snippet3>

            // <Snippet4>
            TimeSpan issuedCookieLifetime = settings.IssuedCookieLifetime;
            // </Snippet4>

            // <Snippet5>
            int maxCachedCookies = settings.MaxCachedCookies;
            // </Snippet5>

            // <Snippet6>
            TimeSpan maxClockSkew = settings.MaxClockSkew;
            // </Snippet6>

            // <Snippet7>
            int maxPendingSessions = settings.MaxPendingSessions;
            // </Snippet7>


            // <Snippet8>
            int maxStatefulNegotiationsNegotiations =
                settings.MaxStatefulNegotiations;
            // </Snippet8>

            // <Snippet9>
            TimeSpan negotiationTimeout = settings.NegotiationTimeout;
            // </Snippet9>

            // <Snippet10>
            int maxStatefulNegotiations = settings.MaxStatefulNegotiations;
            // </Snippet10>

            // <Snippet11>
            int replayCacheSize = settings.ReplayCacheSize;
            // </Snippet11>

            // <Snippet12>
            TimeSpan replayWindow = settings.ReplayWindow;
            // </Snippet12>

            // <Snippet13>
            TimeSpan sessionKeyRenewalInterval =
            settings.SessionKeyRenewalInterval;
            // </Snippet13>

            // <Snippet14>
            TimeSpan rolloverInterval =
                settings.SessionKeyRolloverInterval;
            // </Snippet14>

            // <Snippet15>
            TimeSpan timestampValidityDuration =
            settings.TimestampValidityDuration;
            // </Snippet15>

            // <Snippet16>
            LocalServiceSecuritySettings
                localServiceSecuritySettings =
            settings.Clone();
            // </Snippet16>

        }
    }

}


[ServiceContract]
interface ICalculator
{
    [OperationContract]
    double Add(double a, double b);
}

public class Calculator : ICalculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }
}

