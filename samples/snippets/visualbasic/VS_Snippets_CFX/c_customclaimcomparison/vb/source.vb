'<snippet0>
'<snippet1>
Imports System.IdentityModel.Claims
Imports System.Security.Permissions

'</snippet1>
'<snippet2>
NotInheritable Public Class MyResourceType
    ' private members
    Private textValue As String
    Private numberValue As Integer


    ' Constructors
    Public Sub New()

    End Sub

    Public Sub New(ByVal textVal As String, ByVal numberValue As Integer)
        Me.textValue = textVal
        Me.numberValue = numberValue

    End Sub

    ' Public properties

    Public ReadOnly Property Text() As String
        Get
            Return Me.textValue
        End Get
    End Property

    Public ReadOnly Property Number() As Integer
        Get
            Return Me.numberValue
        End Get
    End Property
    '<snippet3>
    ' Override Object.Equals to perform a specific comparison.
    Public Overrides Function Equals(ByVal obj As [Object]) As Boolean
        ' If the object being compared to is null then return false.
        If obj Is Nothing Then
            Return False
        End If
        ' If the object we are being asked to compare ourselves to is us
        ' then return true.
        If ReferenceEquals(Me, obj) Then
            Return True
        End If
        ' Try to convert the object we are being asked to compare ourselves to
        ' into an instance of MyResourceType.
        Dim rhs As MyResourceType = CType(obj, MyResourceType)

        ' If the object being compared to is not an instance of 
        ' MyResourceType then return false.
        If rhs Is Nothing Then
            Return False
        End If
        ' Return true if members are the same as those of the object
        ' being asked to compare to; otherwise, return false.
        Return Me.textValue = rhs.textValue AndAlso Me.numberValue = rhs.numberValue

    End Function

    '</snippet3>
    Public Overrides Function GetHashCode() As Integer
        Return Me.textValue.GetHashCode() ^ Me.numberValue.GetHashCode()

    End Function
End Class
'</snippet2>
Class Program

    Public Shared Sub Main()
        ' Create two claims.
        Dim c1 As New Claim("http://example.org/claims/mycustomclaim", _
           New MyResourceType("Martin", 38), Rights.PossessProperty)
        Dim c2 As New Claim("http://example.org/claims/mycustomclaim", _
           New MyResourceType("Martin", 38), Rights.PossessProperty)

        ' Compare the claims.
        If c1.Equals(c2) Then
            Console.WriteLine("Claims are equal")
        Else
            Console.WriteLine("Claims are not equal")
        End If

    End Sub
End Class
'</snippet0>

Namespace Snippets

    Public Class ClaimCompareSnippets

        Private Sub Snippet9()
            '<snippet9>
            Dim c1 As Claim = Claim.CreateNameClaim("someone")
            Dim c2 As Claim = Claim.CreateNameClaim("someone")
            '</snippet9>
        End Sub


        Private Sub Snippet4()
            '<snippet4>
            Dim c1 As Claim = Claim.CreateUpnClaim("someone@example.com")
            Dim c2 As Claim = Claim.CreateUpnClaim("example\someone")
            '</snippet4>
        End Sub


        '<snippet5>
        Public Function CompareTwoClaims(ByVal c1 As Claim, ByVal c2 As Claim) As Boolean
            Return c1.Equals(c2)
        End Function
        '</snippet5>
    End Class

    Public Class HoldsCompare

        '<snippet6>
        Public Function CompareTwoClaims(ByVal c1 As Claim, _
        ByVal c2 As Claim) As Boolean
            Return c1.Equals(c2)

        End Function
        '</snippet6>

        Private Function TestClaim1(ByVal obj As Object) As Boolean
            '<snippet7>
            If obj Is Nothing Then
                Return False
                '</snippet7>
            Else
                Return True
            End If

        End Function

        Private Function TestClaim2(ByVal obj As Object) As Boolean
            '<snippet8>
            If ReferenceEquals(Me, obj) Then
                Return True
                '</snippet8>   
            Else
                Return True
            End If

        End Function
    End Class
End Namespace
