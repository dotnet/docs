' <snippet1>
Imports System

Imports System.IdentityModel.Selectors
Imports System.IdentityModel.Tokens

Imports System.Security.Principal

Imports System.ServiceModel
' </snippet1>

' Define a service contract.
<ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
Public Interface ICalculator
    <OperationContract()> _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
    <OperationContract()> _
    Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface 'ICalculator

' Service class which implements the service contract.
' Added code to write output to the console window
<ServiceBehavior(IncludeExceptionDetailInFaults:=True)> _
Public Class CalculatorService

    Implements ICalculator

    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double _
      Implements ICalculator.Add
        Dim result As Double = n1 + n2
        Console.WriteLine("Received Add({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function 'Add



    Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double _
      Implements ICalculator.Subtract
        Dim result As Double = n1 - n2
        Console.WriteLine("Received Subtract({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function 'Subtract



    Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double _
      Implements ICalculator.Multiply
        Dim result As Double = n1 * n2
        Console.WriteLine("Received Multiply({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function 'Multiply



    Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double _
     Implements ICalculator.Divide
        Dim result As Double = n1 / n2
        Console.WriteLine("Received Divide({0},{1})", n1, n2)
        Console.WriteLine("Return: {0}", result)
        Return result

    End Function 'Divide

    ' <snippet2>
    ' <snippet3>
    Public Class CustomUserNameValidator
        Inherits UserNamePasswordValidator
        ' </snippet3>
        ' <snippet4>
        ' This method validates users. It allows in two users, test1 and test2 
        ' with passwords 1tset and 2tset respectively.
        ' This code is for illustration purposes only and 
        ' must not be used in a production environment because it is not secure.	
        Public Overrides Sub Validate(ByVal userName As String, ByVal password As String)
            If Nothing = userName OrElse Nothing = password Then
                Throw New ArgumentNullException()
            End If

            If Not (userName = "test1" AndAlso password = "1tset") AndAlso Not (userName = "test2" AndAlso password = "2tset") Then
                ' This throws an informative fault to the client.
                Throw New FaultException("Unknown Username or Incorrect Password")
                ' When you do not want to throw an infomative fault to the client,
                ' throw the following exception.
                ' Throw New SecurityTokenException("Unknown Username or Incorrect Password")
            End If

        End Sub
        ' </snippet4>
    End Class
    ' </snippet2>


    ' Host the service within this EXE console application.
    Public Shared Sub Main()
        ' Create a ServiceHost for the CalculatorService type and provide the base address.
        Dim serviceHost As New ServiceHost(GetType(CalculatorService))

        ' Open the ServiceHostBase to create listeners and start listening for messages.
        serviceHost.Open()

        ' The service can now be accessed.
        Console.WriteLine("The service is ready.")
        Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name)
        Console.WriteLine("Press <ENTER> to terminate service.")
        Console.WriteLine()
        Console.ReadLine()

    End Sub 'Main
End Class 'CalculatorService