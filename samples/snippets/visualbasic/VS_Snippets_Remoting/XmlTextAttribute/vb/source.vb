
Option Strict Off
Option Explicit On
Imports System.Xml.Serialization
Imports System.Security.Permissions
<Assembly: IsolatedStorageFilePermission(SecurityAction.RequestMinimum)> 

'<snippet0>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)> _
Partial Public Class LinkList
    Private idField As Integer
    Private nameField As String
    Private nextField As LinkList
    Private textField() As String
    Public Property id() As Integer
        Get
            Return Me.idField
        End Get
        Set(ByVal value As Integer)
            Me.idField = value
        End Set
    End Property
    Public Property name() As String
        Get
            Return Me.nameField
        End Get
        Set(ByVal value As String)
            Me.nameField = value
        End Set
    End Property
    Public Property [next]() As LinkList
        Get
            Return Me.nextField
        End Get
        Set(ByVal value As LinkList)
            Me.nextField = value
        End Set
    End Property
    <System.Xml.Serialization.XmlTextAttribute()> _
    Public Property Text() As String()
        Get
            Return Me.textField
        End Get
        Set(ByVal value As String())
            Me.textField = value
        End Set
    End Property
End Class
'</snippet0>