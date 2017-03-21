                    ' Get the .<sqlCacheDependency> section
                    Dim sqlCacheDependency _
                    As SqlCacheDependencySection = _
                    cachingSectionGroup.SqlCacheDependency

                    ' Display one of its attributes.
                    msg = String.Format( _
                    "Sql cache dependency enabled: {0}" + _
                    ControlChars.Lf, _
                    sqlCacheDependency.Enabled.ToString())

                    Console.Write(msg)
