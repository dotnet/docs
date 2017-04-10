Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace SequenceExamples
    Module EnumerableSnippets
        Sub Main()
            CountEx1()
            Count.CountEx2()
        End Sub

#Region "Aggregate"

        ' <Snippet1>
        Sub AggregateEx1()
            Dim sentence As String =
            "the quick brown fox jumps over the lazy dog"
            ' Split the string into individual words.
            Dim words() As String = sentence.Split(" "c)
            ' Prepend each word to the beginning of the new sentence to reverse the word order.
            Dim reversed As String =
            words.Aggregate(Function(ByVal current, ByVal word) word & " " & current)

            ' Display the output.
            MsgBox(reversed)
        End Sub

        ' This code produces the following output:
        '
        ' dog lazy the over jumps fox brown quick the

        ' </Snippet1>

        ' <Snippet2>
        Sub AggregateEx2()
            ' Create an array of Integers.
            Dim ints() As Integer = {4, 8, 8, 3, 9, 0, 7, 8, 2}

            ' Count the even numbers in the array, using a seed value of 0.
            Dim numEven As Integer =
            ints.Aggregate(0,
                           Function(ByVal total, ByVal number) _
                               IIf(number Mod 2 = 0, total + 1, total))

            ' Display the output.
            MsgBox("The number of even integers is " & numEven)
        End Sub

        ' This code produces the following output:
        '
        'The number of even integers is 6

        ' </Snippet2>

        ' <Snippet3>
        Sub AggregateEx3()
            Dim fruits() As String =
            {"apple", "mango", "orange", "passionfruit", "grape"}

            ' Determine whether any string in the array is longer than "banana".
            Dim longestName As String =
            fruits.Aggregate("banana",
                             Function(ByVal longest, ByVal fruit) _
                                 IIf(fruit.Length > longest.Length, fruit, longest),
                             Function(ByVal fruit) fruit.ToUpper())

            ' Display the output.
            MsgBox("The fruit with the longest name is " & longestName)
        End Sub

        ' This code produces the following output:
        '
        ' The fruit with the longest name is PASSIONFRUIT

        ' </Snippet3>
#End Region

#Region "All"
        NotInheritable Class All
            ' <Snippet4>
            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub AllEx()
                ' Create an array of Pets.
                Dim pets() As Pet =
            {New Pet With {.Name = "Barley", .Age = 2},
             New Pet With {.Name = "Boots", .Age = 4},
             New Pet With {.Name = "Whiskers", .Age = 7}}

                ' Determine whether all pet names in the array start with "B".
                Dim allNames As Boolean =
            pets.All(Function(ByVal pet) pet.Name.StartsWith("B"))

                ' Display the output.
                Dim text As String = IIf(allNames, "All", "Not all")
                MsgBox(text & " pet names start with 'B'.")
            End Sub

            ' This code produces the following output:
            '
            ' Not all pet names start with 'B'.

            ' </Snippet4>
        End Class

        NotInheritable Class All2
            ' <Snippet129>
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
            {New Person With {.LastName = "Haas",
                              .Pets = New Pet() {New Pet With {.Name = "Barley", .Age = 10},
                                                 New Pet With {.Name = "Boots", .Age = 14},
                                                 New Pet With {.Name = "Whiskers", .Age = 6}}},
              New Person With {.LastName = "Fakhouri",
                               .Pets = New Pet() {New Pet With {.Name = "Snowball", .Age = 1}}},
              New Person With {.LastName = "Antebi",
                               .Pets = New Pet() {New Pet With {.Name = "Belle", .Age = 8}}},
              New Person With {.LastName = "Philips",
                               .Pets = New Pet() {New Pet With {.Name = "Sweetie", .Age = 2},
                                                  New Pet With {.Name = "Rover", .Age = 13}}}})

                ' Determine which people have pets that are all older than 5.
                Dim names = From person In people
                            Where person.Pets.All(Function(pet) pet.Age > 5)
                            Select person.LastName

                For Each name As String In names
                    Console.WriteLine(name)
                Next

                ' This code produces the following output:
                '
                ' Haas
                ' Antebi

            End Sub
            ' </Snippet129>
        End Class

#End Region

#Region "Any"

        NotInheritable Class Any1
            Sub AnyEx1()
                ' <Snippet5>
                ' Create a list of Integers.
                Dim numbers As New List(Of Integer)(New Integer() {1, 2})

                ' Determine if the list contains any items.
                Dim hasElements As Boolean = numbers.Any()

                ' Display the output.
                Dim text As String = IIf(hasElements, "not ", "")
                MsgBox("The list is " & text & "empty.")

                ' This code produces the following output:
                '
                ' The list is not empty.

                ' </Snippet5>
            End Sub

            ' <Snippet130>
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
            {New Person With {.LastName = "Haas",
                              .Pets = New Pet() {New Pet With {.Name = "Barley", .Age = 10},
                                                 New Pet With {.Name = "Boots", .Age = 14},
                                                 New Pet With {.Name = "Whiskers", .Age = 6}}},
              New Person With {.LastName = "Fakhouri",
                               .Pets = New Pet() {New Pet With {.Name = "Snowball", .Age = 1}}},
              New Person With {.LastName = "Antebi",
                               .Pets = New Pet() {}},
              New Person With {.LastName = "Philips",
                               .Pets = New Pet() {New Pet With {.Name = "Sweetie", .Age = 2},
                                                  New Pet With {.Name = "Rover", .Age = 13}}}})

                ' Determine which people have a non-empty Pet array.
                Dim names = From person In people
                            Where person.Pets.Any()
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
            ' </Snippet130>
        End Class

        Public Class Any2
            ' <Snippet6>
            Structure Pet
                Public Name As String
                Public Age As Integer
                Public Vaccinated As Boolean
            End Structure

            Shared Sub AnyEx3()
                ' Create a list of Pets
                Dim pets As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8, .Vaccinated = True},
                                      New Pet With {.Name = "Boots", .Age = 4, .Vaccinated = False},
                                      New Pet With {.Name = "Whiskers", .Age = 1, .Vaccinated = False}})

                ' Determine whether any pets over age 1 are also unvaccinated.
                Dim unvaccinated As Boolean =
            pets.Any(Function(pet) pet.Age > 1 And pet.Vaccinated = False)

                ' Display the output.
                Dim text As String = IIf(unvaccinated, "are", "are not")
                MsgBox("There " & text & " unvaccinated animals over age 1.")
            End Sub

            ' This code produces the following output:
            '
            ' There are unvaccinated animals over age 1.

            ' </Snippet6>
        End Class

#End Region

#Region "AsEnumerable"
        ' <Snippet108>
        Dim output As New System.Text.StringBuilder

        ' A custom class.
        Class Clump(Of T)
            Inherits List(Of T)

            ' Constructor.
            Public Sub New(ByVal collection As IEnumerable(Of T))
                MyBase.New(collection)
            End Sub

            ' Custom implementation of Where().
            Function Where(ByVal predicate As Func(Of T, Boolean)) As IEnumerable(Of T)
                output.AppendLine("In Clump's implementation of Where().")
                Return Enumerable.Where(Me, predicate)
            End Function
        End Class

        Sub AsEnumerableEx1()
            ' Create a new Clump(Of T) object.
            Dim fruitClump As New Clump(Of String)(New String() _
                                               {"apple", "passionfruit", "banana",
                                                "mango", "orange", "blueberry",
                                                "grape", "strawberry"})

            ' First call to Where():
            ' Call Clump's Where() method with a predicate.
            Dim query1 As IEnumerable(Of String) =
            fruitClump.Where(Function(fruit) fruit.Contains("o"))
            output.AppendLine("query1 has been created." & vbCrLf)

            ' Second call to Where():
            ' First call AsEnumerable() to hide Clump's Where() method and thereby
            ' force System.Linq.Enumerable's Where() method to be called.
            Dim query2 As IEnumerable(Of String) =
            fruitClump.AsEnumerable().Where(Function(fruit) fruit.Contains("o"))
            output.AppendLine("query2 has been created.")

            ' Display the output.
            MsgBox(output.ToString())
        End Sub

        ' This code produces the following output:
        '
        ' In Clump's implementation of Where().
        ' query1 has been created.
        '
        ' query2 has been created.

        ' </Snippet108>
#End Region

#Region "Average"
        Sub AverageEx1()
            ' <Snippet8>
            ' Create a list of integers.
            Dim grades As New List(Of Integer)(New Integer() {78, 92, 100, 37, 81})

            ' Determine the average value in the list.
            Dim avg As Double = grades.Average()

            ' Display the output.
            MsgBox("The average grade is " & avg)

            ' This code produces the following output:
            '
            ' The average grade is 77.6

            ' </Snippet8>
        End Sub

        Sub AverageEx2()
            ' <Snippet12>
            ' Create an array of nullable long values.
            Dim longs() As Nullable(Of Long) = {Nothing, 10007L, 37L, 399846234235L}

            ' Determine the average value in the array.
            Dim avg As Nullable(Of Double) = longs.Average()

            ' Display the output.
            MsgBox("The average is " & avg.ToString)

            ' This code produces the following output:
            '
            ' The average is 133282081426.333

            ' </Snippet12>
        End Sub

        Sub AverageEx3()
            ' <Snippet16>
            ' Create an array of strings.
            Dim numbers() As String = {"10007", "37", "299846234235"}

            ' Determine the average number after converting each
            ' string to an Int64 value.
            Dim avg As Double =
            numbers.Average(Function(number) Convert.ToInt64(number))

            ' Display the output.
            MsgBox("The average is " & avg)

            ' This code produces the following output:
            '
            ' The average is 99948748093

            ' </Snippet16>
        End Sub

        Sub AverageEx4()
            ' <Snippet18>
            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Determine the average length of the strings in the array.
            Dim avg As Double = fruits.Average(Function(s) s.Length)

            ' Display the output.
            MsgBox("The average string length is " & avg)

            ' This code produces the following output:
            '
            ' The average string length is 6.5

            ' </Snippet18>
        End Sub

#End Region

