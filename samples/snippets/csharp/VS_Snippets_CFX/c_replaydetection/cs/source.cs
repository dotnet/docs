//<snippet0>
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Replay
{
    public class Test
    {
        public Test() { }

        static void Main()
        {
            try
            {
                Test t = new Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<snippet1>
        private SecurityBindingElement CreateSymmetricBindingForClient()
        {
            SymmetricSecurityBindingElement b = SecurityBindingElement.CreateKerberosBindingElement();
            b.LocalClientSettings.DetectReplays = true;
            b.LocalClientSettings.MaxClockSkew = new TimeSpan(0, 3, 0);
            b.LocalClientSettings.ReplayWindow = new TimeSpan(0, 2, 0);
            b.LocalClientSettings.ReplayCacheSize = 10000;
            return b;
        }
        //</snippet1>
    }
}
