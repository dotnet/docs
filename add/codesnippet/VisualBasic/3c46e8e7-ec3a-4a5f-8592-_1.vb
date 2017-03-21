         ' Check whether the 'MyServerImpl' type is registered as a remotely activated client type.
         Dim myActivatedClientEntry As ActivatedClientTypeEntry = _ 
                        RemotingConfiguration.IsRemotelyActivatedClientType(GetType(MyServerImpl))
         Console.WriteLine("The Object type is " + myActivatedClientEntry.ObjectType.ToString())
         Console.WriteLine("The Application Url is " + _ 
                                          myActivatedClientEntry.ApplicationUrl.ToString())