#Region "Cast"
        Sub CastEx1()
            ' <Snippet19>
            ' Create an ArrayList and add items to it.
            Dim fruits As New System.Collections.ArrayList()
            fruits.Add("mango")
            fruits.Add("apple")
            fruits.Add("lemon")

            ' Call Cast(Of String) to cast the ArrayList elements to strings.
            Dim query As IEnumerable(Of String) =
            fruits.Cast(Of String)().OrderBy(Function(fruit) fruit).Select(Function(fruit) fruit)

            '' The following code, without the cast, doesn't compile.
            'Dim query As IEnumerable(Of String) = _
            '    fruits.OrderBy(Function(fruit) fruit).Select(Function(fruit) fruit)

            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' lemon
            ' mango
            ' </Snippet19>
        End Sub
#End Region

#Region "Concat"

        NotInheritable Class Concat
            ' <Snippet20>
            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            ' Returns an array of Pet objects.
            Function GetCats() As Pet()
                Dim cats() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                             New Pet With {.Name = "Boots", .Age = 4},
                             New Pet With {.Name = "Whiskers", .Age = 1}}

                Return cats
            End Function

            ' Returns an array of Pet objects.
            Function GetDogs() As Pet()
                Dim dogs() As Pet = {New Pet With {.Name = "Bounder", .Age = 3},
                             New Pet With {.Name = "Snoopy", .Age = 14},
                             New Pet With {.Name = "Fido", .Age = 9}}
                Return dogs
            End Function

            Sub ConcatEx1()
                ' Create two arrays of Pet objects.
                Dim cats() As Pet = GetCats()
                Dim dogs() As Pet = GetDogs()

                ' Project the Name of each cat and concatenate
                ' the collection of cat name strings with a collection
                ' of dog name strings.
                Dim query As IEnumerable(Of String) =
            cats _
            .Select(Function(cat) cat.Name) _
            .Concat(dogs.Select(Function(dog) dog.Name))

                Dim output As New System.Text.StringBuilder
                For Each name As String In query
                    output.AppendLine(name)
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Barley
            ' Boots
            ' Whiskers
            ' Bounder
            ' Snoopy
            ' Fido

            ' </Snippet20>

            Sub ConcatEx2()
                ' <Snippet112>
                ' Create two arrays of Pet objects.
                Dim cats() As Pet = GetCats()
                Dim dogs() As Pet = GetDogs()

                ' Create an IEnumerable collection that contains two elements.
                ' Each element is an array of Pet objects.
                Dim animals() As IEnumerable(Of Pet) = {cats, dogs}

                Dim query As IEnumerable(Of String) =
            (animals.SelectMany(Function(pets) _
                                    pets.Select(Function(pet) pet.Name)))

                Dim output As New System.Text.StringBuilder
                For Each name As String In query
                    output.AppendLine(name)
                Next

                ' Display the output.
                MsgBox(output.ToString())

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

#End Region

#Region "Contains"
        Sub ContainsEx1()
            ' <Snippet21>
            ' Create an array of strings.
            Dim fruits() As String = {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' This is the string to search the array for.
            Dim fruit As String = "mango"

            ' Determine if the array contains the specified string.
            Dim hasMango As Boolean = fruits.Contains(fruit)

            Dim text As String = IIf(hasMango, "does", "does not")

            ' Display the output.
            MsgBox("The array " & text & " contain " & fruit)

            ' This code produces the following output:
            '
            ' The array does contain mango

            ' </Snippet21>
        End Sub
#End Region

#Region "Count"
        Sub CountEx1()
            ' <Snippet22>
            ' Create an array of strings.
            Dim fruits() As String = {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            Try
                ' Count the number of items in the array.
                Dim numberOfFruits As Integer = fruits.Count()
                ' Display the output.
                MsgBox("There are " & numberOfFruits & " fruits in the collection.")
            Catch e As OverflowException
                MsgBox("The count is too large to store as an Int32. Try using LongCount() instead.")
            End Try

            ' This code produces the following output:
            '
            ' There are 6 fruits in the collection.

            ' </Snippet22>
        End Sub

        NotInheritable Class Count

            ' <Snippet23>
            Structure Pet
                Public Name As String
                Public Vaccinated As Boolean
            End Structure

            Public Shared Sub CountEx2()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Vaccinated = True},
                             New Pet With {.Name = "Boots", .Vaccinated = False},
                             New Pet With {.Name = "Whiskers", .Vaccinated = False}}

                Try
                    ' Count the number of Pets in the array where the Vaccinated property is False.
                    Dim numberUnvaccinated As Integer =
                pets.Count(Function(p) p.Vaccinated = False)
                    ' Display the output.
                    MsgBox("There are " & numberUnvaccinated & " unvaccinated animals.")
                Catch e As OverflowException
                    MsgBox("The count is too large to store as an Int32. Try using LongCount() instead.")
                End Try

            End Sub

            ' This code produces the following output:
            '
            ' There are 2 unvaccinated animals.

            ' </Snippet23>
        End Class

#End Region

