                    ' Get the xhtmlConformance section.
                    Dim xhtmlConformance _
                    As XhtmlConformanceSection = _
                    systemWeb.XhtmlConformance
                    ' Read section information.
                    info = xhtmlConformance.SectionInformation

                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()

                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)