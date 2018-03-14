Imports System.Collections.Generic

Module QueryableSnippets
    Sub Main()
        AllEx2()
    End Sub
End Module

Module Aggregate
    Sub AggregateEx1()
        ' <Snippet1>
        Dim sentence As String = "the quick brown fox jumps over the lazy dog"

        ' Split the string into individual words.
        Dim words() As String = sentence.Split(" "c)

        ' Use Aggregate() to prepend each word to the beginning of the 
        ' new sentence to reverse the word order.
        Dim reversed As String = _
            words.AsQueryable().Aggregate( _
                Function(ByVal workingSentence, ByVal nextWord) nextWord & " " & workingSentence _
            )

        MsgBox(reversed)

        ' This code produces the following output:
        '
        ' dog lazy the over jumps fox brown quick the

        ' </Snippet1>
    End Sub

    Sub AggregateEx2()
        ' <Snippet2>
        Dim ints() As Integer = {4, 8, 8, 3, 9, 0, 7, 8, 2}

        ' Count the even numbers in the array, using a seed value of 0.
        Dim numEven As Integer = _
            ints.AsQueryable().Aggregate( _
                0, _
                Function(ByVal total, ByVal number) _
                    IIf(number Mod 2 = 0, total + 1, total) _
            )

        MsgBox(String.Format("The number of even integers is: {0}", numEven))

        ' This code produces the following output:
        '
        ' The number of even integers is: 6 

        ' </Snippet2>
    End Sub

    Sub AggregateEx3()
        ' <Snippet3>
        Dim fruits() As String = {"apple", "mango", "orange", "passionfruit", "grape"}

        ' Determine whether any string in the array is longer than "banana".
        Dim longestName As String = _
            fruits.AsQueryable().Aggregate( _
            "banana", _
            Function(ByVal longest, ByVal fruit) IIf(fruit.Length > longest.Length, fruit, longest), _
            Function(ByVal fruit) fruit.ToUpper() _
        )

        MsgBox(String.Format( _
            "The fruit with the longest name is {0}.", longestName) _
        )

        ' This code produces the following output:
        '
        ' The fruit with the longest name is PASSIONFRUIT. 

        ' </Snippet3>
    End Sub
End Module

Public Module All
    ' <Snippet4>
    Sub AllEx()
        ' Create an array of Pets.
        Dim pets() As Pet = _
            {New Pet With {.Name = "Barley", .Age = 10}, _
             New Pet With {.Name = "Boots", .Age = 4}, _
             New Pet With {.Name = "Whiskers", .Age = 6}}

        ' Determine whether all pet names in the array start with 'B'.
        Dim allStartWithB As Boolean = _
            pets.AsQueryable().All(Function(ByVal pet) pet.Name.StartsWith("B"))

        MsgBox(String.Format( _
            "{0} pet names start with 'B'.", _
            IIf(allStartWithB, "All", "Not all")))
    End Sub

    Public Structure Pet
        Dim Name As String
        Dim Age As Integer
    End Structure

    ' This code produces the following output:
    '
    '  Not all pet names start with 'B'. 

    ' </Snippet4>
End Module

Module All2
    ' <Snippet134>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Structure Person
        Public LastName As String
        Public Pets() As Pet
    End Structure

    Sub AllEx2()
        Dim people As New List(Of Person)(New Person() _
            {New Person With {.LastName = "Haas", _
                              .Pets = New Pet() {New Pet With {.Name = "Barley", .Age = 10}, _
                                                 New Pet With {.Name = "Boots", .Age = 14}, _
                                                 New Pet With {.Name = "Whiskers", .Age = 6}}}, _
              New Person With {.LastName = "Fakhouri", _
                               .Pets = New Pet() {New Pet With {.Name = "Snowball", .Age = 1}}}, _
              New Person With {.LastName = "Antebi", _
                               .Pets = New Pet() {New Pet With {.Name = "Belle", .Age = 8}}}, _
              New Person With {.LastName = "Philips", _
                               .Pets = New Pet() {New Pet With {.Name = "Sweetie", .Age = 2}, _
                                                  New Pet With {.Name = "Rover", .Age = 13}}}})

        ' Determine which people have pets that are all older than 5.
        Dim names = From person In people _
                    Where person.Pets.AsQueryable().All(Function(pet) pet.Age > 5) _
                    Select person.LastName

        For Each name As String In names
            Console.WriteLine(name)
        Next

        ' This code produces the following output:
        '
        ' Haas
        ' Antebi

    End Sub
    ' </Snippet134>
End Module

Public Module Any
    Sub AnyEx1()
        ' <Snippet5>
        Dim numbers As New List(Of Integer)(New Integer() {1, 2})

        ' Determine if the list contains any elements.
        Dim hasElements As Boolean = numbers.AsQueryable().Any()

        MsgBox(String.Format("The list {0} empty.", _
            IIf(hasElements, "is not", "is")))

        ' This code produces the following output:
        '
        ' The list is not empty. 

        ' </Snippet5>
    End Sub

    ' <Snippet135>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Structure Person
        Public LastName As String
        Public Pets() As Pet
    End Structure

    Sub AnyEx2()
        Dim people As New List(Of Person)(New Person() _
            {New Person With {.LastName = "Haas", _
                              .Pets = New Pet() {New Pet With {.Name = "Barley", .Age = 10}, _
                                                 New Pet With {.Name = "Boots", .Age = 14}, _
                                                 New Pet With {.Name = "Whiskers", .Age = 6}}}, _
              New Person With {.LastName = "Fakhouri", _
                               .Pets = New Pet() {New Pet With {.Name = "Snowball", .Age = 1}}}, _
              New Person With {.LastName = "Antebi", _
                               .Pets = New Pet() {}}, _
              New Person With {.LastName = "Philips", _
                               .Pets = New Pet() {New Pet With {.Name = "Sweetie", .Age = 2}, _
                                                  New Pet With {.Name = "Rover", .Age = 13}}}})

        ' Determine which people have a non-empty Pet array.
        Dim names = From person In people _
                    Where person.Pets.AsQueryable().Any() _
                    Select person.LastName

        For Each name As String In names
            Console.WriteLine(name)
        Next

        ' This code produces the following output:
        '
        ' Haas
        ' Fakhouri
        ' Philips

    End Sub
    ' </Snippet135>
End Module

Public Class Any2
    ' <Snippet6>
    Structure Pet
        Dim Name As String
        Dim Age As Integer
        Dim Vaccinated As Boolean
    End Structure

    Shared Sub AnyEx3()
        ' Create an array of Pet objects.
        Dim pets() As Pet = _
            {New Pet With {.Name = "Barley", .Age = 8, .Vaccinated = True}, _
             New Pet With {.Name = "Boots", .Age = 4, .Vaccinated = False}, _
             New Pet With {.Name = "Whiskers", .Age = 1, .Vaccinated = False}}

        ' Determine whether any pets over age 1 are also unvaccinated.
        Dim unvaccinated As Boolean = _
        pets.AsQueryable().Any(Function(p) p.Age > 1 And p.Vaccinated = False)

        MsgBox(String.Format( _
            "There {0} unvaccinated animals over age one.", _
            IIf(unvaccinated, "are", "are not any") _
        ))
    End Sub

    ' This code produces the following output:
    '
    '  There are unvaccinated animals over age one. 

    ' </Snippet6>
End Class

Module AsQueryable
    Sub AsQueryableEx1()
        ' <Snippet125>
        Dim grades As New List(Of Integer)(New Integer() {78, 92, 100, 37, 81})

        ' Convert the List to an IQueryable<int>.
        Dim iqueryable As IQueryable(Of Integer) = grades.AsQueryable()

        ' Get the Expression property of the IQueryable object.
        Dim expressionTree As System.Linq.Expressions.Expression = _
            iqueryable.Expression

        MsgBox("The NodeType of the expression tree is: " _
            & expressionTree.NodeType.ToString())
        MsgBox("The Type of the expression tree is: " _
            & expressionTree.Type.Name)

        ' This code produces the following output:
        '
        ' The NodeType of the expression tree is: Constant
        ' The Type of the expression tree is: EnumerableQuery`1

        ' </Snippet125>
    End Sub
