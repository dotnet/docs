    // Add a DeviceSpecificChoice section programatically
    protected void form1_Init(object sender, EventArgs e)
    {
        DeviceSpecific devSpecific = Panel1.DeviceSpecific;
        DeviceSpecificChoice devChoiceHtml = new DeviceSpecificChoice();
        devChoiceHtml.Filter = "isCHTML10";
        devSpecific.Choices.Add(devChoiceHtml);
        ((IParserAccessor)form1).AddParsedSubObject(devSpecific);
    }