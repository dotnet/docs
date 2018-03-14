'Option Strict On

Module m1
    Public Class ConsoleTest
        Shared Sub SetObject(ByVal o As Object)
        End Sub
        Sub Test()

            '<Snippet1>
            Dim strings As IEnumerable(Of String) = New List(Of String)
            Dim objects As IEnumerable(Of Object) = strings
            '</Snippet1>

            '<Snippet204>
            Dim actObj As Action(Of Object) = Sub(x) Console.WriteLine("object: {0}", x)
            Dim actStr As Action(Of String) = Sub(x) Console.WriteLine("string: {0}", x)

            ' The following statement throws an exception at run time.
            ' Dim actCombine = [Delegate].Combine(actStr, actObj)
            '</Snippet204>
        End Sub
        Sub Test2()
            '<Snippet102>
            Dim integers As IEnumerable(Of Integer) = New List(Of Integer)
            ' The following statement generates a compiler error
            ' with Option Strict On, because Integer is a value type.
            ' Dim objects As IEnumerable(Of Object) = integers
            '</Snippet102>

            '<Snippet103>
            ' The following statement generates a compiler error
            ' because classes are invariant.
            ' Dim list As List(Of Object) = New List(Of String)

            ' You can use the interface object instead.
            Dim listObjects As IEnumerable(Of Object) = New List(Of String)
            '</Snippet103>

        End Sub

        Shared Sub Test3()

            '<Snippet205>
            ' Assignment compatibility. 
            Dim str As String = "test"
            ' An object of a more derived type is assigned to an object of a less derived type. 
            Dim obj As Object = str

            ' Covariance. 
            Dim strings As IEnumerable(Of String) = New List(Of String)()
            ' An object that is instantiated with a more derived type argument 
            ' is assigned to an object instantiated with a less derived type argument. 
            ' Assignment compatibility is preserved. 
            Dim objects As IEnumerable(Of Object) = strings

            ' Contravariance.           
            ' Assume that there is the following method in the class: 
            ' Shared Sub SetObject(ByVal o As Object)
            ' End Sub
            Dim actObject As Action(Of Object) = AddressOf SetObject

            ' An object that is instantiated with a less derived type argument 
            ' is assigned to an object instantiated with a more derived type argument. 
            ' Assignment compatibility is reversed. 
            Dim actString As Action(Of String) = actObject
            '</Snippet205>


            '<Snippet202>
            Dim array() As Object = New String(10) {}
            ' The following statement produces a run-time exception.
            ' array(0) = 10
            '</Snippet202>
        End Sub

    End Class
End Module

Module m101
    '<Snippet101>
    ' Simple hierarchy of classes.
    Class BaseClass
    End Class

    Class DerivedClass
        Inherits BaseClass
    End Class

    ' Comparer class.
    Class BaseComparer
        Implements IEqualityComparer(Of BaseClass)

        Public Function Equals1(ByVal x As BaseClass,
                                ByVal y As BaseClass) As Boolean _
                                Implements IEqualityComparer(Of BaseClass).Equals
            Return (x.Equals(y))
        End Function

        Public Function GetHashCode1(ByVal obj As BaseClass) As Integer _
            Implements IEqualityComparer(Of BaseClass).GetHashCode
            Return obj.GetHashCode
        End Function
    End Class
    Sub Test()
        Dim baseComparer As IEqualityComparer(Of BaseClass) = New BaseComparer
        ' Implicit conversion of IEqualityComparer(Of BaseClass) to 
        ' IEqualityComparer(Of DerivedClass).
        Dim childComparer As IEqualityComparer(Of DerivedClass) = baseComparer
    End Sub
    '</Snippet101>
End Module

Module m2
    '<Snippet3>
    Interface ICovariant(Of Out R)
        Function GetSomething() As R
        ' The following statement generates a compiler error.
        ' Sub SetSomething(ByVal sampleArg As R)
    End Interface
    '</Snippet3>
End Module

Module m3
    '<Snippet4>
    Interface ICovariant(Of Out R)
        Sub DoSomething(ByVal callback As Action(Of R))
    End Interface
    '</Snippet4>
End Module

Module m4
    '<Snippet5>
    Interface ICovariant(Of Out R)
        ' The following statement generates a compiler error
        ' because you can use only contravariant or invariant types
        ' in generic contstraints.
        ' Sub DoSomething(Of T As R)()
    End Interface
    '</Snippet5>

    '<Snippet6>
    Interface IContravariant(Of In A)
        Sub SetSomething(ByVal sampleArg As A)
        Sub DoSomething(Of T As A)()
        ' The following statement generates a compiler error.
        ' Function GetSomething() As A
    End Interface
    '</Snippet6>

    '<Snippet7>
    Interface IVariant(Of Out R, In A)
        Function GetSomething() As R
        Sub SetSomething(ByVal sampleArg As A)
        Function GetSetSomething(ByVal sampleArg As A) As R
    End Interface
    '</Snippet7>
