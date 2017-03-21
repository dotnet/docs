            // This method is called when deserialization of the 
            // exception is complete.
            void ISafeSerializationData.CompleteDeserialization
                (object obj)
            {
                // Since the exception simply contains an instance of 
                // the exception state object, we can repopulate it 
                // here by just setting its instance field to be equal 
                // to this deserialized state instance.
                NewException exception = obj as NewException;
                exception.m_state = this;
            }