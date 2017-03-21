      Dim timeZoneName As String = String.Empty
      ' Get CST, Canadian CST, and Mexican CST adjustment rules
      Dim usCstAdjustments(), canCstAdjustments(), mexCstAdjustments() As TimeZoneInfo.AdjustmentRule
      Try
         timeZoneName = "Central Standard Time"
         usCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The {0} time zone is not defined in the registry.", timeZoneName)
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Data for the {0} time zone is invalid.", timeZoneName)
      End Try
      Try
         timeZoneName = "Canada Central Standard Time"
         canCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The {0} time zone is not defined in the registry.", timeZoneName)
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Data for the {0} time zone is invalid.", timeZoneName)
      End Try
      Try
         timeZoneName = "Central Standard Time (Mexico)"
         mexCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("The {0} time zone is not defined in the registry.", timeZoneName)
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Data for the {0} time zone is invalid.", timeZoneName)
      End Try
      ' Determine if CST and other time zones have the same rules
      For Each rule As TimeZoneInfo.AdjustmentRule In usCstAdjustments
         Console.WriteLine("Comparing Central Standard Time rule for {0:d} to {1:d} with:", _
                           rule.DateStart, rule.DateEnd)
         ' Compare with Canada Central Standard Time
         If canCstAdjustments.Length = 0 Then
            Console.WriteLine("   Canada Central Standard Time has no adjustment rules.")
         Else
            For Each canRule As TimeZoneInfo.AdjustmentRule In canCstAdjustments
               Console.WriteLine("   Canadian CST for {0:d} to {1:d}: {2}", _
                                 canRule.DateStart, canRule.DateEnd, _
                                 IIf(rule.Equals(canRule), "Equal", "Not Equal"))
            Next              
         End If          
   
         ' Compare with Mexico Central Standard Time
         If mexCstAdjustments.Length = 0 Then
            Console.WriteLine("   Mexican Central Standard Time has no adjustment rules.")
         Else
            For Each mexRule As TimeZoneInfo.AdjustmentRule In mexCstAdjustments
               Console.WriteLine("   Mexican CST for {0:d} to {1:d}: {2}", _
                                 mexRule.DateStart, mexRule.DateEnd, _
                                 IIf(rule.Equals(mexRule), "Equal", "Not Equal"))
            Next              
         End If
      Next   
      ' This code displays the following output to the console:
      ' 
      ' Comparing Central Standard Time rule for 1/1/0001 to 12/31/9999 with:
      '    Canada Central Standard Time has no adjustment rules.
      '    Mexican CST for 1/1/0001 to 12/31/9999: Equal