            ' This method is called when deserialization of the 
            ' exception is complete.
            Sub CompleteDeserialization(ByVal obj As Object) _
                Implements ISafeSerializationData.CompleteDeserialization

                ' Since the exception simply contains an instance 
                ' of the exception state object, we can repopulate it 
                ' here by just setting its instance field
                ' to be equal to this deserialized state instance.
                Dim exception As NewException = _
                    CType(obj, NewException)
                exception.m_state = Me
            End Sub