End Module

Module Average
    Sub AverageEx1()
        ' <Snippet8>
        Dim grades As New List(Of Integer)(New Integer() {78, 92, 100, 37, 81})

        Dim average As Double = grades.AsQueryable().Average()

        MsgBox(String.Format("The average grade is {0}.", average))

        ' This code produces the following output:
        '
        ' The average grade is 77.6. 

        ' </Snippet8>
    End Sub

    Sub AverageEx2()
        ' <Snippet12>
        Dim longs() As Nullable(Of Long) = {Nothing, 10007L, 37L, 399846234235L}

        Dim average As Nullable(Of Double) = longs.AsQueryable().Average()

        MsgBox(String.Format("The average is {0}.", average))

        ' This code produces the following output:
        '
        ' The average is 133282081426.333. 

        ' </Snippet12>
    End Sub

    Sub AverageEx3()
        ' <Snippet18>
        Dim fruits() As String = {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

        ' Determine the average string length in the array.
        Dim average As Double = fruits.AsQueryable().Average(Function(s) s.Length)

        MsgBox(String.Format("The average string length is {0}.", average))

        ' This code produces the following output:
        '
        ' The average string length is 6.5. 

        ' </Snippet18>
    End Sub
End Module

Module Cast
    Sub CastExample()
        ' <Snippet19>

        ' Create a list of objects.
        Dim words As New List(Of Object)(New Object() {"green", "blue", "violet"})

        ' Cast the objects in the list to type 'string'
        ' and project the first letter of each string.
        Dim query As IEnumerable(Of String) = _
            words.AsQueryable() _
                    .Cast(Of String)() _
                    .Select(Function(str) str.Substring(0, 1))

        For Each s As String In query
            MsgBox(s)
        Next

        ' This code produces the following output:
        '
        ' g
        ' b
        ' v

        ' </Snippet19>
    End Sub
End Module


Public Class Concat
    ' <Snippet20>

    ' This method creates and returns an array of Pet objects.
    Shared Function GetCats() As Pet()
        Dim cats() As Pet = _
            {New Pet With {.Name = "Barley", .Age = 8}, _
             New Pet With {.Name = "Boots", .Age = 4}, _
             New Pet With {.Name = "Whiskers", .Age = 1}}

        Return cats
    End Function

    ' This method creates and returns an array of Pet objects.
    Shared Function GetDogs() As Pet()
        Dim dogs() As Pet = _
            {New Pet With {.Name = "Bounder", .Age = 3}, _
             New Pet With {.Name = "Snoopy", .Age = 14}, _
             New Pet With {.Name = "Fido", .Age = 9}}

        Return dogs
    End Function

    Shared Sub ConcatEx1()
        Dim cats() As Pet = GetCats()
        Dim dogs() As Pet = GetDogs()

        ' Concatenate a collection of cat names to a
        ' collection of dog names by using Concat().
        Dim query As IEnumerable(Of String) = _
            cats.AsQueryable() _
            .Select(Function(cat) cat.Name) _
            .Concat(dogs.Select(Function(dog) dog.Name))

        For Each name As String In query
            MsgBox(name)
        Next
    End Sub

    Structure Pet
        Dim Name As String
        Dim Age As Integer
    End Structure

    ' This code produces the following output:
    '
    ' Barley
    ' Boots
    ' Whiskers
    ' Bounder
    ' Snoopy
    ' Fido

    ' </Snippet20>

    Shared Sub ConcatEx2()
        ' <Snippet112>
        Dim cats As Pet() = GetCats()
        Dim dogs As Pet() = GetDogs()

        Dim animals() As IEnumerable(Of Pet) = {cats, dogs}

        ' Concatenate a collection of cat names to a
        ' collection of dog names by using SelectMany().
        Dim query As IEnumerable(Of String) = _
            (animals.AsQueryable().SelectMany( _
                Function(pets) pets.Select(Function(pet) pet.Name) _
            ))

        For Each name As String In query
            MsgBox(name)
        Next

        ' This code produces the following output:
        '
        ' Barley
        ' Boots
        ' Whiskers
        ' Bounder
        ' Snoopy
        ' Fido

        ' </Snippet112>
    End Sub
End Class

Module Contains
    Sub ContainsEx1()
        ' <Snippet21>
        Dim fruits() As String = {"apple", "banana", "mango", _
                                "orange", "passionfruit", "grape"}

        ' The string to search for in the array.
        Dim mango As String = "mango"

        Dim hasMango As Boolean = fruits.AsQueryable().Contains(mango)

        MsgBox(String.Format("The array {0} contain '{1}'.", _
                IIf(hasMango, "does", "does not"), mango))

        ' This code produces the following output:
        '
        ' The array does contain 'mango'. 

        ' </Snippet21>
    End Sub
End Module

Public Class Count
    Shared Sub CountEx1()
        ' <Snippet22>
        Dim fruits() As String = {"apple", "banana", "mango", _
                            "orange", "passionfruit", "grape"}

        Dim numberOfFruits As Integer = fruits.AsQueryable().Count()

        MsgBox(String.Format( _
            "There are {0} items in the array.", _
            numberOfFruits))

        ' This code produces the following output:
        '
        ' There are 6 items in the array. 

        ' </Snippet22>
    End Sub

    ' <Snippet23>
    Structure Pet
        Public Name As String
        Public Vaccinated As Boolean
    End Structure

    Shared Sub CountEx2()
        ' Create an array of Pet objects.
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Vaccinated = True}, _
                       New Pet With {.Name = "Boots", .Vaccinated = False}, _
                       New Pet With {.Name = "Whiskers", .Vaccinated = False}}

        ' Count the number of unvaccinated pets in the array.
        Dim numberUnvaccinated As Integer = pets.AsQueryable().Count(Function(p) p.Vaccinated = False)

        MsgBox(String.Format("There are {0} unvaccinated animals.", numberUnvaccinated))
    End Sub

    ' This code produces the following output:
    '
    ' There are 2 unvaccinated animals.

    ' </Snippet23>
End Class

Public Class DefaultIfEmpty
    ' <Snippet24>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub DefaultIfEmptyEx1()
        ' Create a list of Pet objects.
        Dim pets As New List(Of Pet)(New Pet() { _
                            New Pet With {.Name = "Barley", .Age = 8}, _
                            New Pet With {.Name = "Boots", .Age = 4}, _
                            New Pet With {.Name = "Whiskers", .Age = 1}})

        ' Call DefaultIfEmtpy() on the collection that Select()
        ' returns, so that if the initial list is empty, there
        ' will always be at least one item in the returned array.
        Dim names() As String = pets.AsQueryable() _
            .Select(Function(Pet) Pet.Name) _
            .DefaultIfEmpty() _
            .ToArray()

        Dim first As String = names(0)
        MsgBox(first)

        ' This code produces the following output:
        '
        ' Barley

    End Sub
    ' </Snippet24>

    Shared Sub DefaultIfEmptyEx1a()
        ' <Snippet25>
        ' Create a list of Pet objects.
        Dim pets As New List(Of Pet)(New Pet() { _
                           New Pet With {.Name = "Barley", .Age = 8}, _
                           New Pet With {.Name = "Boots", .Age = 4}, _
                           New Pet With {.Name = "Whiskers", .Age = 1}})

        ' This query returns pets that are 10 or older. In case there are no pets 
        ' that meet that criteria, call DefaultIfEmpty(). This code passes an (optional) 
        ' default value to DefaultIfEmpty().
        Dim oldPets() As String = pets.AsQueryable() _
            .Where(Function(Pet) Pet.Age >= 10) _
            .Select(Function(Pet) Pet.Name) _
            .DefaultIfEmpty("[EMPTY]") _
            .ToArray()
        Try
            MsgBox("First query: " + oldPets(0))
        Catch ex As Exception
            Console.WriteLine("First query: An exception was thrown: " + ex.Message)
        End Try

        ' This query selects only those pets that are 10 or older.
        ' This code does not call DefaultIfEmpty().
        Dim oldPets2() As String = _
            pets.AsQueryable() _
            .Where(Function(Pet) Pet.Age >= 10) _
            .Select(Function(Pet) Pet.Name) _
            .ToArray()

        ' There may be no elements in the array, so directly
        ' accessing element 0 may throw an exception.
        Try
            MsgBox("Second query: " + oldPets2(0))
        Catch ex As Exception
            MsgBox("Second query: An exception was thrown: " + ex.Message)
        End Try

        ' This code produces the following output:
        '
        ' First(query) : [EMPTY]
        ' Second query: An exception was thrown: Index was outside the bounds of the array.

        ' </Snippet25>
    End Sub
