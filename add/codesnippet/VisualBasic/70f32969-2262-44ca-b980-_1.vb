                    ' Create a new ClientTarget object.
                    clientTarget = New ClientTarget( _
                    "my alias", "My User Agent")

                    ' Add the clientTarget to 
                    ' the collection.
                    clientTargets.Add(clientTarget)

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If