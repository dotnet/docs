            ' Display the SwitchLevelAttribute for the BooleanSwitch.
            Dim attribs As [Object]() = GetType(BooleanSwitch).GetCustomAttributes(GetType(SwitchLevelAttribute), False)
            If attribs.Length = 0 Then
                Console.WriteLine("Error, couldn't find SwitchLevelAttribute on BooleanSwitch.")
            Else
                Console.WriteLine(CType(attribs(0), SwitchLevelAttribute).SwitchLevelType.ToString())
            End If