'<snippet1>
Public Class EqualsTest
    Enum Colors
        Red
        Green
        Blue
        Yellow
    End Enum 
    
    Enum Mammals
        Cat
        Dog
        Horse
        Dolphin
    End Enum 
    
    Public Shared Sub Main()
        Dim myPet As Mammals = Mammals.Cat
        Dim myColor As Colors = Colors.Red
        Dim yourPet As Mammals = Mammals.Dog
        Dim yourColor As Colors = Colors.Red
        Dim output as string
        
        Console.WriteLine("My favorite animal is a {0}", myPet)
        Console.WriteLine("Your favorite animal is a {0}", yourPet)
        If myPet.Equals(yourPet) Then output = "Yes" Else output = "No"
        Console.WriteLine("Do we like the same animal? {0}", output)
        
        Console.WriteLine()
        Console.WriteLine("My favorite color is {0}", myColor)
        Console.WriteLine("Your favorite color is {0}", yourColor)
        If myColor.Equals(yourColor) Then output = "Yes" Else output = "No"
        Console.WriteLine("Do we like the same color? {0}", output)
        
        Console.WriteLine()
        Console.WriteLine("The value of my color ({0}) is {1}", myColor, [Enum].Format(GetType(Colors), myColor, "d"))
        Console.WriteLine("The value of my pet (a {0}) is {1}", myPet, [Enum].Format(GetType(Mammals), myPet, "d"))
        Console.WriteLine("Even though they have the same value, are they equal? {0}", 
                          If(myColor.Equals(myPet), "Yes", "No"))
    End Sub 
End Class 
' The example displays the following output:
'    My favorite animal is a Cat
'    Your favorite animal is a Dog
'    Do we like the same animal? No
'    
'    My favorite color is Red
'    Your favorite color is Red
'    Do we like the same color? Yes
'    
'    The value of my color (Red) is 0
'    The value of my pet (a Cat) is 0
'    Even though they have the same value, are they equal? No
'</snippet1>