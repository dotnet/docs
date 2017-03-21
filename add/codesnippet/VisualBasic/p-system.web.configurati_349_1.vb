                    ' Get the hostingEnvironment section.
                    Dim hostingEnvironment _
                    As HostingEnvironmentSection = _
                    systemWeb.HostingEnvironment
                    ' Read section information.
                    info = hostingEnvironment.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)