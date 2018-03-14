Imports System
Imports System.Collections.Generic
Imports System.Text


Namespace Microsoft.Samples.ClickOnceOnDemand
   Public Class DynamicClass
      
      Public Sub New()
      End Sub 
      
      Public ReadOnly Property Message() As String
         Get
            Return "Hello, world!"
         End Get
      End Property
   End Class 
End Namespace 