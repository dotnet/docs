                Display("Demonstrating the use of the GetObjectData "
                    "method.");
                SerializationInfo^ entryPointSerializatonInfo =
                    gcnew SerializationInfo(TestSecurityException::typeid,
                    gcnew FormatterConverter);
                exception->GetObjectData(entryPointSerializatonInfo,
                    *gcnew StreamingContext(StreamingContextStates::All));
                Display("The FirstPermissionThatFailed from the call"
                    " to GetObjectData is: ");
                Display(entryPointSerializatonInfo->GetString(
                    "FirstPermissionThatFailed"));