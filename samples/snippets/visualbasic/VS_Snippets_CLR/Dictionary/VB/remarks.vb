Imports System
Imports System.Collections

Public Class SimpleDictionary
    Inherits DictionaryBase
End Class

Public Class DictionaySamples
    Public Shared Sub Main()
        ' Create a dictionary that contains no more than three entries.
        Dim myDictionary As IDictionary = New SimpleDictionary()

        ' Add three people and their ages to the dictionary.
        myDictionary.Add("Jeff", 40)
        myDictionary.Add("Kristin", 34)
        myDictionary.Add("Aidan", 1)
        ' Display every entry's key and value.
        For Each de As DictionaryEntry In myDictionary
            Console.WriteLine("{0} is {1} years old.", de.Key, de.Value)
        Next de

        ' Remove an entry that exists.
        myDictionary.Remove("Jeff")

        ' Remove an entry that does not exist, but do not throw an exception.
        myDictionary.Remove("Max")

        ' <Snippet14>
        For Each de As DictionaryEntry In myDictionary
            '...
        Next de
        ' </Snippet14>
    End Sub
End Class
