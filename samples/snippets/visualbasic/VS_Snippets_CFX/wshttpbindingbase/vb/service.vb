Imports System
Imports System.Xml
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Text

Namespace WSHttpBindingSample
	'<snippet0>

	' Define a service contract for the calculator.
	<ServiceContract()> _
	Public Interface ICalculator
		<OperationContract(IsOneWay := False)> _
		Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract(IsOneWay := False)> _
		Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract(IsOneWay := False)> _
		Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract(IsOneWay := False)> _
		Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
	End Interface

	' Service class which implements the service contract.
	Public Class CalculatorService
		Implements ICalculator
		Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Dim result = n1 + n2
			Return result
		End Function

		Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Dim result = n1 - n2
			Return result
		End Function

		Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Dim result = n1 * n2
			Return result
		End Function

		Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
            Dim result = n1 / n2
			Return result
		End Function

		' Create and configure bindings within this EXE console application.
		Public Shared Sub Main()
            ' Create a WSHttpBinding
		' <Snippet3>
		' <Snippet1>
			Dim binding1 As New WSHttpBinding()
		' </Snippet1>

		binding1.BypassProxyOnLocal = True
		' </Snippet3>

		' <Snippet4>
		Dim envelopeVersion As EnvelopeVersion = binding1.EnvelopeVersion
		' </Snippet4>

		' <Snippet5>
		Dim hostnameComparisonMode As HostNameComparisonMode = binding1.HostNameComparisonMode
		' </Snippet5>

		' <Snippet6>
            Dim maxBufferPoolSize = binding1.MaxBufferPoolSize
		' </Snippet6>


		' <Snippet7>
            Dim maxReceivedMessageSize = binding1.MaxReceivedMessageSize
		' </Snippet7>

		' <Snippet8>
		Dim messageEncoding As WSMessageEncoding = binding1.MessageEncoding
		' </Snippet8>

		' <Snippet9>
		Dim proxyAddress As Uri = binding1.ProxyAddress
		' </Snippet9>

		' <Snippet10>
		Dim readerQuotas As XmlDictionaryReaderQuotas = binding1.ReaderQuotas
		' </Snippet10>

		' <Snippet11>
		Dim reliableSession As OptionalReliableSession = binding1.ReliableSession
		' </Snippet11>

		' <Snippet12>
            Dim scheme = binding1.Scheme
		' </Snippet12>

		' <Snippet13>
            Dim textEncoding = binding1.TextEncoding
		' </Snippet13>

		' <Snippet14>
            Dim transactionFlow = binding1.TransactionFlow
		' </Snippet14>

		' <Snippet15>
            Dim useDefaultWebProxy = binding1.UseDefaultWebProxy
		' </Snippet15>

		' <Snippet16>
		Dim bindingElements As BindingElementCollection = binding1.CreateBindingElements()
		' </Snippet16>

			' Set WSHttpBinding binding property values
			binding1.Name = "Binding1"
			binding1.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
			binding1.Security.Mode = SecurityMode.Message
			binding1.ReliableSession.Enabled = False
			binding1.TransactionFlow = False
		   ' binding1.Security.Message.DefaultProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

			' Enumerate properties of the binding1.
			Console.WriteLine("WSHttpBinding binding1 properties:")
			Console.WriteLine("      - name:" & Constants.vbTab + Constants.vbTab + Constants.vbTab & "{0}", binding1.Name)
			Console.WriteLine("      - hostname comparison:" & Constants.vbTab & "{0}", binding1.HostNameComparisonMode)
			Console.WriteLine("      - security mode:" & Constants.vbTab + Constants.vbTab & "{0}", binding1.Security.Mode)
			Console.WriteLine("      - RM enabled:" & Constants.vbTab + Constants.vbTab & "{0}", binding1.ReliableSession.Enabled)
			Console.WriteLine("      - transaction flow:" & Constants.vbTab & "{0}", binding1.TransactionFlow)
			'Console.WriteLine("      - message security:\t{0}", binding1.Security.Message.DefaultProtectionLevel);
			Console.WriteLine("      - transport scheme:" & Constants.vbTab & "{0}", binding1.Scheme)
			Console.WriteLine("      - max message size:" & Constants.vbTab & "{0}", binding1.MaxReceivedMessageSize)
			Console.WriteLine("      - default text encoding:" & Constants.vbTab & "{0}", binding1.TextEncoding)
			Console.WriteLine()

			' Create a WSFederationBinding with a message security mode
			' and with a reliable session enabled.
			Dim binding3 As New WSFederationHttpBinding(WSFederationHttpSecurityMode.Message, True)

			' Enumerate properties of the binding2.
			Console.WriteLine("WSFederationBinding binding3 properties:")
			Console.WriteLine("      - security mode:" & Constants.vbTab + Constants.vbTab & "{0}", binding3.Security.Mode)
			Console.WriteLine("      - RM enabled:" & Constants.vbTab + Constants.vbTab & "{0}", binding3.ReliableSession.Enabled)
			Console.WriteLine()
			Console.WriteLine("Press <ENTER> to terminate.")
			Console.ReadLine()

		End Sub

	' <Snippet19>
	Private Shared Sub SnippetReceiveSynchronously()
		Dim binding As New WSHttpBinding()
		Dim s As IBindingRuntimePreferences = binding.GetProperty(Of IBindingRuntimePreferences) (New BindingParameterCollection())
            Dim receiveSynchronously = s.ReceiveSynchronously

	End Sub
	   ' </Snippet19>

	End Class
	'</snippet0>
End Namespace


