        If reader.MoveToContent() = XmlNodeType.Element And reader.Name = "price" Then
            _price = reader.ReadString()
        End If