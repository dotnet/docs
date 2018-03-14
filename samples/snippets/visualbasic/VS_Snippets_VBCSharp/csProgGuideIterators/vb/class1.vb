'<Snippet20>
Imports System.Collections
Imports System.Collections.Generic
'</Snippet20>

' Iterators (C# and Visual Basic)
' f45331db-d595-46ec-9142-551d3d1eb1a7

Public Class Example21
    '<Snippet21>
    Sub Main()
        For Each number As Integer In SomeNumbers()
            Console.Write(number & " ")
        Next
        ' Output: 3 5 8
        Console.ReadKey()
    End Sub

    Private Iterator Function SomeNumbers() As System.Collections.IEnumerable
        Yield 3
        Yield 5
        Yield 8
    End Function
    '</Snippet21>
End Class


Public Class Example22
    '<Snippet22>
    Sub Main()
        For Each number As Integer In EvenSequence(5, 18)
            Console.Write(number & " ")
        Next
        ' Output: 6 8 10 12 14 16 18
        Console.ReadKey()
    End Sub

    Private Iterator Function EvenSequence(
    ByVal firstNumber As Integer, ByVal lastNumber As Integer) _
    As System.Collections.Generic.IEnumerable(Of Integer)

        ' Yield even numbers in the range.
        For number As Integer = firstNumber To lastNumber
            If number Mod 2 = 0 Then
                Yield number
            End If
        Next
    End Function
    '</Snippet22>
End Class


