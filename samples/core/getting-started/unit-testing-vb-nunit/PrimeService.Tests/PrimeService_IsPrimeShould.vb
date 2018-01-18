Imports NUnit.Framework

Namespace PrimeService.Tests
    '<Sample_TestCode>
    <TestFixture>
    Public Class PrimeService_IsPrimeShould
        Private _primeService As Prime.Services.PrimeService = New Prime.Services.PrimeService()

        <TestCase(-1)>
        <TestCase(0)>
        <TestCase(1)>
        Sub ReturnFalseGivenValuesLessThan2(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.IsFalse(result, $"{value} should not be prime")
        End Sub

        <TestCase(2)>
        <TestCase(3)>
        <TestCase(5)>
        <TestCase(7)>
        Public Sub ReturnTrueGivenPrimesLessThan10(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.IsTrue(result, $"{value} should be prime")
        End Sub

        <TestCase(4)>
        <TestCase(6)>
        <TestCase(8)>
        <TestCase(9)>
        Public Sub ReturnFalseGivenNonPrimesLessThan10(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.IsFalse(result, $"{value} should not be prime")
        End Sub
    End Class
    '</Sample_TestCode>
End Namespace
