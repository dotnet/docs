 '<Snippet1>
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Reflection



Class DebugViewTest
    ' The following constant will appear in the debug window for DebugViewTest.
    Const TabString As String = "    "
    '<Snippet2>
    ' The following DebuggerBrowsableAttribute prevents the property following it
    ' from appearing in the debug window for the class.
    <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
    Public Shared y As String = "Test String"
    '</Snippet2>

    Shared Sub Main() 
        Dim myHashTable As New MyHashtable()
        myHashTable.Add("one", 1)
        myHashTable.Add("two", 2)
        Console.WriteLine(myHashTable.ToString())
        Console.WriteLine("In Main.")

    End Sub 'Main 
End Class 'DebugViewTest
'<Snippet3>
<DebuggerDisplay("{value}", Name := "{key}")>  _
Friend Class KeyValuePairs
    Private dictionary As IDictionary
    Private key As Object
    Private value As Object
    
    
    Public Sub New(ByVal dictionary As IDictionary, ByVal key As Object, ByVal value As Object) 
        Me.value = value
        Me.key = key
        Me.dictionary = dictionary

    End Sub 'New
End Class 'KeyValuePairs
'</Snippet3>
'<Snippet4>
'<Snippet5>
<DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(GetType(MyHashtable.HashtableDebugView))> _
Class MyHashtable
    Inherits Hashtable
    '</Snippet4>
    Private Const TestString As String = "This should not appear in the debug window."

    Friend Class HashtableDebugView
        Private hashtable As Hashtable
        Public Shared TestString As String = "This should appear in the debug window."

        Public Sub New(ByVal hashtable As Hashtable)
            Me.hashtable = hashtable
        End Sub 'New

        '<Snippet6>
        <DebuggerBrowsable(DebuggerBrowsableState.RootHidden)> _
        ReadOnly Property Keys as KeyValuePairs()
            Get
                Dim nkeys(hashtable.Count) as KeyValuePairs

                Dim i as Integer = 0
                For Each key As Object In hashtable.Keys
                    nkeys(i) = New KeyValuePairs(hashtable, key, hashtable(key))
                    i = i + 1
                Next
                Return nkeys
            End Get
        End Property
        '</Snippet6>

    End Class 'HashtableDebugView
End Class 'MyHashtable
'</Snippet5>
'</Snippet1>

