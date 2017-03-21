    Protected Overrides Function SerializeElement(ByVal writer _
        As System.Xml.XmlWriter, _
        ByVal serializeCollectionKey As Boolean) As Boolean

        Dim ret As Boolean = _
            MyBase.SerializeElement(writer, serializeCollectionKey)
        ' Enter your custom processing code here.
        Return ret
    End Function 'SerializeElement