End Module

Module m5
    '<Snippet77>
    Interface ICovariant(Of Out R)
        ' The following statement generates a compiler error.
        ' Event SampleEvent()
        ' The following statement specifies the delegate type and 
        ' does not generate an error.
        Event AnotherEvent As EventHandler

        ' The following statements generate compiler errors,
        ' because a variant interface cannot have
        ' nested enums, classes, or structures.

        'Enum SampleEnum : test : End Enum
        'Class SampleClass : End Class
        'Structure SampleStructure : Dim value As Integer : End Structure

        ' Variant interfaces can have nested interfaces.
        Interface INested : End Interface
    End Interface
    '</Snippet77>
End Module

Module m6
    '<Snippet8>
    Interface ICovariant(Of Out R)
        Function GetSomething() As R
    End Interface

    Class SampleImplementation(Of R)
        Implements ICovariant(Of R)
        Public Function GetSomething() As R _
        Implements ICovariant(Of R).GetSomething
            ' Some code.
        End Function
    End Class
    '</Snippet8>

    '<Snippet9>
    ' The interface is covariant.
    Dim ibutton As ICovariant(Of Button) =
        New SampleImplementation(Of Button)
    Dim iobj As ICovariant(Of Object) = ibutton

    ' The class is invariant.
    Dim button As SampleImplementation(Of Button) =
        New SampleImplementation(Of Button)
    ' The following statement generates a compiler error
    ' because classes are invariant.
    ' Dim obj As SampleImplementation(Of Object) = button
    '</Snippet9>
End Module

Module m7
    '<Snippet10>
    Interface ICovariant(Of Out T)
    End Interface

    Interface IInvariant(Of T)
        Inherits ICovariant(Of T)
    End Interface

    Interface IExtCovariant(Of Out T)
        Inherits ICovariant(Of T)
    End Interface
    '</Snippet10>
End Module

Module m8
    '<Snippet11>
    Interface ICovariant(Of Out T)
    End Interface

    Interface IContravariant(Of In T)
    End Interface

    Interface IInvariant(Of T)
        Inherits ICovariant(Of T), IContravariant(Of T)
    End Interface
    '</Snippet11>
End Module

Module m9
    '<Snippet12>
    Interface ICovariant(Of Out T)
    End Interface

    ' The following statements generate a compiler error.
    ' Interface ICoContraVariant(Of In T)
    '     Inherits ICovariant(Of T)
    ' End Interface
    '</Snippet12>
End Module

Module m10
    '<Snippet13>
    ' Simple class hierarchy.
    Class Animal
    End Class

    Class Cat
        Inherits Animal
    End Class

    Class Dog
        Inherits Animal
    End Class

    ' This class introduces ambiguity
    ' because IEnumerable(Of Out T) is covariant.
    Class Pets
        Implements IEnumerable(Of Cat), IEnumerable(Of Dog)

        Public Function GetEnumerator() As IEnumerator(Of Cat) _
            Implements IEnumerable(Of Cat).GetEnumerator
            Console.WriteLine("Cat")
            ' Some code.
        End Function

        Public Function GetEnumerator1() As IEnumerator(Of Dog) _
            Implements IEnumerable(Of Dog).GetEnumerator
            Console.WriteLine("Dog")
            ' Some code.
        End Function

        Public Function GetEnumerator2() As IEnumerator _
            Implements IEnumerable.GetEnumerator
            ' Some code.
        End Function
    End Class

    Sub Main()
        Dim pets As IEnumerable(Of Animal) = New Pets()
        pets.GetEnumerator()
    End Sub
    '</Snippet13>
End Module

Module m11
    '<Snippet14>
    ' Simple hierarchy of classes.
    Public Class Person
        Public Property FirstName As String
        Public Property LastName As String
    End Class

    Public Class Employee
        Inherits Person
    End Class

    ' The method has a parameter of the IEnumerable(Of Person) type.
    Public Sub PrintFullName(ByVal persons As IEnumerable(Of Person))
        For Each person As Person In persons
            Console.WriteLine(
                "Name: " & person.FirstName & " " & person.LastName)
        Next
    End Sub

    Sub Main()
        Dim employees As IEnumerable(Of Employee) = New List(Of Employee)

        ' You can pass IEnumerable(Of Employee), 
        ' although the method expects IEnumerable(Of Person).

        PrintFullName(employees)

    End Sub
    '</Snippet14>
