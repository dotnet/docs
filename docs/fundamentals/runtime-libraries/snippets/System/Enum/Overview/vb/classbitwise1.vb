' Visual Basic .NET Document
'Option Strict On

' <Snippet13>
<Flags> Public Enum Pets As Integer
   None = 0
   Dog = 1
   Cat = 2
   Bird = 4
   Rodent = 8
   Reptile = 16
   Other = 32
End Enum
' </Snippet13>

Module Example3
    Public Sub Main()
        ' <Snippet14>
        Dim familyPets As Pets = Pets.Dog Or Pets.Cat
        Console.WriteLine("Pets: {0:G} ({0:D})", familyPets)
        ' The example displays the following output:
        '       Pets: Dog, Cat (3)      
        ' </Snippet14>

        ShowHasFlag()
        ShowIfSet()
        TestForNone()
    End Sub

    Private Sub ShowHasFlag()
        ' <Snippet15>
        Dim familyPets As Pets = Pets.Dog Or Pets.Cat
        If familyPets.HasFlag(Pets.Dog) Then
            Console.WriteLine("The family has a dog.")
        End If
        ' The example displays the following output:
        '       The family has a dog.      
        ' </Snippet15>
    End Sub

    Private Sub ShowIfSet()
        ' <Snippet16>
        Dim familyPets As Pets = Pets.Dog Or Pets.Cat
        If familyPets And Pets.Dog = Pets.Dog Then
            Console.WriteLine("The family has a dog.")
        End If
        ' The example displays the following output:
        '       The family has a dog.      
        ' </Snippet16>
    End Sub

    Private Sub TestForNone()
        ' <Snippet17>
        Dim familyPets As Pets = Pets.Dog Or Pets.Cat
        If familyPets = Pets.None Then
            Console.WriteLine("The family has no pets.")
        Else
            Console.WriteLine("The family has pets.")
        End If
        ' The example displays the following output:
        '       The family has pets.      
        ' </Snippet17>
    End Sub
End Module

