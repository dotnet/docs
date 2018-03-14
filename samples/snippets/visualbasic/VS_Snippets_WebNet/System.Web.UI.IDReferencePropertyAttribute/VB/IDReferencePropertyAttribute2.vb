Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

' <Snippet2>
' This class implements a custom data source control.
Public Class SomeDataBoundControl
    Inherits DataBoundControl
    
    <IDReferencePropertyAttribute(GetType(DataSourceControl))>  _
    Public Shadows Property DataSourceID() As String 
        Get
            Return MyBase.DataSourceID
        End Get
        Set
            MyBase.DataSourceID = value
        End Set
    End Property
    
End Class 'SomeDataBoundControl 
' </Snippet2>