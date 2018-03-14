'<Snippet1>
Imports System
Imports System.Collections
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Permissions
Imports System.Globalization
Imports Microsoft.VisualBasic



Public Class Evidence_Example

    Public Function CreateEvidence() As Boolean
        Dim retVal As Boolean = True

        Try
            ' Create empty evidence using the default contructor.
        '<Snippet15>
            Dim ev1 As New Evidence
            Console.WriteLine("Created empty evidence with the default constructor.")

	'</Snippet15>
            ' Constructor used to create null host evidence.
            Dim ev2a As New Evidence(Nothing)
            Console.WriteLine("Created an Evidence object with null host evidence.")

            ' Constructor used to create host evidence.
            '<Snippet2>
            Dim url As New Url("http://www.treyresearch.com")
            Console.WriteLine(("Adding host evidence " & url.ToString()))
            ev2a.AddHost(url)
            Dim ev2b As New Evidence(ev2a)
            Console.WriteLine("Copy evidence into new evidence")
            Dim enum1 As IEnumerator = ev2b.GetHostEnumerator()
            enum1.MoveNext()
            Console.WriteLine(enum1.Current.ToString())
            '</Snippet2>
            ' Constructor used to create both host and assembly evidence.
            '<Snippet3>
            Dim oa1() As [Object]
            Dim site As New Site("www.wideworldimporters.com")
            Dim oa2 As [Object]() = {url, site}
            Dim ev3a As New Evidence(oa1, oa2)
            enum1 = ev3a.GetHostEnumerator()
            Dim enum2 As IEnumerator = ev3a.GetAssemblyEnumerator()
            enum2.MoveNext()
            Dim obj1 As [Object] = enum2.Current
            enum2.MoveNext()
            Console.WriteLine(("URL = " & obj1.ToString() & "  Site = " & enum2.Current.ToString()))
            '</Snippet3>
            ' Constructor used to create null host and null assembly evidence.
            Dim ev3b As New Evidence(Nothing, Nothing)
            Console.WriteLine("Create new evidence with null host and assembly evidence")

        Catch e As Exception
            Console.WriteLine("Fatal error: {0}", e.ToString())
            Return False
        End Try

        Return retVal
    End Function 'CreateEvidence

    Public Function DemonstrateEvidenceMembers() As Evidence
        Dim myEvidence As New Evidence
        Dim sPubKeyBlob As String = "00240000048000009400000006020000" & "00240000525341310004000001000100" & "19390E945A40FB5730204A25FA5DC4DA" & "B18688B412CB0EDB87A6EFC50E2796C9" & "B41AD3040A7E46E4A02516C598678636" & "44A0F74C39B7AB9C38C01F10AF4A5752" & "BFBCDF7E6DD826676AD031E7BCE63393" & "495BAD2CA4BE03B529A73C95E5B06BE7" & "35CA0F622C63E8F54171BD73E4C8F193" & "CB2664163719CA41F8159B8AC88F8CD3"
        Dim pubkey As [Byte]() = HexsToArray(sPubKeyBlob)

        ' Create a strong name.
        Dim mSN As New StrongName(New StrongNamePublicKeyBlob(pubkey), "SN01", New Version("0.0.0.0"))

        ' Create assembly and host evidence.
        '<Snippet4>
        Console.WriteLine("Adding assembly evidence.")
        myEvidence.AddAssembly("SN01")
        myEvidence.AddAssembly(New Version("0.0.0.0"))
        myEvidence.AddAssembly(mSN)
        Console.WriteLine(("Count of evidence items = " & myEvidence.Count.ToString()))
        '</Snippet4>
        '<Snippet5>
        Dim url As New Url("http://www.treyresearch.com")
        Console.WriteLine(("Adding host evidence " & url.ToString()))
        myEvidence.AddHost(url)
        PrintEvidence(myEvidence).ToString()
        Console.WriteLine(("Count of evidence items = " & myEvidence.Count.ToString()))
        '</Snippet5>
        '<Snippet6>
        Console.WriteLine(ControlChars.Lf & "Copy the evidence to an array using CopyTo, then display the array.")
        Dim evidenceArray(myEvidence.Count - 1) As Object
        myEvidence.CopyTo(evidenceArray, 0)
        Dim obj As Object
        For Each obj In evidenceArray
            Console.WriteLine(obj.ToString())
        Next obj
        '</Snippet6>
        Console.WriteLine(ControlChars.Lf & "Display the contents of the properties.")
        Console.WriteLine("Locked is the only property normally used by code.")
        Console.WriteLine("IsReadOnly, IsSynchronized, and SyncRoot properties are not normally used.")
        '<Snippet7>
        Console.WriteLine((ControlChars.Lf & "The default value for the Locked property = " & myEvidence.Locked.ToString()))
        '</Snippet7>
        '<Snippet8>
        Console.WriteLine(ControlChars.Lf & "Get the hashcode for the evidence.")
        Console.WriteLine(("HashCode = " & myEvidence.GetHashCode().ToString()))
        '</Snippet8>
        '<Snippet9>
        Console.WriteLine(ControlChars.Lf & "Get the type for the evidence.")
        Console.WriteLine(("Type = " & myEvidence.GetType().ToString()))
        '</Snippet9>
        '<Snippet10>
        Console.WriteLine(ControlChars.Lf & "Merge new evidence with the current evidence.")
        Dim oa1() As [Object]
        Dim site As New Site("www.wideworldimporters.com")
        Dim oa2 As [Object]() = {url, site}
        Dim newEvidence As New Evidence(oa1, oa2)
        myEvidence.Merge(newEvidence)

        Console.WriteLine(("Evidence count = " & PrintEvidence(myEvidence).ToString()))
        '</Snippet10>
        '<Snippet11>
        Console.WriteLine(ControlChars.Lf & "Remove URL evidence.")
        myEvidence.RemoveType(url.GetType())
        Console.WriteLine(("Evidence count is now: " & myEvidence.Count.ToString()))
        '</Snippet11>
        '<Snippet12>
        Console.WriteLine(ControlChars.Lf & "Make a copy of the current evidence.")
        Dim evidenceCopy As New Evidence(myEvidence)
        Console.WriteLine(("Count of new evidence items = " & evidenceCopy.Count.ToString()))
        Console.WriteLine(("Does the copy equal the current evidence? " & myEvidence.Equals(evidenceCopy)))
        '</Snippet12>
        '<Snippet13>
        Console.WriteLine(ControlChars.Lf & "Clear the current evidence.")
        myEvidence.Clear()
        Console.WriteLine(("Count is now " & myEvidence.Count.ToString()))
        '</Snippet13>
        Return myEvidence
    End Function 'DemonstrateEvidenceMembers

    Public Shared Function PrintEvidence(ByVal myEvidence As Evidence) As Integer
    '<Snippet14>
        Dim p As Integer = 0
        Console.WriteLine(ControlChars.Lf & "Current evidence = ")
        If myEvidence Is Nothing Then
            Return 0
        End If
        Dim list As IEnumerator = myEvidence.GetEnumerator()
        Dim obj As Object
        While list.MoveNext()
            Console.WriteLine(list.Current.ToString())
            p = p + 1
        End While
'</Snippet14>
        Console.WriteLine(ControlChars.Lf)
        Return p
    End Function 'PrintEvidence

    ' Convert a hexidecimal string to an array.
    Public Shared Function HexsToArray(ByVal sHexString As String) As Byte()
        Dim array(sHexString.Length / 2) As [Byte]
        Dim i As Integer
        For i = 0 To sHexString.Length - 2 Step 2
            array((i / 2)) = [Byte].Parse(sHexString.Substring(i, 2), NumberStyles.HexNumber)
        Next i
        Return array
    End Function 'HexsToArray




    ' Main method.
    Public Shared Sub Main()
        Try
            Dim EvidenceTest As New Evidence_Example
            Dim ret As Boolean = EvidenceTest.CreateEvidence()
            If ret Then
                Console.WriteLine("Evidence successfully created.")
            Else
                Console.WriteLine("Evidence creation failed.")
            End If

            EvidenceTest.DemonstrateEvidenceMembers()
        Catch e As Exception
            Console.WriteLine(e.ToString())
            Environment.ExitCode = 101
        End Try
    End Sub 'Main
End Class 'Evidence_Example
'</Snippet1>
