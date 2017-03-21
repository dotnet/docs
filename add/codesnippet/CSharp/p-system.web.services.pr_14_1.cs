      Type myType = typeof(MyService);
      MethodInfo myMethodInfo = myType.GetMethod("Add");
      // Create a synchronous 'LogicalMethodInfo' instance.
      LogicalMethodInfo myLogicalMethodInfo = 
         (LogicalMethodInfo.Create(new MethodInfo[] {myMethodInfo}, 
                                   LogicalMethodTypes.Sync))[0];
      // Display the method for which the attributes are being displayed.
      Console.WriteLine("\nDisplaying the attributes for the method : {0}\n",
                           myLogicalMethodInfo.MethodInfo);