
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
			Dim binding1 As New WSHttpBinding()

		binding1.BypassProxyOnLocal = True

		Dim envelopeVersion As EnvelopeVersion = binding1.EnvelopeVersion

		Dim hostnameComparisonMode As HostNameComparisonMode = binding1.HostNameComparisonMode

            Dim maxBufferPoolSize = binding1.MaxBufferPoolSize


            Dim maxReceivedMessageSize = binding1.MaxReceivedMessageSize

		Dim messageEncoding As WSMessageEncoding = binding1.MessageEncoding

		Dim proxyAddress As Uri = binding1.ProxyAddress

		Dim readerQuotas As XmlDictionaryReaderQuotas = binding1.ReaderQuotas

		Dim reliableSession As OptionalReliableSession = binding1.ReliableSession

            Dim scheme = binding1.Scheme

            Dim textEncoding = binding1.TextEncoding

            Dim transactionFlow = binding1.TransactionFlow

            Dim useDefaultWebProxy = binding1.UseDefaultWebProxy

		Dim bindingElements As BindingElementCollection = binding1.CreateBindingElements()

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

	Private Shared Sub SnippetReceiveSynchronously()
		Dim binding As New WSHttpBinding()
		Dim s As IBindingRuntimePreferences = binding.GetProperty(Of IBindingRuntimePreferences) (New BindingParameterCollection())
            Dim receiveSynchronously = s.ReceiveSynchronously

	End Sub

	End Class