End Class

Module Distinct
    Sub DistinctEx1()
        ' <Snippet27>
        Dim ages As List(Of Integer) = New List(Of Integer)(New Integer() {21, 46, 46, 55, 17, 21, 55, 55})

        Dim distinctAges As IEnumerable(Of Integer) = ages.AsQueryable().Distinct()

        Dim output As New System.Text.StringBuilder
        output.AppendLine("Distinct ages:")

        For Each age As Integer In distinctAges
            output.AppendLine(age)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' Distinct(ages)
        ' 21
        ' 46
        ' 55
        ' 17

        ' </Snippet27>
    End Sub
End Module

Module ElementAt
    Sub ElementAtEx1()
        ' <Snippet28>
        Dim names() As String = {"Hartono, Tommy", "Adams, Terry", _
                           "Andersen, Henriette Thaulow", _
                           "Hedlund, Magnus", "Ito, Shu"}

        Dim rand As New Random(DateTime.Now.Millisecond)

        Dim name As String = _
            names.AsQueryable().ElementAt(rand.Next(0, names.Length))

        MsgBox(String.Format("The name chosen at random is '{0}'.", name))

        ' This code produces the following sample output.
        ' Yours may be different due to the use of Random.
        '
        ' The name chosen at random is 'Ito, Shu'.

        ' </Snippet28>
    End Sub

    Sub ElementAtOrDefaultEx1()
        ' <Snippet29>
        Dim names() As String = {"Hartono, Tommy", "Adams, Terry", _
                           "Andersen, Henriette Thaulow", _
                           "Hedlund, Magnus", "Ito, Shu"}

        Dim index As Integer = 20

        Dim name As String = names.AsQueryable().ElementAtOrDefault(index)

        MsgBox(String.Format("The name at index {0} is '{1}'.", _
            index, IIf(String.IsNullOrEmpty(name), "[NONE AT THIS INDEX]", name)))

        ' This code produces the following output:
        '
        ' The name at index 20 is '[NONE AT THIS INDEX]'.

        ' </Snippet29>
    End Sub
End Module

Module Except
    Sub ExceptEx()
        ' <Snippet34>
        Dim numbers1() As Double = {2.0, 2.1, 2.2, 2.3, 2.4, 2.5}
        Dim numbers2() As Double = {2.2}

        ' Get the numbers from the first array that
        ' are NOT in the second array.
        Dim onlyInFirstSet As IEnumerable(Of Double) = _
            numbers1.AsQueryable().Except(numbers2)

        Dim output As New System.Text.StringBuilder
        For Each number As Double In onlyInFirstSet
            output.AppendLine(number)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' 2
        ' 2.1
        ' 2.3
        ' 2.4
        ' 2.5

        ' </Snippet34>
    End Sub
End Module

Module First
    Sub FirstEx1()
        ' <Snippet35>
        Dim numbers() As Integer = {9, 34, 65, 92, 87, 435, 3, 54, _
                            83, 23, 87, 435, 67, 12, 19}

        Dim first As Integer = numbers.AsQueryable().First()

        MsgBox(first)

        ' This code produces the following output:
        '
        ' 9

        ' </Snippet35>
    End Sub

    Sub FirstEx2()
        ' <Snippet36>
        Dim numbers() As Integer = {9, 34, 65, 92, 87, 435, 3, 54, _
                          83, 23, 87, 435, 67, 12, 19}

        ' Get the first number in the array that is greater than 80.
        Dim first As Integer = numbers.AsQueryable().First(Function(number) number > 80)

        MsgBox(first)

        ' This code produces the following output:
        '
        ' 92

        ' </Snippet36>
    End Sub

    Sub FirstOrDefaultEx1()
        ' <Snippet37>
        ' Create an empty array.
        Dim numbers() As Integer = {}
        ' Get the first item in the array, or else the 
        ' default value for type int, which is 0.
        Dim first As Integer = numbers.AsQueryable().FirstOrDefault()

        MsgBox(first)

        ' This code produces the following output:

        ' 0

        ' </Snippet37>
    End Sub

    Sub FirstOrDefaultEx2()
        ' <Snippet38>
        Dim names() As String = {"Hartono, Tommy", "Adams, Terry", _
                             "Andersen, Henriette Thaulow", _
                             "Hedlund, Magnus", "Ito, Shu"}

        ' Get the first string in the array that is longer
        ' than 20 characters, or the default value for type
        ' string (null) if none exists.
        Dim firstLongName As String = _
                    names.AsQueryable().FirstOrDefault(Function(name) name.Length > 20)

        MsgBox(String.Format("The first long name is '{0}'.", firstLongName))

        ' Get the first string in the array that is longer
        ' than 30 characters, or the default value for type
        ' string (null) if none exists.
        Dim firstVeryLongName As String = _
            names.AsQueryable().FirstOrDefault(Function(name) name.Length > 30)

        MsgBox(String.Format( _
            "There is {0} name that is longer than 30 characters.", _
            IIf(String.IsNullOrEmpty(firstVeryLongName), "NOT a", "a")))

        ' This code produces the following output:
        '
        ' The first long name is 'Andersen, Henriette Thaulow'.
        ' There is NOT a name that is longer than 30 characters.

        ' </Snippet38>
    End Sub

    Sub FirstOrDefaultEx3()
        ' <Snippet131>
        Dim months As New List(Of Integer)(New Integer() {})

        ' Setting the default value to 1 after the query.
        Dim firstMonth1 As Integer = months.AsQueryable().FirstOrDefault()
        If firstMonth1 = 0 Then
            firstMonth1 = 1
        End If
        MsgBox(String.Format("The value of the firstMonth1 variable is {0}", firstMonth1))

        ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
        Dim firstMonth2 As Integer = months.AsQueryable().DefaultIfEmpty(1).First()
        MsgBox(String.Format("The value of the firstMonth2 variable is {0}", firstMonth2))

        ' This code produces the following output:
        '
        ' The value of the firstMonth1 variable is 1
        ' The value of the firstMonth2 variable is 1

        ' </Snippet131>
    End Sub
End Module

Public Class GroupBy1
    ' <Snippet14>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub GroupByEx1()
        ' Create a list of Pet objects.
        Dim pets As New List(Of Pet)(New Pet() { _
                        New Pet With {.Name = "Barley", .Age = 8}, _
                        New Pet With {.Name = "Boots", .Age = 4}, _
                        New Pet With {.Name = "Whiskers", .Age = 1}, _
                        New Pet With {.Name = "Daisy", .Age = 4}})

        ' Group the pets using Pet.Age as the key.
        ' Use Pet.Name as the value for each entry.
        Dim query = pets.AsQueryable().GroupBy(Function(pet) pet.Age)

        Dim output As New System.Text.StringBuilder
        ' Iterate over each IGrouping in the collection.
        For Each ageGroup In query
            output.AppendFormat("Age group: {0}   Number of pets: {1}{2}", ageGroup.Key, ageGroup.Count(), vbCrLf)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' Age group: 8   Number of pets: 1
    ' Age group: 4   Number of pets: 2
    ' Age group: 1   Number of pets: 1

    ' </Snippet14>
End Class

