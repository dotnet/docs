' The following code example determines the indexes of the first and last occurrences of a character or a substring within a string.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesCompareInfo

   Public Shared Sub Main()

      ' Creates CompareInfo for the InvariantCulture.
      Dim myComp As CompareInfo = CultureInfo.InvariantCulture.CompareInfo

      ' Searches for the ligature Æ.
      Dim myStr As [String] = "Is AE or ae the same as Æ or æ?"
      Console.WriteLine()
      Console.WriteLine("No options    : {0}", myStr)
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE"), myComp.LastIndexOf(myStr, "AE"))
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae"), myComp.LastIndexOf(myStr, "ae"))
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c), myComp.LastIndexOf(myStr, "Æ"c))
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c), myComp.LastIndexOf(myStr, "æ"c))
      Console.WriteLine("Ordinal       : {0}", myStr)
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE", CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "AE", CompareOptions.Ordinal))
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae", CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "ae", CompareOptions.Ordinal))
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "Æ"c, CompareOptions.Ordinal))
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "æ"c, CompareOptions.Ordinal))
      Console.WriteLine("IgnoreCase    : {0}", myStr)
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE", CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "AE", CompareOptions.IgnoreCase))
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae", CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "ae", CompareOptions.IgnoreCase))
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "Æ"c, CompareOptions.IgnoreCase))
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "æ"c, CompareOptions.IgnoreCase))

      ' Searches for the combining character sequence Latin capital letter U with diaeresis or Latin small letter u with diaeresis.
      myStr = "Is " & ChrW(&H0055) & ChrW(&H0308) & " or " & ChrW(&H0075) & ChrW(&H0308) & " the same as " & ChrW(&H00DC) & " or " & ChrW(&H00FC) & "?"
      Console.WriteLine()
      Console.WriteLine("No options    : {0}", myStr)
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308)), myComp.LastIndexOf(myStr, "U" & ChrW(&H0308)))
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308)), myComp.LastIndexOf(myStr, "u" & ChrW(&H0308)))
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c), myComp.LastIndexOf(myStr, "Ü"c))
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c), myComp.LastIndexOf(myStr, "ü"c))
      Console.WriteLine("Ordinal       : {0}", myStr)
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308), CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "U" & ChrW(&H0308), CompareOptions.Ordinal))
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308), CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "u" & ChrW(&H0308), CompareOptions.Ordinal))
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "Ü"c, CompareOptions.Ordinal))
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "ü"c, CompareOptions.Ordinal))
      Console.WriteLine("IgnoreCase    : {0}", myStr)
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308), CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "U" & ChrW(&H0308), CompareOptions.IgnoreCase))
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308), CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "u" & ChrW(&H0308), CompareOptions.IgnoreCase))
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "Ü"c, CompareOptions.IgnoreCase))
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "ü"c, CompareOptions.IgnoreCase))

   End Sub 'Main

   Public Shared Sub PrintMarker(Prefix As [String], First As Integer, Last As Integer)

      ' Determines the size of the array to create.
      Dim mySize As Integer
      If Last > First Then
         mySize = Last
      Else
         mySize = First
      End If 

      If mySize > - 1 Then

         ' Creates an array of Char to hold the markers.
         Dim myCharArr(mySize + 1) As [Char]

         ' Inserts the appropriate markers.
         If First > - 1 Then
            myCharArr(First) = "f"c
         End If
         If Last > - 1 Then
            myCharArr(Last) = "l"c
         End If
         If First = Last Then
            myCharArr(First) = "b"c
         End If 
         ' Displays the array of Char as a String.
         Console.WriteLine("{0}{1}", Prefix, New [String](myCharArr))

      Else
         Console.WriteLine(Prefix)

      End If 

   End Sub 'PrintMarker

End Class 'SamplesCompareInfo 


'This code produces the following output.
'
'No options    : Is AE or ae the same as Æ or æ?
'           AE :    f                    l
'           ae :          f                   l
'            Æ :    f                    l
'            æ :          f                   l
'Ordinal       : Is AE or ae the same as Æ or æ?
'           AE :    b
'           ae :          b
'            Æ :                         b
'            æ :                              b
'IgnoreCase    : Is AE or ae the same as Æ or æ?
'           AE :    f                         l
'           ae :    f                         l
'            Æ :    f                         l
'            æ :    f                         l
'
'No options    : Is U" or u" the same as Ü or ü?
'           U" :    f                    l
'           u" :          f                   l
'            Ü :    f                    l
'            ü :          f                   l
'Ordinal       : Is U" or u" the same as Ü or ü?
'           U" :    b
'           u" :          b
'            Ü :                         b
'            ü :                              b
'IgnoreCase    : Is U" or u" the same as Ü or ü?
'           U" :    f                         l
'           u" :    f                         l
'            Ü :    f                         l
'            ü :    f                         l

'</snippet1>