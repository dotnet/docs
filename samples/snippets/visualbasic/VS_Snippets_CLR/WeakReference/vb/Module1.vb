' <Snippet1>
Imports System.Collections.Generic

Public Class Example
    Public Shared Sub Main()
        ' Create the cache. 
        Dim cacheSize As Integer = 50
        Dim r As Random = New Random()
        Dim c As Cache = New Cache(cacheSize)

        Dim DataName As String = "" 
        GC.Collect(0)
        
        ' Randomly access objects in the cache. 
        For ctr As Integer = 0 To C.Count - 1 
            Dim index As Integer = r.Next(c.Count)

            ' Access the object by getting a property value.
            DataName = c(index).Name
        Next 

        ' Show results. 
        Dim regenPercent As Double = c.RegenerationCount * 100 / c.Count
        Console.WriteLine("Cache size: {0}, Regenerated: {1}%", c.Count, regenPercent)
    End Sub 
End Class 

Public Class Cache
    ' Dictionary to contain the cache. 
    Private Shared _cache As Dictionary(Of Integer, WeakReference)

    ' Track the number of times an object is regenerated. 
    Dim regenCount As Integer = 0

    Public Sub New(ByVal count As Integer)
        _cache = New Dictionary(Of Integer, WeakReference)

' <Snippet2>
        ' Add data objects with a short weak reference to the cache. 
        For ctr = 0 To count - 1
            _cache.Add(ctr, New WeakReference(New Data(ctr)))
        Next
' </Snippet2>
    End Sub 

    ' Number of items in the cache. 
    Public ReadOnly Property Count() As Integer 
        Get 
            Return _cache.Count
        End Get 
    End Property 

    ' Number of times an object needs to be regenerated. 
    Public ReadOnly Property RegenerationCount() As Integer 
        Get 
            Return regenCount
        End Get 
    End Property 

    ' Retrieve a data object from the cache. 
    Default Public ReadOnly Property Item(ByVal index As Integer) As Data
        Get 
' <Snippet3>
            Dim d As Data = TryCast(_cache(index).Target, Data)
            ' If the object was reclaimed, generate a new one.
            If d Is Nothing Then 
                Console.WriteLine("Regenerate object at {0}: Yes", index)
                d = New Data(index)
                _cache(index).Target = d
                regenCount += 1
           Else 
                ' Object was obtained with the weak reference.
                Console.WriteLine("Regenerate object at {0}: No", index.ToString())
            End If 
            Return d
' </Snippet3>
        End Get 
    End Property 
End Class 

' Class that creates byte arrays to simulate data. 
Public Class Data
    Private _data() As Byte 
    Private _name As String 

    Public Sub New(ByVal size As Integer)
        _data = New Byte(((size * 1024)) - 1) {}
        _name = size.ToString
    End Sub 

    ' Simple property for accessing the object. 
    Public ReadOnly Property Name() As String 
        Get 
            Return _name
        End Get 
    End Property 
End Class 
' Example of the last lines of the output: 
' ... 
' Regenerate object at 36: Yes 
' Regenerate object at 8: Yes 
' Regenerate object at 21: Yes 
' Regenerate object at 4: Yes 
' Regenerate object at 38: No 
' Regenerate object at 7: Yes 
' Regenerate object at 2: Yes 
' Regenerate object at 43: Yes 
' Regenerate object at 38: No 
' Cache size: 50, Regenerated: 94% 
 ' </Snippet1>