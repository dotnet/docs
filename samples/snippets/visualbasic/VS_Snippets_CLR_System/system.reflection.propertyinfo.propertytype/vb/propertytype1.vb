' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Public Class Employee
   Private _id As String

   Public Property FirstName As String = String.Empty
   Public Property MiddleName As String = String.Empty
   Public Property LastName As String = String.Empty
   Public Property HireDate As Date = Date.Today

   Public Property ID As String
      Get
         Return _id
      End Get
      Set
         If ID.Trim().Length <> 9 Then _
            Throw New ArgumentException("The ID is invalid")
         _id = value
      End Set
   End Property
End Class

Module Example
   Public Sub Main()
      Dim t As Type = GetType(Employee)
      Console.WriteLine("The {0} type has the following properties: ",
                        t.Name)
      For Each prop In t.GetProperties()
         Console.WriteLine("   {0} ({1})", prop.Name,
                           prop.PropertyType.Name)
      Next
   End Sub
End Module
' The example displays the following output:
'    The Employee type has the following properties:
'       FirstName (String)
'       MiddleName (String)
'       LastName (String)
'       HireDate (DateTime)
'       ID (String)
' </Snippet1>
