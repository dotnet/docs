                    ' Get the httpCookies section.
                    Dim httpCookies _
                    As HttpCookiesSection = _
                    systemWeb.HttpCookies
                    ' Read section information.
                    info = httpCookies.SectionInformation
                    name = info.SectionName
                    type = info.Type
                    declared = info.IsDeclared.ToString()
                    msg = String.Format("Name:     {0}" + _
                    ControlChars.Lf + "Declared: {1}" + _
                    ControlChars.Lf + "Type:     {2}" + _
                    ControlChars.Lf, name, declared, type)