Public Class GroupBy2
    ' <Snippet39>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub GroupByEx2()
        ' Create a list of Pet objects.
        Dim pets As New List(Of Pet)(New Pet() { _
                        New Pet With {.Name = "Barley", .Age = 8}, _
                        New Pet With {.Name = "Boots", .Age = 4}, _
                        New Pet With {.Name = "Whiskers", .Age = 1}, _
                        New Pet With {.Name = "Daisy", .Age = 4}})

        ' Group the pets using Pet.Age as the key.
        ' Use Pet.Name as the value for each entry.
        Dim query As IEnumerable(Of IGrouping(Of Integer, String)) = _
            pets.AsQueryable().GroupBy(Function(pet) pet.Age, Function(pet) pet.Name)

        Dim output As New System.Text.StringBuilder
        ' Iterate over each IGrouping in the collection.
        For Each petGroup As IGrouping(Of Integer, String) In query
            ' Print the key value of the IGrouping.
            output.AppendLine(petGroup.Key)
            ' Iterate over each value in the 
            ' IGrouping and print the value.
            For Each name As String In petGroup
                output.AppendLine(String.Format("  {0}", name))
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' 8
    '  Barley
    ' 4
    '  Boots
    '  Daisy
    ' 1
    '  Whiskers

    ' </Snippet39>
End Class

' Uses a resultSelector function.
Public Class GroupBy3
    ' <Snippet15>
    Structure Pet
        Public Name As String
        Public Age As Double
    End Structure

    Shared Sub GroupByEx3()
        ' Create a list of pets.
        Dim petsList As New List(Of Pet)(New Pet() { _
                           New Pet With {.Name = "Barley", .Age = 8.3}, _
                           New Pet With {.Name = "Boots", .Age = 4.9}, _
                           New Pet With {.Name = "Whiskers", .Age = 1.5}, _
                           New Pet With {.Name = "Daisy", .Age = 4.3}})

        ' Group Pet objects by the Math.Floor of their age.
        ' Then project an anonymous type from each group
        ' that consists of the key, the count of the group's
        ' elements, and the minimum and maximum age in the group.
        Dim query = petsList.AsQueryable().GroupBy( _
            Function(pet) Math.Floor(pet.Age), _
            Function(age, pets) New With { _
                .Key = age, _
                .Count = pets.Count(), _
                .Min = pets.Min(Function(pet) pet.Age), _
                .Max = pets.Max(Function(pet) pet.Age) _
            })

        Dim output As New System.Text.StringBuilder
        ' Iterate over each anonymous type.
        For Each result In query
            output.AppendLine(vbCrLf & "Age group: " & result.Key)
            output.AppendLine("Number of pets with this age: " & result.Count)
            output.AppendLine("Minimum age: " & result.Min)
            output.AppendLine("Maximum age: " & result.Max)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        '  Age group: 8
        '  Number of pets with this age: 1
        '  Minimum age: 8.3
        '  Maximum age: 8.3

        '  Age group: 4
        '  Number of pets with this age: 2
        '  Minimum age: 4.3
        '  Maximum age: 4.9

        '  Age group: 1
        '  Number of pets with this age: 1
        '  Minimum age: 1.5
        '  Maximum age: 1.5
    End Sub
    ' </Snippet15>
End Class

' Uses a resultSelector function.
Public Class GroupBy4
    ' <Snippet130>
    Structure Pet
        Public Name As String
        Public Age As Double
    End Structure

    Shared Sub GroupByEx4()
        ' Create a list of pets.
        Dim petsList As New List(Of Pet)(New Pet() { _
                           New Pet With {.Name = "Barley", .Age = 8.3}, _
                           New Pet With {.Name = "Boots", .Age = 4.9}, _
                           New Pet With {.Name = "Whiskers", .Age = 1.5}, _
                           New Pet With {.Name = "Daisy", .Age = 4.3}})

        ' Group Pet.Age valuesby the Math.Floor of the age.
        ' Then project an anonymous type from each group
        ' that consists of the key, the count of the group's
        ' elements, and the minimum and maximum age in the group.
        Dim query = petsList.AsQueryable().GroupBy( _
            Function(pet) Math.Floor(pet.Age), _
            Function(pet) pet.Age, _
            Function(baseAge, ages) New With { _
                .Key = baseAge, _
                .Count = ages.Count(), _
                .Min = ages.Min(), _
                .Max = ages.Max() _
            })

        Dim output As New System.Text.StringBuilder
        ' Iterate over each anonymous type.
        For Each result In query
            output.AppendLine(vbCrLf & "Age group: " & result.Key)
            output.AppendLine("Number of pets with this age: " & result.Count)
            output.AppendLine("Minimum age: " & result.Min)
            output.AppendLine("Maximum age: " & result.Max)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        '  Age group: 8
        '  Number of pets with this age: 1
        '  Minimum age: 8.3
        '  Maximum age: 8.3

        '  Age group: 4
        '  Number of pets with this age: 2
        '  Minimum age: 4.3
        '  Maximum age: 4.9

        '  Age group: 1
        '  Number of pets with this age: 1
        '  Minimum age: 1.5
        '  Maximum age: 1.5
    End Sub
    ' </Snippet130>
End Class

Public Class GroupJoin
    ' <Snippet40>
    Structure Person
        Public Name As String
    End Structure

    Structure Pet
        Public Name As String
        Public Owner As Person
    End Structure

    Shared Sub GroupJoinEx1()
        Dim magnus As New Person With {.Name = "Hedlund, Magnus"}
        Dim terry As New Person With {.Name = "Adams, Terry"}
        Dim charlotte As New Person With {.Name = "Weiss, Charlotte"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, daisy})

        ' Create a list where each element is an anonymous 
        ' type that contains a person's name and a collection
        ' of the names of the pets that are owned by them.
        Dim query = _
            people.AsQueryable().GroupJoin(pets, _
                       Function(person) person, _
                       Function(pet) pet.Owner, _
                       Function(person, petCollection) _
                           New With {.OwnerName = person.Name, _
                                     .Pets = petCollection.Select( _
                                                        Function(pet) pet.Name)})

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            ' Output the owner's name.
            output.AppendLine(String.Format("{0}:", obj.OwnerName))
            ' Output each of the owner's pet's names.
            For Each pet As String In obj.Pets
                output.AppendLine(String.Format("  {0}", pet))
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Hedlund, Magnus:
    '   Daisy
    ' Adams, Terry:
    '   Barley
    '   Boots
    ' Weiss, Charlotte:
    '   Whiskers

    ' </Snippet40>
End Class

Module Intersect
    Sub IntersectEx1()
        ' <Snippet41>
        Dim id1() As Integer = {44, 26, 92, 30, 71, 38}
        Dim id2() As Integer = {39, 59, 83, 47, 26, 4, 30}

        ' Get the numbers that occur in both arrays (id1 and id2).
        Dim both As IEnumerable(Of Integer) = id1.AsQueryable().Intersect(id2)

        Dim output As New System.Text.StringBuilder
        For Each id As Integer In both
            output.AppendLine(id)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 26
        ' 30

        ' </Snippet41>

    End Sub
End Module

Public Class Join
    ' <Snippet42>
    Structure Person
        Public Name As String
    End Structure

    Structure Pet
        Public Name As String
        Public Owner As Person
    End Structure

    Shared Sub JoinEx1()
        Dim magnus As New Person With {.Name = "Hedlund, Magnus"}
        Dim terry As New Person With {.Name = "Adams, Terry"}
        Dim charlotte As New Person With {.Name = "Weiss, Charlotte"}

        Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
        Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
        Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
        Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

        Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte})
        Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, daisy})

        ' Join the list of Person objects and the list of Pet objects 
        ' to create a list of person-pet pairs where each element is 
        ' an anonymous type that contains pet's name and the name of the
        ' Person object that owns the pet.
        Dim query = people.AsQueryable().Join(pets, _
                        Function(person) person, _
                        Function(pet) pet.Owner, _
                        Function(person, pet) _
                            New With {.OwnerName = person.Name, .Pet = pet.Name})

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            output.AppendLine(String.Format( _
                "{0} - {1}", obj.OwnerName, obj.Pet))
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Hedlund, Magnus - Daisy
    ' Adams, Terry - Barley
    ' Adams, Terry - Boots
    ' Weiss, Charlotte - Whiskers

    ' </Snippet42>
End Class

Module Last
    Sub LastEx1()
        ' <Snippet43>
        Dim numbers() As Integer = {9, 34, 65, 92, 87, 435, 3, 54, _
                            83, 23, 87, 67, 12, 19}

        Dim last As Integer = numbers.AsQueryable().Last()

        MsgBox(last)

        ' This code produces the following output:
        ' 19

        ' </Snippet43>
    End Sub

    Sub LastEx2()
        ' <Snippet44>
        Dim numbers() As Integer = {9, 34, 65, 92, 87, 435, 3, 54, _
                            83, 23, 87, 67, 12, 19}

        ' Get the last number in the array that is greater than 80.
        Dim last As Integer = numbers.AsQueryable().Last(Function(num) num > 80)

        MsgBox(last)

        ' This code produces the following output:
        ' 87

        ' </Snippet44>
    End Sub
