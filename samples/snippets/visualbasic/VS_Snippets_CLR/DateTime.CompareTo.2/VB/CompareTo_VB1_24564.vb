' Visual Basic .NET Document
' <Snippet1>
Option Strict On

Module DateTimeComparison
   Private Enum DateComparisonResult
      Earlier = -1
      Later = 1
      TheSame = 0
   End Enum
   
   Public Sub Main()

      Dim thisDate As Date = Date.Today

      ' Define two DateTime objects for today's date 
      ' next year and last year		
      Dim thisDateNextYear, thisDateLastYear As Date

      ' Call AddYears instance method to add/substract 1 year
      thisDateNextYear = thisDate.AddYears(1)
      thisDateLastYear = thisDate.AddYears(-1)   

       
      ' Compare dates
      '
      Dim comparison As DateComparisonResult
      ' Compare today to last year
      comparison = CType(thisDate.CompareTo(thisDateLastYear), DateComparisonResult)
      Console.WriteLine("CompareTo method returns {0}: {1:d} is {2} than {3:d}", _ 
                        CInt(comparison), thisDate, comparison.ToString().ToLower(), _ 
                        thisDateLastYear)
      
      ' Compare today to next year
      comparison = CType(thisDate.CompareTo(thisDateNextYear), DateComparisonResult)
      Console.WriteLine("CompareTo method returns {0}: {1:d} is {2} than {3:d}", _
                        CInt(comparison), thisDate, comparison.ToString().ToLower(), _
                        thisDateNextYear)
   End Sub
End Module
'
' If run on October 20, 2006, the example produces the following output:
'    CompareTo method returns 1: 10/20/2006 is later than 10/20/2005
'    CompareTo method returns -1: 10/20/2006 is earlier than 10/20/2007
' </Snippet1>
