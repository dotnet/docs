'<snippet0>
'<snippet1>
Imports System.IdentityModel.Claims
Imports System.Runtime.Serialization
Imports System.Security.Permissions

'</snippet1>


'<snippet2>
<DataContract(Name:="MyResource", [Namespace]:="http://example.org/resources")> _
NotInheritable Public Class MyResourceType
    ' private members
    Private text_value As String
    Private number_value As Integer


    ' Constructors
    Public Sub New()

    End Sub


    Public Sub New(ByVal text As String, ByVal number As Integer)
        Me.text_value = text
        Me.number = number

    End Sub

    ' Public properties

    <DataMember()> _
    Public Property Text() As String
        Get
            Return Me.text_value
        End Get
        Set
            Me.text_value = value
        End Set
    End Property

    <DataMember()> _
    Public Property Number() As Integer
        Get
            Return Me.number_value
        End Get
        Set
            Me.number_value = value
        End Set
    End Property
End Class
'</snippet2>

Class Program

    Public Shared Sub Main()
        '<snippet3>
        '<snippet4>
        ' Create claim with custom claim type and primitive resource
        Dim c1 As New Claim("http://example.org/claims/simplecustomclaim", "Driver's License", Rights.PossessProperty)
        '</snippet4>
        '<snippet5>
        ' Create claim with custom claim type and structured resource type
        Dim c2 As New Claim("http://example.org/claims/complexcustomclaim", New MyResourceType("Martin", 38), Rights.PossessProperty)
        '</snippet5>
        '</snippet3>
    End Sub
End Class
' Do something with claims
'</snippet0>