End Module

Module LastOrDefault
    Sub LastOrDefaultEx1()
        ' <Snippet45>
        ' Create an empty array.
        Dim fruits() As String = {}

        ' Get the last item in the array, or else the default
        ' value for type string (null).
        Dim last As String = fruits.AsQueryable().LastOrDefault()

        MsgBox(IIf(String.IsNullOrEmpty(last), "[STRING IS NULL OR EMPTY]", last))

        ' This code produces the following output:
        ' [STRING IS NULL OR EMPTY]

        ' </Snippet45>
    End Sub

    Sub LastOrDefaultEx2()
        ' <Snippet46>
        Dim numbers() As Double = {49.6, 52.3, 51.0, 49.4, 50.2, 48.3}

        ' Get the last number in the array that rounds to 50.0,
        ' or else the default value for type double (0.0).
        Dim last50 As Double = _
             numbers.AsQueryable().LastOrDefault(Function(n) Math.Round(n) = 50.0)

        MsgBox(String.Format("The last number that rounds to 50 is {0}.", last50))

        ' Get the last number in the array that rounds to 40.0,
        ' or else the default value for type double (0.0).
        Dim last40 As Double = _
            numbers.AsQueryable().LastOrDefault(Function(n) Math.Round(n) = 40.0)

        MsgBox(String.Format("The last number that rounds to 40 is {0}.", _
            IIf(last40 = 0.0, "[DOES NOT EXIST]", last40.ToString())))

        'This code produces the following output:

        'The last number that rounds to 50 is 50.2.
        'The last number that rounds to 40 is [DOES NOT EXIST].

        ' </Snippet46>
    End Sub

    Sub LastOrDefaultEx3()
        ' <Snippet132>
        Dim daysOfMonth As New List(Of Integer)(New Integer() {})

        ' Setting the default value to 1 after the query.
        Dim lastDay1 As Integer = daysOfMonth.AsQueryable().LastOrDefault()
        If lastDay1 = 0 Then
            lastDay1 = 1
        End If
        MsgBox(String.Format("The value of the lastDay1 variable is {0}", lastDay1))

        ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
        Dim lastDay2 As Integer = daysOfMonth.AsQueryable().DefaultIfEmpty(1).Last()
        MsgBox(String.Format("The value of the lastDay2 variable is {0}", lastDay2))

        ' This code produces the following output:
        '
        ' The value of the lastDay1 variable is 1
        ' The value of the lastDay2 variable is 1

        ' </Snippet132>
    End Sub
End Module

Module LongCount
    Sub LongCountEx1()
        ' <Snippet47>
        Dim fruits() As String = {"apple", "banana", "mango", _
                              "orange", "passionfruit", "grape"}

        Dim count As Long = fruits.AsQueryable().LongCount()

        MsgBox(String.Format("There are {0} fruits in the collection.", count))

        ' This code produces the following output:

        ' There are 6 fruits in the collection.

        ' </Snippet47>
    End Sub
End Module

Public Class LongCount2
    ' <Snippet48>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub LongCountEx2()
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8}, _
                           New Pet With {.Name = "Boots", .Age = 4}, _
                           New Pet With {.Name = "Whiskers", .Age = 1}}

        Const Age As Integer = 3

        ' Count the number of Pet objects where Pet.Age is greater than 3.
        Dim count As Long = pets.AsQueryable().LongCount(Function(Pet) Pet.Age > Age)

        MsgBox(String.Format("There are {0} animals over age {1}.", count, Age))
    End Sub

    ' This code produces the following output:

    ' There are 2 animals over age 3.

    ' </Snippet48>
End Class

Public Class Max
    Shared Sub MaxEx1()
        ' <Snippet52>
        Dim longs As New List(Of Long)(New Long() {4294967296L, 466855135L, 81125L})

        Dim max As Long = longs.AsQueryable().Max()

        MsgBox(String.Format("The largest number is {0}.", max))

        'This code produces the following output:

        'The largest number is 4294967296.

        ' </Snippet52>
    End Sub

    ' <Snippet58>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub MaxEx2()
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8}, _
                       New Pet With {.Name = "Boots", .Age = 4}, _
                       New Pet With {.Name = "Whiskers", .Age = 1}}

        ' Add Pet.Age to the length of Pet.Name
        ' to determine the "maximum" Pet object in the array.
        Dim max As Integer = _
            pets.AsQueryable().Max(Function(pet) pet.Age + pet.Name.Length)

        MsgBox(String.Format("The maximum pet age plus name length is {0}.", max))

        'This code produces the following output:

        'The maximum pet age plus name length is 14.

        ' </Snippet58>
    End Sub
End Class

Public Class Min
    Shared Sub MinEx1()
        ' <Snippet60>
        Dim doubles() As Double = {1.5E+104, 9.0E+103, -2.0E+103}

        Dim min As Double = doubles.AsQueryable().Min()

        MsgBox(String.Format("The smallest number is {0}.", min))

        'This code produces the following output:

        'The smallest number is -2E+103.

        ' </Snippet60>
    End Sub

    ' <Snippet68>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub MinEx2()
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8}, _
                       New Pet With {.Name = "Boots", .Age = 4}, _
                       New Pet With {.Name = "Whiskers", .Age = 1}}

        ' Get the Pet object that has the smallest Age value.
        Dim min As Integer = pets.AsQueryable().Min(Function(pet) pet.Age)

        MsgBox(String.Format("The youngest animal is age {0}.", min))
    End Sub

    'This code produces the following output:

    'The youngest animal is age 1.  

    ' </Snippet68>
End Class

Module OfType
    Sub OfTypeEx1()
        ' <Snippet69>
        ' Create a list of MemberInfo objects.
        Dim members As List(Of System.Reflection.MemberInfo) = GetType(String).GetMembers().ToList()

        ' Return only those items that can be cast to type PropertyInfo.
        Dim propertiesOnly As IQueryable(Of System.Reflection.PropertyInfo) = _
                members.AsQueryable().OfType(Of System.Reflection.PropertyInfo)()

        Dim output As New System.Text.StringBuilder
        output.AppendLine("Members of type 'PropertyInfo' are:")
        For Each pi As System.Reflection.PropertyInfo In propertiesOnly
            output.AppendLine(pi.Name)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' Members of type 'PropertyInfo' are:
        ' Chars
        ' Length

        ' </Snippet69>
    End Sub
End Module

Public Class OrderBy
    ' <Snippet70>
    Structure Pet
        Public Name As String
        Public Age As Integer
    End Structure

    Shared Sub OrderByEx1()
        Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8}, _
                             New Pet With {.Name = "Boots", .Age = 4}, _
                             New Pet With {.Name = "Whiskers", .Age = 1}}

        ' Sort the Pet objects in the array by Pet.Age.
        Dim query As IEnumerable(Of Pet) = _
                    pets.AsQueryable().OrderBy(Function(pet) pet.Age)

        Dim output As New System.Text.StringBuilder
        For Each pet As Pet In query
            output.AppendLine(String.Format("{0} - {1}", pet.Name, pet.Age))
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Whiskers - 1
    ' Boots - 4
    ' Barley - 8

    ' </Snippet70>
End Class

