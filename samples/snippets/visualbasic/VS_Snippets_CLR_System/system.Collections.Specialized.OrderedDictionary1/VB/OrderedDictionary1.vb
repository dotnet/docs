'<Snippet00>
' The following code example enumerates the elements of a OrderedDictionary.
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class OrderedDictionarySample

    Public Shared Sub Main()

        '<Snippet01>
        ' Creates and initializes a OrderedDictionary.
        Dim myOrderedDictionary As New OrderedDictionary()
        myOrderedDictionary.Add("testKey1", "testValue1")
        myOrderedDictionary.Add("testKey2", "testValue2")
        myOrderedDictionary.Add("keyToDelete", "valueToDelete")
        myOrderedDictionary.Add("testKey3", "testValue3")

        Dim keyCollection As ICollection = myOrderedDictionary.Keys
        Dim valueCollection As ICollection = myOrderedDictionary.Values

        ' Display the contents Imports the key and value collections
        DisplayContents( _
            keyCollection, valueCollection, myOrderedDictionary.Count)
        '</Snippet01>

        '<Snippet02>
        ' Modifying the OrderedDictionary
        If Not myOrderedDictionary.IsReadOnly Then

            ' Insert a new key to the beginning of the OrderedDictionary
            myOrderedDictionary.Insert(0, "insertedKey1", "insertedValue1")

            ' Modify the value of the entry with the key "testKey2"
            myOrderedDictionary("testKey2") = "modifiedValue"

            ' Remove the last entry from the OrderedDictionary: "testKey3"
            myOrderedDictionary.RemoveAt(myOrderedDictionary.Count - 1)

            ' Remove the "keyToDelete" entry, if it exists
            If (myOrderedDictionary.Contains("keyToDelete")) Then
                myOrderedDictionary.Remove("keyToDelete")
            End If
        End If
        '</Snippet02>

        Console.WriteLine( _
            "{0}Displaying the entries of a modified OrderedDictionary.", _
            Environment.NewLine)
        DisplayContents( _
            keyCollection, valueCollection, myOrderedDictionary.Count)

        '<Snippet03>
        ' Clear the OrderedDictionary and add new values
        myOrderedDictionary.Clear()
        myOrderedDictionary.Add("newKey1", "newValue1")
        myOrderedDictionary.Add("newKey2", "newValue2")
        myOrderedDictionary.Add("newKey3", "newValue3")

        ' Display the contents of the "new" Dictionary Imports an enumerator
        Dim myEnumerator As IDictionaryEnumerator = _
            myOrderedDictionary.GetEnumerator()

        Console.WriteLine( _
            "{0}Displaying the entries of a 'new' OrderedDictionary.", _
            Environment.NewLine)

        DisplayEnumerator(myEnumerator)
        '</Snippet03>

        Console.ReadLine()
    End Sub

    '<Snippet04>
    ' Displays the contents of the OrderedDictionary from its keys and values
    Public Shared Sub DisplayContents( _
        ByVal keyCollection As ICollection, _
        ByVal valueCollection As ICollection, ByVal dictionarySize As Integer)

        Dim myKeys(dictionarySize) As [String]
        Dim myValues(dictionarySize) As [String]
        keyCollection.CopyTo(myKeys, 0)
        valueCollection.CopyTo(myValues, 0)

        ' Displays the contents of the OrderedDictionary
        Console.WriteLine("   INDEX KEY                       VALUE")
        Dim i As Integer
        For i = 0 To dictionarySize - 1
            Console.WriteLine("   {0,-5} {1,-25} {2}", _
                 i, myKeys(i), myValues(i))
        Next i
        Console.WriteLine()
    End Sub
    '</Snippet04>

    '<Snippet05>
    ' Displays the contents of the OrderedDictionary using its enumerator
    Public Shared Sub DisplayEnumerator( _
        ByVal myEnumerator As IDictionaryEnumerator)

        Console.WriteLine("   KEY                       VALUE")
        While myEnumerator.MoveNext()
            Console.WriteLine("   {0,-25} {1}", _
                myEnumerator.Key, myEnumerator.Value)
        End While
    End Sub
    '</Snippet05>
End Class

'This code produces the following output.
'
'   INDEX KEY                       VALUE
'0:              testKey1(testValue1)
'1:              testKey2(testValue2)
'2:              keyToDelete(valueToDelete)
'3:              testKey3(testValue3)
'
'
'Displaying the entries of a modified OrderedDictionary.
'   INDEX KEY                       VALUE
'0:              insertedKey1(insertedValue1)
'1:              testKey1(testValue1)
'2:              testKey2(modifiedValue)
'
'
'Displaying the entries of a "new" OrderedDictionary.
'                KEY(VALUE)
'                newKey1(newValue1)
'                newKey2(newValue2)
'                newKey3(newValue3)
'</Snippet00>
