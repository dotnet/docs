Module Joins
    Sub Main(ByVal args As String())
        'LeftOuterJoin.LeftOuterJoinExample()
        'GroupJoinXML.GroupJoinXMLExample()
        'GroupJoins.GroupJoinExample()
        'InnerGroupJoin.InnerGroupJoinExample()
        'MultipleJoin.MultipleJoinExample()
        'CompositeKeyJoin.CompositeKeyJoinExample()
        InnerJoin.InnerJoinExample()
    End Sub
End Module

Module Test
    Sub TestEx1()

    End Sub
End Module

Module InnerJoin
    ' <1>
    Class Person
        Private _firstName As String
        Private _lastName As String

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property
    End Class

    Class Pet
        Private _name As String
        Private _owner As Person

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Owner() As Person
            Get
                Return _owner
            End Get
            Set(ByVal value As Person)
                _owner = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Simple inner join.
    ''' </summary>
    Sub InnerJoinExample()
        Dim magnus As New Person With {.FirstName = "Magnus", .LastName = "Hedlund"}
        Dim terry As New Person With {.FirstName = "Terry", .LastName = "Adams"}
        Dim charlotte As New Person With {.FirstName = "Charlotte", .LastName = "Weiss"}
        Dim arlene As New Person With {.FirstName = "Arlene", .LastName = "Huff"}
        Dim rui As New Person With {.FirstName = "Rui", .LastName = "Raposo"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim bluemoon As New Pet With {.Name = "Blue Moon", .Owner = rui}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        ' Create two lists.
        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte, arlene, rui})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, bluemoon, daisy})

        ' Create a collection of person-pet pairs. Each element in the collection
        ' is an anonymous type containing both the person's name and their pet's name.
        Dim query = From person In people _
                    Join pet In pets On person Equals pet.Owner _
                    Select OwnerName = person.FirstName, PetName = pet.Name

        Dim output As New System.Text.StringBuilder
        For Each ownerAndPet In query
            output.AppendFormat("""{0}"" is owned by {1}{2}", ownerAndPet.PetName, ownerAndPet.OwnerName, vbCrLf)
        Next

        ' Display the output.
        MsgBox(output.ToString())

    End Sub

    ' This code produces the following output:
    '
    ' "Daisy" is owned by Magnus
    ' "Barley" is owned by Terry
    ' "Boots" is owned by Terry
    ' "Whiskers" is owned by Charlotte
    ' "Blue Moon" is owned by Rui

    ' </1>
End Module

Module CompositeKeyJoin
    ' <2>
    Class Employee
        Public _firstName As String
        Public _lastName As String
        Public _employeeID As Integer

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property

        Public Property EmployeeID() As Integer
            Get
                Return _employeeID
            End Get
            Set(ByVal value As Integer)
                _employeeID = value
            End Set
        End Property
    End Class

    Class Student
        Public _firstName As String
        Public _lastName As String
        Public _studentID As Integer

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property

        Public Property StudentID() As Integer
            Get
                Return _studentID
            End Get
            Set(ByVal value As Integer)
                _studentID = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Performs a join operation using a composite key.
    ''' </summary>
    Sub CompositeKeyJoinExample()
        ' Create a list of employees.
        Dim employees As New List(Of Employee)(New Employee() _
            {New Employee With {.FirstName = "Terry", .LastName = "Adams", .EmployeeID = 522459}, _
             New Employee With {.FirstName = "Charlotte", .LastName = "Weiss", .EmployeeID = 204467}, _
             New Employee With {.FirstName = "Magnus", .LastName = "Hedland", .EmployeeID = 866200}, _
             New Employee With {.FirstName = "Vernette", .LastName = "Price", .EmployeeID = 437139}})

        ' Create a list of students.
        Dim students As New List(Of Student)(New Student() _
            {New Student With {.FirstName = "Vernette", .LastName = "Price", .StudentID = 9562}, _
            New Student With {.FirstName = "Terry", .LastName = "Earls", .StudentID = 9870}, _
            New Student With {.FirstName = "Terry", .LastName = "Adams", .StudentID = 9913}})

        ' Join the two data sources based on a composite key consisting of first and last name,
        ' to determine which employees are also students.
        Dim query = From employee In employees _
                    Join student In students On _
                    employee.FirstName Equals student.FirstName _
                    And employee.LastName Equals student.LastName _
                    Select employee.FirstName & " " & employee.LastName

        Dim output As New System.Text.StringBuilder
        output.AppendLine("The following people are both employees and students:")
        For Each name As String In query
            output.AppendLine(name)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' The following people are both employees and students:
    ' Terry Adams
    ' Vernette Price

    ' </2>
