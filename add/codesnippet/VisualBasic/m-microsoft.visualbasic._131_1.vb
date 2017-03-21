        Dim testType As String
        Dim strVar As String = "String for testing"
        Dim decVar As Decimal
        Dim intVar, arrayVar(5) As Integer
        testType = TypeName(strVar)
        ' The preceding call returns "String".
        testType = TypeName(decVar)
        ' The preceding call returns "Decimal".
        testType = TypeName(intVar)
        ' The preceding call returns "Integer".
        testType = TypeName(arrayVar)
        ' The preceding call returns "Integer()".