#Region "DefaultIfEmpty"
        NotInheritable Class DefaultIfEmpty1
            ' <Snippet24>
            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub DefaultIfEmptyEx1()
                ' Create a List of Pet objects.
                Dim pets As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8},
                                      New Pet With {.Name = "Boots", .Age = 4},
                                      New Pet With {.Name = "Whiskers", .Age = 1}})

                Dim output As New System.Text.StringBuilder
                ' Iterate through the items in the List, calling DefaultIfEmpty().
                For Each pet As Pet In pets.DefaultIfEmpty()
                    output.AppendLine(pet.Name)
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Barley
            ' Boots
            ' Whiskers

            ' </Snippet24>
        End Class

        Sub DefaultIfEmptyEx1a()
            ' <Snippet25>
            ' Create an empty List.
            Dim numbers As New List(Of Integer)()

            Dim output As New System.Text.StringBuilder
            ' Iterate through the items in the List, calling DefaultIfEmpty().
            For Each number As Integer In numbers.DefaultIfEmpty()
                output.AppendLine(number)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 0

            ' </Snippet25>
        End Sub

        NotInheritable Class DefaultIfEmpty2
            ' <Snippet26>
            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub DefaultIfEmptyEx2()
                ' Create a Pet object to use as the default value.
                Dim defaultPet As New Pet With {.Name = "Default Pet", .Age = 0}

                ' Create a List of Pet objects.
                Dim pets1 As New List(Of Pet)(New Pet() _
                                      {New Pet With {.Name = "Barley", .Age = 8},
                                       New Pet With {.Name = "Boots", .Age = 4},
                                       New Pet With {.Name = "Whiskers", .Age = 1}})

                Dim output1 As New System.Text.StringBuilder
                ' Enumerate the items in the list, calling DefaultIfEmpty() 
                ' with a default value.
                For Each pet As Pet In pets1.DefaultIfEmpty(defaultPet)
                    output1.AppendLine("Name: " & pet.Name)
                Next

                ' Display the output.
                MsgBox(output1.ToString())

                ' Create an empty List.
                Dim pets2 As New List(Of Pet)

                Dim output2 As New System.Text.StringBuilder
                ' Enumerate the items in the list, calling DefaultIfEmpty() 
                ' with a default value.
                For Each pet As Pet In pets2.DefaultIfEmpty(defaultPet)
                    output2.AppendLine("Name: " & pet.Name)
                Next

                ' Display the output.
                MsgBox(output2.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Name: Barley
            ' Name: Boots
            ' Name: Whiskers
            '
            ' Name: Default Pet

            ' </Snippet26>
        End Class

#End Region

#Region "Distinct"
        Sub DistinctEx1()
            ' <Snippet27>
            ' Create a list of integers.
            Dim ages As New List(Of Integer)(New Integer() _
                                         {21, 46, 46, 55, 17, 21, 55, 55})

            ' Select the unique numbers in the List.
            Dim distinctAges As IEnumerable(Of Integer) = ages.Distinct()

            Dim output As New System.Text.StringBuilder("Distinct ages:" & vbCrLf)
            For Each age As Integer In distinctAges
                output.AppendLine(age)
            Next

            ' Display the output.
            MsgBox(output.ToString)

            ' This code produces the following output:
            '
            ' Distinct ages:
            ' 21
            ' 46
            ' 55
            ' 17

            ' </Snippet27>
        End Sub
#End Region

#Region "ElementAt"
        Sub ElementAtEx1()
            ' <Snippet28>
            ' Create an array of strings.
            Dim names() As String =
            {"Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu"}

            Dim random As Random = New Random(DateTime.Now.Millisecond)

            ' Get a string at a random index within the array.
            Dim name As String = names.ElementAt(random.Next(0, names.Length))

            ' Display the output.
            MsgBox("The name chosen at random is " & name)

            ' This code produces the following output:
            '
            ' The name chosen at random is Ito, Shu

            ' </Snippet28>
        End Sub
#End Region

#Region "ElementAtOrDefault"
        Sub ElementAtOrDefaultEx1()
            ' <Snippet29>
            ' Create an array of strings.
            Dim names() As String =
            {"Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu"}

            Dim index As Integer = 20

            ' Get a string at an index that is out of range in the array.
            Dim name As String = names.ElementAtOrDefault(index)

            Dim text As String = If(String.IsNullOrEmpty(name), "[THERE IS NO NAME AT THIS INDEX]", name)

            ' Display the output.
            MsgBox("The name chosen at index " & index & " is " & text)

            ' This code produces the following output:
            '
            ' The name chosen at index 20 is [THERE IS NO NAME AT THIS INDEX]

            ' </Snippet29>
        End Sub
#End Region

#Region "Empty"

        Sub EmptyEx1()
            ' <Snippet30>
            ' Create an empty sequence.
            Dim empty As IEnumerable(Of Decimal) = Enumerable.Empty(Of Decimal)()
            ' </Snippet30>
        End Sub

        Sub EmptyEx2()
            ' <Snippet31>
            ' Create three string arrays.
            Dim names1() As String =
            {"Hartono, Tommy"}
            Dim names2() As String =
            {"Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu"}
            Dim names3() As String =
            {"Solanki, Ajay", "Hoeing, Helge", "Andersen, Henriette Thaulow", "Potra, Cristina", "Iallo, Lucio"}

            ' Create a List that contains 3 elements, where
            ' each element is an array of strings.
            Dim namesList As New List(Of String())(New String()() {names1, names2, names3})

            ' Select arrays that have four or more elements and union
            ' them into one collection, using Empty() to generate the 
            ' empty collection for the seed value.
            Dim allNames As IEnumerable(Of String) =
            namesList.Aggregate(Enumerable.Empty(Of String)(),
                                Function(current, nextOne) _
                                    IIf(nextOne.Length > 3, current.Union(nextOne), current))

            Dim output As New System.Text.StringBuilder
            For Each name As String In allNames
                output.AppendLine(name)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' Adams, Terry
            ' Andersen, Henriette Thaulow
            ' Hedlund, Magnus
            ' Ito, Shu
            ' Solanki, Ajay
            ' Hoeing, Helge
            ' Potra, Cristina
            ' Iallo, Lucio

            ' </Snippet31>
        End Sub
#End Region

#Region "Except"
        Sub ExceptEx1()
            ' <Snippet34>
            ' Create two arrays of doubles.
            Dim numbers1() As Double = { 2.0, 2.0, 2.1, 2.2, 2.3, 2.3, 2.4, 2.5 }
            Dim numbers2() As Double = {2.2}

            ' Select the elements from the first array that are not
            ' in the second array.
            Dim onlyInFirstSet As IEnumerable(Of Double) = numbers1.Except(numbers2)

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
#End Region

#Region "First"
        Sub FirstEx1()
            ' <Snippet35>
            ' Create an array of integers.
            Dim numbers() As Integer =
            {9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 435, 67, 12, 19}

            ' Select the first element in the array.
            Dim first As Integer = numbers.First()

            ' Display the output.
            MsgBox(first)

            ' This code produces the following output:
            '
            ' 9

            ' </Snippet35>
        End Sub

        Sub FirstEx2()
            ' <Snippet36>
            ' Create an array of integers.
            Dim numbers() As Integer =
            {9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 435, 67, 12, 19}

            ' Select the first element in the array whose value is greater than 80.
            Dim first As Integer = numbers.First(Function(number) number > 80)

            ' Display the output.
            MsgBox(first)

            ' This code produces the following output:
            '
            ' 92

            ' </Snippet36>
        End Sub
#End Region

#Region "FirstOrDefault"
        Sub FirstOrDefaultEx1()
            ' <Snippet37>
            ' Create an empty array.
            Dim numbers() As Integer = {}

            ' Select the first element in the array, or a default value
            ' if there are not elements in the array.
            Dim first As Integer = numbers.FirstOrDefault()

            ' Display the output.
            MsgBox(first)

            ' This code produces the following output:
            '
            ' 0

            ' </Snippet37>
        End Sub

        Sub FirstOrDefaultEx2()
            ' <Snippet38>
            ' Create an array of strings.
            Dim names() As String =
            {"Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu"}

            ' Select the first string in the array whose length is greater than 20.
            Dim firstLongName As String =
            names.FirstOrDefault(Function(name) name.Length > 20)

            ' Display the output.
            MsgBox("The first long name is " & firstLongName)

            ' Select the first string in the array whose length is greater than 30,
            ' or a default value if there are no such strings in the array.
            Dim firstVeryLongName As String =
            names.FirstOrDefault(Function(name) name.Length > 30)

            Dim text As String = IIf(String.IsNullOrEmpty(firstVeryLongName), "not a", "a")

            MsgBox("There is " & text & " name longer than 30 characters.")

            ' This code produces the following output:
            '
            ' The first long name is Andersen, Henriette Thaulow
            '
            ' There is not a name longer than 30 characters.

            ' </Snippet38>
        End Sub

        Sub FirstOrDefaultEx3()
            ' <Snippet126>
            Dim months As New List(Of Integer)(New Integer() {})

            ' Setting the default value to 1 after the query.
            Dim firstMonth1 As Integer = months.FirstOrDefault()
            If firstMonth1 = 0 Then
                firstMonth1 = 1
            End If
            MsgBox(String.Format("The value of the firstMonth1 variable is {0}", firstMonth1))

            ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
            Dim firstMonth2 As Integer = months.DefaultIfEmpty(1).First()
            MsgBox(String.Format("The value of the firstMonth2 variable is {0}", firstMonth2))

            ' This code produces the following output:
            '
            ' The value of the firstMonth1 variable is 1
            ' The value of the firstMonth2 variable is 1

            ' </Snippet126>
        End Sub
#End Region

#Region "GroupBy"

        NotInheritable Class GroupBy

            ' <Snippet39>
            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub GroupByEx1()
                'Create a list of Pet objects.
                Dim pets As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8},
                                      New Pet With {.Name = "Boots", .Age = 4},
                                      New Pet With {.Name = "Whiskers", .Age = 1},
                                      New Pet With {.Name = "Daisy", .Age = 4}})

                ' Group the pets using Age as the key 
                ' and selecting only the pet's Name for each value.
                Dim query As IEnumerable(Of IGrouping(Of Integer, String)) =
            pets.GroupBy(Function(pet) pet.Age,
                         Function(pet) pet.Name)

                Dim output As New System.Text.StringBuilder
                ' Iterate over each IGrouping in the collection.
                For Each petGroup As IGrouping(Of Integer, String) In query
                    ' Print the key value of the IGrouping.
                    output.AppendLine(petGroup.Key)
                    ' Iterate over each value in the IGrouping and print the value.
                    For Each name As String In petGroup
                        output.AppendLine("  " & name)
                    Next
                Next

                ' Display the output.
                MsgBox(output.ToString)
            End Sub

            ' This code produces the following output:
            '
            ' 8
            '   Barley
            ' 4
            '   Boots
            '   Daisy
            ' 1
            '   Whiskers

            ' </Snippet39>

            ' Uses query expression syntax.
            Sub GroupByEx2()
                ' Create a list of pets.
                Dim pets As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8},
                                      New Pet With {.Name = "Boots", .Age = 4},
                                      New Pet With {.Name = "Whiskers", .Age = 1},
                                      New Pet With {.Name = "Daisy", .Age = 4}})

                ' Group the pets using Age as the key 
                ' and selecting only the pet's Name for each value.
                ' <Snippet122>
                Dim query =
            From pet In pets
            Group pet.Name By Age = pet.Age Into ageGroup = Group
                ' </Snippet122>

                Dim output As New System.Text.StringBuilder
                ' Iterate over each IGrouping in the collection.
                For Each petGroup In query
                    ' Print the key value of the IGrouping.
                    output.AppendLine(petGroup.Age)
                    ' Iterate over each value in the IGrouping 
                    ' and print the value.
                    For Each name As String In petGroup.ageGroup
                        output.AppendLine(String.Format("  {0}", name))
                    Next
                Next

                ' Display the output.
                MsgBox(output.ToString)

                ' This code produces the following output:
                '
                ' 8
                '   Barley
                ' 4
                '   Boots
                '   Daisy
                ' 1
                '   Whiskers
            End Sub
        End Class

        ' Uses a resultSelector function.

        NotInheritable Class GroupBy3
            ' <Snippet15>
            Structure Pet
                Public Name As String
                Public Age As Double
            End Structure

            Public Sub GroupByEx3()
                ' Create a list of pets.
                Dim petsList As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8.3},
                                      New Pet With {.Name = "Boots", .Age = 4.9},
                                      New Pet With {.Name = "Whiskers", .Age = 1.5},
                                      New Pet With {.Name = "Daisy", .Age = 4.3}})

                ' Group Pet objects by the Math.Floor of their age.
                ' Then project an anonymous type from each group
                ' that consists of the key, the count of the group's
                ' elements, and the minimum and maximum age in the group.
                Dim query = petsList.GroupBy(
            Function(pet) Math.Floor(pet.Age),
            Function(age, pets) New With
                {.Key = age,
                .Count = pets.Count(),
                .Min = pets.Min(Function(pet) pet.Age),
                .Max = pets.Max(Function(Pet) Pet.Age)}
            )

                Dim output As New System.Text.StringBuilder
                ' Iterate over each anonymous type.
                For Each result In query
                    output.AppendLine(vbCrLf & "Age group: " & result.Key)
                    output.AppendLine("Number of pets in this age group: " & result.Count)
                    output.AppendLine("Minimum age: " & result.Min)
                    output.AppendLine("Maximum age: " & result.Max)
                Next

                ' Display the output.
                MsgBox(output.ToString)
            End Sub

            ' This code produces the following output:

            ' Age group: 8
            ' Number of pets in this age group: 1
            ' Minimum age: 8.3
            ' Maximum age: 8.3
            '
            ' Age group: 4
            ' Number of pets in this age group: 2
            ' Minimum age: 4.3
            ' Maximum age: 4.9
            '
            ' Age group: 1
            ' Number of pets in this age group: 1
            ' Minimum age: 1.5
            ' Maximum age: 1.5

            ' </Snippet15>

        End Class

        NotInheritable Class GroupBy4
            ' <Snippet125>
            Structure Pet
                Public Name As String
                Public Age As Double
            End Structure

            Public Sub GroupByEx4()
                ' Create a list of pets.
                Dim petsList As New List(Of Pet)(New Pet() _
                                     {New Pet With {.Name = "Barley", .Age = 8.3},
                                      New Pet With {.Name = "Boots", .Age = 4.9},
                                      New Pet With {.Name = "Whiskers", .Age = 1.5},
                                      New Pet With {.Name = "Daisy", .Age = 4.3}})

                ' Group Pet.Age values by the Math.Floor of the age.
                ' Then project an anonymous type from each group
                ' that consists of the key, the count of the group's
                ' elements, and the minimum and maximum age in the group.
                Dim query = petsList.GroupBy(
            Function(pet) Math.Floor(pet.Age),
            Function(pet) pet.Age,
            Function(baseAge, ages) New With
                {.Key = baseAge,
                .Count = ages.Count(),
                .Min = ages.Min(),
                .Max = ages.Max()}
            )

                Dim output As New System.Text.StringBuilder
                ' Iterate over each anonymous type.
                For Each result In query
                    output.AppendLine(vbCrLf & "Age group: " & result.Key)
                    output.AppendLine("Number of pets in this age group: " & result.Count)
                    output.AppendLine("Minimum age: " & result.Min)
                    output.AppendLine("Maximum age: " & result.Max)
                Next

                ' Display the output.
                MsgBox(output.ToString)
            End Sub

            ' This code produces the following output:

            ' Age group: 8
            ' Number of pets in this age group: 1
            ' Minimum age: 8.3
            ' Maximum age: 8.3
            '
            ' Age group: 4
            ' Number of pets in this age group: 2
            ' Minimum age: 4.3
            ' Maximum age: 4.9
            '
            ' Age group: 1
            ' Number of pets in this age group: 1
            ' Minimum age: 1.5
            ' Maximum age: 1.5

            ' </Snippet125>
        End Class

