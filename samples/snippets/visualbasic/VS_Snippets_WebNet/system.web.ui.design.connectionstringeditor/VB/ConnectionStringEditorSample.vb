' <Snippet1>

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls

Namespace ASP.NET.Samples.VB

    ' <Snippet2>
    ' Define a custom class derived from the SqlDataSource Web control. 
    Public Class SqlDataSourceWithBackup
        Inherits SqlDataSource

        Private _alternateConnectionString As String

        ' Define an alternate connection string, which could be used
        ' as a fallback value if the primary connection string fails.

        ' The EditorAttribute indicates the property can
        ' be edited at design-time with the ConnectionStringEditor class.
        <DefaultValue(""), _
         EditorAttribute(GetType(System.Web.UI.Design.ConnectionStringEditor), _
             GetType(System.Drawing.Design.UITypeEditor)), _
         Category("Data"), _
         Description("The alternate connection string.")> _
       Public Property AlternateConnectionString() As String

            Get
                Return _alternateConnectionString
            End Get
            Set(ByVal value As String)
                _alternateConnectionString = value
            End Set
        End Property

    End Class
    ' </Snippet2>


End Namespace
' </Snippet1>
