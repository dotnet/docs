                    ' Clear the client target collection.
                    clientTargets.Clear()

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If