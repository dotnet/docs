' Visual Basic .NET Document
Option Strict On

Imports System.IO
' <Snippet6>
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
' </Snippet6>

<Assembly: CLSCompliant(True)>
Module modMain

   Public Sub Main()
      Console.WriteLine("First Overload of CreateCustomTimeZone: ")
      DefineMawsonTime()
      Console.WriteLine()
      Console.WriteLine("Second Overload of CreateCustomTimeZone: ")
      Dim palmer As TimeZoneInfo = DefinePalmerTime()
      Console.WriteLine()
      Console.WriteLine("Third Overload of CreateCustomTimeZone: ")
      DefineNonDSTTime()
      Console.WriteLine()
      ' Use ConvertTime and ConvertTimeBySystemTimeZoneId
       Console.WriteLine(TimeZoneInfo.ConvertTime(Date.Now, TimeZoneInfo.Local, palmer))
'       Console.WriteLine(TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Date.Now, "Pacific Standard Time", "Palmer Standard Time"))
      Console.WriteLine("About to create Antarctic/South Pole time zone")
      ' Define Time Zone for Serialization
      Dim southPole As TimeZoneInfo = InitializeTimeZone()
      TestCst()
   End Sub
   
   Private Sub TestCST()
      Console.WriteLine()
      Console.WriteLine("Testing new Central Standard Time zone...")
      console.WriteLine()
      Dim cst As TimeZoneInfo = CreateNewCentralStandardTimeZone()
      ' <Snippet7>
      Dim est As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")

      Dim pastDate1 As Date = #2/11/1942#
      Console.WriteLine("Is {0} daylight saving time: {1}", pastDate1, _
                        cst.IsDaylightSavingTime(pastDate1))
      
      Dim pastDate2 As Date = #10/29/1967 1:30AM#
      Console.WriteLine("Is {0} ambiguous: {1}", pastDate2, _
                        cst.IsAmbiguousTime(pastDate2))

      Dim pastDate3 As Date = #1/7/1974 2:59AM#
      Console.WriteLine("{0} {1} is {2} {3}", pastDate3, _
                        IIf(est.IsDaylightSavingTime(pastDate3), _
                            est.DaylightName, est.StandardName), _
                        TimeZoneInfo.ConvertTime(pastDate3, est, cst), _ 
                        IIf(cst.IsDaylightSavingTime(TimeZoneInfo.ConvertTime(pastDate3, est, cst)), _
                            cst.DaylightName, cst.StandardName)) 
      '
      ' This code produces the following output to the console:
      ' 
      '    Is 2/11/1942 12:00:00 AM daylight saving time: True
      '    Is 10/29/1967 1:30:00 AM ambiguous: True
      '    1/7/1974 2:59:00 AM Eastern Standard Time is 1/7/1974 2:59:00 AM Central Daylight Time                            
      ' </Snippet7>
   End Sub

   Private Sub DefineMawsonTime()
      ' <Snippet1>
      Dim displayName As String = "(GMT+06:00) Antarctica/Mawson Time"
      Dim standardName As String = "Mawson Time" 
      Dim offset As TimeSpan = New TimeSpan(06, 00, 00)
      Dim mawson As TimeZoneInfo = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName)
      Console.WriteLine("The current time is {0} {1}", _ 
                        TimeZoneInfo.ConvertTime(Date.Now, TimeZoneInfo.Local, mawson), _
                        mawson.StandardName)      
      ' </Snippet1>  
   End Sub
   
   Private Function DefinePalmerTime() As TimeZoneInfo
      ' <Snippet2>
      ' Define transition times to/from DST
      Dim startTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#04:00:00#, 10, 2, DayOfWeek.Sunday) 
      Dim endTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#3:00:00#, 3, 2, DayOfWeek.Sunday)
      ' Define adjustment rule
      Dim delta As TimeSpan = New TimeSpan(1, 0, 0)
      Dim adjustment As TimeZoneInfo.AdjustmentRule = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#10/01/1999#, Date.MaxValue.Date, delta, startTransition, endTransition)
      ' Create array for adjustment rules
      Dim adjustments() As TimeZoneInfo.AdjustmentRule = {adjustment}
      ' Define other custom time zone arguments
      Dim DisplayName As String = "(GMT-04:00) Antarctica/Palmer Time"
      Dim standardName As String = "Palmer Standard Time"
      Dim daylightName As String = "Palmer Daylight Time"
      Dim offset As TimeSpan = New TimeSpan(-4, 0, 0)
      Dim palmer As TimeZoneInfo = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments)
      Console.WriteLine("The current time is {0} {1}", _ 
                        TimeZoneInfo.ConvertTime(Date.Now, TimeZoneInfo.Local, palmer), _
                        palmer.StandardName)
      ' </Snippet2>
      return palmer
   End Function
   
   Private Sub DefineNonDSTTime()
      ' <Snippet3>
      ' Define transition times to/from DST
      Dim startTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#04:00:00#, 10, 2, DayOfWeek.Sunday) 
      Dim endTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#3:00:00#, 3, 2, DayOfWeek.Sunday)
      ' Define adjustment rule
      Dim delta As TimeSpan = New TimeSpan(1, 0, 0)
      Dim adjustment As TimeZoneInfo.AdjustmentRule = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#10/01/1999#, Date.MaxValue.Date, delta, startTransition, endTransition)
      ' Create array for adjustment rules
      Dim adjustments() As TimeZoneInfo.AdjustmentRule = {adjustment}
      ' Define other custom time zone arguments
      Dim displayName As String = "(GMT-04:00) Antarctica/Palmer Time"
      Dim standardName As String = "Palmer Standard Time"
      Dim daylightName As String = "Palmer Daylight Time"
      Dim offset As TimeSpan = New TimeSpan(-4, 0, 0)
      Dim palmer As TimeZoneInfo = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments, True)
      ' Indicate whether new time zone's adjustment rules are present
      Console.WriteLine("{0} {1}has {2} adjustment rules.", _
                        palmer.StandardName, _
                        IIf(Not String.IsNullOrEmpty(palmer.DaylightName), "(" & palmer.DaylightName & ") ", ""), _
                        palmer.GetAdjustmentRules().Length)
      ' Indicate whether new time zone supports DST
      Console.WriteLine("{0} supports DST: {1}", palmer.StandardName, palmer.SupportsDaylightSavingTime)
      ' </Snippet3>
   End Sub
   
   ' <Snippet4> 
   Private Function InitializeTimeZone() As TimeZoneInfo
      Dim southPole As TimeZoneInfo = Nothing
      ' Determine if South Pole time zone is defined in system
      Try
         southPole = TimeZoneInfo.FindSystemTimeZoneById("Antarctica/South Pole Standard Time")
      ' Time zone does not exist; create it, store it in a text file, and return it
      Catch e As TimeZoneNotFoundException
         Dim found As Boolean
         Const filename As String = ".\TimeZoneInfo.txt"
         
         If File.Exists(filename) Then
            Dim reader As StreamReader = New StreamReader(fileName)
            Dim timeZoneString As String
            Do While reader.Peek() >= 0
               timeZoneString = reader.ReadLine()
               If timeZoneString.Contains("Antarctica/South Pole") Then
                  southPole = TimeZoneInfo.FromSerializedString(timeZoneString)
                  reader.Close()
                  found = True
                  Exit Do
               End If   
            Loop
         End If
         If Not found Then               
            ' Define transition times to/from DST
            Dim startTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00#, 10, 1, DayOfWeek.Sunday) 
            Dim endTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00#, 3, 3, DayOfWeek.Sunday)
            ' Define adjustment rule
            Dim delta As TimeSpan = New TimeSpan(1, 0, 0)
            Dim adjustment As TimeZoneInfo.AdjustmentRule = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#10/01/1989#, Date.MaxValue.Date, delta, startTransition, endTransition)
            ' Create array for adjustment rules
            Dim adjustments() As TimeZoneInfo.AdjustmentRule = {adjustment}
            ' Define other custom time zone arguments
            Dim displayName As String = "(GMT+12:00) Antarctica/South Pole"
            Dim standardName As String = "Antarctica/South Pole Standard Time"
            Dim daylightName As String = "Antarctica/South Pole Daylight Time"
            Dim offset As TimeSpan = New TimeSpan(12, 0, 0)
            southPole = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments)
            ' Write time zone to the file
            Dim writer As StreamWriter = New StreamWriter(filename, True)
            writer.WriteLine(southPole.ToSerializedString())
            writer.Close()
         End If
      End Try
      Return southPole
   End Function
   ' </Snippet4>

   Private Function CreateNewCentralStandardTimeZone() As TimeZoneInfo
      ' <Snippet5>
      Dim cst As TimeZoneInfo
      ' Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
      Dim delta As New TimeSpan(1, 0, 0)
      Dim adjustment As TimeZoneInfo.AdjustmentRule
      Dim adjustmentList As New List(Of TimeZoneInfo.AdjustmentRule)
      ' Declare transition time variables to hold transition time information
      Dim transitionRuleStart, transitionRuleEnd As TimeZoneInfo.TransitionTime
                            
      ' Define new Central Standard Time zone 6 hours earlier than UTC
      ' Define rule 1 (for 1918-1919)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00AM#, 03, 05, DayOfWeek.Sunday)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00AM#, 10, 05, DayOfWeek.Sunday) 
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1918#, #12/31/1919#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment) 
      ' Define rule 2 (for 1942)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#2:00:00AM#, 02, 09)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1942#, #12/31/1942#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define rule 3 (for 1945)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#11:00:00PM#, 08, 14)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#2:00:00AM#, 09, 30)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1945#, #12/31/1945#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define end rule (for 1967-2006)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00AM#, 10, 5, DayOfWeek.Sunday)
      ' Define rule 4 (for 1967-73)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 04, 05, DayOfWeek.Sunday)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1967#, #12/31/1973#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define rule 5 (for 1974 only)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#2:00:00AM#, 01, 06)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1974#, #12/31/1974#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define rule 6 (for 1975 only)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(#2:00:00AM#, 02, 23)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1975#, #12/31/1975#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define rule 7 (1976-1986)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 04, 05, DayOfWeek.Sunday)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1976#, #12/31/1986#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define rule 8 (1987-2006)  
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 04, 01, DayOfWeek.Sunday)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/1987#, #12/31/2006#, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
      ' Define rule 9 (2007- )  
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 03, 02, DayOfWeek.Sunday)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#2:00:00AM#, 11, 01, DayOfWeek.Sunday)
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#01/01/2007#, Date.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd)
      adjustmentList.Add(adjustment)
                    
      ' Convert list of adjustment rules to an array
      Dim adjustments(adjustmentList.Count - 1) As TimeZoneInfo.AdjustmentRule
      adjustmentList.CopyTo(adjustments)
         
      cst = TimeZoneInfo.CreateCustomTimeZone("Central Standard Time", New TimeSpan(-6, 0, 0), _
            "(GMT-06:00) Central Time (US Only)", "Central Standard Time", _
            "Central Daylight Time", adjustments)
      ' </Snippet5>            
      Return cst      
   End Function

End Module

