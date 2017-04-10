' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.IO
Imports System.Reflection
Imports System.Resources

Module Example
   Public Sub Main()
      Dim assem As Assembly = GetType(Example).Assembly
      Dim fs As Stream = assem.GetManifestResourceStream("PatientForm.resources")
      Dim rr As New ResourceReader(fs)
      Dim dict As IDictionaryEnumerator = rr.GetEnumerator
      Dim ctr As Integer

      Do While dict.MoveNext()
         ctr += 1
         Console.WriteLine("{0:00}: {1} = {2}", ctr, dict.Key, dict.Value)
      Loop

      rr.Close()
   End Sub
End Module
' The example displays the following output:
'       01: Label3 = "Species:"
'       02: Label2 = "Pet Name:"
'       03: Label1 = "Patient Number:"
'       04: Label7 = "Owner:"
'       05: Label6 = "Age:"
'       06: Label5 = "Date of Birth:"
'       07: Label4 = "Breed:"
'       08: Label9 = "Home Phone:"
'       09: Label8 = "Address:"
'       10: Title = "Top Pet Animal Clinic"
'       11: Label10 = "Work Phone:"
'       12: Label11 = "Mobile Phone:"
' </Snippet1>