End Module

' Snippet two (composite key join) using method-based query syntax.
'Dim query = employees.Join(students, _
'                          Function(ByVal e) New With {Key e.FirstName, Key e.LastName}, _
'                          Function(ByVal s) New With {Key s.FirstName, Key s.LastName}, _
'                          Function(ByVal e, ByVal s) e.FirstName & " " & e.LastName)

Module MultipleJoin
    ' <3>
    Class Person
        Public _firstName As String
        Public _lastName As String

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property
    End Class

    Class Pet
        Public _name As String
        Public _owner As Person

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Owner() As Person
            Get
                Return _owner
            End Get
            Set(ByVal value As Person)
                _owner = value
            End Set
        End Property
    End Class

    Class Cat
        Inherits Pet
    End Class

    Class Dog
        Inherits Pet
    End Class

    Sub MultipleJoinExample()
        Dim magnus As New Person With {.FirstName = "Magnus", .LastName = "Hedlund"}
        Dim terry As New Person With {.FirstName = "Terry", .LastName = "Adams"}
        Dim charlotte As New Person With {.FirstName = "Charlotte", .LastName = "Weiss"}
        Dim arlene As New Person With {.FirstName = "Arlene", .LastName = "Huff"}
        Dim rui As New Person With {.FirstName = "Rui", .LastName = "Raposo"}
        Dim phyllis As New Person With {.FirstName = "Phyllis", .LastName = "Harris"}

        Dim barley As New Cat With {.Name = "Barley", .Owner = terry}
        Dim boots As New Cat With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Cat With {.Name = "Whiskers", .Owner = charlotte}
        Dim bluemoon As New Cat With {.Name = "Blue Moon", .Owner = rui}
        Dim daisy As New Cat With {.Name = "Daisy", .Owner = magnus}

        Dim fourwheeldrive As New Dog With {.Name = "Four Wheel Drive", .Owner = phyllis}
        Dim duke As New Dog With {.Name = "Duke", .Owner = magnus}
        Dim denim As New Dog With {.Name = "Denim", .Owner = terry}
        Dim wiley As New Dog With {.Name = "Wiley", .Owner = charlotte}
        Dim snoopy As New Dog With {.Name = "Snoopy", .Owner = rui}
        Dim snickers As New Dog With {.Name = "Snickers", .Owner = arlene}

        ' Create three lists.
        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte, arlene, rui, phyllis})
        Dim cats As New List(Of Cat)(New Cat() {barley, boots, whiskers, bluemoon, daisy})
        Dim dogs As New List(Of Dog)(New Dog() {fourwheeldrive, duke, denim, wiley, snoopy, snickers})

        ' The first join matches Person and Cat.Owner from the list of people and cats.
        ' It creates a sequence of anonymous types that contain the Owner
        ' and Cat.Name. The second join matches dogs whose names start
        ' with the same letter as cats that have the same Owner.
        Dim query = From person In people _
                    Join cat In cats On person Equals cat.Owner _
                    Select Owner = person, CatName = cat.Name _
                    Join dog In dogs On Owner Equals dog.Owner _
                    And CatName.Substring(0, 1) Equals dog.Name.Substring(0, 1) _
                    Select CatName, DogName = dog.Name

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            output.AppendFormat( _
                "The cat ""{0}"" shares a house, and the first letter of their name, with ""{1}"".{2}", _
                obj.CatName, obj.DogName, vbCrLf)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' The cat "Daisy" shares a house, and the first letter of their name, with "Duke".
    ' The cat "Whiskers" shares a house, and the first letter of their name, with "Wiley".

    ' </3>
End Module

