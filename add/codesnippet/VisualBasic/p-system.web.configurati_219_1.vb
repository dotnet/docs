                    ' Get the mobileControls section.
                    Dim mobileControls _
                    As ConfigurationSection = _
                    systemWeb.MobileControls
                    ' Read section information.
                    info = mobileControls.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)