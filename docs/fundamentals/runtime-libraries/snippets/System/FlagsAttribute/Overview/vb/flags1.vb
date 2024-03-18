' Visual Basic .NET Document
Option Strict On

' <Snippet2>
<Flags()>
Public Enum PhoneService As Integer
   None = 0
   LandLine = 1
   Cell = 2
   Fax = 4
   Internet = 8
   Other = 16
End Enum

Module Example1
   Public Sub Main()
      ' Define three variables representing the types of phone service
      ' in three households.
      Dim household1 As PhoneService = PhoneService.LandLine Or
                                       PhoneService.Cell Or
                                       PhoneService.Internet
      Dim household2 As PhoneService = PhoneService.None
      Dim household3 As PhoneService = PhoneService.Cell Or
                                       PhoneService.Internet

      ' Store the variables in an array for ease of access.
      Dim households() As PhoneService = { household1, household2,
                                           household3 }

      ' Which households have no service?
      For ctr As Integer = 0 To households.Length - 1
         Console.WriteLine("Household {0} has phone service: {1}",
                           ctr + 1,
                           If(households(ctr) = PhoneService.None,
                              "No", "Yes"))
      Next
      Console.WriteLine()
      
      ' Which households have cell phone service?
      For ctr As Integer = 0 To households.Length - 1
         Console.WriteLine("Household {0} has cell phone service: {1}",
                           ctr + 1,
                           If((households(ctr) And PhoneService.Cell) = PhoneService.Cell,
                              "Yes", "No"))
      Next
      Console.WriteLine()
      
      ' Which households have cell phones and land lines?
      Dim cellAndLand As PhoneService = PhoneService.Cell Or PhoneService.LandLine
      For ctr As Integer = 0 To households.Length - 1
         Console.WriteLine("Household {0} has cell and land line service: {1}",
                           ctr + 1,
                           If((households(ctr) And cellAndLand) = cellAndLand,
                              "Yes", "No"))
      Next
      Console.WriteLine()
      
      ' List all types of service of each household?'
      For ctr As Integer = 0 To households.Length - 1
         Console.WriteLine("Household {0} has: {1:G}",
                           ctr + 1, households(ctr))
      Next
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'    Household 1 has phone service: Yes
'    Household 2 has phone service: No
'    Household 3 has phone service: Yes
'
'    Household 1 has cell phone service: Yes
'    Household 2 has cell phone service: No
'    Household 3 has cell phone service: Yes
'
'    Household 1 has cell and land line service: Yes
'    Household 2 has cell and land line service: No
'    Household 3 has cell and land line service: No
'
'    Household 1 has: LandLine, Cell, Internet
'    Household 2 has: None
'    Household 3 has: Cell, Internet
' </Snippet2>
