' Snippet for S_UELocalClientSecuritySettings


Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Globalization
Imports System.Net
Imports System.Net.Security
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Security
Imports System.Text
Imports System.Xml

Namespace Snippets
	Friend Class Snippet
		Private Sub LocalClient()
			'<snippet15>
			' Create an instance of the binding to use.
			Dim b As New WSHttpBinding()

			' Get the binding element collection.
			Dim bec As BindingElementCollection = b.CreateBindingElements()

			' Find the SymmetricSecurityBindingElement in the collection.
			' Important: Cast to the SymmetricSecurityBindingElement when using the Find
			' method.
			Dim sbe As SymmetricSecurityBindingElement = CType(bec.Find(Of SecurityBindingElement)(), SymmetricSecurityBindingElement)

			' Get the LocalSecuritySettings from the binding element.
			Dim lc As LocalClientSecuritySettings = sbe.LocalClientSettings

			' Print out values.
			Console.WriteLine("Maximum cookie caching time: {0} days", lc.MaxCookieCachingTime.Days)
			Console.WriteLine("Replay Cache Size: {0}", lc.ReplayCacheSize)
			Console.WriteLine("ReplayWindow: {0} minutes", lc.ReplayWindow.Minutes)
			Console.WriteLine("MaxClockSkew: {0} minutes", lc.MaxClockSkew.Minutes)
			Console.ReadLine()

			' Change the MaxClockSkew to 3 minutes.
			lc.MaxClockSkew = New TimeSpan(0, 0, 3, 0)

			' Print the new value.
			Console.WriteLine("New MaxClockSkew: {0} minutes", lc.MaxClockSkew.Minutes)
			Console.ReadLine()

			' Create an EndpointAddress for the service.
			Dim ea As New EndpointAddress("http://localhost/calculator")

			' Create a client. The binding has the changed MaxClockSkew.
			' CalculatorClient cc = new CalculatorClient(b, ea);
			' Use the new client. (Not shown.)
			' cc.Close();
			'</snippet15>
		End Sub


		Shared Sub Main()

			' <Snippet2>
			' <Snippet0>
			' <Snippet1>
			Dim settings As New LocalClientSecuritySettings()
			' </Snippet1>

			Dim cacheCookies As Boolean = settings.CacheCookies
			' </Snippet0>
			' </Snippet2>

			' <Snippet3>
			' Set to 20 minutes.
			settings.CookieRenewalThresholdPercentage = 20
			' </Snippet3>

			' <Snippet4>
			' Enable replay detection.
			settings.DetectReplays = True
			' </Snippet4>

			' <Snippet5>
			Dim id As IdentityVerifier = settings.IdentityVerifier
			' </Snippet5>

			' <Snippet6>
			Dim timeSpan As TimeSpan = settings.MaxClockSkew
			' </Snippet6>

			' <Snippet7>
			Dim maxCookieCachingTime As TimeSpan = settings.MaxCookieCachingTime
			' </Snippet7>

			' <Snippet8>
			Dim reconnect As Boolean = settings.ReconnectTransportOnFailure
			' </Snippet8>

			' <Snippet9>
			Dim replayCacheSize As Integer = settings.ReplayCacheSize
			' </Snippet9>

			' <Snippet10>
			Dim replayWindow As TimeSpan = settings.ReplayWindow
			' </Snippet10>

			' <Snippet11>
			Dim sessionKeyRenewalInterval As TimeSpan = settings.SessionKeyRenewalInterval
			' </Snippet11>

			' <Snippet12>
			Dim rollover As TimeSpan = settings.SessionKeyRolloverInterval
			' </Snippet12>

			' <Snippet13>
			Dim timestamp As TimeSpan = settings.TimestampValidityDuration
			' </Snippet13>

			' <Snippet14>
			Dim clone As LocalClientSecuritySettings = settings.Clone()
			' </Snippet14>




		End Sub
	End Class

End Namespace
