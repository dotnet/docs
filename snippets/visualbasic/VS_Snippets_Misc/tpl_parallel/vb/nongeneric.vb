Imports System.Linq
Imports System.Collections
Imports System.Threading.Tasks
Module Module1

    Sub Main()
        Dim nonGenericCollection As New ArrayList()

        '<snippet07>
        Parallel.ForEach(nonGenericCollection.Cast(Of Object), _
                         Sub(currentElement)
                             ' ... work with currentElement
                         End Sub)
        '</snippet07>
    End Sub

End Module
