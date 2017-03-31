' The following code example clones a CultureInfo array and demonstrates the behavior of a shallow copy.

' <Snippet1>
Imports System
Imports System.Globalization

Public Class SamplesArray

    Public Shared Sub Main()

        ' Create and initialize a new CultureInfo array.
        Dim ci0 As New CultureInfo("ar-SA", False)
        Dim ci1 As New CultureInfo("en-US", False)
        Dim ci2 As New CultureInfo("fr-FR", False)
        Dim ci3 As New CultureInfo("ja-JP", False)
        Dim arrCI() As CultureInfo = {ci0, ci1, ci2, ci3}

        ' Create a clone of the CultureInfo array.
        Dim arrCIClone As CultureInfo() = CType(arrCI.Clone(), CultureInfo())

        ' Replace an element in the clone array.
        Dim ci4 As New CultureInfo("th-TH", False)
        arrCIClone(0) = ci4

        ' Display the contents of the original array.
        Console.WriteLine("The original array contains the following values:")
        PrintIndexAndValues(arrCI)

        ' Display the contents of the clone array.
        Console.WriteLine("The clone array contains the following values:")
        PrintIndexAndValues(arrCIClone)

        ' Display the DateTimeFormatInfo.DateSeparator for the fourth element in both arrays.
        Console.WriteLine("Before changes to the clone:")
        Console.WriteLine("   Original: The DateTimeFormatInfo.DateSeparator for {0} is {1}.", arrCI(3).Name, arrCI(3).DateTimeFormat.DateSeparator)
        Console.WriteLine("      Clone: The DateTimeFormatInfo.DateSeparator for {0} is {1}.", arrCIClone(3).Name, arrCIClone(3).DateTimeFormat.DateSeparator)

        ' Replace the DateTimeFormatInfo.DateSeparator for the fourth element in the clone array.
        arrCIClone(3).DateTimeFormat.DateSeparator = "-"

        ' Display the DateTimeFormatInfo.DateSeparator for the fourth element in both arrays.
        Console.WriteLine("After changes to the clone:")
        Console.WriteLine("   Original: The DateTimeFormatInfo.DateSeparator for {0} is {1}.", arrCI(3).Name, arrCI(3).DateTimeFormat.DateSeparator)
        Console.WriteLine("      Clone: The DateTimeFormatInfo.DateSeparator for {0} is {1}.", arrCIClone(3).Name, arrCIClone(3).DateTimeFormat.DateSeparator)

    End Sub 'Main

    Public Shared Sub PrintIndexAndValues(myArray As Array)
        Dim i As Integer
        For i = myArray.GetLowerBound(0) To myArray.GetUpperBound(0)
            Console.WriteLine(vbTab + "[{0}]:" + vbTab + "{1}", i, myArray.GetValue(i))
        Next i
    End Sub 'PrintIndexAndValues 

End Class 'SamplesArray


'This code produces the following output.
'
'The original array contains the following values:
'        [0]:    ar-SA
'        [1]:    en-US
'        [2]:    fr-FR
'        [3]:    ja-JP
'The clone array contains the following values:
'        [0]:    th-TH
'        [1]:    en-US
'        [2]:    fr-FR
'        [3]:    ja-JP
'Before changes to the clone:
'   Original: The DateTimeFormatInfo.DateSeparator for ja-JP is /.
'      Clone: The DateTimeFormatInfo.DateSeparator for ja-JP is /.
'After changes to the clone:
'   Original: The DateTimeFormatInfo.DateSeparator for ja-JP is -.
'      Clone: The DateTimeFormatInfo.DateSeparator for ja-JP is -.

' </Snippet1>