#End Region

#Region "GroupJoin"

        NotInheritable Class GroupJoin

            ' <Snippet40>
            Structure Person
                Public Name As String
            End Structure

            Structure Pet
                Public Name As String
                Public Owner As Person
            End Structure

            Sub GroupJoinEx1()
                Dim magnus As New Person With {.Name = "Hedlund, Magnus"}
                Dim terry As New Person With {.Name = "Adams, Terry"}
                Dim charlotte As New Person With {.Name = "Weiss, Charlotte"}

                Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
                Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
                Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
                Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

                Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte})
                Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, daisy})

                ' Create a collection where each element is an anonymous type
                ' that contains a Person's name and a collection of names of 
                ' the pets that are owned by them.
                Dim query =
            people.GroupJoin(pets,
                       Function(person) person,
                       Function(pet) pet.Owner,
                       Function(person, petCollection) _
                           New With {.OwnerName = person.Name,
                                     .Pets = petCollection.Select(
                                                        Function(pet) pet.Name)})

                Dim output As New System.Text.StringBuilder
                For Each obj In query
                    ' Output the owner's name.
                    output.AppendLine(obj.OwnerName & ":")
                    ' Output each of the owner's pet's names.
                    For Each pet As String In obj.Pets
                        output.AppendLine("  " & pet)
                    Next
                Next

                ' Display the output.
                MsgBox(output.ToString)
            End Sub

            ' This code produces the following output:
            '
            ' Hedlund, Magnus
            '   Daisy
            ' Adams, Terry
            '   Barley
            '   Boots
            ' Weiss, Charlotte
            '   Whiskers

            ' </Snippet40>
        End Class

#End Region

#Region "Intersect"
        Sub IntersectExample1()
            ' <Snippet41>
            ' Create two integer arrays.
            Dim id1() As Integer = {44, 26, 92, 30, 71, 38}
            Dim id2() As Integer = {39, 59, 83, 47, 26, 4, 30}

            ' Find the set intersection of the two arrays.
            Dim intersection As IEnumerable(Of Integer) = id1.Intersect(id2)

            Dim output As New System.Text.StringBuilder
            For Each id As Integer In intersection
                output.AppendLine(id)
            Next

            ' Display the output.
            MsgBox(output.ToString)

            ' This code produces the following output:
            '
            ' 26
            ' 30

            ' </Snippet41>
        End Sub
#End Region

#Region "Join"

        NotInheritable Class Join
            ' <Snippet42>
            Structure Person
                Public Name As String
            End Structure

            Structure Pet
                Public Name As String
                Public Owner As Person
            End Structure

            Sub JoinEx1()
                Dim magnus As New Person With {.Name = "Hedlund, Magnus"}
                Dim terry As New Person With {.Name = "Adams, Terry"}
                Dim charlotte As New Person With {.Name = "Weiss, Charlotte"}

                Dim barley As New Pet With {.Name = "Barley", .Owner = terry}
                Dim boots As New Pet With {.Name = "Boots", .Owner = terry}
                Dim whiskers As New Pet With {.Name = "Whiskers", .Owner = charlotte}
                Dim daisy As New Pet With {.Name = "Daisy", .Owner = magnus}

                Dim people As New List(Of Person)(New Person() {magnus, terry, charlotte})
                Dim pets As New List(Of Pet)(New Pet() {barley, boots, whiskers, daisy})

                ' Create a list of Person-Pet pairs, where each element is an
                ' anonymous type that contains a Pet's name and the name of the 
                ' Person that owns the Pet.
                Dim query =
            people.Join(pets,
                        Function(person) person,
                        Function(pet) pet.Owner,
                        Function(person, pet) _
                            New With {.OwnerName = person.Name, .Pet = pet.Name})

                Dim output As New System.Text.StringBuilder
                For Each obj In query
                    output.AppendLine(obj.OwnerName & " - " & obj.Pet)
                Next

                ' Display the output.
                MsgBox(output.ToString)
            End Sub

            ' This code produces the following output:
            '
            ' Hedlund, Magnus - Daisy
            ' Adams, Terry - Barley
            ' Adams, Terry - Boots
            ' Weiss, Charlotte - Whiskers

            ' </Snippet42>

        End Class

#End Region

#Region "Last"
        Sub LastEx1()
            ' <Snippet43>
            ' Create an array of integers.
            Dim numbers() As Integer =
            {9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 67, 12, 19}

            ' Get the last item in the array.
            Dim last As Integer = numbers.Last()

            ' Display the result.
            MsgBox(last)

            ' This code produces the following output:
            '
            ' 19

            ' </Snippet43>
        End Sub

        Sub LastEx2()
            ' <Snippet44>
            ' Create an array of integers.
            Dim numbers() As Integer =
            {9, 34, 65, 92, 87, 435, 3, 54, 83, 23, 87, 67, 12, 19}

            ' Get the last element in the array whose value is
            ' greater than 80.
            Dim last As Integer = numbers.Last(Function(num) num > 80)

            ' Display the result.
            MsgBox(last)

            ' This code produces the following output:
            '
            ' 87

            ' </Snippet44>
        End Sub
#End Region

#Region "LastOrDefault"
        Sub LastOrDefaultEx1()
            ' <Snippet45>
            ' Create an empty array.
            Dim fruits() As String = {}

            ' Get the last item in the array, or a
            ' default value if there are no items.
            Dim last As String = fruits.LastOrDefault()

            ' Display the result.
            MsgBox(IIf(String.IsNullOrEmpty(last),
                   "<string is Nothing or empty>",
                   last))

            ' This code produces the following output:
            '
            ' <string is Nothing or empty>

            ' </Snippet45>
        End Sub

        Sub LastOrDefaultEx2()
            ' <Snippet46>
            ' Create an array of doubles.
            Dim numbers() As Double = {49.6, 52.3, 51.0, 49.4, 50.2, 48.3}

            ' Get the last item whose value rounds to 50.0.
            Dim number50 As Double =
            numbers.LastOrDefault(Function(n) Math.Round(n) = 50.0)

            Dim output As New System.Text.StringBuilder
            output.AppendLine("The last number that rounds to 50 is " & number50)

            ' Get the last item whose value rounds to 40.0.
            Dim number40 As Double =
            numbers.LastOrDefault(Function(n) Math.Round(n) = 40.0)

            Dim text As String = IIf(number40 = 0.0,
                                 "[DOES NOT EXIST]",
                                 number40.ToString())
            output.AppendLine("The last number that rounds to 40 is " & text)

            ' Display the output.
            MsgBox(output.ToString)

            ' This code produces the following output:
            '
            ' The last number that rounds to 50 is 50.2
            ' The last number that rounds to 40 is [DOES NOT EXIST]

            ' </Snippet46>
        End Sub

        Sub LastOrDefaultEx3()
            ' <Snippet127>
            Dim daysOfMonth As New List(Of Integer)(New Integer() {})

            ' Setting the default value to 1 after the query.
            Dim lastDay1 As Integer = daysOfMonth.LastOrDefault()
            If lastDay1 = 0 Then
                lastDay1 = 1
            End If
            MsgBox(String.Format("The value of the lastDay1 variable is {0}", lastDay1))

            ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
            Dim lastDay2 As Integer = daysOfMonth.DefaultIfEmpty(1).Last()
            MsgBox(String.Format("The value of the lastDay2 variable is {0}", lastDay2))

            ' This code produces the following output:
            '
            ' The value of the lastDay1 variable is 1
            ' The value of the lastDay2 variable is 1

            ' </Snippet127>
        End Sub
#End Region

#Region "LongCount"
        Sub LongCountEx1()
            ' <Snippet47>
            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Get the number of items in the array.
            Dim count As Long = fruits.LongCount()

            ' Display the result.
            MsgBox("There are " & count & " fruits in the collection.")

            ' This code produces the following output:
            '
            ' There are 6 fruits in the collection.

            ' </Snippet47>
        End Sub

        NotInheritable Class LongCount
            ' <Snippet48>
            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub LongCountEx2()
                ' Create a list of Pet objects.
                Dim pets As New List(Of Pet)(New Pet() _
                             {New Pet With {.Name = "Barley", .Age = 8},
                              New Pet With {.Name = "Boots", .Age = 4},
                              New Pet With {.Name = "Whiskers", .Age = 1}})

                ' Determine the number of elements in the list
                ' where the pet's age is greater than a constant value (3).
                Const Age As Integer = 3
                Dim count As Long =
            pets.LongCount(Function(pet) pet.Age > Age)

                ' Display the result.
                MsgBox("There are " & count & " animals over age " & Age)
            End Sub

            ' This code produces the following output:
            '
            ' There are 2 animals over age 3

            ' </Snippet48>
        End Class

#End Region

