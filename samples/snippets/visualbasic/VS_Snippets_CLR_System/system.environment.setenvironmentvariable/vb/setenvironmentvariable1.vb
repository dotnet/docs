' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim envName As String = "AppDomain"
      Dim envValue As String = "True"
      
      ' Determine whether the environment variable exists.
      If Environment.GetEnvironmentVariable(envName) Is Nothing Then
         ' If it doesn't exist, create it.
         Environment.SetEnvironmentVariable(envName, envValue)
      End If
      
      Dim createAppDomain As Boolean
      Dim msg As Message
      If Boolean.TryParse(Environment.GetEnvironmentVariable(envName),
                          createAppDomain) AndAlso createAppDomain Then
         Dim domain As AppDomain = AppDomain.CreateDomain("Domain2")
         msg = CType(domain.CreateInstanceAndUnwrap(GetType(Example).Assembly.FullName, 
                                                    "Message"), Message)
         msg.Display()                                                                            
      Else
         msg = New Message()
         msg.Display()   
      End If     
   End Sub
End Module

Public Class Message : Inherits MarshalByRefObject
   Public Sub Display()
      Console.WriteLine("Executing in domain {0}", 
                        AppDomain.CurrentDomain.FriendlyName)
   End Sub
End Class
' </Snippet1>

