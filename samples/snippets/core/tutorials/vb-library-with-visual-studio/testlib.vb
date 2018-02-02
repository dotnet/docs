Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports UtilityLibraries

Namespace StringLibraryTest
    <TestClass>
    Public Class UnitTest1
        <TestMethod>
        Public Sub TestStartsWithUpper()
            ' Tests that we expect to return true.
            Dim words() As String = {"Alphabet", "Zebra", "ABC", "Αθήνα", "Москва"}
            For Each word In words
                Dim result As Boolean = word.StartsWithUpper()
                Assert.IsTrue(result,
                       $"Expected for '{word}': true; Actual: {result}")
            Next
        End Sub

        <TestMethod>
        Public Sub TestDoesNotStartWithUpper()
            ' Tests that we expect to return false.
            Dim words() As String = {"alphabet", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                               "1234", ".", ";", " "}
            For Each word In words
                Dim result As Boolean = word.StartsWithUpper()
                Assert.IsFalse(result,
                       $"Expected for '{word}': false; Actual: {result}")
            Next
        End Sub

        <TestMethod>
        Public Sub DirectCallWithNullOrEmpty()
            ' Tests that we expect to return false.
            Dim words() As String = {String.Empty, Nothing}
            For Each word In words
                Dim result As Boolean = StringLibrary.StartsWithUpper(word)
                Assert.IsFalse(result,
                       $"Expected for '{If(word Is Nothing, "<null>", word)}': false; Actual: {result}")
            Next
        End Sub
    End Class
End Namespace
