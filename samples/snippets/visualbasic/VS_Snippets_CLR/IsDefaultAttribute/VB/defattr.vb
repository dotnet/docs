' <Snippet1>
Imports System
Imports System.Reflection

Module DemoModule

    ' An enumeration of animals. Start at 1 (0 = uninitialized).
    Enum Animal
        ' Pets
        Dog = 1
        Cat
        Bird
    End Enum

    ' Visual Basic requires that the AttributeUsage be specified.
    ' A custom attribute to allow a target to have a pet.
    <AttributeUsage(AttributeTargets.Method)> _
    Public Class AnimalTypeAttribute
        Inherits Attribute

        ' The constructor is called when the attribute is set.
        Public Sub New(ByVal animal As Animal)
            Me.thePet = animal
        End Sub

        ' Provide a default constructor and make Dog the default.
        Public Sub New()
            thePet = Animal.Dog
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

        ' Override IsDefaultAttribute to return the correct response.
        Public Overrides Function IsDefaultAttribute() As Boolean
            If thePet = Animal.Dog Then
                Return True
            Else
                Return False
            End If
        End Function

    End Class

    Public Class TestClass
        ' Use the default constructor.
        <AnimalType()> _
        Public Sub Method1()
        End Sub

    End Class

    Sub Main()
        ' Get the class type to access its metadata.
        Dim clsType As Type = GetType(TestClass)
        ' Get type information for the method.
        Dim mInfo As MethodInfo = clsType.GetMethod("Method1")
        ' Get the AnimalType attribute for the method.
        Dim attr As Attribute = Attribute.GetCustomAttribute(mInfo, _
            GetType(AnimalTypeAttribute))
        If Not attr Is Nothing And TypeOf attr Is AnimalTypeAttribute Then
            ' Convert the attribute to the required type.
            Dim atAttr As AnimalTypeAttribute = _
                CType(attr, AnimalTypeAttribute)
            Dim strDef As String
            ' Check to see if the default attribute is applied.
            If atAttr.IsDefaultAttribute() Then
                strDef = "is"
            Else
                strDef = "is not"
            End If
            ' Display the result.
            Console.WriteLine("The attribute {0} for method {1} " & _
                    "in class {2}", atAttr.Pet.ToString(), mInfo.Name, _
                    clsType.Name)
            Console.WriteLine("{0} the default for the AnimalType " & _
                    "attribute.", strDef)
        End If
    End Sub
End Module
' </Snippet1>
