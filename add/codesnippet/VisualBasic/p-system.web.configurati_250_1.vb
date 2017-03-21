                    ' Get the anonymousIdentification section.
                    Dim anonymousIdentification _
                    As AnonymousIdentificationSection = _
                    systemWeb.AnonymousIdentification
                    ' Read section information.
                    info = anonymousIdentification.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
