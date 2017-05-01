' Visual Basic .NET Document
Option Strict On
' ReferenceEquals with Interned Strings'

' <Snippet2>
Module Example
   Public Sub Main()
      Dim s1 As String = "String1"
      Dim s2 As String = "String1"
      Console.WriteLine("s1 = s2: {0}", Object.ReferenceEquals(s1, s2))
      Console.WriteLine("{0} interned: {1}", s1, 
                        If(String.IsNullOrEmpty(String.IsInterned(s1)), "No", "Yes"))

      Dim suffix As String = "A"
      Dim s3 = "String" + suffix
      Dim s4 = "String" + suffix
      Console.WriteLine("s3 = s4: {0}", Object.ReferenceEquals(s3, s4))
      Console.WriteLine("{0} interned: {1}", s3, 
                        If(String.IsNullOrEmpty(String.IsInterned(s3)), "No", "Yes"))
   End Sub
End Module
' The example displays the following output:
'       s1 = s2: True
'       String1 interned: Yes
'       s3 = s4: False
'       StringA interned: No
' </Snippet2>
