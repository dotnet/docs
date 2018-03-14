' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Diagnostics


Public Class UsingConsoleConfigElement

	Private Shared Sub GetConfigurationFile()

		Try
			' Get the current application configuration file.
            Dim config As Configuration = _
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

			Console.WriteLine(config.FilePath)

		Catch e As ConfigurationErrorsException
			Console.WriteLine("[Exception error: {0}]", e.ToString())
		End Try


	End Sub

	' Get the roaming configuration file associated 
	' with the current user.
	Private Shared Sub GetRoamingConfigurationFile()


	  Try
		  ' Get the roaming configuration 
		  ' that applies to the current user.
            Dim roamingConfig As Configuration = _
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming)

		  Console.WriteLine(roamingConfig.FilePath)

	  Catch e As ConfigurationErrorsException
		  Console.WriteLine("[Exception error: {0}]", e.ToString())
	  End Try


	End Sub

	
	Shared Sub Main(ByVal args() As String)
		Console.Write("Roaming configuration file: ")
			GetRoamingConfigurationFile()
			Console.WriteLine()
		Console.Write("Configuration file: ")
			GetConfigurationFile()
		Console.WriteLine("Enter any key to exit")
		Console.ReadLine()
	End Sub
End Class
' </Snippet1>
