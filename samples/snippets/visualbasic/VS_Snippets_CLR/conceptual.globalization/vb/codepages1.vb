' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO
Imports System.Text

Module Example
    Public Sub CodePages()
        ' Represent Greek uppercase characters in code page 737.
        Dim greekChars() As Char = {"Α"c, "Β"c, "Γ"c, "Δ"c, "Ε"c, "Ζ"c, "Η"c, "Θ"c,
                                     "Ι"c, "Κ"c, "Λ"c, "Μ"c, "Ν"c, "Ξ"c, "Ο"c, "Π"c,
                                     "Ρ"c, "Σ"c, "Τ"c, "Υ"c, "Φ"c, "Χ"c, "Ψ"c, "Ω"c}

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)

        Dim cp737 As Encoding = Encoding.GetEncoding(737)
        Dim nBytes As Integer = CInt(cp737.GetByteCount(greekChars))
        Dim bytes737(nBytes - 1) As Byte
        bytes737 = cp737.GetBytes(greekChars)
        ' Write the bytes to a file.
        Dim fs As New FileStream(".\CodePageBytes.dat", FileMode.Create)
        fs.Write(bytes737, 0, bytes737.Length)
        fs.Close()

        ' Retrieve the byte data from the file.
        fs = New FileStream(".\CodePageBytes.dat", FileMode.Open)
        Dim bytes1(CInt(fs.Length - 1)) As Byte
        fs.Read(bytes1, 0, CInt(fs.Length))
        fs.Close()

        ' Restore the data on a system whose code page is 737.
        Dim data As String = cp737.GetString(bytes1)
        Console.WriteLine(data)
        Console.WriteLine()

        ' Restore the data on a system whose code page is 1252.
        Dim cp1252 As Encoding = Encoding.GetEncoding(1252)
        data = cp1252.GetString(bytes1)
        Console.WriteLine(data)
    End Sub
End Module
' The example displays the following output:
'       ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ
'       €‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’""•–—
' </Snippet1>

