' The following code example determines the indexes of the first and last occurrences of a character or a substring within a portion of a string.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesCompareInfo

   Public Shared Sub Main()

      ' Creates CompareInfo for the InvariantCulture.
      Dim myComp As CompareInfo = CultureInfo.InvariantCulture.CompareInfo

      ' iS is the starting index of the substring.
      Dim [iS] As Integer = 8
      ' iL is the length of the substring.
      Dim iL As Integer = 18
      ' myT1 and myT2 are the strings used for padding.
      Dim myT1 As New [String]("-"c, [iS])
      Dim myT2 As [String]

      ' Searches for the ligature Æ.
      Dim myStr As [String] = "Is AE or ae the same as Æ or æ?"
      myT2 = New [String]("-"c, myStr.Length - [iS] - iL)
      Console.WriteLine()
      Console.WriteLine("Original      : {0}", myStr)
      Console.WriteLine("No options    : {0}{1}{2}", myT1, myStr.Substring([iS], iL), myT2)
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE", [iS], iL), myComp.LastIndexOf(myStr, "AE", [iS] + iL - 1, iL))
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae", [iS], iL), myComp.LastIndexOf(myStr, "ae", [iS] + iL - 1, iL))
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c, [iS], iL), myComp.LastIndexOf(myStr, "Æ"c, [iS] + iL - 1, iL))
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c, [iS], iL), myComp.LastIndexOf(myStr, "æ"c, [iS] + iL - 1, iL))
      Console.WriteLine("Ordinal       : {0}{1}{2}", myT1, myStr.Substring([iS], iL), myT2)
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE", [iS], iL, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "AE", [iS] + iL - 1, iL, CompareOptions.Ordinal))
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae", [iS], iL, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "ae", [iS] + iL - 1, iL, CompareOptions.Ordinal))
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c, [iS], iL, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "Æ"c, [iS] + iL - 1, iL, CompareOptions.Ordinal))
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c, [iS], iL, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "æ"c, [iS] + iL - 1, iL, CompareOptions.Ordinal))
      Console.WriteLine("IgnoreCase    : {0}{1}{2}", myT1, myStr.Substring([iS], iL), myT2)
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE", [iS], iL, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "AE", [iS] + iL - 1, iL, CompareOptions.IgnoreCase))
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae", [iS], iL, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "ae", [iS] + iL - 1, iL, CompareOptions.IgnoreCase))
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c, [iS], iL, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "Æ"c, [iS] + iL - 1, iL, CompareOptions.IgnoreCase))
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c, [iS], iL, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "æ"c, [iS] + iL - 1, iL, CompareOptions.IgnoreCase))

      ' Searches for the combining character sequence Latin capital letter U with diaeresis or Latin small letter u with diaeresis.
      myStr = "Is " & ChrW(&H0055) & ChrW(&H0308) & " or " & ChrW(&H0075) & ChrW(&H0308) & " the same as " & ChrW(&H00DC) & " or " & ChrW(&H00FC) & "?"
      myT2 = New [String]("-"c, myStr.Length - [iS] - iL)
      Console.WriteLine()
      Console.WriteLine("Original      : {0}", myStr)
      Console.WriteLine("No options    : {0}{1}{2}", myT1, myStr.Substring([iS], iL), myT2)
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308), [iS], iL), myComp.LastIndexOf(myStr, "U" & ChrW(&H0308), [iS] + iL - 1, iL))
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308), [iS], iL), myComp.LastIndexOf(myStr, "u" & ChrW(&H0308), [iS] + iL - 1, iL))
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c, [iS], iL), myComp.LastIndexOf(myStr, "Ü"c, [iS] + iL - 1, iL))
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c, [iS], iL), myComp.LastIndexOf(myStr, "ü"c, [iS] + iL - 1, iL))
      Console.WriteLine("Ordinal       : {0}{1}{2}", myT1, myStr.Substring([iS], iL), myT2)
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308), [iS], iL, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "U" & ChrW(&H0308), [iS] + iL - 1, iL, CompareOptions.Ordinal))
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308), [iS], iL, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "u" & ChrW(&H0308), [iS] + iL - 1, iL, CompareOptions.Ordinal))
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c, [iS], iL, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "Ü"c, [iS] + iL - 1, iL, CompareOptions.Ordinal))
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c, [iS], iL, CompareOptions.Ordinal), myComp.LastIndexOf(myStr, "ü"c, [iS] + iL - 1, iL, CompareOptions.Ordinal))
      Console.WriteLine("IgnoreCase    : {0}{1}{2}", myT1, myStr.Substring([iS], iL), myT2)
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308), [iS], iL, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "U" & ChrW(&H0308), [iS] + iL - 1, iL, CompareOptions.IgnoreCase))
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308), [iS], iL, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "u" & ChrW(&H0308), [iS] + iL - 1, iL, CompareOptions.IgnoreCase))
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c, [iS], iL, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "Ü"c, [iS] + iL - 1, iL, CompareOptions.IgnoreCase))
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c, [iS], iL, CompareOptions.IgnoreCase), myComp.LastIndexOf(myStr, "ü"c, [iS] + iL - 1, iL, CompareOptions.IgnoreCase))

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
'Original      : Is AE or ae the same as Æ or æ?
'No options    : -------- ae the same as Æ -----
'           AE :                         b
'           ae :          b
'            Æ :                         b
'            æ :          b
'Ordinal       : -------- ae the same as Æ -----
'           AE :
'           ae :          b
'            Æ :                         b
'            æ :
'IgnoreCase    : -------- ae the same as Æ -----
'           AE :          f              l
'           ae :          f              l
'            Æ :          f              l
'            æ :          f              l
'
'Original      : Is U" or u" the same as Ü or ü?
'No options    : -------- u" the same as Ü -----
'           U" :                         b
'           u" :          b
'            Ü :                         b
'            ü :          b
'Ordinal       : -------- u" the same as Ü -----
'           U" :
'           u" :          b
'            Ü :                         b
'            ü :
'IgnoreCase    : -------- u" the same as Ü -----
'           U" :          f              l
'           u" :          f              l
'            Ü :          f              l
'            ü :          f              l

' </snippet1>