#Region "Max"
        Sub MaxEx1()
            ' <Snippet52>
            ' Create a list of Long values.
            Dim longs As New List(Of Long)(New Long() _
                                       {4294967296L, 466855135L, 81125L})

            ' Get the maximum value in the list.
            Dim max As Long = longs.Max()

            ' Display the result.
            MsgBox("The largest number is " & max)

            ' This code produces the following output:
            '
            ' The largest number is 4294967296

            ' </Snippet52>
        End Sub

        Sub MaxEx2()
            ' <Snippet54>
            ' Create an array of Nullable Double values.
            Dim doubles() As Nullable(Of Double) =
            {Nothing, 1.5E+104, 9.0E+103, -2.0E+103}

            ' Determine the maximum value in the array.
            Dim max As Nullable(Of Double) = doubles.Max()

            ' Display the result.
            MsgBox("The largest number is " & max)

            ' This code produces the following output:
            '
            ' The largest number is 1.5E+104

            ' </Snippet54>
        End Sub

        NotInheritable Class Max2
            ' <Snippet57>
            ' This class implements IComparable 
            ' and has a custom 'CompareTo' implementation.
            Class Pet
                Implements IComparable(Of Pet)

                Public Name As String
                Public Age As Integer

                ''' <summary>
                ''' Compares Pet objects by the sum of their age and name length.
                ''' </summary>
                ''' <param name="other">The Pet to compare this Pet to.</param>
                ''' <returns>-1 if this Pet's sum is 'less' than the other Pet,
                ''' 0 if they are equal,
                ''' or 1 if this Pet's sum is 'greater' than the other Pet.</returns>
                Function CompareTo(ByVal other As Pet) As Integer _
                Implements IComparable(Of Pet).CompareTo

                    If (other.Age + other.Name.Length > Me.Age + Me.Name.Length) Then
                        Return -1
                    ElseIf (other.Age + other.Name.Length = Me.Age + Me.Name.Length) Then
                        Return 0
                    Else
                        Return 1
                    End If
                End Function
            End Class

            Sub MaxEx3()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                                 New Pet With {.Name = "Boots", .Age = 4},
                                 New Pet With {.Name = "Whiskers", .Age = 1}}

                ' Find the "maximum" pet according to the 
                ' custom CompareTo() implementation.
                Dim max As Pet = pets.Max()

                ' Display the result.
                MsgBox("The 'maximum' animal is " & max.Name)
            End Sub

            ' This code produces the following output:
            '
            ' The 'maximum' animal is Barley

            ' </Snippet57>
        End Class

#End Region

#Region "Max2"
        NotInheritable Class Max10 'with a selector
            ' <Snippet58>
            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub MaxEx4()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                                 New Pet With {.Name = "Boots", .Age = 4},
                                 New Pet With {.Name = "Whiskers", .Age = 1}}

                ' Determine the "maximum" pet by passing a
                ' lambda expression to Max() that sums the pet's age
                ' and name length.
                Dim max As Integer = pets.Max(Function(pet) _
                                              pet.Age + pet.Name.Length)

                ' Display the result.
                MsgBox("The maximum pet age plus name length is " & max)
            End Sub

            ' This code produces the following output:
            '
            ' The maximum pet age plus name length is 14

            ' </Snippet58>
        End Class

#End Region

#Region "Min"
        Sub MinEx1()
            ' <Snippet60>
            ' Create an array of double values.
            Dim doubles() As Double = {1.5E+104, 9.0E+103, -2.0E+103}

            ' Determine the smallest number in the array.
            Dim min As Double = doubles.Min()

            ' Display the result.
            MsgBox("The smallest number is " & min)

            ' This code produces the following output:
            '
            ' The smallest number is -2E+103

            ' </Snippet60>
        End Sub

        Sub MinEx2()
            ' <Snippet63>
            Dim grades() As Nullable(Of Integer) = {78, 92, Nothing, 99, 37, 81}
            Dim min As Nullable(Of Integer) = grades.Min()

            ' Display the output.
            MsgBox("The lowest grade is " & min)

            ' This code produces the following output:
            '
            ' The lowest grade is 37

            ' </Snippet63>
        End Sub

        NotInheritable Class Min9
            ' <Snippet67>
            ' This class implements IComparable 
            ' and has a custom 'CompareTo' implementation.
            Class Pet
                Implements IComparable(Of Pet)

                Public Name As String
                Public Age As Integer

                ''' <summary>
                ''' Compares this Pet's age to another Pet's age.
                ''' </summary>
                ''' <param name="other">The Pet to compare this Pet to.</param>
                ''' <returns>-1 if this Pet's age is smaller,
                ''' 0 if the Pets' ages are equal,
                ''' or 1 if this Pet's age is greater.</returns>
                Function CompareTo(ByVal other As Pet) As Integer _
                Implements IComparable(Of Pet).CompareTo

                    If (other.Age > Me.Age) Then
                        Return -1
                    ElseIf (other.Age = Me.Age) Then
                        Return 0
                    Else
                        Return 1
                    End If
                End Function
            End Class

            Sub MinEx3()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                                 New Pet With {.Name = "Boots", .Age = 4},
                                 New Pet With {.Name = "Whiskers", .Age = 1}}

                ' Determine the "minimum" pet in the array,
                ' according to the custom CompareTo() implementation.
                Dim min As Pet = pets.Min()

                ' Display the result.
                MsgBox("The 'minimum' pet is " & min.Name)
            End Sub

            ' This code produces the following output:
            '
            ' The 'minimum' pet is Whiskers

            ' </Snippet67>
        End Class

#End Region

#Region "Min2"
        NotInheritable Class Min10
            ' <Snippet68>
            Structure Pet
                Public Name As String
                Public Age As Integer
            End Structure

            Sub MinEx4()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                                 New Pet With {.Name = "Boots", .Age = 4},
                                 New Pet With {.Name = "Whiskers", .Age = 1}}

                ' Find the youngest pet by passing a 
                ' lambda expression to the Min() method.
                Dim min As Integer = pets.Min(Function(pet) pet.Age)

                ' Display the result.
                MsgBox("The youngest pet is age " & min)
            End Sub

            ' This code produces the following output:
            '
            ' The youngest pet is age 1

            ' </Snippet68>
        End Class

#End Region

#Region "OfType"
        Sub OfTypeEx1()
            ' <Snippet69>
            ' Create an ArrayList and add items to it.
            Dim fruits As New System.Collections.ArrayList(4)
            fruits.Add("Mango")
            fruits.Add("Orange")
            fruits.Add("Apple")
            fruits.Add(3.0)
            fruits.Add("Banana")

            ' Apply OfType(Of String)() to the ArrayList
            ' to filter out non-string items.
            Dim query1 As IEnumerable(Of String) = fruits.OfType(Of String)()

            ' Print the results.
            Dim output As New System.Text.StringBuilder("Elements of type 'string' are:" _
                                                    & vbCrLf)
            For Each fruit As String In query1
                output.AppendLine(fruit)
            Next

            ' The following query shows that the standard query operators such as 
            ' Where() can be applied to the ArrayList type after calling OfType().
            Dim query2 As IEnumerable(Of String) =
            fruits.OfType(Of String)().Where(Function(fruit) _
                                                 fruit.ToLower().Contains("n"))

            output.AppendLine(vbCrLf & "The following strings contain 'n':")
            For Each fruit As String In query2
                output.AppendLine(fruit)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' Elements of type 'string' are:
            ' Mango
            ' Orange
            ' Apple
            ' Banana
            '
            ' The following strings contain 'n':
            ' Mango
            ' Orange
            ' Banana

            ' </Snippet69>
        End Sub
#End Region

#Region "OrderBy"
        ' <Snippet70>
        Structure Pet
            Public Name As String
            Public Age As Integer
        End Structure

        Sub OrderByEx1()
            ' Create an array of Pet objects.
            Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                             New Pet With {.Name = "Boots", .Age = 4},
                             New Pet With {.Name = "Whiskers", .Age = 1}}

            ' Order the Pet objects by their Age property.
            Dim query As IEnumerable(Of Pet) =
            pets.OrderBy(Function(pet) pet.Age)

            Dim output As New System.Text.StringBuilder
            For Each pt As Pet In query
                output.AppendLine(pt.Name & " - " & pt.Age)
            Next

            ' Display the output.
            MsgBox(output.ToString())
        End Sub

        ' This code produces the following output:
        '
        ' Whiskers - 1
        ' Boots - 4
        ' Barley - 8

        ' </Snippet70>

        ' <Snippet140>
        Class CaseInsensitiveCompare
            Implements IComparer(Of String)
            ' Define a compare method that ignores case.
            Public Function Compare(ByVal s1 As String, ByVal s2 As String) As Integer _
            Implements System.Collections.Generic.IComparer(Of String).Compare
                Return String.Compare(s1, s2, True)
            End Function
        End Class

        Class CaseSensitiveCompare
            Implements IComparer(Of String)
            ' Define a compare method that does not ignore case.
            Public Function Compare(ByVal s1 As String, ByVal s2 As String) As Integer _
            Implements System.Collections.Generic.IComparer(Of String).Compare
                Return String.Compare(s1, s2, False)
            End Function
        End Class


        Sub OrderByIcomparer()
            Dim unsortedArray() As String = {"one", "Four", "One", "First", "four", "first"}

            ' Sort the array, ignoring case, and display the results.
            Dim sortedArray = unsortedArray.OrderBy(Function(a) a, New CaseInsensitiveCompare())
            Console.WriteLine("Case-insensitive sort of the strings in the array:")
            For Each element In sortedArray
                Console.WriteLine(element)
            Next

            ' Sort the array, not ignoring case, and display the results.
            sortedArray = unsortedArray.OrderBy(Function(a As String) a, New CaseSensitiveCompare())
            Console.WriteLine(vbCrLf & "Case-sensitive sort of the strings in the array:")
            For Each element In sortedArray
                Console.WriteLine(element)
            Next

            ' Change the lambda expression to sort by the length of each string.
            sortedArray = unsortedArray.OrderBy(Function(a) (a.Length).ToString(), New CaseInsensitiveCompare())
            Console.WriteLine(vbCrLf & "Sort based on the lengths of the strings in " &
                "the array:")
            For Each element In sortedArray
                Console.WriteLine(element)
            Next
        End Sub
        ' Output:
        ' Case-insensitive sort of the strings in the array:
        ' First
        ' first
        ' Four
        ' four
        ' one
        ' One

        ' Case-sensitive sort of the strings in the array:
        ' first
        ' First
        ' four
        ' Four
        ' one
        ' One

        ' Sort based on the lengths of the strings in the array:
        ' one
        ' One
        ' Four
        ' four
        ' First
        ' first 
        ' </Snippet140>
