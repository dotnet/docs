  ' Create a validating reader.
  Dim settings As New XmlReaderSettings()
  settings.ValidationType = ValidationType.Schema
  settings.Schemas.Add("urn:items", "item.xsd")
  Dim reader As XmlReader = XmlReader.Create("item.xml", settings)
        
  ' Get the CLR type of the price element. 
  reader.ReadToFollowing("price")
  Console.WriteLine(reader.ValueType)
        
  ' Return the value of the price element as Decimal object.
  Dim price As [Decimal] = CType(reader.ReadElementContentAsObject(), [Decimal])
        
  ' Add 2.50 to the price.
  price = [Decimal].Add(price, 2.5D)
