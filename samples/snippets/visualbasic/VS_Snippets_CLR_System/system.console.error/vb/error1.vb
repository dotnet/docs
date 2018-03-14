' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim increment As Integer = 0
      Dim exitFlag As Boolean = False
      
      Do While Not exitFlag
         If Console.IsOutputRedirected Then
            Console.Error.WriteLine("Generating multiples of numbers from {0} to {1}",
                                    increment + 1, increment + 10)
         End If
         Console.WriteLine("Generating multiples of numbers from {0} to {1}",
                           increment + 1, increment + 10)
         For ctr As Integer = increment + 1 To increment + 10
            Console.Write("Multiples of {0}: ", ctr)
            For ctr2 As Integer = 1 To 10
               Console.Write("{0}{1}", ctr * ctr2, If(ctr2 = 10, "", ", "))
            Next
            Console.WriteLine()
         Next
         Console.WriteLine()
         
         increment += 10
         Console.Error.Write("Display multiples of {0} through {1} (y/n)? ",
                             increment + 1, increment + 10)
         Dim response As Char = Console.ReadKey(True).KeyChar
         Console.Error.WriteLine(response)
         If Not Console.IsOutputRedirected Then
            Console.CursorTop = Console.CursorTop - 1
         End If
         If Char.ToUpperInvariant(response) = "N" Then exitFlag = True
      Loop
   End Sub
End Module
' </Snippet1>
