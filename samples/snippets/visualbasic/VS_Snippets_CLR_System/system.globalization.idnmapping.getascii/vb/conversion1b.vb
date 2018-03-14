' This example simply tries to demonstrates the use of the GetAscii and GetUnicode methods
' with some valid and invalid characters. There is no difference here betweeen the two 
' versions of IDNA.  

Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim email As String = "johann_doe@bücher.com john_doe@hotmail.com иван@мойдомен.рф"
      Dim idn As New IdnMapping()
      Dim start, [end] As Integer
      
      Do While [end] >= 0
         start = email.IndexOf("@", [end])
         [end] = email.IndexOf(" ", start)
         Dim domain As String = String.Empty
         
         Try
            Dim punyCode As String = String.Empty
            If start >= 0 And [end] >= 0 Then 
               domain = email.Substring(start + 1, [end] - start - 1)
               punyCode = idn.GetAscii(email, start + 1, [end] - start - 1)
            Else
               domain = email.Substring(start + 1)
               punyCode = idn.GetAscii(email, start + 1)
            End If
            Dim name2 As String = idn.GetUnicode(punyCode)
            Console.WriteLine("{0} --> {1} --> {2}", domain, punyCode, name2) 
         Catch e As ArgumentException 
            Console.WriteLine("{0} is not a valid domain name.", domain)
         End Try
         Console.WriteLine()
      Loop   
   End Sub
End Module
' The example displays the following output:
'       bücher.com --> xn--bcher-kva.com --> bücher.com
'       
'       hotmail.com --> hotmail.com --> hotmail.com
'       
'       мойдомен.рф --> xn--d1acklchcc.xn--p1ai --> мойдомен.рф
' </Snippet3>
 
