                    ' Get the healthMonitoring section.
                    Dim healthMonitoring _
                    As HealthMonitoringSection = _
                    systemWeb.HealthMonitoring
                    ' Read section information.
                    info = healthMonitoring.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)