            // Check whether the 'MyServerImpl' type is registered as
            // a remotely activated client type.
            ActivatedClientTypeEntry myActivatedClientEntry =
            RemotingConfiguration.IsRemotelyActivatedClientType(
                                            typeof(MyServerImpl));
            Console.WriteLine("The Object type is "
                   +myActivatedClientEntry.ObjectType);
            Console.WriteLine("The Application Url is "
                   +myActivatedClientEntry.ApplicationUrl);