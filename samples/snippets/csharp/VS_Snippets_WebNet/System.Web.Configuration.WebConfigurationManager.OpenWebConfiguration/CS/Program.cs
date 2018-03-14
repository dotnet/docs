//<snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace SamplesAspNet.Config
{
    class GetFullConfig
    {
        public static void Main(string[] args)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/MyApp");
            config.SaveAs("c:\\MyApp.web.config", ConfigurationSaveMode.Full, true);
        }
    }
}
//</snippet1>