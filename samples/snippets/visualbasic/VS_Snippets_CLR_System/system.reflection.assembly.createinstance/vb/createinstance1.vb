' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection
Imports Contoso.Libraries

Namespace Contoso.Libraries
   Public Class Person
      Private _name As String 
   
      Public Sub New()
      End Sub 
   
      Public Sub New(name As String)
         Me._name = name
      End Sub 
   
      Public Property Name As String 
         Get 
            Return Me._name
         End Get 
         Set 
            Me._name = value
         End Set 
      End Property 
   
      Public Overrides Function ToString() As String 
         Return Me._name
      End Function 
   End Class
End Namespace 

Module Example
   Public Sub Main()
      Dim assem As Assembly = GetType(Person).Assembly
      Dim p As Person = CType(assem.CreateInstance("Contoso.Libraries.Person"),
                              Person)
      If p IsNot Nothing Then
         p.Name = "John"
         Console.WriteLine("Instantiated a {0} object whose value is '{1}'",
                           p.GetType().Name, p)
      Else
         Console.WriteLine("Unable to instantiate a Person object.")
      End If   
   End Sub
End Module
' The example displays the following output:
'       Instantiated a Person object whose value is 'John'
' </Snippet1>
