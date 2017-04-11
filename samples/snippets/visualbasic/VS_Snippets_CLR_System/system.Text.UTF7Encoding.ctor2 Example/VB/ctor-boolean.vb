' <Snippet1>
Imports System
Imports System.Text

Class UTF7EncodingExample
    
    Public Shared Sub Main()
        
        ' A few optional characters.
        Dim chars As String = "!@#$"
        
        ' The default Encoding does not allow optional characters.
        ' Alternate byte values are used.
        Dim utf7 As New UTF7Encoding()
        Dim bytes1 As Byte() = utf7.GetBytes(chars)
        
        Console.WriteLine("Default UTF7 Encoding:")
        ShowArray(bytes1)
        
        ' Convert back to characters.
        Console.WriteLine("Characters:")
        ShowArray(utf7.GetChars(bytes1))
        
        ' Now, allow optional characters.
        ' Optional characters are encoded with their normal code points.
        Dim utf7AllowOptionals As New UTF7Encoding(True)
        Dim bytes2 As Byte() = utf7AllowOptionals.GetBytes(chars)
        
        Console.WriteLine("UTF7 Encoding with optional characters allowed:")
        ShowArray(bytes2)
        
        ' Convert back to characters.
        Console.WriteLine("Characters:")
        ShowArray(utf7AllowOptionals.GetChars(bytes2))
    End Sub 'Main
    
    
    Public Shared Sub ShowArray(theArray As Array)
        Dim o As Object
        For Each o In  theArray
            Console.Write("[{0}]", o)
        Next o
        Console.WriteLine()
    End Sub 'ShowArray
End Class 'UTF7EncodingExample

' </Snippet1>
