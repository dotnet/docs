' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      ShowAddition()
      ShowEquality()
      ShowGreaterThan()
      ShowGreaterThanDirect()
      ShowGreaterThanOrEqualTo()
      ShowGreaterThanOrEqualToDirect()
      ShowImplicitConversions()
      ShowInequality()
      ShowInequalityDirect()
      ShowLessThan()
      ShowLessThanDirect()
      ShowLessThanOrEqualTo()
      ShowLessThanOrEqualToDirect()
      ShowSubtraction1()
      ShowSubtraction2()
   End Sub
   
   Private Sub ShowAddition()
      ' <Snippet1>
      Dim date1 As New DateTimeOffset(#1/1/2008 1:32:45PM#, _
                   New TimeSpan(-5, 0, 0)) 
      Dim interval1 As New TimeSpan(202, 3, 30, 0)
      Dim interval2 As New TimeSpan(5, 0, 0, 0)      
      Dim date2 As DateTimeOffset 
      
      Console.WriteLine(date1)         ' Displays 1/1/2008 1:32:45 PM -05:00
      date2 = date1 + interval1
      Console.WriteLine(date2)         ' Displays 7/21/2008 5:02:45 PM -05:00
      date2 += interval2
      Console.WriteLine(date2)         ' Displays 7/26/2008 5:02:45 PM -05:00     
      ' </Snippet1>
   End Sub

   Private Sub ShowEquality()
      ' <Snippet2>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-6, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Console.WriteLine(date1 = date2)        ' Displays True
      Console.WriteLine(date1 = date3)        ' Displays False
      ' </Snippet2> 
   End Sub
   
   Private Sub ShowGreaterThan()
      ' <Snippet3>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-6, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Console.WriteLine(date1 > date2)        ' Displays False
      Console.WriteLine(date1 > date3)        ' Displays True
      ' </Snippet3>
   End Sub
   
   Private Sub ShowGreaterThanDirect()
      ' <Snippet4>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-6, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Console.WriteLine(DateTimeOffset.op_GreaterThan(date1, date2))  ' Displays False
      Console.WriteLine(DateTimeOffset.op_GreaterThan(date1, date3))  ' Displays True
      ' </Snippet4>
   End Sub

   Private Sub ShowGreaterThanOrEqualTo()
      ' <Snippet5>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Dim date4 As DateTimeOffset = date1
      Console.WriteLine(date1 >= date2)        ' Displays False
      Console.WriteLine(date1 >= date3)        ' Displays True
      Console.WriteLine(date1 >= date4)        ' Displays True
      ' </Snippet5>
   End Sub
   
   Private Sub ShowGreaterThanOrEqualToDirect()
      ' <Snippet6>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Dim date4 As DateTimeOffset = date1
      Console.WriteLine( _
          DateTimeOffset.op_GreaterThanOrEqual(date1, date2))   ' Displays False
      Console.WriteLine( _
          DateTimeOffset.op_GreaterThanOrEqual(date1, date3))   ' Displays True
      Console.WriteLine( _
          DateTimeOffset.op_GreaterThanOrEqual(date1, date4))   ' Displays True
      ' </Snippet6>
   End Sub

   Private Sub ShowImplicitConversions()
      ' <Snippet7>
      Dim timeWithOffset As DateTimeOffset 
      timeWithOffset = #07/03/2008 6:45PM#
      Console.WriteLine(timeWithOffset.ToString())
      
      timeWithOffset = Date.UtcNow
      Console.WriteLine(timeWithOffset.ToString())
      
      timeWithOffset = Date.SpecifyKind(Date.Now, DateTimeKind.Unspecified)
      Console.WriteLine(timeWithOffset.ToString())
   
      timeWithOffset = #1/1/2008 2:30AM# + New TimeSpan(1, 0, 0, 0)
      Console.WriteLine(timeWithOffset.ToString())
      ' The example produces the following output if run on 3/20/2007 
      ' at 6:25 PM on a computer in the U.S. Pacific Daylight Time zone:
      '       7/3/2008 6:45:00 PM -07:00
      '       3/21/2007 1:25:52 AM +00:00
      '       3/20/2007 6:25:52 PM -07:00
      '       1/2/2008 2:30:00 AM -08:00      
      ' </Snippet7>
   End Sub

   Private Sub ShowInequality()
      ' <Snippet8>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-6, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Console.WriteLine(date1 <> date2)        ' Displays False
      Console.WriteLine(date1 <> date3)        ' Displays True
      ' </Snippet8> 
   End Sub

   Private Sub ShowInequalityDirect()
      ' <Snippet9>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Dim date4 As DateTimeOffset = date1
      Console.WriteLine( _
          DateTimeOffset.op_Inequality(date1, date2))   ' Displays True
      Console.WriteLine( _
          DateTimeOffset.op_Inequality(date1, date3))   ' Displays True
      Console.WriteLine( _
          DateTimeOffset.op_Inequality(date1, date4))   ' Displays False
      ' </Snippet9>
   End Sub
   
   Private Sub ShowLessThan()
      ' <Snippet10>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-6, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-8, 0, 0))
      Console.WriteLine(date1 < date2)        ' Displays False
      Console.WriteLine(date1 < date3)        ' Displays True
      ' </Snippet10>
   End Sub
   
   Private Sub ShowLessThanDirect()
      ' <Snippet11>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-6, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-8, 0, 0))
      Console.WriteLine(DateTimeOffset.op_LessThan(date1, date2))  ' Displays False
      Console.WriteLine(DateTimeOffset.op_LessThan(date1, date3))  ' Displays True
      ' </Snippet11>
   End Sub
   
   Private Sub ShowLessThanOrEqualTo()
      ' <Snippet12>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Dim date4 As DateTimeOffset = date1
      Console.WriteLine(date1 <= date2)        ' Displays True
      Console.WriteLine(date1 <= date3)        ' Displays False
      Console.WriteLine(date1 <= date4)        ' Displays True
      ' </Snippet12>
   End Sub
   
   Private Sub ShowLessThanOrEqualToDirect()
      ' <Snippet13>
      Dim date1 As New DateTimeOffset(#6/3/2007 2:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date2 As New DateTimeOffset(#6/3/2007 3:45PM#, _
                   New TimeSpan(-7, 0, 0))
      Dim date3 As New DateTimeOffset(date1.DateTime, _
                   New TimeSpan(-6, 0, 0))
      Dim date4 As DateTimeOffset = date1
      Console.WriteLine(DateTimeOffset.op_LessThanOrEqual(date1, date2))   ' Displays True
      Console.WriteLine(DateTimeOffset.op_LessThanOrEqual(date1, date3)) ' Displays False
      Console.WriteLine(DateTimeOffset.op_LessThanOrEqual(date1, date4)) ' Displays True
      ' </Snippet13>
   End Sub

   Private Sub ShowSubtraction1()
      ' <Snippet14>
      Dim firstDate As New DateTimeOffset(#3/25/2008 6:00PM#, _
                                          New TimeSpan(-7, 0, 0))
      Dim secondDate As New DateTimeOffset(#3/25/2008 6:00PM#, _
                                           New TimeSpan(-5, 0, 0))
      Dim thirdDate As New DateTimeOffset(#2/28/2008 9:00AM#, _
                                          New TimeSpan(-7, 0, 0))
      Dim difference As TimeSpan
      
      difference = firstDate - secondDate
      Console.WriteLine("({0}) - ({1}): {2} days, {3}:{4:d2}", _
                        firstDate.ToString(), _
                        secondDate.ToString(), _
                        difference.Days, _
                        difference.Hours, _
                        difference.Minutes)      
      difference = firstDate - thirdDate
      Console.WriteLine("({0}) - ({1}): {2} days, {3}:{4:d2}", _
                        firstDate.ToString(), _
                        secondDate.ToString(), _
                        difference.Days, _
                        difference.Hours, _
                        difference.Minutes) 
      ' The example produces the following output:
      '    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 0 days, 2:00
      '    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 26 days, 9:00                                 
      ' </Snippet14>   
   End Sub

   Private Sub ShowSubtraction2()
      ' <Snippet15>   
      Dim offsetDate As New DateTimeOffset(#12/3/2007 11:30AM#, _
                                     New TimeSpan(-8, 0, 0)) 
      Dim duration As New TimeSpan(7, 18, 0, 0)
      Console.WriteLine(offsetDate - duration)    ' Displays 11/25/2007 5:30:00 PM -08:00
      ' </Snippet15>   
   End Sub
End Module




