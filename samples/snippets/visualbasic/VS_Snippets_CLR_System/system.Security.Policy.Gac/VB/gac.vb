'<Snippet1>
Imports System
Imports System.Security.Policy
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.VisualBasic

Class GacDemo
    <STAThread()> _
    Overloads Shared Sub Main(ByVal args() As String)
        '<Snippet2>
        Dim myGacInstalled As New GacInstalled
        '</Snippet2>

        '<Snippet3>
        Dim hostEvidence() As Object = {myGacInstalled}
        Dim assemblyEvidence() As Object
        Dim myEvidence As New Evidence(hostEvidence, assemblyEvidence)
        Dim myPerm As GacIdentityPermission = _
            CType(myGacInstalled.CreateIdentityPermission(myEvidence), _ 
            GacIdentityPermission)
        Console.WriteLine(myPerm.ToXml().ToString())
        '</Snippet3>

        '<Snippet4>
        Dim myGacInstalledCopy As GacInstalled = _
            CType(myGacInstalled.Copy(), GacInstalled)
        Dim result As Boolean = myGacInstalled.Equals(myGacInstalledCopy)
        '</Snippet4>

        '<Snippet5>
        Console.WriteLine( _
            ("Hashcode = " & myGacInstalled.GetHashCode().ToString()))
        '</Snippet5>

        '<Snippet6>
        Console.WriteLine(myGacInstalled.ToString())
    End Sub 'Main 
    '</Snippet6>
End Class 'GacDemo
'</Snippet1>
