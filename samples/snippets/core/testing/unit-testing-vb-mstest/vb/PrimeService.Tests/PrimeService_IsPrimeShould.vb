Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace PrimeService.Tests
    '<Sample_TestCode>
    <TestClass>
    Public Class PrimeService_IsPrimeShould
        Private _primeService As Prime.Services.PrimeService = New Prime.Services.PrimeService()

        <DataTestMethod>
        <DataRow(-1)>
        <DataRow(0)>
        <DataRow(1)>
        Sub IsPrime_ValuesLessThan2_ReturnFalse(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.IsFalse(result, $"{value} should not be prime")
        End Sub

        <DataTestMethod>
        <DataRow(2)>
        <DataRow(3)>
        <DataRow(5)>
        <DataRow(7)>
        Public Sub IsPrime_PrimesLessThan10_ReturnTrue(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.IsTrue(result, $"{value} should be prime")
        End Sub

        <DataTestMethod>
        <DataRow(4)>
        <DataRow(6)>
        <DataRow(8)>
        <DataRow(9)>
        Public Sub IsPrime_NonPrimesLessThan10_ReturnFalse(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.IsFalse(result, $"{value} should not be prime")
        End Sub
    End Class
    '</Sample_TestCode>
End Namespace
