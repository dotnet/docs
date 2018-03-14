' Visual Basic .NET Document
Option Strict On
' <Snippet2>
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim enc As Encoding = Encoding.Unicode
      Dim value As String = "This is a string to persist."
      Dim bytes() As Byte = enc.GetBytes(value)

      Dim fs As New FileStream(".\TestFile.dat", 
                               FileMode.Create,
                               FileAccess.Write)
      Dim t As Task = fs.WriteAsync(enc.GetPreamble(), 0, enc.GetPreamble().Length)
      Dim t2 As Task = t.ContinueWith(Sub(a) fs.WriteAsync(bytes, 0, bytes.Length)) 
      t2.Wait()
      fs.Close()
   End Sub
End Module
' </Snippet2>
