' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Console.Write("Enter your first name: ")
      Dim firstName As String = Console.ReadLine()
      
      Console.Write("Enter your middle name or initial: ")
      Dim middleName As String = Console.ReadLine()
      
      Console.Write("Enter your last name: ")
      Dim lastName As String = Console.ReadLine
      
      Console.WriteLine()
      Console.WriteLine("You entered '{0}', '{1}', and '{2}'.", _
                        firstName, middleName, lastName)
                        
      Dim name As String = ((firstName.Trim() + " " + middleName.Trim()).Trim() _
                           + " " + lastName.Trim()).Trim()                        
      Console.WriteLine("The result is " + name + ".")
   End Sub
End Module
' The following is possible output from this example:
'       Enter your first name:    John
'       Enter your middle name or initial:
'       Enter your last name:    Doe
'       
'       You entered '   John  ', '', and '   Doe'.
'       The result is John Doe.
' </Snippet2>
