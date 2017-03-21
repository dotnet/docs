      Const SHIFT_LENGTH As Integer = 8
      
      Dim startTime As New DateTimeOffset(#8/6/2007 12:00:00AM#, _
                           DateTimeOffset.Now.Offset)
      Dim startOfShift As DateTimeOffset = startTime.AddHours(SHIFT_LENGTH)
      
      Console.WriteLine("Shifts for the week of {0:D}", startOfShift)                           
      Do 
         ' Exclude third shift
         If startOfShift.Hour > 6 Then _
            Console.WriteLine("   {0:d} at {0:T}", startOfShift)

         startOfShift = startOfShift.AddHours(SHIFT_LENGTH)
      Loop While startOfShift.DayOfWeek <> DayOfWeek.Saturday And _
                 startOfShift.DayOfWeek <> DayOfWeek.Sunday
                
      ' The example produces the following output:
      '
      '    Shifts for the week of Monday, August 06, 2007
      '       8/6/2007 at 8:00:00 AM
      '       8/6/2007 at 4:00:00 PM
      '       8/7/2007 at 8:00:00 AM
      '       8/7/2007 at 4:00:00 PM
      '       8/8/2007 at 8:00:00 AM
      '       8/8/2007 at 4:00:00 PM
      '       8/9/2007 at 8:00:00 AM
      '       8/9/2007 at 4:00:00 PM
      '       8/10/2007 at 8:00:00 AM
      '       8/10/2007 at 4:00:00 PM                 