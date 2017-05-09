' The following code example determines whether a string is the prefix or suffix of another string using CompareOptions.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesCompareInfo

   Public Shared Sub Main()

      ' Defines the strings to compare.
      Dim myStr1 As [String] = "calle"
      Dim myStr2 As [String] = "llegar"
      Dim myXfix As [String] = "LLE"

      ' Uses the CompareInfo property of the InvariantCulture.
      Dim myComp As CompareInfo = CultureInfo.InvariantCulture.CompareInfo

      Console.WriteLine("IsSuffix ""{0}"", ""{1}""", myStr1, myXfix)
      Console.WriteLine("   With no CompareOptions            : {0}", myComp.IsSuffix(myStr1, myXfix))
      Console.WriteLine("   With None                         : {0}", myComp.IsSuffix(myStr1, myXfix, CompareOptions.None))
      Console.WriteLine("   With Ordinal                      : {0}", myComp.IsSuffix(myStr1, myXfix, CompareOptions.Ordinal))
      Console.WriteLine("   With IgnoreCase                   : {0}", myComp.IsSuffix(myStr1, myXfix, CompareOptions.IgnoreCase))

      Console.WriteLine("IsPrefix ""{0}"", ""{1}""", myStr2, myXfix)
      Console.WriteLine("   With no CompareOptions            : {0}", myComp.IsPrefix(myStr2, myXfix))
      Console.WriteLine("   With None                         : {0}", myComp.IsPrefix(myStr2, myXfix, CompareOptions.None))
      Console.WriteLine("   With Ordinal                      : {0}", myComp.IsPrefix(myStr2, myXfix, CompareOptions.Ordinal))
      Console.WriteLine("   With IgnoreCase                   : {0}", myComp.IsPrefix(myStr2, myXfix, CompareOptions.IgnoreCase))

   End Sub 'Main 

End Class 'SamplesCompareInfo


'This code produces the following output.
'
'IsSuffix "calle", "LLE"
'   With no CompareOptions            : False
'   With None                         : False
'   With Ordinal                      : False
'   With IgnoreCase                   : True
'IsPrefix "llegar", "LLE"
'   With no CompareOptions            : False
'   With None                         : False
'   With Ordinal                      : False
'   With IgnoreCase                   : True

' </snippet1>