#End Region

#Region "OrderByDescending"
        ' <Snippet71>
        ' This class provides a custom implementation 
        ' of the IComparer.Compare() method.
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
            Dim query As IEnumerable(Of Decimal) =
            decimals.OrderByDescending(Function(num) num,
                                       New SpecialComparer())

            Dim output As New System.Text.StringBuilder
            For Each num As Decimal In query
                output.AppendLine(num)
            Next

            ' Display the output.
            MsgBox(output.ToString())
        End Sub

        ' This code produces the following output:
        '
        ' 9.7
        ' 0.5
        ' 8.3
        ' 6.3
        ' 1.3
        ' 6.2

        ' </Snippet71>
#End Region

#Region "Range"
        Sub RangeEx1()
            ' <Snippet72>
            ' Generate a sequence of integers from 1 to 10 
            ' and project their squares.
            Dim squares As IEnumerable(Of Integer) =
            Enumerable.Range(1, 10).Select(Function(x) x * x)

            Dim output As New System.Text.StringBuilder
            For Each num As Integer In squares
                output.AppendLine(num)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
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

            ' </Snippet72>
        End Sub
#End Region

#Region "Repeat"
        Sub RepeatEx1()
            ' <Snippet73>
            ' Repeat the same string to create a sequence.
            Dim sentences As IEnumerable(Of String) =
            Enumerable.Repeat("I like programming.", 15)

            Dim output As New System.Text.StringBuilder
            For Each sentence As String In sentences
                output.AppendLine(sentence)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.
            ' I like programming.

            ' </Snippet73>
        End Sub
#End Region

#Region "Reverse"
        Sub ReverseEx1()
            ' <Snippet74>
            ' Create a List of Char values.
            Dim appleLetters As New List(Of Char)(New Char() _
                                              {"a"c, "P"c, "P"c, "L"c, "E"c})

            ' Reverse the order of the elements in the list.
            ' (We have to call AsEnumerable() in order to
            ' use System.Linq.Enumerable's Reverse() method.
            Dim reversed() As Char =
            appleLetters.AsEnumerable().Reverse().ToArray()

            Dim output As New System.Text.StringBuilder
            For Each chr As Char In reversed
                output.Append(chr & " ")
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' E L P P a 

            ' </Snippet74>
        End Sub
#End Region

#Region "_Select"
        Sub SelectEx1()
            ' <Snippet75>
            ' Create a collection of sequential integers
            ' from 1 to 10 and project their squares.
            Dim squares As IEnumerable(Of Integer) =
            Enumerable.Range(1, 10).Select(Function(x) x * x)

            Dim output As New System.Text.StringBuilder
            For Each num As Integer In squares
                output.AppendLine(num)
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
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
            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Project each item in the array to an anonymous type
            ' that stores the item's index in the array and
            ' a substring of each item whose length is equal
            ' to the index position in the original array.
            Dim query =
            fruits.Select(Function(fruit, index) _
                              New With {index, .Str = fruit.Substring(0, index)})

            Dim output As New System.Text.StringBuilder
            For Each obj In query
                output.AppendLine(obj.ToString())
            Next

            ' Display the output.
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' { index = 0, Str =  }
            ' { index = 1, Str = b }
            ' { index = 2, Str = ma }
            ' { index = 3, Str = ora }
            ' { index = 4, Str = pass }
            ' { index = 5, Str = grape }

            ' </Snippet76>
        End Sub
#End Region

#Region "SelectMany"
        NotInheritable Class SelectMany1
            ' <Snippet77>
            Structure PetOwner
                Public Name As String
                Public Pets() As String
            End Structure

            Sub SelectManyEx1()
                ' Create an array of PetOwner objects.
                Dim petOwners() As PetOwner =
            {New PetOwner With
             {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}},
             New PetOwner With
             {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}},
             New PetOwner With
             {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}}}

                ' Call SelectMany() to gather all pets into a "flat" sequence.
                Dim query1 As IEnumerable(Of String) =
            petOwners.SelectMany(Function(petOwner) petOwner.Pets)

                Dim output As New System.Text.StringBuilder("Using SelectMany():" & vbCrLf)
                ' Only one foreach loop is required to iterate through 
                ' the results because it is a one-dimensional collection.
                For Each pet As String In query1
                    output.AppendLine(pet)
                Next

                ' This code demonstrates how to use Select() instead 
                ' of SelectMany() to get the same result.
                Dim query2 As IEnumerable(Of String()) =
            petOwners.Select(Function(petOwner) petOwner.Pets)
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
            '
            ' Using SelectMany():
            ' Scruffy
            ' Sam
            ' Walker
            ' Sugar
            ' Scratches
            ' Diesel
            '
            ' Using Select():
            ' Scruffy
            ' Sam
            ' Walker
            ' Sugar
            ' Scratches
            ' Diesel

            ' </Snippet77>
        End Class

        NotInheritable Class SelectMany2
            ' <Snippet78>
            Structure PetOwner
                Public Name As String
                Public Pets() As String
            End Structure

            Sub SelectManyEx2()
                ' Create an array of PetOwner objects.
                Dim petOwners() As PetOwner =
            {New PetOwner With
             {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}},
             New PetOwner With
             {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}},
             New PetOwner With
             {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}},
             New PetOwner With
             {.Name = "Hines, Patrick", .Pets = New String() {"Dusty"}}}

                ' Project the items in the array by appending the index 
                ' of each PetOwner to each pet's name in that petOwner's 
                ' array of pets.
                Dim query As IEnumerable(Of String) =
            petOwners.SelectMany(Function(petOwner, index) _
                                     petOwner.Pets.Select(Function(pet) _
                                                              index.ToString() + pet))

                Dim output As New System.Text.StringBuilder
                For Each pet As String In query
                    output.AppendLine(pet)
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub
            ' </Snippet78>
        End Class

        NotInheritable Class SelectMany3
            ' <Snippet124>
            Structure PetOwner
                Public Name As String
                Public Pets() As String
            End Structure

            Sub SelectManyEx3()
                ' Create an array of PetOwner objects.
                Dim petOwners() As PetOwner =
            {New PetOwner With
             {.Name = "Higa", .Pets = New String() {"Scruffy", "Sam"}},
             New PetOwner With
             {.Name = "Ashkenazi", .Pets = New String() {"Walker", "Sugar"}},
             New PetOwner With
             {.Name = "Price", .Pets = New String() {"Scratches", "Diesel"}},
             New PetOwner With
             {.Name = "Hines", .Pets = New String() {"Dusty"}}}

                ' Project an anonymous type that consists of
                ' the owner's name and the pet's name (string).
                Dim query =
            petOwners _
            .SelectMany(
                Function(petOwner) petOwner.Pets,
                Function(petOwner, petName) New With {petOwner, petName}) _
            .Where(Function(ownerAndPet) ownerAndPet.petName.StartsWith("S")) _
            .Select(Function(ownerAndPet) _
                   New With {.Owner = ownerAndPet.petOwner.Name,
                             .Pet = ownerAndPet.petName
                   })

                Dim output As New System.Text.StringBuilder
                For Each obj In query
                    output.AppendLine(String.Format("Owner={0}, Pet={1}", obj.Owner, obj.Pet))
                Next

                ' Display the output.
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Owner=Higa, Pet=Scruffy
            ' Owner=Higa, Pet=Sam
            ' Owner=Ashkenazi, Pet=Sugar
            ' Owner=Price, Pet=Scratches

            ' </Snippet124>
        End Class

#End Region

#Region "SequenceEqual"

        NotInheritable Class SequenceEqual1
            ' <Snippet32>
            Class Pet
                Public Name As String
                Public Age As Integer
            End Class

            Sub SequenceEqualEx1()
                ' Create two Pet objects.
                Dim pet1 As New Pet With {.Name = "Turbo", .Age = 2}
                Dim pet2 As New Pet With {.Name = "Peanut", .Age = 8}

                ' Create two lists of pets.
                Dim pets1 As New List(Of Pet)(New Pet() {pet1, pet2})
                Dim pets2 As New List(Of Pet)(New Pet() {pet1, pet2})

                'Determine if the two lists are equal.
                Dim equal As Boolean = pets1.SequenceEqual(pets2)

                ' Display the output.
                Dim text As String = IIf(equal, "are", "are not")
                MsgBox("The lists " & text & " equal.")

            End Sub

            ' This code produces the following output:
            '
            ' The lists are equal.

            ' </Snippet32>
        End Class

        NotInheritable Class SequenceEqual2
            Sub SequenceEqualEx2()
                ' <Snippet33>
                ' Create two Pet objects.
                Dim pet1 As New Pet With {.Name = "Turbo", .Age = 2}
                Dim pet2 As New Pet With {.Name = "Peanut", .Age = 8}

                ' Create two lists of pets.
                Dim pets1 As New List(Of Pet)()
                pets1.Add(pet1)
                pets1.Add(pet2)

                Dim pets2 As New List(Of Pet)()
                pets2.Add(New Pet With {.Name = "Turbo", .Age = 2})
                pets2.Add(New Pet With {.Name = "Peanut", .Age = 8})

                ' Determine if the two lists are equal.
                Dim equal As Boolean = pets1.SequenceEqual(pets2)

                ' Display the output.
                Dim text As String = IIf(equal, "are", "are not")
                MsgBox("The lists " & text & " equal.")

                ' This code produces the following output:
                '
                ' The lists are not equal.

                ' </Snippet33>
            End Sub
        End Class

#End Region

