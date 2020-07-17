Imports Xunit

Namespace PrimeService.Tests
    '<Sample_TestCode>
    Public Class PrimeService_IsPrimeShould
        Private _primeService As Prime.Services.PrimeService = New Prime.Services.PrimeService()

        <Theory>
        <InlineData(-1)>
        <InlineData(0)>
        <InlineData(1)>
        Sub IsPrime_ValueLessThan2_ReturnFalse(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.False(result, $"{value} should not be prime")
        End Sub

        <Theory>
        <InlineData(2)>
        <InlineData(3)>
        <InlineData(5)>
        <InlineData(7)>
        Public Sub IsPrime_PrimesLessThan10_ReturnTrue(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.True(result, $"{value} should be prime")
        End Sub

        <Theory>
        <InlineData(4)>
        <InlineData(6)>
        <InlineData(8)>
        <InlineData(9)>
        Public Sub IsPrime_NonPrimesLessThan10_ReturnFalse(value As Integer)
            Dim result As Boolean = _primeService.IsPrime(value)

            Assert.False(result, $"{value} should not be prime")
        End Sub
    End Class
    '</Sample_TestCode>
End Namespace
