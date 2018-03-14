' Visual Basic .NET Document
Option Strict On

Imports System.Runtime.InteropServices

Public Class Example
   Public Shared Sub Main()

   End Sub
   
   ' <Snippet2>
   Public Sub SomeMethod(<MarshalAs(UnmanagedType.LPStr)> s As String)
   ' </Snippet2>
   End Sub

   ' <Snippet3>
   Dim _money As Decimal   
   
   Public Property Money As <MarshalAs(UnmanagedType.Currency)> Decimal 
      Get
         Return Me._money
      End Get
      Set(<MarshalAs(UnmanagedType.Currency)> value As Decimal)
         Me._money = value
      End Set   
   End Property
   ' </Snippet3>
 
End Class