' Snippet three, using method-based query syntax.
'Dim query = people.Join( _
'    cats, _
'    Function(ByVal person) person, _
'    Function(ByVal cat) cat.Owner, _
'    Function(ByVal p, ByVal c) New With {.Owner = p, .CatName = c.Name} _
'    ).Join(dogs, _
'         Function(ByVal anon) New With {Key anon.Owner, Key .Letter = anon.CatName.Substring(0, 1)}, _
'         Function(ByVal dog) New With {Key dog.Owner, Key .Letter = dog.Name.Substring(0, 1)}, _
'         Function(ByVal anon, ByVal dog) New With {anon.CatName, .DogName = dog.Name})

Module InnerGroupJoin
    ' <4>
    Class Person
        Public _firstName As String
        Public _lastName As String

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property
    End Class

    Class Pet
        Public _name As String
        Public _owner As Person

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Owner() As Person
            Get
                Return _owner
            End Get
            Set(ByVal value As Person)
                _owner = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Performs an inner join by using GroupJoin().
    ''' </summary>
    Sub InnerGroupJoinExample()
        Dim magnus As New Person With {.FirstName = "Magnus", .LastName = "Hedlund"}
        Dim terry As New Person With {.FirstName = "Terry", .LastName = "Adams"}
        Dim charlotte As New Person With {.FirstName = "Charlotte", .LastName = "Weiss"}
        Dim arlene As New Person With {.FirstName = "Arlene", .LastName = "Huff"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim bluemoon As New Pet With {.Name = "Blue Moon", .Owner = terry}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        ' Create two lists.
        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte, arlene})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, bluemoon, daisy})

        Dim query1 = From person In people _
                     Group Join pet In pets On person Equals pet.Owner Into gj = Group _
                     From subpet In gj _
                     Select OwnerName = person.FirstName, PetName = subpet.Name

        Dim output As New System.Text.StringBuilder
        output.AppendLine("Inner join using GroupJoin():")
        For Each v In query1
            output.AppendFormat("{0} - {1}" & vbCrLf, v.OwnerName, v.PetName)
        Next

        Dim query2 = From person In people _
                     Join pet In pets On person Equals pet.Owner _
                     Select OwnerName = person.FirstName, PetName = pet.Name

        output.AppendLine(vbCrLf & "The equivalent operation using Join():")
        For Each v In query2
            output.AppendFormat("{0} - {1}" & vbCrLf, v.OwnerName, v.PetName)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' Inner join using GroupJoin():
    ' Magnus - Daisy
    ' Terry - Barley
    ' Terry - Boots
    ' Terry - Blue Moon
    ' Charlotte - Whiskers
    '
    ' The equivalent operation using Join():
    ' Magnus - Daisy
    ' Terry - Barley
    ' Terry - Boots
    ' Terry - Blue Moon
    ' Charlotte - Whiskers

    ' </4>
End Module

' Snippet four using method-based query syntax.
'Dim query1 = people.GroupJoin( _
'    pets, _
'    Function(ByVal person) person, _
'    Function(ByVal pet) pet.Owner, _
'    Function(ByVal person, ByVal petCollection) _
'        petCollection.Select(Function(ByVal pet) New With { _
'                            .OwnerName = person.FirstName, _
'                            .PetName = pet.Name}) _
'    ).SelectMany(Function(ByVal anon) anon)

Module GroupJoins
    ' <5>
    Class Person
        Public _firstName As String
        Public _lastName As String

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property
    End Class

    Class Pet
        Public _name As String
        Public _owner As Person

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Owner() As Person
            Get
                Return _owner
            End Get
            Set(ByVal value As Person)
                _owner = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' This example performs a grouped join.
    ''' </summary>
    Sub GroupJoinExample()
        Dim magnus As New Person With {.FirstName = "Magnus", .LastName = "Hedlund"}
        Dim terry As New Person With {.FirstName = "Terry", .LastName = "Adams"}
        Dim charlotte As New Person With {.FirstName = "Charlotte", .LastName = "Weiss"}
        Dim arlene As New Person With {.FirstName = "Arlene", .LastName = "Huff"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim bluemoon As New Pet With {.Name = "Blue Moon", .Owner = terry}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        ' Create two lists.
        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte, arlene})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, bluemoon, daisy})

        ' Create a list where each element is an anonymous type
        ' that contains the person's first name and a collection of
        ' pets that are owned by them.
        Dim query = From person In people _
                    Group Join pet In pets On person Equals pet.Owner Into gj = Group _
                    Select OwnerName = person.FirstName, MyPets = gj

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            ' Output the owner's name.
            output.AppendFormat("{0}:" & vbCrLf, obj.OwnerName)
            ' Output each of the owner's pet's names.
            For Each pet As Pet In obj.MyPets
                output.AppendFormat("  {0}" & vbCrLf, pet.Name)
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' Magnus:
    '   Daisy
    ' Terry:
    '   Barley
    '   Boots
    '   Blue Moon
    ' Charlotte:
    '   Whiskers
    ' Arlene:

    ' </5>
