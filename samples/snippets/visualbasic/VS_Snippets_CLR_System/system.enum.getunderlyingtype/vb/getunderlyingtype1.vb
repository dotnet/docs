' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim enumValues() As [Enum] = { ConsoleColor.Red, DayOfWeek.Monday, 
                                     MidpointRounding.ToEven, PlatformID.Win32NT, 
                                     DateTimeKind.Utc, StringComparison.Ordinal }
      Console.WriteLine("{0,-10} {1, 18}   {2,15}", 
                        "Member", "Enumeration", "Underlying Type")
      Console.WriteLine()
      For Each enumValue In enumValues
         DisplayEnumInfo(enumValue)
      Next
   End Sub

   Sub DisplayEnumInfo(enumValue As [Enum])
      Dim enumType As Type = enumValue.GetType()
      Dim underlyingType As Type = [Enum].GetUnderlyingType(enumType)
      Console.WriteLine("{0,-10} {1, 18}   {2,15}",
                        enumValue, enumType.Name, underlyingType.Name)   
   End Sub
End Module
' The example displays the following output:
'       Member            Enumeration   Underlying Type
'       
'       Red              ConsoleColor             Int32
'       Monday              DayOfWeek             Int32
'       ToEven       MidpointRounding             Int32
'       Win32NT            PlatformID             Int32
'       Utc              DateTimeKind             Int32
'       Ordinal      StringComparison             Int32
' </Snippet1>
