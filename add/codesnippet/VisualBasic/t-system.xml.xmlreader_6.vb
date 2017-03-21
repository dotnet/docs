' Create a validating XmlReader object. The schema 
' provides the necessary type information.
Dim settings As XmlReaderSettings = New XmlReaderSettings()
settings.ValidationType = ValidationType.Schema
settings.Schemas.Add("urn:empl-hire", "hireDate.xsd")
Using reader As XmlReader = XmlReader.Create("hireDate.xml", settings) 
  ' Move to the hire-date element.
  reader.MoveToContent()
  reader.ReadToDescendant("hire-date")

  ' Return the hire-date as a DateTime object.
  Dim hireDate As DateTime = reader.ReadElementContentAsDateTime()
  Console.WriteLine("Six Month Review Date: {0}", hireDate.AddMonths(6))
End Using