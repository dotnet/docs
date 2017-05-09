' The following code example shows how sorting with CompareOptions.StringSort differs from sorting without CompareOptions.StringSort.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Globalization

Public Class SamplesCompareOptions

   Private Class MyStringComparer
      Implements IComparer

      Private myComp As CompareInfo
      Private myOptions As CompareOptions = CompareOptions.None
      
      ' Constructs a comparer using the specified CompareOptions.
      Public Sub New(cmpi As CompareInfo, options As CompareOptions)
         myComp = cmpi
         Me.myOptions = options
      End Sub 'New
      
      ' Compares strings with the CompareOptions specified in the constructor.
      Public Function Compare(a As [Object], b As [Object]) As Integer Implements IComparer.Compare
         If a = b Then
            Return 0
         End If
         If a Is Nothing Then
            Return - 1
         End If
         If b Is Nothing Then
            Return 1
         End If 

         Dim sa As [String] = a
         Dim sb As [String] = b
         If Not (sa Is Nothing) And Not (sb Is Nothing) Then
            Return myComp.Compare(sa, sb, myOptions)
         End If
         Throw New ArgumentException("a and b should be strings.")

      End Function 'Compare 

   End Class 'MyStringComparer


   Public Shared Sub Main()
      
      ' Creates and initializes an array of strings to sort.
      Dim myArr() As [String] = {"cant", "bill's", "coop", "cannot", "billet", "can't", "con", "bills", "co-op"}
      Console.WriteLine()
      Console.WriteLine("Initially,")
      Dim myStr As [String]
      For Each myStr In  myArr
         Console.WriteLine(myStr)
      Next myStr 

      ' Creates and initializes a Comparer to use.
      'CultureInfo myCI = new CultureInfo( "en-US", false );
      Dim myComp As New MyStringComparer(CompareInfo.GetCompareInfo("en-US"), CompareOptions.None)
      
      ' Sorts the array without StringSort.
      Array.Sort(myArr, myComp)
      Console.WriteLine()
      Console.WriteLine("After sorting without CompareOptions.StringSort:")
      For Each myStr In  myArr
         Console.WriteLine(myStr)
      Next myStr 

      ' Sorts the array with StringSort.
      myComp = New MyStringComparer(CompareInfo.GetCompareInfo("en-US"), CompareOptions.StringSort)
      Array.Sort(myArr, myComp)
      Console.WriteLine()
      Console.WriteLine("After sorting with CompareOptions.StringSort:")
      For Each myStr In  myArr
         Console.WriteLine(myStr)
      Next myStr 

   End Sub 'Main

End Class 'SamplesCompareOptions 


'This code produces the following output.
'
'Initially,
'cant
'bill's
'coop
'cannot
'billet
'can't
'con
'bills
'co-op
'
'After sorting without CompareOptions.StringSort:
'billet
'bills
'bill's
'cannot
'cant
'can't
'con
'coop
'co-op
'
'After sorting with CompareOptions.StringSort:
'bill's
'billet
'bills
'can't
'cannot
'cant
'co-op
'con
'coop

' </snippet1>