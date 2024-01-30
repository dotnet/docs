' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Module Example3
    Public Sub Main()
        Dim flag As Boolean = True

        Dim byteValue As Byte
        byteValue = Convert.ToByte(flag)
        Console.WriteLine("{0} -> {1} ({2})", flag, byteValue,
                                            byteValue.GetType().Name)
        byteValue = CByte(flag)
        Console.WriteLine("{0} -> {1} ({2})", flag, byteValue,
                                            byteValue.GetType().Name)

        Dim sbyteValue As SByte
        sbyteValue = Convert.ToSByte(flag)
        Console.WriteLine("{0} -> {1} ({2})", flag, sbyteValue,
                                            sbyteValue.GetType().Name)
        sbyteValue = CSByte(flag)
        Console.WriteLine("{0} -> {1} ({2})", flag, sbyteValue,
                                            sbyteValue.GetType().Name)

        Dim dblValue As Double
        dblValue = Convert.ToDouble(flag)
        Console.WriteLine("{0} -> {1} ({2})", flag, dblValue,
                                            dblValue.GetType().Name)
        dblValue = CDbl(flag)
        Console.WriteLine("{0} -> {1} ({2})", flag, dblValue,
                                            dblValue.GetType().Name)

        Dim intValue As Integer
        intValue = Convert.ToInt32(flag)
        Console.WriteLine("{0} -> {1} ({2})", flag, intValue,
                                            intValue.GetType().Name)
        intValue = CInt(flag)
        Console.WriteLine("{0} -> {1} ({2})", flag, intValue,
                                            intValue.GetType().Name)
    End Sub
End Module
' The example displays the following output:
'       True -> 1 (Byte)
'       True -> 255 (Byte)
'       True -> 1 (SByte)
'       True -> -1 (SByte)
'       True -> 1 (Double)
'       True -> -1 (Double)
'       True -> 1 (Int32)
'       True -> -1 (Int32)
' </Snippet8>