End Module

Module GroupJoinXML
    ' <6>
    Class Person
        Public _firstName As String
        Public _lastName As String

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property
    End Class

    Class Pet
        Public _name As String
        Public _owner As Person

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Owner() As Person
            Get
                Return _owner
            End Get
            Set(ByVal value As Person)
                _owner = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' This example creates XML output from a grouped join.
    ''' </summary>
    Sub GroupJoinXMLExample()
        Dim magnus As New Person With {.FirstName = "Magnus", .LastName = "Hedlund"}
        Dim terry As New Person With {.FirstName = "Terry", .LastName = "Adams"}
        Dim charlotte As New Person With {.FirstName = "Charlotte", .LastName = "Weiss"}
        Dim arlene As New Person With {.FirstName = "Arlene", .LastName = "Huff"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim bluemoon As New Pet With {.Name = "Blue Moon", .Owner = terry}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        ' Create two lists.
        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte, arlene})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, bluemoon, daisy})

        Dim petOwnersXML = _
        <PetOwners>
            <%= From person In people _
                Group Join pet In pets On person Equals pet.Owner Into gj = Group _
                Select <Person FirstName=<%= person.FirstName %> LastName=<%= person.LastName %>>
                           <%= From subpet In gj _
                               Select <Pet><%= subpet.Name %></Pet> %>
                       </Person> %>
        </PetOwners>

        Console.WriteLine(petOwnersXML)
    End Sub

    ' This code produces the following output:
    '
    ' <PetOwners>
    '   <Person FirstName="Magnus" LastName="Hedlund">
    '     <Pet>Daisy</Pet>
    '   </Person>
    '   <Person FirstName="Terry" LastName="Adams">
    '     <Pet>Barley</Pet>
    '     <Pet>Boots</Pet>
    '     <Pet>Blue Moon</Pet>
    '   </Person>
    '   <Person FirstName="Charlotte" LastName="Weiss">
    '     <Pet>Whiskers</Pet>
    '   </Person>
    '   <Person FirstName="Arlene" LastName="Huff" />
    ' </PetOwners>

    ' </6>
End Module

Module LeftOuterJoin
    ' <7>
    Class Person
        Public _firstName As String
        Public _lastName As String

        Public Property FirstName() As String
            Get
                Return _firstName
            End Get
            Set(ByVal value As String)
                _firstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property
    End Class

    Class Pet
        Public _name As String
        Public _owner As Person

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Owner() As Person
            Get
                Return _owner
            End Get
            Set(ByVal value As Person)
                _owner = value
            End Set
        End Property
    End Class

    Sub LeftOuterJoinExample()
        Dim magnus As New Person With {.FirstName = "Magnus", .LastName = "Hedlund"}
        Dim terry As New Person With {.FirstName = "Terry", .LastName = "Adams"}
        Dim charlotte As New Person With {.FirstName = "Charlotte", .LastName = "Weiss"}
        Dim arlene As New Person With {.FirstName = "Arlene", .LastName = "Huff"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim bluemoon As New Pet With {.Name = "Blue Moon", .Owner = terry}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        ' Create two lists.
        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte, arlene})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, bluemoon, daisy})

        Dim query = From person In people _
                    Group Join pet In pets On person Equals pet.Owner Into gj = Group _
                    From subpet In gj.DefaultIfEmpty() _
                    Select person.FirstName, PetName = If(subpet Is Nothing, String.Empty, subpet.Name)

        Dim output As New System.Text.StringBuilder
        For Each v In query
            output.AppendFormat("{0}:{1}{2}{3}{4}", _
                v.FirstName, vbTab, vbTab, v.PetName, vbCrLf)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' Magnus:	    Daisy
    ' Terry:	    Barley
    ' Terry:	    Boots
    ' Terry:	    Blue Moon
    ' Charlotte:	Whiskers
    ' Arlene:	

    ' </7>
End Module