End Module

Module m12

    '<Snippet15>
    ' Simple hierarhcy of classes.
    Public Class Person
        Public Property FirstName As String
        Public Property LastName As String
    End Class

    Public Class Employee
        Inherits Person
    End Class
    ' The custom comparer for the Person type
    ' with standard implementations of Equals()
    ' and GetHashCode() methods.
    Class PersonComparer
        Implements IEqualityComparer(Of Person)

        Public Function Equals1(
            ByVal x As Person,
            ByVal y As Person) As Boolean _
            Implements IEqualityComparer(Of Person).Equals

            If x Is y Then Return True
            If x Is Nothing OrElse y Is Nothing Then Return False
            Return (x.FirstName = y.FirstName) AndAlso
                (x.LastName = y.LastName)
        End Function
        Public Function GetHashCode1(
            ByVal person As Person) As Integer _
            Implements IEqualityComparer(Of Person).GetHashCode

            If person Is Nothing Then Return 0
            Dim hashFirstName =
                If(person.FirstName Is Nothing,
                0, person.FirstName.GetHashCode())
            Dim hashLastName = person.LastName.GetHashCode()
            Return hashFirstName Xor hashLastName
        End Function
    End Class

    Sub Main()
        Dim employees = New List(Of Employee) From {
            New Employee With {.FirstName = "Michael", .LastName = "Alexander"},
            New Employee With {.FirstName = "Jeff", .LastName = "Price"}
        }

        ' You can pass PersonComparer, 
        ' which implements IEqualityComparer(Of Person),
        ' although the method expects IEqualityComparer(Of Employee)

        Dim noduplicates As IEnumerable(Of Employee) = employees.Distinct(New PersonComparer())

        For Each employee In noduplicates
            Console.WriteLine(employee.FirstName & " " & employee.LastName)
        Next
    End Sub
    '</Snippet15>
End Module

Module m13
    '<Snippet16>
    Public Delegate Function DCovariant(Of Out R)() As R
    '</Snippet16>

    '<Snippet17>
    Public Delegate Sub DContravariant(Of In A)(ByVal a As A)
    '</Snippet17>

    '<Snippet18>
    Public Delegate Function DVariant(Of In A, Out R)(ByVal a As A) As R
    '</Snippet18>
    Sub Test1()
        '<Snippet19>
        Dim dvariant As DVariant(Of String, String) = Function(str) str + " "
        dvariant("test")
        '</Snippet19>
    End Sub
End Module

Module m14
    '<Snippet20>
    Public Class First
    End Class

    Public Class Second
        Inherits First
    End Class

    Public Delegate Function SampleDelegate(ByVal a As Second) As First
    Public Delegate Function SampleGenericDelegate(Of A, R)(ByVal a As A) As R
    '</Snippet20>


    Class Test
        '<Snippet21>
        ' Matching signature.
        Public Shared Function ASecondRFirst(
            ByVal second As Second) As First
            Return New First()
        End Function

        ' The return type is more derived.
        Public Shared Function ASecondRSecond(
            ByVal second As Second) As Second
            Return New Second()
        End Function

        ' The argument type is less derived.
        Public Shared Function AFirstRFirst(
            ByVal first As First) As First
            Return New First()
        End Function

        ' The return type is more derived 
        ' and the argument type is less derived.
        Public Shared Function AFirstRSecond(
            ByVal first As First) As Second
            Return New Second()
        End Function
        '</Snippet21>

        Public Sub MainTest()
            '<Snippet22>
            ' Assigning a method with a matching signature 
            ' to a non-generic delegate. No conversion is necessary.
            Dim dNonGeneric As SampleDelegate = AddressOf ASecondRFirst
            ' Assigning a method with a more derived return type 
            ' and less derived argument type to a non-generic delegate.
            ' The implicit conversion is used.
            Dim dNonGenericConversion As SampleDelegate = AddressOf AFirstRSecond

            ' Assigning a method with a matching signature to a generic delegate.
            ' No conversion is necessary.
            Dim dGeneric As SampleGenericDelegate(Of Second, First) = AddressOf ASecondRFirst
            ' Assigning a method with a more derived return type 
            ' and less derived argument type to a generic delegate.
            ' The implicit conversion is used.
            Dim dGenericConversion As SampleGenericDelegate(Of Second, First) = AddressOf AFirstRSecond
            '</Snippet22>
        End Sub
    End Class


