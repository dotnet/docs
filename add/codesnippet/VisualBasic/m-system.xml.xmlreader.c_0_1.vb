        ' Set the validation settings.
        Dim settings As New XmlReaderSettings()
        settings.DtdProcessing = DtdProcessing.Parse
        settings.ValidationType = ValidationType.DTD
        AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
        
        ' Create the XmlReader object.
        Dim reader As XmlReader = XmlReader.Create("itemDTD.xml", settings)
        
        ' Parse the file. 
        While reader.Read()
        End While