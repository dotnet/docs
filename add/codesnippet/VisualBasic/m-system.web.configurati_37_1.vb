                    ' Remove the client target at the 
                    ' specified index from the collection.
                    clientTargets.RemoveAt(0)

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If
