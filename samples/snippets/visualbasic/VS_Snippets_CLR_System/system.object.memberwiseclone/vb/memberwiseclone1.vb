' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class IdInfo
    Public IdNumber As Integer
    
    Public Sub New(IdNumber As Integer)
        Me.IdNumber = IdNumber
    End Sub
End Class

Public Class Person 
    Public Age As Integer
    Public Name As String
    Public IdInfo As IdInfo

    Public Function ShallowCopy() As Person
       Return DirectCast(Me.MemberwiseClone(), Person)
    End Function

    Public Function DeepCopy() As Person
       Dim other As Person = DirectCast(Me.MemberwiseClone(), Person) 
       other.IdInfo = New IdInfo(IdInfo.IdNumber)
       other.Name = String.Copy(Name)
       Return other
    End Function
End Class

Module Example
   Public Sub Main()
        ' Create an instance of Person and assign values to its fields.
        Dim p1 As New Person()
        p1.Age = 42
        p1.Name = "Sam"
        p1.IdInfo = New IdInfo(6565)

        ' Perform a shallow copy of p1 and assign it to p2.
        Dim p2 As Person = p1.ShallowCopy()

        ' Display values of p1, p2
        Console.WriteLine("Original values of p1 and p2:")
        Console.WriteLine("   p1 instance values: ")
        DisplayValues(p1)
        Console.WriteLine("   p2 instance values:")
        DisplayValues(p2)
        Console.WriteLine()
                
        ' Change the value of p1 properties and display the values of p1 and p2.
        p1.Age = 32
        p1.Name = "Frank"
        p1.IdInfo.IdNumber = 7878
        Console.WriteLine("Values of p1 and p2 after changes to p1:")
        Console.WriteLine("   p1 instance values: ")
        DisplayValues(p1)
        Console.WriteLine("   p2 instance values:")
        DisplayValues(p2)
        Console.WriteLine()
        
        ' Make a deep copy of p1 and assign it to p3.
        Dim p3 As Person = p1.DeepCopy()
        ' Change the members of the p1 class to new values to show the deep copy.
        p1.Name = "George"
        p1.Age = 39
        p1.IdInfo.IdNumber = 8641
        Console.WriteLine("Values of p1 and p3 after changes to p1:")
        Console.WriteLine("   p1 instance values: ")
        DisplayValues(p1)
        Console.WriteLine("   p3 instance values:")
        DisplayValues(p3)
   End Sub
   
    Public Sub DisplayValues(p As Person)
        Console.WriteLine("      Name: {0:s}, Age: {1:d}", p.Name, p.Age)
        Console.WriteLine("      Value: {0:d}", p.IdInfo.IdNumber)
    End Sub
End Module
' The example displays the following output:
'       Original values of m1 and m2:
'          m1 instance values:
'             Name: Sam, Age: 42
'             Value: 6565
'          m2 instance values:
'             Name: Sam, Age: 42
'             Value: 6565
'       
'       Values of m1 and m2 after changes to m1:
'          m1 instance values:
'             Name: Frank, Age: 32
'             Value: 7878
'          m2 instance values:
'             Name: Sam, Age: 42
'             Value: 7878
'       
'       Values of m1 and m3 after changes to m1:
'          m1 instance values:
'             Name: George, Age: 39
'             Value: 8641
'          m3 instance values:
'             Name: Frank, Age: 32
'             Value: 7878
' </Snippet1>

