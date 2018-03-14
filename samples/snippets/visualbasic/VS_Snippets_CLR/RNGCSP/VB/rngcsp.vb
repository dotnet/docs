'<SNIPPET1>
'The following sample uses the Cryptography class to simulate the roll of a dice.
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography



Class RNGCSP
    Private Shared rngCsp As New RNGCryptoServiceProvider()
    ' Main method.
    Public Shared Sub Main()
        Const totalRolls As Integer = 25000
        Dim results(5) As Integer

        ' Roll the dice 25000 times and display
        ' the results to the console.
        Dim x As Integer
        For x = 0 To totalRolls
            Dim roll As Byte = RollDice(System.Convert.ToByte(results.Length))
            results((roll - 1)) += 1
        Next x
        Dim i As Integer

        While i < results.Length
            Console.WriteLine("{0}: {1} ({2:p1})", i + 1, results(i), System.Convert.ToDouble(results(i)) / System.Convert.ToDouble(totalRolls))
            i += 1
        End While
        rngCsp.Dispose()
        Console.ReadLine()
    End Sub


    ' This method simulates a roll of the dice. The input parameter is the
    ' number of sides of the dice.
    Public Shared Function RollDice(ByVal numberSides As Byte) As Byte
        If numberSides <= 0 Then
            Throw New ArgumentOutOfRangeException("NumSides")
        End If 
        ' Create a byte array to hold the random value.
        Dim randomNumber(0) As Byte
        Do
            ' Fill the array with a random value.
            rngCsp.GetBytes(randomNumber)
        Loop While Not IsFairRoll(randomNumber(0), numberSides)
        ' Return the random number mod the number
        ' of sides.  The possible values are zero-
        ' based, so we add one.
        Return System.Convert.ToByte(randomNumber(0) Mod numberSides + 1)

    End Function


    Private Shared Function IsFairRoll(ByVal roll As Byte, ByVal numSides As Byte) As Boolean
        ' There are MaxValue / numSides full sets of numbers that can come up
        ' in a single byte.  For instance, if we have a 6 sided die, there are
        ' 42 full sets of 1-6 that come up.  The 43rd set is incomplete.
        Dim fullSetsOfValues As Integer = [Byte].MaxValue / numSides

        ' If the roll is within this range of fair values, then we let it continue.
        ' In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use
        ' < rather than <= since the = portion allows through an extra 0 value).
        ' 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair
        ' to use.
        Return roll < numSides * fullSetsOfValues

    End Function 'IsFairRoll
End Class
'</SNIPPET1>