      Dim myType As Type = GetType(MyService)
      Dim myMethodInfo As MethodInfo = myType.GetMethod("Add")
      ' Create a synchronous 'LogicalMethodInfo' instance.
      Dim myLogicalMethodInfo As LogicalMethodInfo = _
                 LogicalMethodInfo.Create(New MethodInfo() {myMethodInfo}, LogicalMethodTypes.Sync)(0)
      ' Display the method for which the attributes are being displayed.
      Console.WriteLine(ControlChars.NewLine + "Displaying the attributes for the method : {0}" + _
                 ControlChars.NewLine, myLogicalMethodInfo.MethodInfo.ToString())
      