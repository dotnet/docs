'Types:System.Reflection.StrongNameKeyPair Vendor: Richter
'<snippet1>
Imports System.Reflection
Imports System.IO

Module Module1

    Sub Main()
        ' Open a file that contains a public key value. The line below  
        ' assumes that the Strong Name tool (SN.exe) was executed from 
        ' a command prompt as follows:
        '       SN.exe -k C:\Company.keys
        Dim fs As FileStream = File.Open("C:\Company.keys", FileMode.Open)

        '<snippet2>        
        ' Construct a StrongNameKeyPair object. This object should obtain 
        ' the public key from the Company.keys file.
        Dim k As Reflection.StrongNameKeyPair = _
            New Reflection.StrongNameKeyPair(fs)
        '</snippet2>

        '<snippet3>
        ' Display the bytes that make up the public key.
        Console.WriteLine(BitConverter.ToString(k.PublicKey))
        '</snippet3>

        ' Close the file.
        fs.Close()
    End Sub
End Module

' Output will vary by user.
' 
'  00-24-00-00-04-80-00-00-94-69-89-78-BB-F1-F2-71-00-00-00-34-26-
'  69-89-78-BB-F1-F2-71-00-F1-FA-F2-F9-4A-A8-5E-82-55-AB-49-4D-A6-
'  ED-AB-5F-CE-DE-59-49-8D-63-01-B0-E1-BF-43-07-FA-55-D4-36-75-EE-
'  8B-83-32-39-B7-02-DE-3D-81-29-7B-E8-EA-F0-2E-78-94-96-F1-73-79-
'  69-89-78-BB-F1-F2-71-0E-4E-F4-5D-DD-A4-7F-11-54-DF-65-DE-89-23-
'  91-AD-53-E1-C0-DA-9E-0C-88-BE-AA-7B-39-20-9C-9B-55-34-26-3B-1A-
'  53-41-31-00-04-00-00-01-00-01-00-9D-F1-EA-14-4C-88-34-26-3B-1A-
'  2D-D7-A0-AB-F6-7E-B7-24-7F-87-DF-3E-97
'</snippet1>
