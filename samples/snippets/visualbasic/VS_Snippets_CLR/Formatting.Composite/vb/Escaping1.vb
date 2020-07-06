' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>
Module modMain

    Public Sub Main()
        ' <Snippet2>  
        Dim value As Integer = 6324
        Dim output As String = String.Format("{0}{1:D}{2}", _
                                             "{", value, "}")
        Console.WriteLine(output)
        ' The example displays the following output:
        '       {6324}
        ' </Snippet2>                                           
    End Sub
End Module

