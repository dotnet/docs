                    ' Get the processModel section.
                    Dim processModel _
                    As ProcessModelSection = _
                    systemWeb.ProcessModel
                    ' Read section information.
                    info = processModel.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
