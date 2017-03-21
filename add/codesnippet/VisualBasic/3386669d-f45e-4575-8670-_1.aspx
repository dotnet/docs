    ' Add a DeviceSpecificChoice section programatically
    Protected Sub form1_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim devSpecific As DeviceSpecific = Panel1.DeviceSpecific
        Dim devChoiceHtml As DeviceSpecificChoice = New DeviceSpecificChoice()
        devChoiceHtml.Filter = "isCHTML10"
        devSpecific.Choices.Add(devChoiceHtml)
        CType(form1, IParserAccessor).AddParsedSubObject(devSpecific)
    End Sub