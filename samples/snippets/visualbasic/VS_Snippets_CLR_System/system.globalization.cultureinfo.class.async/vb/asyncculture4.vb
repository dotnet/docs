' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization
Imports System.Runtime.Versioning
Imports System.Threading
Imports System.Threading.Tasks

<Assembly:TargetFramework(".NETFramework,Version=v4.6")>

Module Example
   Public Sub Main()
       Dim formatString As String = "C2"
       Console.WriteLine("The example is running on thread {0}", 
                         Thread.CurrentThread.ManagedThreadId)
       ' Make the current culture different from the system culture.
       Console.WriteLine("The current culture is {0}", 
                         CultureInfo.CurrentCulture.Name)
       If CultureInfo.CurrentCulture.Name = "fr-FR" Then
          Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US")
       Else
          Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR")
       End If

       Console.WriteLine("Changed the current culture to {0}.",
                         CultureInfo.CurrentCulture.Name)
       Console.WriteLine()
       
       ' Call an async delegate to format the values using one format string.
       Console.WriteLine("Executing a task asynchronously in the main appdomain:") 
       Dim t1 = Task.Run(Function()
                            Dim d As New DataRetriever()
                            Return d.GetFormattedNumber(formatString)
                         End Function)
       Console.WriteLine(t1.Result)
       Console.WriteLine() 
       
       Console.WriteLine("Executing a task synchronously in two appdomains:")
       Dim t2 = Task.Run(Function()
                            Console.WriteLine("Thread {0} is running in app domain '{1}'", 
                                              Thread.CurrentThread.ManagedThreadId, 
                                              AppDomain.CurrentDomain.FriendlyName)
                            Dim domain As AppDomain = AppDomain.CreateDomain("Domain2")
                            Dim d As DataRetriever = CType(domain.CreateInstanceAndUnwrap(GetType(Example).Assembly.FullName,
                                                                                          "DataRetriever"), DataRetriever)
                            Return d.GetFormattedNumber(formatString) 
                         End Function) 
       Console.WriteLine(t2.Result)
   End Sub
End Module

Public Class DataRetriever : Inherits MarshalByRefObject
   Public Function GetFormattedNumber(format As String) As String
      Dim thread As Thread = Thread.CurrentThread
      Console.WriteLine("Current culture is {0}", thread.CurrentCulture)
      Console.WriteLine("Thread {0} is running in app domain '{1}'", 
                        thread.ManagedThreadId, 
                        AppDomain.CurrentDomain.FriendlyName)
      Dim rnd As New Random()
      Dim value As Double = rnd.NextDouble() * 1000
      Return value.ToString(format)
   End Function
End Class
' The example displays output like the following:
'     The example is running on thread 1
'     The current culture is en-US
'     Changed the current culture to fr-FR.
'     
'     Executing a task asynchronously in a single appdomain:
'     Current culture is fr-FR
'     Thread 3 is running in app domain 'AsyncCulture4.exe'
'     93,48 €
'     
'     Executing a task synchronously in two appdomains:
'     Thread 4 is running in app domain 'AsyncCulture4.exe'
'     Current culture is fr-FR
'     Thread 4 is running in app domain 'Domain2'
'     288,66 €
' </Snippet4>

