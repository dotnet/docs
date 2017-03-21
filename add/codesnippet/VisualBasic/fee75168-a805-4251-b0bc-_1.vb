            Display("Demonstrating the use of the GetObjectData method.")
            Dim si As New SerializationInfo( _
                GetType(EntryPoint), New FormatterConverter())
            sE.GetObjectData(si, _
                New StreamingContext(StreamingContextStates.All))
            Display("The FirstPermissionThatFailed from the " & _
                "call to GetObjectData is: ")
            Display(si.GetString("FirstPermissionThatFailed"))
        End Try