Public Class Example23
    '<Snippet23>
    Sub Main()
        Dim days As New DaysOfTheWeek()
        For Each day As String In days
            Console.Write(day & " ")
        Next
        ' Output: Sun Mon Tue Wed Thu Fri Sat
        Console.ReadKey()
    End Sub

    Private Class DaysOfTheWeek
        Implements IEnumerable

        Public days =
            New String() {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"}

        Public Iterator Function GetEnumerator() As IEnumerator _
            Implements IEnumerable.GetEnumerator

            ' Yield each day of the week.
            For i As Integer = 0 To days.Length - 1
                Yield days(i)
            Next
        End Function
    End Class
    '</Snippet23>
End Class

Public Class Example24
    '<Snippet24>
    Sub Main()
        Dim theZoo As New Zoo()

        theZoo.AddMammal("Whale")
        theZoo.AddMammal("Rhinoceros")
        theZoo.AddBird("Penguin")
        theZoo.AddBird("Warbler")

        For Each name As String In theZoo
            Console.Write(name & " ")
        Next
        Console.WriteLine()
        ' Output: Whale Rhinoceros Penguin Warbler

        For Each name As String In theZoo.Birds
            Console.Write(name & " ")
        Next
        Console.WriteLine()
        ' Output: Penguin Warbler

        For Each name As String In theZoo.Mammals
            Console.Write(name & " ")
        Next
        Console.WriteLine()
        ' Output: Whale Rhinoceros

        Console.ReadKey()
    End Sub

    Public Class Zoo
        Implements IEnumerable

        ' Private members.
        Private animals As New List(Of Animal)

        ' Public methods.
        Public Sub AddMammal(ByVal name As String)
            animals.Add(New Animal With {.Name = name, .Type = Animal.TypeEnum.Mammal})
        End Sub

        Public Sub AddBird(ByVal name As String)
            animals.Add(New Animal With {.Name = name, .Type = Animal.TypeEnum.Bird})
        End Sub

        Public Iterator Function GetEnumerator() As IEnumerator _
            Implements IEnumerable.GetEnumerator

            For Each theAnimal As Animal In animals
                Yield theAnimal.Name
            Next
        End Function

        ' Public members.
        Public ReadOnly Property Mammals As IEnumerable
            Get
                Return AnimalsForType(Animal.TypeEnum.Mammal)
            End Get
        End Property

        Public ReadOnly Property Birds As IEnumerable
            Get
                Return AnimalsForType(Animal.TypeEnum.Bird)
            End Get
        End Property

        ' Private methods.
        Private Iterator Function AnimalsForType( _
        ByVal type As Animal.TypeEnum) As IEnumerable
            For Each theAnimal As Animal In animals
                If (theAnimal.Type = type) Then
                    Yield theAnimal.Name
                End If
            Next
        End Function

        ' Private class.
        Private Class Animal
            Public Enum TypeEnum
                Bird
                Mammal
            End Enum

            Public Property Name As String
            Public Property Type As TypeEnum
        End Class
    End Class
    '</Snippet24>
End Class


Public Class Example25
    '<Snippet25>
    Sub Main()
        For Each number As Integer In Test()
            Console.WriteLine(number)
        Next
        Console.WriteLine("For Each is done.")

        ' Output:
        '  3
        '  4
        '  Something happened. Yields are done.
        '  Finally is called.
        '  For Each is done.
        Console.ReadKey()
    End Sub

    Private Iterator Function Test() As IEnumerable(Of Integer)
        Try
            Yield 3
            Yield 4
            Throw New Exception("Something happened. Yields are done.")
            Yield 5
            Yield 6
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Console.WriteLine("Finally is called.")
        End Try
    End Function
    '</Snippet25>
End Class


Public Class Example26
    Sub Main()
        '<Snippet26>
        Dim iterateSequence = Iterator Function() _
                              As IEnumerable(Of Integer)
                                  Yield 1
                                  Yield 2
                              End Function

        For Each number As Integer In iterateSequence()
            Console.Write(number & " ")
        Next
        ' Output: 1 2
        Console.ReadKey()
        '</Snippet26>
    End Sub
End Class


Public Class Example27
    '<Snippet27>
    Sub Main()
        For Each number As Integer In GetSequence(5, 10)
            Console.Write(number & " ")
        Next
        ' Output: 5 6 7 8 9 10
        Console.ReadKey()
    End Sub

    Public Function GetSequence(ByVal low As Integer, ByVal high As Integer) _
    As IEnumerable
        ' Validate the arguments.
        If low < 1 Then
            Throw New ArgumentException("low is too low")
        End If
        If high > 140 Then
            Throw New ArgumentException("high is too high")
        End If

        ' Return an anonymous iterator function.
        Dim iterateSequence = Iterator Function() As IEnumerable
                                  For index = low To high
                                      Yield index
                                  Next
                              End Function
        Return iterateSequence()
    End Function
    '</Snippet27>
End Class


Public Class Example28
    '<Snippet28>
    Sub Main()
        Dim theStack As New Stack(Of Integer)

        ' Add items to the stack.
        For number As Integer = 0 To 9
            theStack.Push(number)
        Next

        ' Retrieve items from the stack.
        ' For Each is allowed because theStack implements
        ' IEnumerable(Of Integer).
        For Each number As Integer In theStack
            Console.Write("{0} ", number)
        Next
        Console.WriteLine()
        ' Output: 9 8 7 6 5 4 3 2 1 0

        ' For Each is allowed, because theStack.TopToBottom
        ' returns IEnumerable(Of Integer).
        For Each number As Integer In theStack.TopToBottom
            Console.Write("{0} ", number)
        Next
        Console.WriteLine()
        ' Output: 9 8 7 6 5 4 3 2 1 0

        For Each number As Integer In theStack.BottomToTop
            Console.Write("{0} ", number)
        Next
        Console.WriteLine()
        ' Output: 0 1 2 3 4 5 6 7 8 9 

        For Each number As Integer In theStack.TopN(7)
            Console.Write("{0} ", number)
        Next
        Console.WriteLine()
        ' Output: 9 8 7 6 5 4 3

        Console.ReadKey()
    End Sub

    Public Class Stack(Of T)
        Implements IEnumerable(Of T)

        Private values As T() = New T(99) {}
        Private top As Integer = 0

        Public Sub Push(ByVal t As T)
            values(top) = t
            top = top + 1
        End Sub

        Public Function Pop() As T
            top = top - 1
            Return values(top)
        End Function

        ' This function implements the GetEnumerator method. It allows
        ' an instance of the class to be used in a For Each statement.
        Public Iterator Function GetEnumerator() As IEnumerator(Of T) _
            Implements IEnumerable(Of T).GetEnumerator

            For index As Integer = top - 1 To 0 Step -1
                Yield values(index)
            Next
        End Function

        Public Iterator Function GetEnumerator1() As IEnumerator _
            Implements IEnumerable.GetEnumerator

            Yield GetEnumerator()
        End Function

        Public ReadOnly Property TopToBottom() As IEnumerable(Of T)
            Get
                Return Me
            End Get
        End Property

        Public ReadOnly Iterator Property BottomToTop As IEnumerable(Of T)
            Get
                For index As Integer = 0 To top - 1
                    Yield values(index)
                Next
            End Get
        End Property

        Public Iterator Function TopN(ByVal itemsFromTop As Integer) _
            As IEnumerable(Of T)

            ' Return less than itemsFromTop if necessary.
            Dim startIndex As Integer =
                If(itemsFromTop >= top, 0, top - itemsFromTop)

            For index As Integer = top - 1 To startIndex Step -1
                Yield values(index)
            Next
        End Function
    End Class
    '</Snippet28>
End Class
