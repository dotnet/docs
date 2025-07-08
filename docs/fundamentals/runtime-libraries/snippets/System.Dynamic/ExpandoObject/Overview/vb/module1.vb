Imports System.Dynamic
Imports System.ComponentModel
Imports System.Linq
Imports System.Collections.Generic

Module Module2

    Sub Test()
        '<Snippet1>
        Dim sampleObject As Object = New ExpandoObject()
        '</Snippet1>

        '<Snippet2>
        sampleObject.Test = "Dynamic Property"
        Console.WriteLine(sampleObject.test)
        Console.WriteLine(sampleObject.test.GetType())
        ' This code example produces the following output:
        ' Dynamic Property
        ' System.String
        '</Snippet2>

        '<Snippet3>
        sampleObject.Number = 10
        sampleObject.Increment = Function() sampleObject.Number + 1
        ' Before calling the Increment method.
        Console.WriteLine(sampleObject.number)

        sampleObject.Increment.Invoke()

        ' After calling the Increment method.
        Console.WriteLine(sampleObject.number)
        ' This code example produces the following output:
        ' 10
        ' 11
        '</Snippet3>

        '<Snippet5>
        Dim employee As Object = New ExpandoObject()
        employee.Name = "John Smith"
        employee.Age = 33
        For Each member In CType(employee, IDictionary(Of String, Object))
            Console.WriteLine(member.Key & ": " & member.Value)
        Next
        ' This code example produces the following output:
        ' Name: John Smith
        ' Age: 33
        '</Snippet5>
    End Sub

    Sub Test2()
        '<Snippet6>
        Dim employee As Object = New ExpandoObject()
        employee.Name = "John Smith"
        CType(employee, IDictionary(Of String, Object)).Remove("Name")
        '</Snippet6>
    End Sub

End Module

Module Module1

    '<Snippet4>
    Sub Main()
        Dim employee, manager As Object

        employee = New ExpandoObject()
        employee.Name = "John Smith"
        employee.Age = 33

        manager = New ExpandoObject()
        manager.Name = "Allison Brown"
        manager.Age = 42
        manager.TeamSize = 10

        WritePerson(manager)
        WritePerson(employee)
    End Sub

    Private Sub WritePerson(ByVal person As Object)

        Console.WriteLine("{0} is {1} years old.",
                          person.Name, person.Age)
        ' The following statement causes an exception
        ' if you pass the employee object.
        ' Console.WriteLine("Manages {0} people", person.TeamSize)

    End Sub
    '</Snippet4>
End Module

Module M3
    '<Snippet7>
    ' Add "Imports System.ComponentModel" line 
    ' to the beginning of the file.
    Sub Main()
        Dim employee As Object = New ExpandoObject
        AddHandler CType(
            employee, INotifyPropertyChanged).PropertyChanged,
            AddressOf HandlePropertyChanges
        employee.Name = "John Smith"
    End Sub

    Private Sub HandlePropertyChanges(
           ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Console.WriteLine("{0} has changed.", e.PropertyName)
    End Sub
    '</Snippet7>
End Module

