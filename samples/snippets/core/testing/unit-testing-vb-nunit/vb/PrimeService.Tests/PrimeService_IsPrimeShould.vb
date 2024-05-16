Imports NUnit.Framework

Namespace PrimeService.Tests
    '<Sample_TestCode>
    <TestFixture>
    Public Class PrimeService_IsPrimeShould
        Private _primeService As Prime.Services.PrimeService = New Prime.Services.PrimeService()

        <TestCase(-1)>
        <TestCase(0)>
        <TestCase(1)>
        Sub IsPrime_ValuesLessThan2_ReturnFalse(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.That(result, [Is].False, $"{value} should not be prime")
        End Sub

        <TestCase(2)>
        <TestCase(3)>
        <TestCase(5)>
        <TestCase(7)>
        Public Sub IsPrime_PrimesLessThan10_ReturnTrue(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.That(result, [Is].True, $"{value} should be prime")
        End Sub

        <TestCase(4)>
        <TestCase(6)>
        <TestCase(8)>
        <TestCase(9)>
        Public Sub IsPrime_NonPrimesLessThan10_ReturnFalse(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.That(result, [Is].False, $"{value} should not be prime")
        End Sub
    End Class
    '</Sample_TestCode>
End Namespace