End Module

Module m104
    '<Snippet104>
    Public Delegate Function SampleGenericDelegate(Of T)() As T
    Sub Test()
        Dim dString As SampleGenericDelegate(Of String) = Function() " "

        ' You can assign the dObject delegate
        ' to the same lambda expression as dString delegate
        ' because of the variance support for 
        ' matching method signatures with delegate types.
        Dim dObject As SampleGenericDelegate(Of Object) = Function() " "

        ' The following statement generates a compiler error
        ' because the generic type T is not marked as covariant.
        ' Dim dObject As SampleGenericDelegate(Of Object) = dString

        
    End Sub
    '</Snippet104>
End Module

Module m105
    '<Snippet105>
    ' Type T is declared covariant by using the out keyword.
    Public Delegate Function SampleGenericDelegate(Of Out T)() As T
    Sub Test()
        Dim dString As SampleGenericDelegate(Of String) = Function() " "
        ' You can assign delegates to each other,
        ' because the type T is declared covariant.
        Dim dObject As SampleGenericDelegate(Of Object) = dString
    End Sub
    '</Snippet105>
End Module

Module M106
    '<Snippet106>
    ' The type T is covariant.
    Public Delegate Function DVariant(Of Out T)() As T
    ' The type T is invariant.
    Public Delegate Function DInvariant(Of T)() As T
    Sub Test()
        Dim i As Integer = 0
        Dim dInt As DInvariant(Of Integer) = Function() i
        Dim dVaraintInt As DVariant(Of Integer) = Function() i

        ' All of the following statements generate a compiler error
        ' because type variance in generic parameters is not supported
        ' for value types, even if generic type parameters are declared variant.
        ' Dim dObject As DInvariant(Of Object) = dInt
        ' Dim dLong As DInvariant(Of Long) = dInt
        ' Dim dVaraintObject As DInvariant(Of Object) = dInt
        ' Dim dVaraintLong As DInvariant(Of Long) = dInt
    End Sub
    '</Snippet106>
End Module

Module m15
    '<Snippet23>
    ' Simple hierarchy of classes.
    Public Class Person
    End Class

    Public Class Employee
        Inherits Person
    End Class

    Class Finder
        Public Shared Function FindByTitle(
            ByVal title As String) As Employee
            ' This is a stub for a method that returns
            ' an employee that has the specified title.
            Return New Employee
        End Function

        Sub Test()
            ' Create an instance of the delegate without using variance.
            Dim findEmployee As Func(Of String, Employee) =
                AddressOf FindByTitle

            ' The delegate expects a method to return Person,
            ' but you can assign it a method that returns Employee.
            Dim findPerson As Func(Of String, Person) =
                AddressOf FindByTitle

            ' You can also assign a delegate 
            ' that returns a more derived type to a delegate 
            ' that returns a less derived type.
            findPerson = findEmployee
        End Sub
    End Class
    '</Snippet23>
End Module

Module m16
    '<Snippet24>
    Public Class Person
    End Class

    Public Class Employee
        Inherits Person
    End Class

    Class AddressBook
        Shared Sub AddToContacts(ByVal person As Person)
            ' This method adds a Person object
            ' to a contact list.
        End Sub

        Sub Test()
            ' Create an instance of the delegate without using variance.
            Dim addPersonToContacts As Action(Of Person) =
                AddressOf AddToContacts

            ' The Action delegate expects 
            ' a method that has an Employee parameter,
            ' but you can assign it a method that has a Person parameter
            ' because Employee derives from Person.
            Dim addEmployeeToContacts As Action(Of Employee) =
                AddressOf AddToContacts

            ' You can also assign a delegate 
            ' that accepts a less derived parameter 
            ' to a delegate that accepts a more derived parameter.
            addEmployeeToContacts = addPersonToContacts
        End Sub
    End Class
    '</Snippet24>
End Module

Module m17
    Class Test
        '<Snippet203>
        Shared Function GetObject() As Object
            Return Nothing
        End Function

        Shared Sub SetObject(ByVal obj As Object)
        End Sub

        Shared Function GetString() As String
            Return ""
        End Function

        Shared Sub SetString(ByVal str As String)

        End Sub

        Shared Sub Test()
            ' Covariance. A delegate specifies a return type as object,
            ' but you can assign a method that returns a string.
            Dim del As Func(Of Object) = AddressOf GetString

            ' Contravariance. A delegate specifies a parameter type as string,
            ' but you can assign a method that takes an object.
            Dim del2 As Action(Of String) = AddressOf SetObject
        End Sub
        '</Snippet203>
    End Class
End Module