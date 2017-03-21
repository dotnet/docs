    ' Displays the contents of the OrderedDictionary using its enumerator
    Public Shared Sub DisplayEnumerator( _
        ByVal myEnumerator As IDictionaryEnumerator)

        Console.WriteLine("   KEY                       VALUE")
        While myEnumerator.MoveNext()
            Console.WriteLine("   {0,-25} {1}", _
                myEnumerator.Key, myEnumerator.Value)
        End While
    End Sub