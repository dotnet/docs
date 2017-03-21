                    ' Get the .<outputCacheSettings> section
                    Dim outputCacheSettings _
                    As OutputCacheSettingsSection = _
                    cachingSectionGroup.OutputCacheSettings

                    ' Display the number of existing 
                    ' profiles.
                    Dim profilesCount As Integer = _
                    outputCacheSettings.OutputCacheProfiles.Count
                    msg = String.Format( _
                    "Number of profiles: {0}" + _
                    ControlChars.Lf, profilesCount.ToString())

                    Console.Write(msg)
