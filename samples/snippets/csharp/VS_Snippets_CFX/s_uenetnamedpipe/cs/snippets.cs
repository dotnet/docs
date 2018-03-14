using System;
using System.ServiceModel;

/*
Found 13 lines with R-E "snippet" in \sdtree\snippets\indigo\S_UENetNamedPipe\**\*.* (cur dir "c:\eps11\bin")
\sdtree\snippets\indigo\S_UENetNamedPipe\Common\serverApp.config:     <!-- <Snippet1>-->
   \sdtree\snippets\indigo\S_UENetNamedPipe\Common\serverApp.config:     <!-- </Snippet1>-->
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\makefile: service.exe: service.cs Snippets.cs
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\makefile:  csc /t:exe service.cs Snippets.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\service.cs:     // <Snippet2>
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\service.cs:     // </Snippet2>
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\Snippets.cs:     class Snippets
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\Snippets.cs:         public static void Snippet3()
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\Snippets.cs:             // <Snippet3>
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\Snippets.cs:             // </Snippet3>
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\Snippets.cs:         public static void Snippet4()
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\Snippets.cs:             // <Snippet4>
   \sdtree\snippets\indigo\S_UENetNamedPipe\cs\Snippets.cs:             // </Snippet4
*/

namespace UE.Samples
{
    class Snippets
    {
        public static void Snippet3()
        {
            // <Snippet3>
            Uri baseAddress = new Uri("http://localhost:8000/uesamples/service");

            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            Uri baseAddress = new Uri("http://localhost:8000/uesamples/service");

            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            NetNamedPipeBinding binding = new NetNamedPipeBinding("CalcConfig");
            // </Snippet4>
        }

    }
}
