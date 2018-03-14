
Imports System
Imports System.Data
Imports System.ServiceModel
Imports System.ServiceModel.Dispatcher
Imports System.ServiceModel.Channels
Imports System.Collections.ObjectModel
Imports System.Collections.Generic

Namespace Service
	Friend Class Snippets
		Private Sub Snippet1()
			' <Snippet1>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			' </Snippet1>
		End Sub

		Private Sub Snippet2()
			' <Snippet2>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl, "MyTestBinding")
			' </Snippet2>
		End Sub

		Private Sub Snippet3()
			' <Snippet3>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
			Dim binding As New WSHttpBinding()

			serviceHost.AddServiceEndpoint(GetType(ICalculator), binding, "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl, "MyTestBinding", binding)
			' </Snippet3>
		End Sub

		Private Sub Snippet4()
			' <Snippet4>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim dispatcher As ChannelDispatcher = CType(serviceHost.ChannelDispatchers(0), ChannelDispatcher)
			Dim bindingName As String = dispatcher.BindingName
			' </Snippet4>
		End Sub

		Private Sub Snippet5()
			' <Snippet5>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim dispatcher As ChannelDispatcher = CType(serviceHost.ChannelDispatchers(0), ChannelDispatcher)
			Dim col As SynchronizedCollection(Of IChannelInitializer) = dispatcher.ChannelInitializers
			' </Snippet5>
		End Sub

		Private Sub Snippet6()
			' <Snippet6>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim dispatcher As ChannelDispatcher = CType(serviceHost.ChannelDispatchers(0), ChannelDispatcher)
			Dim col As SynchronizedCollection(Of EndpointDispatcher) = dispatcher.Endpoints
			' </Snippet6>
		End Sub

		Private Sub Snippet7()
			' <Snippet7>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim dispatcher As ChannelDispatcher = CType(serviceHost.ChannelDispatchers(0), ChannelDispatcher)
			Dim col As Collection(Of IErrorHandler) = dispatcher.ErrorHandlers
			' </Snippet7>
		End Sub

		Private Sub Snippet8()
			' <Snippet8>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim dispatcher As ChannelDispatcher = CType(serviceHost.ChannelDispatchers(0), ChannelDispatcher)
			Dim hostBase As ServiceHostBase = dispatcher.Host
			' </Snippet8>
		End Sub

		Private Sub Snippet9()
			' <Snippet9>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim dispatcher As ChannelDispatcher = CType(serviceHost.ChannelDispatchers(0), ChannelDispatcher)
			Dim isTransactedAccept As Boolean = dispatcher.IsTransactedAccept
			' </Snippet9>
		End Sub

		Private Sub Snippet10()
			' <Snippet10>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			Dim isTransactedReceive As Boolean = dispatcher.IsTransactedReceive
			' </Snippet10>
		End Sub

		Private Sub Snippet11()
			' <Snippet11>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim dispatcher As ChannelDispatcher = CType(serviceHost.ChannelDispatchers(0), ChannelDispatcher)
			Dim listener As IChannelListener = dispatcher.Listener
			' </Snippet11>
		End Sub

		Private Sub Snippet12()
			' <Snippet12>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)

			Dim isManualAddressing As Boolean = dispatcher.ManualAddressing
			' </Snippet12>
		End Sub

		Private Sub Snippet13()
			' <Snippet13>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)

			dispatcher.MaxTransactedBatchSize = 10
			' </Snippet13>
		End Sub

		Private Sub Snippet14()
			' <Snippet14>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			Dim receiveSynchronously As Boolean = dispatcher.ReceiveSynchronously
			' </Snippet14>
		End Sub

		Private Sub Snippet15()
			' <Snippet15>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			Dim throttle As ServiceThrottle = dispatcher.ServiceThrottle
			' </Snippet15>
		End Sub

		Private Sub Snippet16()
			' <Snippet16>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			dispatcher.TransactionIsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
			' </Snippet16>
		End Sub

		Private Sub Snippet17()
			' <Snippet17>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			dispatcher.TransactionTimeout = New TimeSpan(100)
			' </Snippet17>
		End Sub

		Private Sub Snippet18()
			' <Snippet18>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			dispatcher.CloseInput()
			' </Snippet18>
		End Sub

		Private Sub Snippet19()
			' <Snippet19>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			dispatcher.IncludeExceptionDetailInFaults = True
			' </Snippet19>
		End Sub

		Private Sub Snippet20()
			' <Snippet20>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			dispatcher.MessageVersion = MessageVersion.Default
			' </Snippet20>
		End Sub
	End Class
End Namespace
