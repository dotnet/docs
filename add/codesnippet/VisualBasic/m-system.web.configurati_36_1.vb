                    ' Remove the client target with the
                    ' specified alias from the collection
                    ' (if exists).
                    clientTargets.Remove("my alias")

                    ' Update the configuration file.
                    If Not clientTargetSection.IsReadOnly() Then
                        configuration.Save()
                    End If