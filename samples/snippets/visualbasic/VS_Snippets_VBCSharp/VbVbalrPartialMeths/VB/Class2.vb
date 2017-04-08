' ********************************************************

Option Infer On
Imports System.Collections.Generic

'<Snippet1>
Module Module1

    Sub Main()
        ' Creation of cust will invoke the partial method.
        Dim cust As New Customer With {.Name = "Blue Yonder Airlines"}
    End Sub
End Module
'</Snippet1>


' ****************************************************


'<Snippet2>
' File Customer.Designer.vb provides a partial class definition for
' Customer, which includes the signature for partial method 
' OnNameChanged.
Partial Class Customer
    Private _Name As String
    Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
            OnNameChanged()
        End Set
    End Property

    ' Definition of the partial method signature.
    Partial Private Sub OnNameChanged()

    End Sub
End Class
'</Snippet2>

' *******************************************************

'<Snippet3>
' In a separate file, a developer who wants to use the partial class
' and partial method fills in an implementation for OnNameChanged.
Partial Class Customer

    ' Implementation of the partial method.
    Private Sub OnNameChanged()
        MsgBox("Name was changed to " & Me.Name)
    End Sub
End Class
'</Snippet3>

