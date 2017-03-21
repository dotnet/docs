Imports System
Imports System.Security.Policy
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.VisualBasic

Class GacDemo
    <STAThread()> _
    Overloads Shared Sub Main(ByVal args() As String)
        Dim myGacInstalled As New GacInstalled

        Dim hostEvidence() As Object = {myGacInstalled}
        Dim assemblyEvidence() As Object
        Dim myEvidence As New Evidence(hostEvidence, assemblyEvidence)
        Dim myPerm As GacIdentityPermission = _
            CType(myGacInstalled.CreateIdentityPermission(myEvidence), _ 
            GacIdentityPermission)
        Console.WriteLine(myPerm.ToXml().ToString())

        Dim myGacInstalledCopy As GacInstalled = _
            CType(myGacInstalled.Copy(), GacInstalled)
        Dim result As Boolean = myGacInstalled.Equals(myGacInstalledCopy)

        Console.WriteLine( _
            ("Hashcode = " & myGacInstalled.GetHashCode().ToString()))

        Console.WriteLine(myGacInstalled.ToString())
    End Sub 'Main 
End Class 'GacDemo