#Region "_Single"
        Sub SingleEx1()
            ' <Snippet79>
            ' Create an array that contains one item.
            Dim fruits1() As String = {"orange"}

            ' Get the single item in the array.
            Dim result As String = fruits1.Single()

            ' Display the result.
            MsgBox("First query: " & result)
            ' </Snippet79>

            ' <Snippet80>
            ' Create an array that contains two items.
            Dim fruits2() As String = {"orange", "apple"}

            result = String.Empty

            ' Try to get the 'single' item in the array.
            Try
                result = fruits2.Single()
            Catch ex As System.InvalidOperationException
                result = "The collection does not contain exactly one element."
            End Try

            ' Display the result.
            MsgBox("Second query: " & result)

            ' This code produces the following output:
            '
            ' First query: orange
            ' Second query: The collection does not contain exactly one element.

            ' </Snippet80>
        End Sub

        Sub SingleEx2()
            ' <Snippet81>
            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Get the single item in the array whose length is greater than 10.
            Dim result As String =
            fruits.Single(Function(fruit) fruit.Length > 10)

            ' Display the result.
            MsgBox("First query: " & result)
            ' </Snippet81>

            ' <Snippet82>
            result = String.Empty

            ' Try to get the single item in the array whose length is > 15.
            Try
                result = fruits.Single(Function(fruit) _
                                       fruit.Length > 15)
            Catch ex As System.InvalidOperationException
                result = "There is not EXACTLY ONE element whose length is > 15."
            End Try

            ' Display the result.
            MsgBox("Second query: " & result)

            ' This code produces the following output:
            '
            ' First query: passionfruit
            ' Second query: There is not EXACTLY ONE element whose length is > 15.

            ' </Snippet82>
        End Sub
#End Region

#Region "SingleOrDefault"
        Sub SingleOrDefaultEx1()
            ' <Snippet83>
            ' Create an array that contains one item.
            Dim fruits1() As String = {"orange"}

            ' Get the single item in the array or else a default value.
            Dim result As String = fruits1.SingleOrDefault()

            ' Display the result.
            MsgBox("First array: " & result)
            ' </Snippet83>

            ' <Snippet84>
            ' Create an empty array.
            Dim fruits2() As String = {}

            result = String.Empty

            ' Get the single item in the array or else a default value.
            result = fruits2.SingleOrDefault()

            ' Display the result.
            Dim output As String =
            IIf(String.IsNullOrEmpty(result), "No single item found", result)
            MsgBox("Second array: " & output)

            ' This code produces the following output:
            '
            ' First array: orange
            ' Second array: No single item found

            ' </Snippet84>
        End Sub

        Sub SingleOrDefaultEx2()
            ' <Snippet85>
            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Get the single item in the array whose length is > 10.
            Dim fruit1 As String =
            fruits.SingleOrDefault(Function(fruit) fruit.Length > 10)

            ' Display the result.
            MsgBox("First array: " & fruit1)
            ' </Snippet85>

            ' <Snippet86>
            ' Get the single item in the array whose length is > 15.
            Dim fruit2 As String =
            fruits.SingleOrDefault(Function(fruit) fruit.Length > 15)

            ' Display the result.
            Dim output As String =
            IIf(String.IsNullOrEmpty(fruit2), "No single item found", fruit2)
            MsgBox("Second array: " & output)

            ' This code produces the following output:
            '
            ' First array: passionfruit
            ' Second array: No single item found

            ' </Snippet86>
        End Sub

        Sub SingleOrDefaultEx3()
            ' <Snippet128>
            Dim pageNumbers() As Integer = {}

            ' Setting the default value to 1 after the query.
            Dim pageNumber1 As Integer = pageNumbers.SingleOrDefault()
            If pageNumber1 = 0 Then
                pageNumber1 = 1
            End If
            MsgBox(String.Format("The value of the pageNumber1 variable is {0}", pageNumber1))

            ' Setting the default value to 1 by using DefaultIfEmpty() in the query.
            Dim pageNumber2 As Integer = pageNumbers.DefaultIfEmpty(1).Single()
            MsgBox(String.Format("The value of the pageNumber2 variable is {0}", pageNumber2))

            ' This code produces the following output:

            ' The value of the pageNumber1 variable is 1
            ' The value of the pageNumber2 variable is 1

            ' </Snippet128>
        End Sub
#End Region

#Region "Skip"
        Sub SkipEx1()
            ' <Snippet87>
            ' Create an array of integers that represent grades.
            Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

            ' Sort the numbers in descending order and
            ' get all but the first (largest) three numbers.
            Dim lowerGrades As IEnumerable(Of Integer) =
            grades _
            .OrderByDescending(Function(g) g) _
            .Skip(3)

            ' Display the results.
            Dim output As New System.Text.StringBuilder("All grades except the top three are:" & vbCrLf)
            For Each grade As Integer In lowerGrades
                output.AppendLine(grade)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' All grades except the top three are:
            ' 82
            ' 70
            ' 59
            ' 56

            ' </Snippet87>
        End Sub
#End Region

#Region "SkipWhile"
        Sub SkipWhileEx1()
            ' <Snippet88>
            ' Create an array of integers that represent grades.
            Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

            ' Sort the grades in descending order and
            ' get all grades greater less than 80.
            Dim lowerGrades As IEnumerable(Of Integer) =
            grades _
            .OrderByDescending(Function(grade) grade) _
            .SkipWhile(Function(grade) grade >= 80)

            ' Display the results.
            Dim output As New System.Text.StringBuilder("All grades below 80:" & vbCrLf)
            For Each grade As Integer In lowerGrades
                output.AppendLine(grade)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' All grades below 80:
            ' 70
            ' 59
            ' 56

            ' </Snippet88>
        End Sub

        Sub SkipWhileEx2()
            ' <Snippet89>
            ' Create an array of integers.
            Dim amounts() As Integer =
            {5000, 2500, 9000, 8000, 6500, 4000, 1500, 5500}

            ' Skip items in the array whose value is greater than
            ' the item's index times 1000; get the remaining items.
            Dim query As IEnumerable(Of Integer) =
            amounts.SkipWhile(Function(amount, index) _
                                  amount > index * 1000)

            ' Output the results.
            Dim output As New System.Text.StringBuilder
            For Each amount As Integer In query
                output.AppendLine(amount)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 4000
            ' 1500
            ' 5500

            ' </Snippet89>
        End Sub
#End Region

#Region "Sum"

        NotInheritable Class Sum9
            ' <Snippet98>
            Structure Package
                Public Company As String
                Public Weight As Double
            End Structure

            Sub SumEx1()
                ' Create a list of Package values.
                Dim packages As New List(Of Package)(New Package() _
                 {New Package With {.Company = "Coho Vineyard", .Weight = 25.2},
                  New Package With {.Company = "Lucerne Publishing", .Weight = 18.7},
                  New Package With {.Company = "Wingtip Toys", .Weight = 6.0},
                  New Package With {.Company = "Adventure Works", .Weight = 33.8}})

                ' Sum the values from each item's Weight property.
                Dim totalWeight As Double = packages.Sum(Function(pkg) _
                                                         pkg.Weight)

                ' Display the result.
                MsgBox("The total weight of the packages is: " & totalWeight)
            End Sub

            ' This code produces the following output:
            '
            ' The total weight of the packages is: 83.7

            ' </Snippet98>
        End Class

        Sub SumEx2()
            ' <Snippet120>
            ' Create a list of Single values.
            Dim numbers As New List(Of Single)(New Single() _
                                           {43.68F, 1.25F, 583.7F, 6.5F})

            ' Get the sum of values in the list.
            Dim sum As Single = numbers.Sum()

            ' Display the output.
            MsgBox("The sum of the numbers is " & sum)

            ' This code produces the following output:
            '
            ' The sum of the numbers is 635.13

            ' </Snippet120>
        End Sub

        Sub SumEx3()
            ' <Snippet121>
            ' Create an array of Nullable Single values.
            Dim points() As Nullable(Of Single) =
            {Nothing, 0, 92.83F, Nothing, 100.0F, 37.46F, 81.1F}

            ' Get the sum of values in the list.
            Dim sum As Nullable(Of Single) = points.Sum()

            ' Display the output.
            MsgBox("Total points earned: " & sum)

            ' This code produces the following output:
            '
            ' Total points earned: 311.39

            ' </Snippet121>
        End Sub
#End Region

#Region "Take"
        Sub TakeEx1()
            ' <Snippet99>
            ' Create an array of Integer values that represent grades.
            Dim grades() As Integer = {59, 82, 70, 56, 92, 98, 85}

            ' Get the highest three grades by first sorting
            ' them in descending order and then taking the
            ' first three values.
            Dim topThreeGrades As IEnumerable(Of Integer) =
            grades _
            .OrderByDescending(Function(grade) grade) _
            .Take(3)

            ' Display the results.
            Dim output As New System.Text.StringBuilder("The top three grades are:" & vbCrLf)
            For Each grade As Integer In topThreeGrades
                output.AppendLine(grade)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' The top three grades are:
            ' 98
            ' 92
            ' 85

            ' </Snippet99>
        End Sub
#End Region

#Region "TakeWhile"
        Sub TakeWhileEx1()
            ' <Snippet100>
            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "banana", "mango", "orange", "passionfruit", "grape"}

            ' Take strings from the array until one of
            ' the strings matches "orange".
            Dim query As IEnumerable(Of String) =
            fruits.TakeWhile(Function(fruit) _
                                 String.Compare("orange", fruit, True) <> 0)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' banana
            ' mango

            ' </Snippet100>
        End Sub

        Sub TakeWhileEx2()
            ' <Snippet101>
            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "passionfruit", "banana", "mango",
             "orange", "blueberry", "grape", "strawberry"}

            ' Take strings from the array until one
            ' of the string's lengths is greater than or
            ' equal to the string item's index in the array.
            Dim query As IEnumerable(Of String) =
            fruits.TakeWhile(Function(fruit, index) _
                                 fruit.Length >= index)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' passionfruit
            ' banana
            ' mango
            ' orange
            ' blueberry

            ' </Snippet101>
        End Sub
#End Region

