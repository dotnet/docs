'<snippet1>
Public Class CompareToTest
    Enum VehicleDoors
        Motorbike = 0
        Sportscar = 2
        Sedan = 4
        Hatchback = 5
    End Enum
    
    Public Shared Sub Main()
        Dim myVeh As VehicleDoors = VehicleDoors.Sportscar
        Dim yourVeh As VehicleDoors = VehicleDoors.Motorbike
        Dim otherVeh As VehicleDoors = VehicleDoors.Sedan
        
        Dim output as String

        If myVeh.CompareTo(yourVeh) > 0 Then output = "Yes" Else output = "No"
        Console.WriteLine("Does a {0} have more doors than a {1}?", myVeh, yourVeh)
        Console.WriteLine("{0}{1}", output, Environment.NewLine)
        
        Console.WriteLine("Does a {0} have more doors than a {1}?", myVeh, otherVeh)
        If myVeh.CompareTo(otherVeh) > 0 Then output = "Yes" Else output = "No"
        Console.WriteLine("{0}", output)
    End Sub
End Class
' The example displays the following output:
'       Does a Sportscar have more doors than a Motorbike?
'       Yes
'       
'       Does a Sportscar have more doors than a Sedan?
'       No
' </snippet1>