'<Snippet1>
Imports System
Imports System.Reflection

Public Module CustomAttrVB

    ' An enumeration of animals. Start at 1 (0 = uninitialized).
    Public Enum Animal
        ' Pets
        Dog = 1
        Cat
        Bird
    End Enum

    ' Visual Basic requires the AttributeUsage be specified.
    ' A custom attribute to allow a target to have a pet.
    <AttributeUsage(AttributeTargets.Method)> _
    Public Class AnimalTypeAttribute
        Inherits Attribute

        ' The constructor is called when the attribute is set.
        Public Sub New(ByVal animal As Animal)
            Me.thePet = animal
        End Sub

        ' Keep a variable internally ...
        Protected thePet As Animal

        ' .. and show a copy to the outside world.
        Public Property Pet() As Animal
            Get
                Return thePet
            End Get
            Set(ByVal Value As Animal)
                thePet = Value
            End Set
        End Property

    End Class

    ' A test class where each method has its own pet.
    Class AnimalTypeTestClass

        <AnimalType(Animal.Dog)> _
        Public Sub DogMethod()
        End Sub

        <AnimalType(Animal.Cat)> _
        Public Sub CatMethod()
        End Sub

        <AnimalType(Animal.Bird)> _
        Public Sub BirdMethod()
        End Sub
    End Class

    ' The runtime test.
    Sub Main()
        Dim testClass As New AnimalTypeTestClass()
        Dim tcType As Type = testClass.GetType()
        Dim mInfo As MethodInfo
        ' Iterate through all the methods of the class.
        For Each mInfo In tcType.GetMethods()
            Dim attr As Attribute
            ' Iterate through all the attributes of the method.
            For Each attr In Attribute.GetCustomAttributes(mInfo)
                If TypeOf attr Is AnimalTypeAttribute Then
                    Dim attrCustom As AnimalTypeAttribute = _
                        CType(attr, AnimalTypeAttribute)
                    Console.WriteLine("Method {0} has a pet {1} attribute.", _
                         mInfo.Name(), attrCustom.Pet.ToString())
                End If
            Next
        Next
    End Sub
End Module

' Output:
' Method DogMethod has a pet Dog attribute.
' Method CatMethod has a pet Cat attribute.
' Method BirdMethod has a pet Bird attribute.
'</Snippet1>