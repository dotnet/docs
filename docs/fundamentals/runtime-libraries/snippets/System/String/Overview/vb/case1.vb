' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet7>
Imports System.Globalization
Imports System.IO

Module Example1
    Public Sub Main()
        Dim sw As New StreamWriter(".\case.txt")
        Dim words As String() = {"file", "sıfır", "ǅenana"}
        Dim cultures() As CultureInfo = {CultureInfo.InvariantCulture,
                                        New CultureInfo("en-US"),
                                        New CultureInfo("tr-TR")}

        For Each word In words
            sw.WriteLine("{0}:", word)
            For Each culture In cultures
                Dim name As String = If(String.IsNullOrEmpty(culture.Name),
                                 "Invariant", culture.Name)
                Dim upperWord As String = word.ToUpper(culture)
                sw.WriteLine("   {0,10}: {1,7} {2, 38}", name,
                         upperWord, ShowHexValue(upperWord))

            Next
            sw.WriteLine()
        Next
        sw.Close()
    End Sub

    Private Function ShowHexValue(s As String) As String
        Dim retval As String = Nothing
        For Each ch In s
            Dim bytes() As Byte = BitConverter.GetBytes(ch)
            retval += String.Format("{0:X2} {1:X2} ", bytes(1), bytes(0))
        Next
        Return retval
    End Function
End Module
' The example displays the following output:
'    file:
'        Invariant:    FILE               00 46 00 49 00 4C 00 45 
'            en-US:    FILE               00 46 00 49 00 4C 00 45 
'            tr-TR:    FİLE               00 46 01 30 00 4C 00 45 
'    
'    sıfır:
'        Invariant:   SıFıR         00 53 01 31 00 46 01 31 00 52 
'            en-US:   SIFIR         00 53 00 49 00 46 00 49 00 52 
'            tr-TR:   SIFIR         00 53 00 49 00 46 00 49 00 52 
'    
'    ǅenana:
'        Invariant:  ǅENANA   01 C5 00 45 00 4E 00 41 00 4E 00 41 
'            en-US:  ǄENANA   01 C4 00 45 00 4E 00 41 00 4E 00 41 
'            tr-TR:  ǄENANA   01 C4 00 45 00 4E 00 41 00 4E 00 41  
' </Snippet7>

