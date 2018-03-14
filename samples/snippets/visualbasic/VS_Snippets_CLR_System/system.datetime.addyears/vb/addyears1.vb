' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim baseDate As Date = #2/29/2000#
      Console.WriteLine("    Base Date:        {0:d}", baseDate)
      Console.WriteLine()
      
      ' Show dates of previous fifteen years.
      For ctr As Integer = -1 To -15 Step -1
         Console.WriteLine("{0,3} years ago:        {1:d}", 
                           ctr, baseDate.AddYears(ctr))
      Next
      Console.WriteLine()
      ' Show dates of next fifteen years.
      For ctr As Integer = 1 To 15
         Console.WriteLine("{0,3} years from now:   {1:d}", 
                           ctr, baseDate.AddYears(ctr))
      Next      
   End Sub
End Module
' The example displays the following output:
'           Base Date:        2/29/2000
'       
'        1 year(s) ago:        2/28/1999
'        2 year(s) ago:        2/28/1998
'        3 year(s) ago:        2/28/1997
'        4 year(s) ago:        2/29/1996
'        5 year(s) ago:        2/28/1995
'        6 year(s) ago:        2/28/1994
'        7 year(s) ago:        2/28/1993
'        8 year(s) ago:        2/29/1992
'        9 year(s) ago:        2/28/1991
'       10 year(s) ago:        2/28/1990
'       11 year(s) ago:        2/28/1989
'       12 year(s) ago:        2/29/1988
'       13 year(s) ago:        2/28/1987
'       14 year(s) ago:        2/28/1986
'       15 year(s) ago:        2/28/1985
'       
'        1 year(s) from now:   2/28/2001
'        2 year(s) from now:   2/28/2002
'        3 year(s) from now:   2/28/2003
'        4 year(s) from now:   2/29/2004
'        5 year(s) from now:   2/28/2005
'        6 year(s) from now:   2/28/2006
'        7 year(s) from now:   2/28/2007
'        8 year(s) from now:   2/29/2008
'        9 year(s) from now:   2/28/2009
'       10 year(s) from now:   2/28/2010
'       11 year(s) from now:   2/28/2011
'       12 year(s) from now:   2/29/2012
'       13 year(s) from now:   2/28/2013
'       14 year(s) from now:   2/28/2014
'       15 year(s) from now:   2/28/2015
' </Snippet1>
