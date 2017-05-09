' The following code example determines the indexes of the first and last occurrences of a character or a substring within a portion of a string.
' Note that IndexOf and LastIndexOf are searching in different portions of the string, even with the same StartIndex parameter.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesCompareInfo

   Public Shared Sub Main()

      ' Creates CompareInfo for the InvariantCulture.
      Dim myComp As CompareInfo = CultureInfo.InvariantCulture.CompareInfo

      ' iS is the starting index of the substring.
      Dim [iS] As Integer = 20
      ' myT1 is the string used for padding.
      Dim myT1 As [String]

      ' Searches for the ligature Æ.
      Dim myStr As [String] = "Is AE or ae the same as Æ or æ?"
      Console.WriteLine()

      myT1 = New [String]("-"c, [iS])
      Console.WriteLine("IndexOf( String, *, {0}, * )", [iS])
      Console.WriteLine("Original      : {0}", myStr)
      Console.WriteLine("No options    : {0}{1}", myT1, myStr.Substring([iS]))
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE", [iS]), - 1)
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae", [iS]), - 1)
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c, [iS]), - 1)
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c, [iS]), - 1)
      Console.WriteLine("Ordinal       : {0}{1}", myT1, myStr.Substring([iS]))
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE", [iS], CompareOptions.Ordinal), - 1)
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae", [iS], CompareOptions.Ordinal), - 1)
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c, [iS], CompareOptions.Ordinal), - 1)
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c, [iS], CompareOptions.Ordinal), - 1)
      Console.WriteLine("IgnoreCase    : {0}{1}", myT1, myStr.Substring([iS]))
      PrintMarker("           AE : ", myComp.IndexOf(myStr, "AE", [iS], CompareOptions.IgnoreCase), - 1)
      PrintMarker("           ae : ", myComp.IndexOf(myStr, "ae", [iS], CompareOptions.IgnoreCase), - 1)
      PrintMarker("            Æ : ", myComp.IndexOf(myStr, "Æ"c, [iS], CompareOptions.IgnoreCase), - 1)
      PrintMarker("            æ : ", myComp.IndexOf(myStr, "æ"c, [iS], CompareOptions.IgnoreCase), - 1)

      myT1 = New [String]("-"c, myStr.Length - [iS] - 1)
      Console.WriteLine("LastIndexOf( String, *, {0}, * )", [iS])
      Console.WriteLine("Original      : {0}", myStr)
      Console.WriteLine("No options    : {0}{1}", myStr.Substring(0, [iS] + 1), myT1)
      PrintMarker("           AE : ", - 1, myComp.LastIndexOf(myStr, "AE", [iS]))
      PrintMarker("           ae : ", - 1, myComp.LastIndexOf(myStr, "ae", [iS]))
      PrintMarker("            Æ : ", - 1, myComp.LastIndexOf(myStr, "Æ"c, [iS]))
      PrintMarker("            æ : ", - 1, myComp.LastIndexOf(myStr, "æ"c, [iS]))
      Console.WriteLine("Ordinal       : {0}{1}", myStr.Substring(0, [iS] + 1), myT1)
      PrintMarker("           AE : ", - 1, myComp.LastIndexOf(myStr, "AE", [iS], CompareOptions.Ordinal))
      PrintMarker("           ae : ", - 1, myComp.LastIndexOf(myStr, "ae", [iS], CompareOptions.Ordinal))
      PrintMarker("            Æ : ", - 1, myComp.LastIndexOf(myStr, "Æ"c, [iS], CompareOptions.Ordinal))
      PrintMarker("            æ : ", - 1, myComp.LastIndexOf(myStr, "æ"c, [iS], CompareOptions.Ordinal))
      Console.WriteLine("IgnoreCase    : {0}{1}", myStr.Substring(0, [iS] + 1), myT1)
      PrintMarker("           AE : ", - 1, myComp.LastIndexOf(myStr, "AE", [iS], CompareOptions.IgnoreCase))
      PrintMarker("           ae : ", - 1, myComp.LastIndexOf(myStr, "ae", [iS], CompareOptions.IgnoreCase))
      PrintMarker("            Æ : ", - 1, myComp.LastIndexOf(myStr, "Æ"c, [iS], CompareOptions.IgnoreCase))
      PrintMarker("            æ : ", - 1, myComp.LastIndexOf(myStr, "æ"c, [iS], CompareOptions.IgnoreCase))

      ' Searches for the combining character sequence Latin capital letter U with diaeresis or Latin small letter u with diaeresis.
      myStr = "Is " & ChrW(&H0055) & ChrW(&H0308) & " or " & ChrW(&H0075) & ChrW(&H0308) & " the same as " & ChrW(&H00DC) & " or " & ChrW(&H00FC) & "?"
      Console.WriteLine()

      myT1 = New [String]("-"c, [iS])
      Console.WriteLine("IndexOf( String, *, {0}, * )", [iS])
      Console.WriteLine("Original      : {0}", myStr)
      Console.WriteLine("No options    : {0}{1}", myT1, myStr.Substring([iS]))
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308), [iS]), - 1)
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308), [iS]), - 1)
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c, [iS]), - 1)
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c, [iS]), - 1)
      Console.WriteLine("Ordinal       : {0}{1}", myT1, myStr.Substring([iS]))
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308), [iS], CompareOptions.Ordinal), - 1)
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308), [iS], CompareOptions.Ordinal), - 1)
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c, [iS], CompareOptions.Ordinal), - 1)
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c, [iS], CompareOptions.Ordinal), - 1)
      Console.WriteLine("IgnoreCase    : {0}{1}", myT1, myStr.Substring([iS]))
      PrintMarker("           U" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "U" & ChrW(&H0308), [iS], CompareOptions.IgnoreCase), - 1)
      PrintMarker("           u" & ChrW(&H0308) & " : ", myComp.IndexOf(myStr, "u" & ChrW(&H0308), [iS], CompareOptions.IgnoreCase), - 1)
      PrintMarker("            Ü : ", myComp.IndexOf(myStr, "Ü"c, [iS], CompareOptions.IgnoreCase), - 1)
      PrintMarker("            ü : ", myComp.IndexOf(myStr, "ü"c, [iS], CompareOptions.IgnoreCase), - 1)

      myT1 = New [String]("-"c, myStr.Length - [iS] - 1)
      Console.WriteLine("LastIndexOf( String, *, {0}, * )", [iS])
      Console.WriteLine("Original      : {0}", myStr)
      Console.WriteLine("No options    : {0}{1}", myStr.Substring(0, [iS] + 1), myT1)
      PrintMarker("           U" & ChrW(&H0308) & " : ", - 1, myComp.LastIndexOf(myStr, "U" & ChrW(&H0308), [iS]))
      PrintMarker("           u" & ChrW(&H0308) & " : ", - 1, myComp.LastIndexOf(myStr, "u" & ChrW(&H0308), [iS]))
      PrintMarker("            Ü : ", - 1, myComp.LastIndexOf(myStr, "Ü"c, [iS]))
      PrintMarker("            ü : ", - 1, myComp.LastIndexOf(myStr, "ü"c, [iS]))
      Console.WriteLine("Ordinal       : {0}{1}", myStr.Substring(0, [iS] + 1), myT1)
      PrintMarker("           U" & ChrW(&H0308) & " : ", - 1, myComp.LastIndexOf(myStr, "U" & ChrW(&H0308), [iS], CompareOptions.Ordinal))
      PrintMarker("           u" & ChrW(&H0308) & " : ", - 1, myComp.LastIndexOf(myStr, "u" & ChrW(&H0308), [iS], CompareOptions.Ordinal))
      PrintMarker("            Ü : ", - 1, myComp.LastIndexOf(myStr, "Ü"c, [iS], CompareOptions.Ordinal))
      PrintMarker("            ü : ", - 1, myComp.LastIndexOf(myStr, "ü"c, [iS], CompareOptions.Ordinal))
      Console.WriteLine("IgnoreCase    : {0}{1}", myStr.Substring(0, [iS] + 1), myT1)
      PrintMarker("           U" & ChrW(&H0308) & " : ", - 1, myComp.LastIndexOf(myStr, "U" & ChrW(&H0308), [iS], CompareOptions.IgnoreCase))
      PrintMarker("           u" & ChrW(&H0308) & " : ", - 1, myComp.LastIndexOf(myStr, "u" & ChrW(&H0308), [iS], CompareOptions.IgnoreCase))
      PrintMarker("            Ü : ", - 1, myComp.LastIndexOf(myStr, "Ü"c, [iS], CompareOptions.IgnoreCase))
      PrintMarker("            ü : ", - 1, myComp.LastIndexOf(myStr, "ü"c, [iS], CompareOptions.IgnoreCase))

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
'IndexOf( String, *, 20, * )
'Original      : Is AE or ae the same as Æ or æ?
'No options    : -------------------- as Æ or æ?
'           AE :                         f
'           ae :                              f
'            Æ :                         f
'            æ :                              f
'Ordinal       : -------------------- as Æ or æ?
'           AE :
'           ae :
'            Æ :                         f
'            æ :                              f
'IgnoreCase    : -------------------- as Æ or æ?
'           AE :                         f
'           ae :                         f
'            Æ :                         f
'            æ :                         f
'LastIndexOf( String, *, 20, * )
'Original      : Is AE or ae the same as Æ or æ?
'No options    : Is AE or ae the same ----------
'           AE :    l
'           ae :          l
'            Æ :    l
'            æ :          l
'Ordinal       : Is AE or ae the same ----------
'           AE :    l
'           ae :          l
'            Æ :
'            æ :
'IgnoreCase    : Is AE or ae the same ----------
'           AE :          l
'           ae :          l
'            Æ :          l
'            æ :          l
'
'IndexOf( String, *, 20, * )
'Original      : Is U" or u" the same as Ü or ü?
'No options    : -------------------- as Ü or ü?
'           U" :                         f
'           u" :                              f
'            Ü :                         f
'            ü :                              f
'Ordinal       : -------------------- as Ü or ü?
'           U" :
'           u" :
'            Ü :                         f
'            ü :                              f
'IgnoreCase    : -------------------- as Ü or ü?
'           U" :                         f
'           u" :                         f
'            Ü :                         f
'            ü :                         f
'LastIndexOf( String, *, 20, * )
'Original      : Is U" or u" the same as Ü or ü?
'No options    : Is U" or u" the same ----------
'           U" :    l
'           u" :          l
'            Ü :    l
'            ü :          l
'Ordinal       : Is U" or u" the same ----------
'           U" :    l
'           u" :          l
'            Ü :
'            ü :
'IgnoreCase    : Is U" or u" the same ----------
'           U" :          l
'           u" :          l
'            Ü :          l
'            ü :          l

' </snippet1>