Module OrderByDescending
    ' <Snippet71>
    ''' <summary>
    ''' This class provides a custom implementation of the
    ''' IComparer.Compare() method. It sorts by the fractional part of the decimal number.
    ''' </summary>
    Class SpecialComparer
        Implements IComparer(Of Decimal)

        ''' <summary>
        ''' Compare two decimal numbers by their fractional parts.
        ''' </summary>
        ''' <param name="d1">The first decimal to compare.</param>
        ''' <param name="d2">The second decimal to compare.</param>
        ''' <returns>1 if the first decimal's fractional part is greater than
        ''' the second decimal's fractional part,
        ''' -1 if the first decimal's fractional
        ''' part is less than the second decimal's fractional part,
        ''' or the result of calling Decimal.Compare()
        ''' if the fractional parts are equal.</returns>
        Function Compare(ByVal d1 As Decimal, ByVal d2 As Decimal) As Integer _
            Implements IComparer(Of Decimal).Compare

            Dim fractional1 As Decimal
            Dim fractional2 As Decimal

            ' Get the fractional part of the first number.
            Try
                fractional1 = Decimal.Remainder(d1, Decimal.Floor(d1))
            Catch ex As DivideByZeroException
                fractional1 = d1
            End Try

            ' Get the fractional part of the second number.
            Try
                fractional2 = Decimal.Remainder(d2, Decimal.Floor(d2))
            Catch ex As DivideByZeroException
                fractional2 = d2
            End Try

            If (fractional1 = fractional2) Then
                ' The fractional parts are equal, so compare the entire numbers.
                Return Decimal.Compare(d1, d2)
            ElseIf (fractional1 > fractional2) Then
                Return 1
            Else
                Return -1
            End If
        End Function
    End Class

    Sub OrderByDescendingEx1()
        ' Create a list of decimal values.
        Dim decimals As New List(Of Decimal)(New Decimal() _
                                             {6.2D, 8.3D, 0.5D, 1.3D, 6.3D, 9.7D})

        ' Order the elements of the list by passing
        ' in the custom IComparer class.
        Dim query As IEnumerable(Of Decimal) = _
            decimals.AsQueryable(). _
            OrderByDescending(Function(num) num, New SpecialComparer())

        Dim output As New System.Text.StringBuilder
        For Each num As Decimal In query
            output.AppendLine(num)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' 9.7
    ' 0.5
    ' 8.3
    ' 6.3
    ' 1.3
    ' 6.2

    ' </Snippet71>
End Module

Module Reverse
    Sub ReverseEx1()
        ' <Snippet74>
        Dim appleLetters As New List(Of Char)(New Char() _
                                              {"a"c, "p"c, "p"c, "l"c, "e"c})

        ' Reverse the order of the characters in the collection.
        Dim reversed As IQueryable(Of Char) = _
           appleLetters.AsQueryable().Reverse()

        Dim output As New System.Text.StringBuilder
        For Each chr As Char In reversed
            output.Append(chr & " ")
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:
        '
        ' e l p p a 

        ' </Snippet74>
    End Sub
End Module

Module SelectModule
    Sub SelectEx1()
        ' <Snippet75>
        Dim range As New List(Of Integer)(New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})

        ' Project the square of each int value.
        Dim squares As IEnumerable(Of Integer) = _
            range.AsQueryable().Select(Function(x) x * x)

        Dim output As New System.Text.StringBuilder
        For Each num As Integer In squares
            output.AppendLine(num)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 1
        ' 4
        ' 9
        ' 16
        ' 25
        ' 36
        ' 49
        ' 64
        ' 81
        ' 100

        ' </Snippet75>
    End Sub

    Sub SelectEx2()
        ' <Snippet76>
        Dim fruits() As String = {"apple", "banana", "mango", "orange", _
                              "passionfruit", "grape"}

        ' Project an anonymous type that contains the
        ' index of the string in the source array, and
        ' a string that contains the same number of characters
        ' as the string's index in the source array.
        Dim query = _
            fruits.AsQueryable() _
            .Select(Function(fruit, index) New With {index, .str = fruit.Substring(0, index)})

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            output.AppendLine(obj.ToString())
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' { index = 0, str =  }
        ' { index = 1, str = b }
        ' { index = 2, str = ma }
        ' { index = 3, str = ora }
        ' { index = 4, str = pass }
        ' { index = 5, str = grape }

        ' </Snippet76>
    End Sub
End Module

Public Class SelectMany
    ' <Snippet77>
    Structure PetOwner
        Public Name As String
        Public Pets() As String
    End Structure

    Shared Sub SelectManyEx1()
        Dim petOwners() As PetOwner = _
            {New PetOwner With _
             {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}}, _
             New PetOwner With _
             {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}}, _
             New PetOwner With _
             {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}}}

        ' Query using SelectMany().
        Dim query1 As IEnumerable(Of String) = _
                    petOwners.AsQueryable().SelectMany(Function(petOwner) petOwner.Pets)

        Dim output As New System.Text.StringBuilder("Using SelectMany():" & vbCrLf)
        ' Only one foreach loop is required to iterate through 
        ' the results because it is a one-dimensional collection.
        For Each pet As String In query1
            output.AppendLine(pet)
        Next

        ' This code shows how to use Select() instead of SelectMany().
        Dim query2 As IEnumerable(Of String()) = _
                    petOwners.AsQueryable().Select(Function(petOwner) petOwner.Pets)

        output.AppendLine(vbCrLf & "Using Select():")
        ' Notice that two foreach loops are required to iterate through 
        ' the results because the query returns a collection of arrays.
        For Each petArray() As String In query2
            For Each pet As String In petArray
                output.AppendLine(pet)
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Using SelectMany():
    ' Scruffy
    ' Sam
    ' Walker
    ' Sugar
    ' Scratches
    ' Diesel

    ' Using Select():
    ' Scruffy
    ' Sam
    ' Walker
    ' Sugar
    ' Scratches
    ' Diesel

    ' </Snippet77>

End Class

Public Class SelectMany2
    ' <Snippet78>
    Structure PetOwner
        Public Name As String
        Public Pets() As String
    End Structure

    Shared Sub SelectManyEx2()
        Dim petOwners() As PetOwner = _
            {New PetOwner With _
             {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}}, _
             New PetOwner With _
             {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}}, _
             New PetOwner With _
             {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}}, _
             New PetOwner With _
             {.Name = "Hines, Patrick", .Pets = New String() {"Dusty"}}}

        ' For each PetOwner element in the source array,
        ' project a sequence of strings where each string
        ' consists of the index of the PetOwner element in the
        ' source array and the name of each pet in PetOwner.Pets.
        Dim query As IEnumerable(Of String) = _
            petOwners.AsQueryable() _
            .SelectMany(Function(petOwner, index) petOwner.Pets.Select(Function(pet) index.ToString() + pet))

        Dim output As New System.Text.StringBuilder
        For Each pet As String In query
            output.AppendLine(pet)
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:
    '
    ' 0Scruffy
    ' 0Sam
    ' 1Walker
    ' 1Sugar
    ' 2Scratches
    ' 2Diesel
    ' 3Dusty

    ' </Snippet78>
End Class

Public Class SelectMany3
    ' <Snippet124>
    Structure PetOwner
        Public Name As String
        Public Pets As List(Of Pet)
    End Structure

    Structure Pet
        Public Name As String
        Public Breed As String
    End Structure

    Shared Sub SelectManyEx3()
        Dim petOwners() As PetOwner = _
                    {New PetOwner With {.Name = "Higa", _
                          .Pets = New List(Of Pet)(New Pet() { _
                              New Pet With {.Name = "Scruffy", .Breed = "Poodle"}, _
                              New Pet With {.Name = "Sam", .Breed = "Hound"}})}, _
                      New PetOwner With {.Name = "Ashkenazi", _
                          .Pets = New List(Of Pet)(New Pet() { _
                              New Pet With {.Name = "Walker", .Breed = "Collie"}, _
                              New Pet With {.Name = "Sugar", .Breed = "Poodle"}})}, _
                      New PetOwner With {.Name = "Price", _
                          .Pets = New List(Of Pet)(New Pet() { _
                              New Pet With {.Name = "Scratches", .Breed = "Dachshund"}, _
                              New Pet With {.Name = "Diesel", .Breed = "Collie"}})}, _
                      New PetOwner With {.Name = "Hines", _
                          .Pets = New List(Of Pet)(New Pet() { _
                              New Pet With {.Name = "Dusty", .Breed = "Collie"}})} _
                    }

        ' This query demonstrates how to obtain a sequence of
        ' the names of all the pets whose breed is "Collie", while
        ' keeping an association with the owner that owns the pet.
        Dim query = petOwners.AsQueryable() _
            .SelectMany(Function(owner) owner.Pets, _
                   Function(owner, pet) New With {owner, pet}) _
            .Where(Function(ownerAndPet) ownerAndPet.pet.Breed = "Collie") _
            .Select(Function(ownerAndPet) New With { _
                .Owner = ownerAndPet.owner.Name, _
                .Pet = ownerAndPet.pet.Name})

        Dim output As New System.Text.StringBuilder
        For Each obj In query
            output.AppendLine(String.Format("Owner={0}, Pet={1}", obj.Owner, obj.Pet))
        Next

        ' Display the output.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' Owner=Ashkenazi, Pet=Walker
    ' Owner=Price, Pet=Diesel
    ' Owner=Hines, Pet=Dusty

    ' </Snippet124>
End Class

Public Class SequenceEqual
    ' <Snippet32>
    Class Pet
        Public Name As String
        Public Age As Integer
    End Class

    Shared Sub SequenceEqualEx1()
        Dim pet1 As New Pet With {.Name = "Turbo", .Age = 2}
        Dim pet2 As New Pet With {.Name = "Peanut", .Age = 8}

        ' Create two lists of pets.
        Dim pets1 As New List(Of Pet)(New Pet() {pet1, pet2})
        Dim pets2 As New List(Of Pet)(New Pet() {pet1, pet2})

        ' Determine if the lists are equal.
        Dim equal As Boolean = pets1.AsQueryable().SequenceEqual(pets2)

        ' Display the output.
        Dim text As String = IIf(equal, "are", "are not")
        MsgBox("The lists " & text & " equal.")
    End Sub

    'This code produces the following output:

    'The lists are equal.

    ' </Snippet32>
End Class

Public Class SequenceEqual2
    ' <Snippet33>
    Class Pet
        Public Name As String
        Public Age As Integer
    End Class

    Shared Sub SequenceEqualEx2()
        Dim pet1 As New Pet With {.Name = "Turbo", .Age = 2}
        Dim pet2 As New Pet With {.Name = "Peanut", .Age = 8}

        ' Create two lists of pets.
        Dim pets1 As New List(Of Pet)()
        pets1.Add(pet1)
        pets1.Add(pet2)

        Dim pets2 As New List(Of Pet)()
        pets2.Add(New Pet With {.Name = "Turbo", .Age = 2})
        pets2.Add(New Pet With {.Name = "Peanut", .Age = 8})

        ' Determine if the lists are equal.
        Dim equal As Boolean = pets1.AsQueryable().SequenceEqual(pets2)

        ' Display the output.
        Dim text As String = IIf(equal, "are", "are not")
        MsgBox("The lists " & text & " equal.")
    End Sub

    ' This code produces the following output:

    ' The lists are not equal.

    ' </Snippet33>
End Class

Module SingleMod
    Sub SingleEx1()
        ' <Snippet79>
        ' Create two arrays.
        Dim fruits1() As String = {"orange"}
        Dim fruits2() As String = {"orange", "apple"}

        ' Get the only item in the first array.
        Dim result As String = fruits1.AsQueryable().Single()

        ' Display the result.
        MsgBox("First query: " & result)

        Try
            ' Try to get the only item in the second array.
            Dim fruit2 As String = fruits2.AsQueryable().Single()
            MsgBox("Second query: " + fruit2)
        Catch
            MsgBox("Second query: The collection does not contain exactly one element.")
        End Try

        ' This code produces the following output:

        ' First query: orange
        ' Second query: The collection does not contain exactly one element.

        ' </Snippet79>
    End Sub

    Sub SingleEx2()
        ' <Snippet81>
        Dim fruits() As String = _
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

        ' Get the only string in the array whose length is greater than 10.
        Dim result As String = _
            fruits.AsQueryable().Single(Function(fruit) fruit.Length > 10)

        ' Display the result.
        MsgBox("First Query: " & result)

        Try
            ' Try to get the only string in the array
            ' whose length is greater than 15.
            Dim fruit2 As String = fruits.AsQueryable().Single(Function(fruit) fruit.Length > 15)
            MsgBox("Second Query: " + fruit2)
        Catch
            Dim text As String = "Second Query: The collection does not contain "
            text = text & "exactly one element whose length is greater than 15."
            MsgBox(text)
        End Try

        ' This code produces the following output:

        ' First Query: passionfruit
        ' Second Query: The collection does not contain exactly one 
        '   element whose length is greater than 15.

        ' </Snippet81>
    End Sub
End Module

Module SingleOrDefault
    Sub SingleOrDefaultEx1()
        ' <Snippet83>
        ' Create two arrays. The second is empty.
        Dim fruits1() As String = {"orange"}
        Dim fruits2() As String = {}

        ' Get the only item in the first array, or else
        ' the default value for type string (null).
        Dim fruit1 As String = fruits1.AsQueryable().SingleOrDefault()
        MsgBox("First Query: " + fruit1)

        ' Get the only item in the second array, or else
        ' the default value for type string (null). 
        Dim fruit2 As String = fruits2.AsQueryable().SingleOrDefault()
        MsgBox("Second Query: " & _
            IIf(String.IsNullOrEmpty(fruit2), "No such string!", fruit2))

        ' This code produces the following output:

        ' First Query: orange
        ' Second Query: No such string!

        ' </Snippet83>
    End Sub

    Sub SingleOrDefaultEx2()
        ' <Snippet85>
        Dim fruits() As String = _
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

        ' Get the single string in the array whose length is greater
        ' than 10, or else the default value for type string (null).
        Dim fruit1 As String = _
            fruits.AsQueryable().SingleOrDefault(Function(fruit) fruit.Length > 10)
        ' Display the result.
        MsgBox("First Query: " & fruit1)

        ' Get the single string in the array whose length is greater
        ' than 15, or else the default value for type string (null).
        Dim fruit2 As String = _
            fruits.AsQueryable().SingleOrDefault(Function(fruit) fruit.Length > 15)
        MsgBox("Second Query: " & _
            IIf(String.IsNullOrEmpty(fruit2), "No such string!", fruit2))

        ' This code produces the following output:

        ' First Query: passionfruit
        ' Second Query: No such string!

        ' </Snippet85>
    End Sub

    Sub SingleOrDefaultEx3()
        ' <Snippet133>
        Dim pageNumbers() As Integer = {}

        ' Setting the default value to 1 after the query.
        Dim pageNumber1 As Integer = pageNumbers.AsQueryable().SingleOrDefault()
        If pageNumber1 = 0 Then
            pageNumber1 = 1
        End If
        MsgBox(String.Format("The value of the pageNumber1 variable is {0}", pageNumber1))

        ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
        Dim pageNumber2 As Integer = pageNumbers.AsQueryable().DefaultIfEmpty(1).Single()
        MsgBox(String.Format("The value of the pageNumber2 variable is {0}", pageNumber2))

        ' This code produces the following output:

        ' The value of the pageNumber1 variable is 1
        ' The value of the pageNumber2 variable is 1

        ' </Snippet133>
    End Sub
End Module

Module Skip
    Sub SkipEx1()
        ' <Snippet87>
        Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

        ' Sort the grades in descending order and
        ' get all except the first three.
        Dim lowerGrades = grades.AsQueryable() _
            .OrderByDescending(Function(g) g) _
            .Skip(3)

        Dim output As New System.Text.StringBuilder
        output.AppendLine("All grades except the top three are:")
        For Each grade As Integer In lowerGrades
            output.AppendLine(grade)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' All grades except the top three are:
        ' 82
        ' 70
        ' 59
        ' 56

        ' </Snippet87>
    End Sub
End Module

Module SkipWhile
    Sub SkipWhileEx1()
        ' <Snippet88>
        Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

        ' Get all grades less than 80 by first  sorting the grades 
        ' in descending order and then taking all the grades that 
        ' occur after the first grade that is less than 80.
        Dim lowerGrades = grades.AsQueryable() _
            .OrderByDescending(Function(grade) grade) _
            .SkipWhile(Function(grade) grade >= 80)

        Dim output As New System.Text.StringBuilder
        output.AppendLine("All grades below 80:")
        For Each grade As Integer In lowerGrades
            output.AppendLine(grade)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' All grades below 80:
        ' 70
        ' 59
        ' 56

        ' </Snippet88>    
    End Sub

    Sub SkipWhileEx2()
        ' <Snippet89>
        Dim amounts() As Integer = {5000, 2500, 9000, 8000, _
                            6500, 4000, 1500, 5500}

        ' Skip over amounts in the array until the first amount
        ' that is less than or equal to the product of its
        ' index in the array and 1000. Take the remaining items.
        Dim query = amounts.AsQueryable() _
            .SkipWhile(Function(amount, index) amount > index * 1000)

        Dim output As New System.Text.StringBuilder
        For Each amount As Integer In query
            output.AppendLine(amount)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 4000
        ' 1500
        ' 5500

        ' </Snippet89>    
    End Sub
End Module

Public Class Sum
    Shared Sub SumEx1()
        ' <Snippet120>
        Dim numbers As New List(Of Single)(New Single() {43.68F, 1.25F, 583.7F, 6.5F})

        Dim sum As Single = numbers.AsQueryable().Sum()

        MsgBox("The sum of the numbers is " & sum)

        ' This code produces the following output:

        ' The sum of the numbers is 635.13.

        ' </Snippet120>
    End Sub

    Shared Sub SumEx2()
        ' <Snippet121>
        Dim points As Nullable(Of Single)() = {Nothing, 0, 92.83F, Nothing, 100.0F, 37.46F, 81.1F}

        Dim sum As Nullable(Of Single) = points.AsQueryable().Sum()

        MsgBox("Total points earned: " & sum)

        'This code produces the following output:

        'Total points earned: 311.39

        ' </Snippet121>
    End Sub

    ' <Snippet98>
    Structure Package
        Public Company As String
        Public Weight As Double
    End Structure

    Shared Sub SumEx3()
        Dim packages As New List(Of Package)(New Package() { _
                New Package With {.Company = "Coho Vineyard", .Weight = 25.2}, _
                  New Package With {.Company = "Lucerne Publishing", .Weight = 18.7}, _
                  New Package With {.Company = "Wingtip Toys", .Weight = 6.0}, _
                  New Package With {.Company = "Adventure Works", .Weight = 33.8}})

        ' Calculate the sum of all package weights.
        Dim totalWeight As Double = packages.AsQueryable().Sum(Function(pkg) pkg.Weight)

        MsgBox("The total weight of the packages is: " & totalWeight)
    End Sub

    'This code produces the following output:

    'The total weight of the packages is: 83.7

    ' </Snippet98>
End Class

Module Take
    Sub TakeEx1()
        ' <Snippet99>
        Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

        ' Sort the grades in descending order and take the first three.
        Dim topThreeGrades = _
            grades.AsQueryable().OrderByDescending(Function(grade) grade).Take(3)

        Dim output As New System.Text.StringBuilder
        output.AppendLine("The top three grades are:")
        For Each grade As Integer In topThreeGrades
            output.AppendLine(grade)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' The top three grades are:
        ' 98
        ' 92
        ' 85

        ' </Snippet99>
    End Sub

    Sub TakeWhileEx1()
        ' <Snippet100>
        Dim fruits() As String = {"apple", "banana", "mango", "orange", _
                              "passionfruit", "grape"}

        ' Take strings from the array until a string
        ' that is equal to "orange" is found.
        Dim query = fruits.AsQueryable() _
            .TakeWhile(Function(fruit) String.Compare("orange", fruit, True) <> 0)

        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next

        ' Display the output.
        MsgBox(output.ToString())

        'This code produces the following output:

        'apple
        'banana
        'mango

        ' </Snippet100>
    End Sub

    Sub TakeWhileEx2()
        ' <Snippet101>
        Dim fruits() As String = _
            {"apple", "passionfruit", "banana", "mango", _
             "orange", "blueberry", "grape", "strawberry"}

        ' Take strings from the array until a string whose length
        ' is less than its index in the array is found.
        Dim query = fruits.AsQueryable() _
            .TakeWhile(Function(fruit, index) fruit.Length >= index)

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' apple
        ' passionfruit
        ' banana
        ' mango
        ' orange
        ' blueberry

        ' </Snippet101>
    End Sub
End Module

Module ThenBy
    Sub ThenByEx1()
        ' <Snippet102>
        Dim fruits() As String = _
            {"grape", "passionfruit", "banana", "mango", _
             "orange", "raspberry", "apple", "blueberry"}

        ' Sort the strings first by their length and then 
        ' alphabetically by passing the identity selector function.
        Dim query = fruits.AsQueryable() _
            .OrderBy(Function(fruit) fruit.Length).ThenBy(Function(fruit) fruit)

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next
        MsgBox(output.ToString())

        'This code produces the following output:

        'apple
        'grape
        'mango
        'banana
        'orange
        'blueberry
        'raspberry
        'passionfruit

        ' </Snippet102>
    End Sub
End Module

Module ThenByDescending
    ' <Snippet103>
    Class CaseInsensitiveComparer
        Implements IComparer(Of String)

        Function Compare(ByVal x As String, ByVal y As String) As Integer _
            Implements IComparer(Of String).Compare

            ' Compare values and ignore case.
            Return String.Compare(x, y, True)
        End Function
    End Class

    Sub ThenByDescendingEx1()
        Dim fruits() As String = _
            {"apPLe", "baNanA", "apple", "APple", "orange", "BAnana", "ORANGE", "apPLE"}

        ' Sort the strings first ascending by their length and 
        ' then descending by using a custom case insensitive comparer.
        Dim query = fruits.AsQueryable() _
            .OrderBy(Function(fruit) fruit.Length) _
            .ThenByDescending(Function(fruit) fruit, New CaseInsensitiveComparer())

        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next

        ' Display the results.
        MsgBox(output.ToString())
    End Sub

    ' This code produces the following output:

    ' apPLe
    ' apple
    ' APple
    ' apPLE
    ' orange
    ' ORANGE
    ' baNanA
    ' BAnana

    ' </Snippet103>
End Module

Module Union
    Sub UnionEx1()
        ' <Snippet109>
        Dim ints1() As Integer = {5, 3, 9, 7, 5, 9, 3, 7}
        Dim ints2() As Integer = {8, 3, 6, 4, 4, 9, 1, 0}

        ' Get the set union of the items in the two arrays.
        Dim union = ints1.AsQueryable().Union(ints2)

        Dim output As New System.Text.StringBuilder
        For Each num As Integer In union
            output.Append(String.Format("{0} ", num))
        Next

        ' Display the output.
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 5 3 9 7 8 6 4 1 0

        ' </Snippet109>
    End Sub
End Module

Module Where
    Sub WhereEx1()
        ' <Snippet110>
        Dim fruits As New List(Of String)(New String() _
                                {"apple", "passionfruit", "banana", "mango", _
                                 "orange", "blueberry", "grape", "strawberry"})

        ' Get all strings whose length is less than 6.
        Dim query = fruits.AsQueryable().Where(Function(fruit) fruit.Length < 6)

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each fruit As String In query
            output.AppendLine(fruit)
        Next
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' apple
        ' mango
        ' grape

        ' </Snippet110>
    End Sub

    Sub WhereEx2()
        ' <Snippet111>
        Dim numbers() As Integer = {0, 30, 20, 15, 90, 85, 40, 75}

        ' Get all the numbers that are less than or equal to
        ' the product of their index in the array and 10.
        Dim query = numbers.AsQueryable() _
            .Where(Function(number, index) number <= index * 10)

        ' Display the results.
        Dim output As New System.Text.StringBuilder
        For Each number As Integer In query
            output.AppendLine(number)
        Next
        MsgBox(output.ToString())

        ' This code produces the following output:

        ' 0
        ' 20
        ' 15
        ' 40

        ' </Snippet111>
    End Sub
End Module

Module Zip
    Sub ZipEx()
        ' <Snippet200>
        Dim numbers() As Integer = {1, 2, 3, 4}
        Dim words() As String = {"one", "two", "three"}
        Dim numbersAndWords = numbers.AsQueryable().Zip(words, Function(first, second) first & " " & second)

        For Each item In numbersAndWords
            Console.WriteLine(item)
        Next

        ' This code produces the following output:

        ' 1 one
        ' 2 two
        ' 3 three

        ' </Snippet200>
    End Sub
End Module