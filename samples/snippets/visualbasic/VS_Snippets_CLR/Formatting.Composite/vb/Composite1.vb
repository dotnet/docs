' Visual Basic .NET Document
Option Strict On

Module modMain
    Public Sub Main()
        ' <Snippet1>
        Dim name As String = "Fred"
        ' <Snippet9>
        String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now)
        ' </Snippet9>
        ' </Snippet1>

        ' <Snippet3>
        Dim FormatString1 As String = String.Format("{0:dddd MMMM}", DateTime.Now)
        Dim FormatString2 As String = DateTime.Now.ToString("dddd MMMM")
        ' </Snippet3>    

        ' <Snippet4>
        Dim MyInt As Integer = 100
        Console.WriteLine("{0:C}", MyInt)
        ' The example displays the following output
        ' if en-US is the current culture:
        '        $100.00
        ' </Snippet4>  

        CallSnippet5()
        Console.WriteLine()
        CallSnippet6()
    End Sub

    Private Sub CallSnippet5()
        ' <Snippet5>
        Dim myName As String = "Fred"
        Console.WriteLine(String.Format("Name = {0}, hours = {1:hh}, minutes = {1:mm}", _
                          myName, DateTime.Now))
        ' Depending on the current time, the example displays output like the following:
        '    Name = Fred, hours = 11, minutes = 30                 
        ' </Snippet5>
    End Sub

    Private Sub CallSnippet6
        ' <Snippet6>
        Dim myFName As String = "Fred"
        Dim myLName As String = "Opals"

        Dim myInt As Integer = 100
        Dim FormatFName As String = String.Format("First Name = |{0,10}|", myFName)
        Dim FormatLName As String = String.Format("Last Name = |{0,10}|", myLName)
        Dim FormatPrice As String = String.Format("Price = |{0,10:C}|", myInt)
        Console.WriteLine(FormatFName)
        Console.WriteLine(FormatLName)
        Console.WriteLine(FormatPrice)
        Console.WriteLine()

        FormatFName = String.Format("First Name = |{0,-10}|", myFName)
        FormatLName = String.Format("Last Name = |{0,-10}|", myLName)
        FormatPrice = String.Format("Price = |{0,-10:C}|", myInt)
        Console.WriteLine(FormatFName)
        Console.WriteLine(FormatLName)
        Console.WriteLine(FormatPrice)
        ' The example displays the following output on a system whose current
        ' culture is en-US:
        '          First Name = |      Fred|
        '          Last Name = |     Opals|
        '          Price = |   $100.00|
        '
        '          First Name = |Fred      |
        '          Last Name = |Opals     |
        '          Price = |$100.00   |
        ' </Snippet6>
    End Sub
End Module

