' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      ' <Snippet1>
      Dim centuryBegin As Date = #1/1/2001 0:0:0#
      Dim currentDate As Date = Date.Now
      Dim elapsedTicks As Long = currentDate.Ticks - centuryBegin.Ticks
      Dim elapsedSpan As New TimeSpan(elapsedTicks)
      
      Console.WriteLine("Elapsed from the beginning of the century to {0:f}:", _
                         currentDate)
      Console.WriteLine("   {0:N0} nanoseconds", elapsedTicks * 100)
      Console.WriteLine("   {0:N0} ticks", elapsedTicks)
      Console.WriteLine("   {0:N2} seconds", elapsedSpan.TotalSeconds)
      Console.WriteLine("   {0:N2} minutes", elapsedSpan.TotalMinutes)
      Console.WriteLine("   {0:N0} days, {1} hours, {2} minutes, {3} seconds", _
                        elapsedSpan.Days, elapsedSpan.Hours, _
                        elapsedSpan.Minutes, elapsedSpan.Seconds)
      ' If run on December 14, 2007, at 15:23, this example displays the
      ' following output to the console:
      '          219,338,580,000,000,000 nanoseconds
      '          2,193,385,800,000,000 ticks
      '          219,338,580.00 seconds
      '          3,655,643.00 minutes
      '          2,538 days, 15 hours, 23 minutes, 0 seconds
      ' </Snippet1>
   End Sub
End Module

