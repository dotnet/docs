'<Snippet21>
Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Collections
Imports System.Text


Namespace ConfigurationStringSettings

    Class ConfigurationStringSettings

        Shared Sub DisplayConnectionStrings()
            ' Set the path of the config file.
            ' Make sure that you have a Web site on the
            ' same server called TestConfig. 
            Dim configPath As String = "/TestConfig"

            ' Get the Web application configuration object.
            Dim config As Configuration = _
            WebConfigurationManager.OpenWebConfiguration(configPath)


            ' Get the conectionStrings section.
            Dim csSection As ConnectionStringsSection = _
            config.ConnectionStrings

            Console.WriteLine("Display configuration strings.")

            Dim i As Integer = 0
            While i < ConfigurationManager.ConnectionStrings.Count
                Dim cs As ConnectionStringSettings = _
                csSection.ConnectionStrings(i)

                Console.WriteLine("  Connection String: ""{0}""", _
                                  cs.ConnectionString)

                Console.WriteLine("#{0}", i)
                Console.WriteLine("  Name: {0}", cs.Name)

                Console.WriteLine("  Provider Name: {0}", cs.ProviderName)
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While

        End Sub


        Shared Sub Main(ByVal args As String())
            Try
                ' Display connection strings.
                DisplayConnectionStrings()
            Catch e As Exception
                ' Unknown error.
                Console.WriteLine(e.ToString())
            End Try

            ' Display and wait.
            Console.WriteLine("Enter any key to exit.")
            Console.ReadLine()
        End Sub
    End Class
End Namespace

'</Snippet21>