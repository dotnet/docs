' <Snippet2>
Imports System
Imports System.Collections

Public Class HashtableExample
    Public Shared Sub Main()
        ' Creates and initializes a new Hashtable.
        Dim clouds As New Hashtable()
        clouds.Add("Cirrus", "Castellanus")
        clouds.Add("Cirrocumulus", "Stratiformis")
        clouds.Add("Altostratus", "Radiatus")
        clouds.Add("Stratocumulus", "Perlucidus")
        clouds.Add("Stratus", "Fractus")
        clouds.Add("Nimbostratus", "Pannus")
        clouds.Add("Cumulus", "Humilis")
        clouds.Add("Cumulonimbus", "Incus")

        ' Displays the keys and values of the Hashtable using GetEnumerator()

        Dim denum As IDictionaryEnumerator = clouds.GetEnumerator()
        Dim dentry As DictionaryEntry

        Console.WriteLine()
        Console.WriteLine("    Cloud Type       Variation")
        Console.WriteLine("    -----------------------------")
        While denum.MoveNext()
            dentry = CType(denum.Current, DictionaryEntry)
            Console.WriteLine("    {0,-17}{1}", dentry.Key, dentry.Value)
        End While
        Console.WriteLine()

        ' Displays the keys and values of the Hashtable using foreach statement

        Console.WriteLine("    Cloud Type       Variation")
        Console.WriteLine("    -----------------------------")
        For Each de As DictionaryEntry in clouds
            Console.WriteLine("    {0,-17}{1}", de.Key, de.Value)
        Next de
        Console.WriteLine()
    End Sub
End Class

' The program displays the following output to the console:
'
'    Cloud Type       Variation
'    -----------------------------
'    Cirrocumulus     Stratiformis
'    Stratocumulus    Perlucidus
'    Cirrus           Castellanus
'    Cumulus          Humilis
'    Nimbostratus     Pannus
'    Stratus          Fractus
'    Altostratus      Radiatus
'    Cumulonimbus     Incus
'
'    Cloud Type       Variation
'    -----------------------------
'    Cirrocumulus     Stratiformis
'    Stratocumulus    Perlucidus
'    Cirrus           Castellanus
'    Cumulus          Humilis
'    Nimbostratus     Pannus
'    Stratus          Fractus
'    Altostratus      Radiatus
'    Cumulonimbus     Incus*/
' </Snippet2>