#Region "ThenBy"
        Sub ThenByEx1()
            ' <Snippet102>
            ' Create an array of strings.
            Dim fruits() As String =
            {"grape", "passionfruit", "banana", "mango",
             "orange", "raspberry", "apple", "blueberry"}

            ' Sort the strings first by their length and then 
            ' alphabetically by passing the identity function.
            Dim query As IEnumerable(Of String) =
            fruits _
            .OrderBy(Function(fruit) fruit.Length) _
            .ThenBy(Function(fruit) fruit)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' grape
            ' mango
            ' banana
            ' orange
            ' blueberry
            ' raspberry
            ' passionfruit

            ' </Snippet102>
        End Sub
#End Region

#Region "ThenByDescending"
        ' <Snippet103>
        ' This class provides a custom implementation of the Compare() method.
        Class CaseInsensitiveComparer
            Implements IComparer(Of String)

            Function Compare(ByVal x As String, ByVal y As String) As Integer _
            Implements IComparer(Of String).Compare

                ' Compare values and ignore case.
                Return String.Compare(x, y, True)
            End Function
        End Class

        Sub ThenByDescendingEx1()
            Dim fruits() As String =
            {"apPLe", "baNanA", "apple", "APple", "orange", "BAnana", "ORANGE", "apPLE"}

            ' Sort the strings first by their length and then 
            ' by using a custom "case insensitive" comparer.
            Dim query As IEnumerable(Of String) =
            fruits _
            .OrderBy(Function(fruit) fruit.Length) _
            .ThenByDescending(Function(fruit) fruit, New CaseInsensitiveComparer())

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
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
#End Region

#Region "ToArray"
        NotInheritable Class ToArray
            ' <Snippet104>
            Structure Package
                Public Company As String
                Public Weight As Double
            End Structure

            Sub ToArrayEx1()
                ' Create a list of Package values.
                Dim packages As New List(Of Package)(New Package() _
                 {New Package With {.Company = "Coho Vineyard", .Weight = 25.2},
                  New Package With {.Company = "Lucerne Publishing", .Weight = 18.7},
                  New Package With {.Company = "Wingtip Toys", .Weight = 6.0},
                  New Package With {.Company = "Adventure Works", .Weight = 33.8}})

                ' Project the Company values from each item in the list
                ' and put them into an array.
                Dim companies() As String =
                packages _
                .Select(Function(pkg) pkg.Company) _
                .ToArray()

                ' Display the results.
                Dim output As New System.Text.StringBuilder
                For Each company As String In companies
                    output.AppendLine(company)
                Next
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Coho Vineyard
            ' Lucerne Publishing
            ' Wingtip Toys
            ' Adventure Works

            ' </Snippet104>
        End Class

#End Region

#Region "ToDictionary"

        NotInheritable Class ToDictionary

            ' <Snippet105>
            Structure Package
                Public Company As String
                Public Weight As Double
                Public TrackingNumber As Long
            End Structure

            Sub ToDictionaryEx1()
                ' Create a list of Package values.
                Dim packages As New List(Of Package)(New Package() _
                 {New Package With
                  {.Company = "Coho Vineyard", .Weight = 25.2, .TrackingNumber = 89453312L},
                  New Package With
                  {.Company = "Lucerne Publishing", .Weight = 18.7, .TrackingNumber = 89112755L},
                  New Package With
                  {.Company = "Wingtip Toys", .Weight = 6.0, .TrackingNumber = 299456122L},
                  New Package With
                  {.Company = "Adventure Works", .Weight = 33.8, .TrackingNumber = 4665518773L}})

                ' Create a Dictionary that contains Package values, 
                ' using TrackingNumber as the key.
                Dim dict As Dictionary(Of Long, Package) =
                packages.ToDictionary(Function(p) p.TrackingNumber)

                ' Display the results.
                Dim output As New System.Text.StringBuilder
                For Each kvp As KeyValuePair(Of Long, Package) In dict
                    output.AppendLine("Key " & kvp.Key & ": " &
                                  kvp.Value.Company & ", " &
                                  kvp.Value.Weight & " pounds")
                Next
                MsgBox(output.ToString())
            End Sub

            ' This code produces the following output:
            '
            ' Key 89453312: Coho Vineyard, 25.2 pounds
            ' Key 89112755: Lucerne Publishing, 18.7 pounds
            ' Key 299456122: Wingtip Toys, 6 pounds
            ' Key 4665518773: Adventure Works, 33.8 pounds

            ' </Snippet105>
        End Class

#End Region

#Region "ToList"
        Sub ToListEx1()
            ' <Snippet106>
            ' Create an array of strings.
            Dim fruits() As String =
            {"apple", "passionfruit", "banana", "mango",
             "orange", "blueberry", "grape", "strawberry"}

            ' Project the length of each string and 
            ' put the length values into a List object.
            Dim lengths As List(Of Integer) =
            fruits _
            .Select(Function(fruit) fruit.Length) _
            .ToList()

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each length As Integer In lengths
                output.AppendLine(length)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 5
            ' 12
            ' 6
            ' 5
            ' 6
            ' 9
            ' 5
            ' 10

            ' </Snippet106>
        End Sub
#End Region

#Region "ToLookup"
        ' <Snippet107>
        Structure Package
            Public Company As String
            Public Weight As Double
            Public TrackingNumber As Long
        End Structure

        Sub ToLookupEx1()
            ' Create a list of Packages.
            Dim packages As New List(Of Package)(New Package() _
             {New Package With
              {.Company = "Coho Vineyard", .Weight = 25.2, .TrackingNumber = 89453312L},
              New Package With
              {.Company = "Lucerne Publishing", .Weight = 18.7, .TrackingNumber = 89112755L},
              New Package With
              {.Company = "Wingtip Toys", .Weight = 6.0, .TrackingNumber = 299456122L},
              New Package With
              {.Company = "Contoso Pharmaceuticals", .Weight = 9.3, .TrackingNumber = 670053128L},
              New Package With
              {.Company = "Wide World Importers", .Weight = 33.8, .TrackingNumber = 4665518773L}})

            ' Create a Lookup to organize the packages. 
            ' Use the first character of Company as the key value.
            ' Select Company appended to TrackingNumber 
            ' as the element values of the Lookup.
            Dim lookup As ILookup(Of Char, String) =
            packages.ToLookup(Function(p) _
                                  Convert.ToChar(p.Company.Substring(0, 1)),
                              Function(p) _
                                  p.Company & " " & p.TrackingNumber)

            Dim output As New System.Text.StringBuilder

            ' Iterate through each IGrouping in the Lookup.
            For Each packageGroup As IGrouping(Of Char, String) In lookup
                ' Print the key value of the IGrouping.
                output.AppendLine(packageGroup.Key)
                ' Iterate through each value in the IGrouping and print its value.
                For Each str As String In packageGroup
                    output.AppendLine("   " & str)
                Next
            Next

            ' Select a group of packages by indexing directly into the Lookup.
            Dim cgroup As IEnumerable(Of String) = lookup("C"c)

            output.AppendLine(vbCrLf & "Packages from Company names that start with 'C':")
            For Each str As String In cgroup
                output.AppendLine(str)
            Next

            ' Display the output.
            MsgBox(output.ToString())
        End Sub

        ' This code produces the following output:
        '
        ' C
        '    Coho Vineyard 89453312
        '    Contoso Pharmaceuticals 670053128
        ' L
        '    Lucerne Publishing 89112755
        ' W
        '    Wingtip Toys 299456122
        '    Wide World Importers 4665518773
        '
        ' Packages from Company names that start with 'C':
        ' Coho Vineyard 89453312
        ' Contoso Pharmaceuticals 670053128

        ' </Snippet107>
#End Region

#Region "Union"
        Sub UnionEx1()
            ' <Snippet109>
            ' Create two arrays of integer values.
            Dim ints1() As Integer = {5, 3, 9, 7, 5, 9, 3, 7}
            Dim ints2() As Integer = {8, 3, 6, 4, 4, 9, 1, 0}

            ' Get the set union of the two arrays.
            Dim union As IEnumerable(Of Integer) = ints1.Union(ints2)

            ' Display the resulting set's values.
            Dim output As New System.Text.StringBuilder
            For Each num As Integer In union
                output.AppendLine(num & " ")
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 5 
            ' 3 
            ' 9 
            ' 7 
            ' 8 
            ' 6 
            ' 4 
            ' 1 
            ' 0 

            ' </Snippet109>
        End Sub
#End Region

#Region "_Where"
        Sub WhereEx1()
            ' <Snippet110>
            ' Create a list of strings.
            Dim fruits As New List(Of String)(New String() _
                                {"apple", "passionfruit", "banana", "mango",
                                 "orange", "blueberry", "grape", "strawberry"})

            ' Restrict the results to those strings whose 
            ' length is less than six.
            Dim query As IEnumerable(Of String) =
            fruits.Where(Function(fruit) fruit.Length < 6)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each fruit As String In query
                output.AppendLine(fruit)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' apple
            ' mango
            ' grape

            ' </Snippet110>
        End Sub

        Sub WhereEx2()
            ' <Snippet111>
            ' Create an array of integers.
            Dim numbers() As Integer = {0, 30, 20, 15, 90, 85, 40, 75}

            ' Restrict the results to those numbers whose
            ' values are less than or equal to their index times 10.
            Dim query As IEnumerable(Of Integer) =
            numbers.Where(Function(number, index) number <= index * 10)

            ' Display the results.
            Dim output As New System.Text.StringBuilder
            For Each number As Integer In query
                output.AppendLine(number)
            Next
            MsgBox(output.ToString())

            ' This code produces the following output:
            '
            ' 0
            ' 20
            ' 15
            ' 40

            ' </Snippet111>
        End Sub
#End Region

#Region "Zip"
        Sub ZipEx()
            ' <Snippet200>
            Dim numbers() As Integer = {1, 2, 3, 4}
            Dim words() As String = {"one", "two", "three"}
            Dim numbersAndWords = numbers.Zip(words, Function(first, second) first & " " & second)

            For Each item In numbersAndWords
                Console.WriteLine(item)
            Next

            ' This code produces the following output:

            ' 1 one
            ' 2 two
            ' 3 three
            ' </Snippet200>
        End Sub
#End Region

    End Module

End Namespace
