// Snippet for S_UELocalClientSecuritySettings
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
        private void LocalClient()
        {
            //<snippet15>
            // Create an instance of the binding to use.
            WSHttpBinding b = new WSHttpBinding();

            // Get the binding element collection.
            BindingElementCollection bec = b.CreateBindingElements();

            // Find the SymmetricSecurityBindingElement in the collection.
            // Important: Cast to the SymmetricSecurityBindingElement when using the Find
            // method.
            SymmetricSecurityBindingElement sbe = (SymmetricSecurityBindingElement)
                bec.Find<SecurityBindingElement>();

            // Get the LocalSecuritySettings from the binding element.
            LocalClientSecuritySettings lc = sbe.LocalClientSettings;

            // Print out values.
            Console.WriteLine("Maximum cookie caching time: {0} days", lc.MaxCookieCachingTime.Days);
            Console.WriteLine("Replay Cache Size: {0}", lc.ReplayCacheSize);
            Console.WriteLine("ReplayWindow: {0} minutes", lc.ReplayWindow.Minutes);
            Console.WriteLine("MaxClockSkew: {0} minutes", lc.MaxClockSkew.Minutes);
            Console.ReadLine();

            // Change the MaxClockSkew to 3 minutes.
            lc.MaxClockSkew = new TimeSpan(0, 0, 3, 0);

            // Print the new value.
            Console.WriteLine("New MaxClockSkew: {0} minutes", lc.MaxClockSkew.Minutes);
            Console.ReadLine();

            // Create an EndpointAddress for the service.
            EndpointAddress ea = new EndpointAddress("http://localhost/calculator");

            // Create a client. The binding has the changed MaxClockSkew.
            // CalculatorClient cc = new CalculatorClient(b, ea);
            // Use the new client. (Not shown.)
            // cc.Close();
            //</snippet15>
        }


        static void Main()
        {

            // <Snippet2>
            // <Snippet0>
            // <Snippet1>
            LocalClientSecuritySettings settings =
                new LocalClientSecuritySettings();
            // </Snippet1>

            bool cacheCookies = settings.CacheCookies;
            // </Snippet0>
            // </Snippet2>

            // <Snippet3>
            // Set to 20 minutes.
            settings.CookieRenewalThresholdPercentage = 20;
            // </Snippet3>

            // <Snippet4>
            // Enable replay detection.
            settings.DetectReplays = true;
            // </Snippet4>

            // <Snippet5>
            IdentityVerifier id = settings.IdentityVerifier;
            // </Snippet5>

            // <Snippet6>
            TimeSpan timeSpan = settings.MaxClockSkew;
            // </Snippet6>

            // <Snippet7>
            TimeSpan maxCookieCachingTime = settings.MaxCookieCachingTime;
            // </Snippet7>

            // <Snippet8>
            bool reconnect = settings.ReconnectTransportOnFailure;
            // </Snippet8>

            // <Snippet9>
            int replayCacheSize = settings.ReplayCacheSize;
            // </Snippet9>

            // <Snippet10>
            TimeSpan replayWindow = settings.ReplayWindow;
            // </Snippet10>

            // <Snippet11>
            TimeSpan sessionKeyRenewalInterval = settings.SessionKeyRenewalInterval;
            // </Snippet11>

            // <Snippet12>
            TimeSpan rollover = settings.SessionKeyRolloverInterval;
            // </Snippet12>

            // <Snippet13>
            TimeSpan timestamp = settings.TimestampValidityDuration;
            // </Snippet13>

            // <Snippet14>
            LocalClientSecuritySettings clone =
                settings.Clone();
            // </Snippet14>




        }
    }

}
