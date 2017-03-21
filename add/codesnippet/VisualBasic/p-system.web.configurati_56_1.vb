                    ' Get the sessionState section.
                    Dim sessionState _
                    As SessionStateSection = _
                    systemWeb.SessionState
                    ' Read section information.
                    info = sessionState.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
