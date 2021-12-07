' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Globalization
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading

Module Example16
    Public Sub Main16()
        ' Create ten random doubles.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Dim numbers() As Double = GetRandomNumbers(10)
        DisplayRandomNumbers(numbers)

        ' Serialize the array.
        Dim fsIn As New FileStream("randoms.dat", FileMode.Create)
        Dim formatter As New BinaryFormatter()
        formatter.Serialize(fsIn, numbers)
        fsIn.Close()

        ' Read the persisted data.
        Dim fsOut As New FileStream("randoms.dat", FileMode.Open)
        Dim numbers1() As Double = DirectCast(formatter.Deserialize(fsOut), Double())
        fsOut.Close()

        ' Display the data using the conventions of the en-US culture.
        Console.WriteLine("Current Culture: {0}",
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        DisplayRandomNumbers(numbers1)

        ' Display the data using the conventions of the fr-FR culture.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR")
        Console.WriteLine("Current Culture: {0}",
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        DisplayRandomNumbers(numbers1)
    End Sub

    Private Function GetRandomNumbers(n As Integer) As Double()
        Dim rnd As New Random()
        Dim numbers(n - 1) As Double
        For ctr As Integer = 0 To n - 1
            numbers(ctr) = rnd.NextDouble * 1000
        Next
        Return numbers
    End Function

    Private Sub DisplayRandomNumbers(numbers As Double())
        For ctr As Integer = 0 To numbers.Length - 1
            Console.WriteLine(numbers(ctr).ToString("R"))
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays output like the following:
'       932.10070623648392
'       96.868112262742642
'       857.111520067375
'       771.37727233179726
'       262.65733840999064
'       387.00796914613244
'       557.49389788019187
'       83.79498919648816
'       957.31006048494487
'       996.54487892824454
'       
'       Current Culture: English (United States)
'       932.10070623648392
'       96.868112262742642
'       857.111520067375
'       771.37727233179726
'       262.65733840999064
'       387.00796914613244
'       557.49389788019187
'       83.79498919648816
'       957.31006048494487
'       996.54487892824454
'       
'       Current Culture: French (France)
'       932,10070623648392
'       96,868112262742642
'       857,111520067375
'       771,37727233179726
'       262,65733840999064
'       387,00796914613244
'       557,49389788019187
'       83,79498919648816
'       957,31006048494487
'       996,54487892824454
' </Snippet7>
