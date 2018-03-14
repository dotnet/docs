' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Public Enum TimeComparison As Integer
   EarlierThan = -1
   TheSameAs = 0
   LaterThan = 1
End Enum

Module DateManipulation
   Public Sub Main()
      Dim localTime As Date = Date.Now
      Dim utcTime As Date = Date.UtcNow
      
      Console.WriteLine("Difference between {0} and {1} time: {2}:{3} hours", _
                        localTime.Kind.ToString(), _
                        utcTime.Kind.ToString(), _
                        (localTime - utcTime).Hours, _
                        (localTime - utcTime).Minutes)
      Console.WriteLine("The {0} time is {1} the {2} time.", _
                        localTime.Kind.ToString(), _ 
                        [Enum].GetName(GetType(TimeComparison), localTime.CompareTo(utcTime)), _
                        utcTime.Kind.ToString())  
      ' If run in the U.S. Pacific Standard Time zone, the example displays 
      ' the following output to the console:
      '    Difference between Local and Utc time: -7:0 hours
      '    The Local time is EarlierThan the Utc time.                                                    
   End Sub
End Module
' </Snippet2>

