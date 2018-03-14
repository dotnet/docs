'<Snippet1>
Imports System
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Permissions
Imports System.Security.Cryptography.X509Certificates
Class Program

    Public Shared Sub Main(ByVal args() As String)
        Try
            If Test Then
                Console.WriteLine("PASSED.")
                Environment.ExitCode = 100
            Else
                Console.WriteLine("FAILED.")
                Environment.ExitCode = 101
            End If
        Catch e As Exception
            Console.Write("Exception occured: {0}", e.ToString)
            Environment.ExitCode = 101
        End Try
        Return
    End Sub

    Public Shared Function Test() As Boolean
        Dim bRes As Boolean = True
        Dim evidence1 As Evidence = GetTestEvidence
        Dim evidence2 As Evidence = GetTestEvidence
        Dim isf As IsolatedStorageFile = IsolatedStorageFile.GetStore((IsolatedStorageScope.User _
         Or IsolatedStorageScope.Assembly), _
         evidence1, _
         GetType(System.Security.Policy.Publisher), _
         evidence2, _
         GetType(System.Security.Policy.Publisher))
        Dim isfs As IsolatedStorageFileStream = New IsolatedStorageFileStream("AdminEvd1.testfile", _
         FileMode.OpenOrCreate, isf)
        isfs.WriteByte(5)
        isfs.Flush()
        isfs.Close()
        Return bRes
    End Function

    Public Shared Function GetTestEvidence() As Evidence

        ' For demonsration purposes, use a blank certificate.
        Dim CertTemp(63) As Byte
        Dim pub As Publisher = New Publisher(New X509Certificate(CertTemp))
        Dim arrObj(0) As Object
        arrObj(0) = CType(pub, Object)
        Return New Evidence(arrObj, arrObj)
    End Function
End Class
'</Snippet1>