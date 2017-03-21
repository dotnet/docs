                    ' Get the httpHandlers section.
                    Dim httpHandlers _
                    As HttpHandlersSection = _
                    systemWeb.HttpHandlers
                    ' Read section information.
                    info = httpHandlers.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
