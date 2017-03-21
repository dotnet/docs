                    ' Create a ClientTarget object.
                    clientTarget = New ClientTarget( _
                    "my alias", "My User Agent")

                    ' Remove it from the collection
                    ' (if exists).
                    clientTargets.Remove(clientTarget)

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If