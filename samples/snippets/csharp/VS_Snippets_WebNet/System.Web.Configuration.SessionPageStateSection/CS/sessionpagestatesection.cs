using System;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace Microsoft.Samples.AspNet.Configuration
{
    class UsingSessionPageState
    {

        static void Main(string[] args)
        {

            // <Snippet1>

            // Get the Web application configuration.
            System.Configuration.Configuration configuration =
                WebConfigurationManager.OpenWebConfiguration(
                "/aspnetTest");

            // Get the <sessionPageState> section.
            SessionPageStateSection sessionPageState =
              (SessionPageStateSection)configuration.GetSection(
              "system.web/sessionPageState");

            // </Snippet1>

            // <Snippet2>

            // Get the history size.
            int historySize =
                sessionPageState.HistorySize;

            string msg = String.Format(
            "Current history size: {0}\n",
            historySize.ToString());

            Console.Write(msg);


            if (!sessionPageState.IsReadOnly())
            {
                // Double current history size.
                sessionPageState.HistorySize =
                    2 * sessionPageState.HistorySize;

                configuration.Save();

                historySize =
                    sessionPageState.HistorySize;

                msg = String.Format(
                "New history size: {0}\n",
                historySize.ToString());

                Console.Write(msg);
            }

            // </Snippet2>

        }
    }
}
