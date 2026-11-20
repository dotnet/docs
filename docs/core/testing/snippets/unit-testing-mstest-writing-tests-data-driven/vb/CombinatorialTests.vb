Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Combinatorial

Namespace CombinatorialExample

    <TestClass>
    Public NotInheritable Class CombinatorialTests

        ' <CombinatorialExample>
        <TestMethod>
        <CombinatorialData>
        Public Sub Calculate_UsesEveryCombination(
            enabled As Boolean,
            <CombinatorialValues(1, 3)> factor As Integer,
            <CombinatorialRange(2, 6, 2)> value As Integer,
            <CombinatorialRandomData(Count:=2, Minimum:=10, Maximum:=20, Seed:=42)> offset As Integer)

            Dim result = If(enabled, (factor * value) + offset, value + offset)

            Assert.IsTrue(result >= 12)
        End Sub
        ' </CombinatorialExample>

    End Class

End Namespace
