' Contact.vb
' The type of the items in the Contacts collection property 
' in QuickContacts.
Option Strict On
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web.UI

Namespace Samples.AspNet.VB.Controls
    < _
    TypeConverter(GetType(ExpandableObjectConverter)) _
    > _
    Public Class Contact
        Private _name As String
        Private _email As String
        Private _phone As String

        Public Sub New()
            Me.New(String.Empty, String.Empty, String.Empty)
        End Sub

        Public Sub New(ByVal name As String, _
        ByVal email As String, ByVal phone As String)
            _name = name
            _email = email
            _phone = phone
        End Sub

        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("Name of contact"), _
        NotifyParentProperty(True) _
        > _
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("Email address of contact"), _
        NotifyParentProperty(True) _
        > _
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                _email = value
            End Set
        End Property


        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("Phone number of contact"), _
        NotifyParentProperty(True) _
        > _
        Public Property Phone() As String
            Get
                Return _phone
            End Get
            Set(ByVal value As String)
                _phone = value
            End Set
        End Property
    End Class
End Namespace
