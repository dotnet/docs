' Snippet for S_UELocalServiceSecuritySettings.
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
		Private Sub ShowUse()
			'<snippet17>
			' Create an instance of the binding to use.
			Dim b As New WSHttpBinding()

			' Get the binding element collection.
			Dim bec As BindingElementCollection = b.CreateBindingElements()

			' Find the SymmetricSecurityBindingElement in the colllection.
			' Important: Cast to the SymmetricSecurityBindingElement when using the Find
			' method.
			Dim sbe As SymmetricSecurityBindingElement = CType(bec.Find(Of SecurityBindingElement)(), SymmetricSecurityBindingElement)

			' Get the LocalServiceSettings from the binding element.
			Dim lss As LocalServiceSecuritySettings = sbe.LocalServiceSettings

			' Print out values.
			Console.WriteLine("DetectReplays: {0} days", lss.DetectReplays)
			Console.WriteLine("ReplayWindow: {0} minutes", lss.ReplayWindow.Minutes)
			Console.WriteLine("MaxClockSkew: {0} minutes", lss.MaxClockSkew.Minutes)

			Console.ReadLine()
			Console.WriteLine("Press Enter to Continue")
			' Change the MaxClockSkew to 3 minutes.
			lss.MaxClockSkew = New TimeSpan(0, 0, 3, 0)

			' Print the new value.
			Console.WriteLine("New MaxClockSkew: {0} minutes", lss.MaxClockSkew.Minutes)
			Console.WriteLine("Press Enter to End")
			Console.ReadLine()

			' Create a URI for the service.
			Dim httpUri As New Uri("http://localhost/calculator")

			' Create a ServiceHost. The binding has the changed MaxClockSkew.
			Dim sh As New ServiceHost(GetType(Calculator), httpUri)
			sh.AddServiceEndpoint(GetType(ICalculator), b, "")
			' sh.Open();
			' Console.WriteLine("Listening");
			' Console.ReadLine();
			' sh.Close();
			'</snippet17>
		End Sub

		Shared Sub Main()

			' <Snippet2>
			' <Snippet0>
			' <Snippet1>
			Dim settings As New LocalServiceSecuritySettings()
			' </Snippet1>

            Dim detectReplays = settings.DetectReplays
			' </Snippet0>
			' </Snippet2>

			' <Snippet3>
			Dim inactivityTimeout As TimeSpan = settings.InactivityTimeout
			' </Snippet3>

			' <Snippet4>
			Dim issuedCookieLifetime As TimeSpan = settings.IssuedCookieLifetime
			' </Snippet4>

			' <Snippet5>
            Dim maxCachedCookies = settings.MaxCachedCookies
			' </Snippet5>

			' <Snippet6>
			Dim maxClockSkew As TimeSpan = settings.MaxClockSkew
			' </Snippet6>

			' <Snippet7>
            Dim maxPendingSessions = settings.MaxPendingSessions
			' </Snippet7>


			' <Snippet8>
            Dim maxStatefulNegotiationsNegotiations = settings.MaxStatefulNegotiations
			' </Snippet8>

			' <Snippet9>
			Dim negotiationTimeout As TimeSpan = settings.NegotiationTimeout
			' </Snippet9>

			' <Snippet10>
            Dim maxStatefulNegotiations = settings.MaxStatefulNegotiations
			' </Snippet10>

			' <Snippet11>
            Dim replayCacheSize = settings.ReplayCacheSize
			' </Snippet11>

			' <Snippet12>
			Dim replayWindow As TimeSpan = settings.ReplayWindow
			' </Snippet12>

			' <Snippet13>
			Dim sessionKeyRenewalInterval As TimeSpan = settings.SessionKeyRenewalInterval
			' </Snippet13>

			' <Snippet14>
			Dim rolloverInterval As TimeSpan = settings.SessionKeyRolloverInterval
			' </Snippet14>

			' <Snippet15>
			Dim timestampValidityDuration As TimeSpan = settings.TimestampValidityDuration
			' </Snippet15>

			' <Snippet16>
			Dim localServiceSecuritySettings As LocalServiceSecuritySettings = settings.Clone()
			' </Snippet16>

		End Sub
	End Class

End Namespace


<ServiceContract> _
Friend Interface ICalculator
	<OperationContract> _
	Function Add(ByVal a As Double, ByVal b As Double) As Double
End Interface

Public Class Calculator
	Implements ICalculator
	Public Function Add(ByVal a As Double, ByVal b As Double) As Double Implements ICalculator.Add
		Return a + b
	End Function
End Class

