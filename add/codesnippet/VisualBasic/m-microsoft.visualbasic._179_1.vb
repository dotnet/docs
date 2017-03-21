        Dim testString As String = "String for testing"
        Dim testObject As New Object
        Dim testNumber, testArray(5) As Integer
        Dim testVarType As VariantType
        testVarType = VarType(testVarType)
        ' Returns VariantType.Integer.
        testVarType = VarType(testString)
        ' Returns VariantType.String.
        testVarType = VarType(testObject)
        ' Returns VariantType.Object.
        testVarType = VarType(testNumber)
        ' Returns VariantType.Integer.
        testVarType = VarType(testArray)
        ' Returns the bitwise OR of VariantType.Array and VariantType.Integer.