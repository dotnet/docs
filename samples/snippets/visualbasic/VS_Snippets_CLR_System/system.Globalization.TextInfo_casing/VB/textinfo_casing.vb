' The following code example changes the casing of a string.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesTextInfo

   Public Shared Sub Main()

      ' Defines the string with mixed casing.
      Dim myString As String = "wAr aNd pEaCe"

      ' Creates a TextInfo based on the "en-US" culture.
      Dim myTI As TextInfo = New CultureInfo("en-US", False).TextInfo

      ' Changes a string to lowercase.
      Console.WriteLine("""{0}"" to lowercase: {1}", myString, myTI.ToLower(myString))

      ' Changes a string to uppercase.
      Console.WriteLine("""{0}"" to uppercase: {1}", myString, myTI.ToUpper(myString))

      ' Changes a string to titlecase.
      Console.WriteLine("""{0}"" to titlecase: {1}", myString, myTI.ToTitleCase(myString))

   End Sub 'Main 

End Class 'SamplesTextInfo


'This code produces the following output.
'
'"wAr aNd pEaCe" to lowercase: war and peace
'"wAr aNd pEaCe" to uppercase: WAR AND PEACE
'"wAr aNd pEaCe" to titlecase: War And Peace


' </snippet1>