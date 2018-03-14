' <Snippet1>
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class SomeDataBoundControl
    Inherits DataBoundControl

    ' Implementation of a custom data source control.
    
    <Themeable(False)> _
    <IDReferenceProperty()>  _
    Public Overrides Property DataSourceID() As String 
        Get
            Return MyBase.DataSourceID
        End Get
        Set
            MyBase.DataSourceID = value
        End Set
    End Property
    
End Class 'SomeDataBoundControl 
' </Snippet1>