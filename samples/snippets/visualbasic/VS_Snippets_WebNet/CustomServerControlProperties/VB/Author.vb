' <Snippet2>
' Author.vb
Option Strict On
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Globalization
Imports System.Web.UI

Namespace Samples.AspNet.VB.Controls
    < _
    TypeConverter(GetType(AuthorConverter)) _
    > _
    Public Class Author
        Dim firstNameValue As String
        Dim lastNameValue As String
        Dim middleNameValue As String

        Public Sub New()
            Me.New(String.Empty, String.Empty, String.Empty)
        End Sub

        Public Sub New(ByVal firstname As String, _
            ByVal lastname As String)
            Me.New(firstname, String.Empty, lastname)
        End Sub

        Public Sub New(ByVal firstname As String, _
            ByVal middlename As String, ByVal lastname As String)
            firstNameValue = firstname
            middleNameValue = middlename
            lastNameValue = lastname
        End Sub

        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("First name of author."), _
        NotifyParentProperty(True) _
        > _
        Public Overridable Property FirstName() As String
            Get
                Return firstNameValue
            End Get
            Set(ByVal value As String)
                firstNameValue = value
            End Set
        End Property


        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("Last name of author."), _
        NotifyParentProperty(True) _
        > _
        Public Overridable Property LastName() As String
            Get
                Return lastNameValue
            End Get
            Set(ByVal value As String)
                lastNameValue = value
            End Set
        End Property

        < _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("Middle name of author."), _
            NotifyParentProperty(True) _
        > _
        Public Overridable Property MiddleName() As String
            Get
                Return middleNameValue
            End Get
            Set(ByVal value As String)
                middleNameValue = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return ToString(CultureInfo.InvariantCulture)
        End Function

        Public Overloads Function ToString( _
            ByVal culture As CultureInfo) As String
            Return TypeDescriptor.GetConverter( _
                Me.GetType()).ConvertToString(Nothing, culture, Me)
        End Function
    End Class
End Namespace
' </Snippet2>
