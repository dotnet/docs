'<snippet1>
Public Class EnumTest
    Enum Days
        Saturday
        Sunday
        Monday
        Tuesday
        Wednesday
        Thursday
        Friday
    End Enum 
    
    Enum BoilingPoints
        Celsius = 100
        Fahrenheit = 212
    End Enum 
    
    <Flags()> _
    Enum Colors
        Red = 1
        Green = 2
        Blue = 4
        Yellow = 8
    End Enum 

    Public Shared Sub Main()
        Dim weekdays As Type = GetType(Days)
        Dim boiling As Type = GetType(BoilingPoints)

        Console.WriteLine("The days of the week, and their corresponding values in the Days Enum are:")

        Dim s As String
        For Each s In  [Enum].GetNames(weekdays)
            Console.WriteLine("{0,-11} = {1}", s, [Enum].Format(weekdays, [Enum].Parse(weekdays, s), "d"))
        
        Next s
        Console.WriteLine()
        Console.WriteLine("Enums can also be created which have values that represent some meaningful amount.")
        Console.WriteLine("The BoilingPoints Enum defines the following items, and corresponding values:")

        For Each s In  [Enum].GetNames(boiling)
            Console.WriteLine("{0,-11} = {1}", s, [Enum].Format(boiling, [Enum].Parse(boiling, s), "d"))
        Next s

        Dim myColors As Colors = Colors.Red Or Colors.Blue Or Colors.Yellow
        Console.WriteLine()
        Console.WriteLine("myColors holds a combination of colors. Namely: {0}", myColors)
    End Sub 
End Class 
'</snippet1>
