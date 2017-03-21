                    ' Get the securityPolicy section.
                    Dim securityPolicy _
                    As SecurityPolicySection = _
                    systemWeb.SecurityPolicy
                    ' Read section information.
                    info = securityPolicy.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
