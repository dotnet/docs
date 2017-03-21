                    ' Clear the url mapping collection.
                    urlMappings.Clear()

                    ' Update the configuration file.
                    ' Define the save modality.
                    Dim saveMode _
                    As ConfigurationSaveMode = _
                    ConfigurationSaveMode.Minimal

                    urlMappings.EmitClear = _
                    Convert.ToBoolean(parm2)

                    If parm1 = "none" Then
                        If Not urlMappingSection.IsReadOnly() Then
                            configuration.Save()
                        End If
                        msg = String.Format( _
                        "Default modality, EmitClear:      {0}", _
                        urlMappings.EmitClear.ToString())
                    Else
                        If parm1 = "full" Then
                            saveMode = ConfigurationSaveMode.Full
                        ElseIf parm1 = "modified" Then
                            saveMode = ConfigurationSaveMode.Modified
                        End If
                        If Not urlMappingSection.IsReadOnly() Then
                            configuration.Save(saveMode)
                        End If
                        msg = String.Format( _
                        "Save modality:      {0}", _
                        saveMode.ToString())
                    End If
