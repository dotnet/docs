'<Snippet1>
Imports System
Imports System.Web
Imports System.Web.Util

Public Class CustomRequestValidation
    Inherits RequestValidator

    Public Sub New()
    End Sub

    Protected Overloads Overrides Function IsValidRequestString(ByVal context As HttpContext, ByVal value As String, _
            ByVal requestValidationSource__1 As RequestValidationSource, _
            ByVal collectionKey As String, _
            ByRef validationFailureIndex As Integer) As Boolean
        validationFailureIndex = -1 ' Set a default value for the out parameter.

        ' This application does not use RawUrl directly so you can ignore the check.
        If requestValidationSource__1 = RequestValidationSource.RawUrl Then
            Return True
        End If

        ' Allow the query-string key data to have a value that is formated like XML.
        If (requestValidationSource__1 = RequestValidationSource.QueryString) AndAlso (collectionKey = "data") Then

            ' The query-string value "<example>1234</example>" is allowed.
            If value = "<example>1234</example>" Then
                validationFailureIndex = -1
                Return True
            Else
                ' Leave any further checks to ASP.NET.
                Return MyBase.IsValidRequestString(context, value,
                     requestValidationSource__1, collectionKey,
                     validationFailureIndex)
            End If
        Else
            ' All other HTTP input checks are left to the base ASP.NET implementation.
            Return MyBase.IsValidRequestString(context, value, requestValidationSource__1, collectionKey, validationFailureIndex)
        End If
    End Function
End Class




'</Snippet1>

