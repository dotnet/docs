      ' Check whether the 'MyServerImpl' object is allowed for activation or not.
      If RemotingConfiguration.IsActivationAllowed(GetType(MyServerImpl)) Then
         ' Get the registered activated service types .
         Dim myActivatedServiceEntries As ActivatedServiceTypeEntry() = _ 
                             RemotingConfiguration.GetRegisteredActivatedServiceTypes()
         Console.WriteLine("The Length of the registered activated service type array is " + _ 
                                        myActivatedServiceEntries.Length.ToString())
         Console.WriteLine("The Object type is:" + _ 
                                 myActivatedServiceEntries(0).ObjectType.ToString())
      End If