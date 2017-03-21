                Display("Demonstrating the use of the GetObjectData method.");
                SerializationInfo si = new SerializationInfo(
                    typeof(EntryPoint), new FormatterConverter());
                sE.GetObjectData(si, 
                    new StreamingContext(StreamingContextStates.All));
                Display("The FirstPermissionThatFailed from the " +
                    "call to GetObjectData is: ");
                Display(si.GetString("FirstPermissionThatFailed"));