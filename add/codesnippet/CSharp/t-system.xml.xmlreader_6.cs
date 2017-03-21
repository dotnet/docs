// Create a validating XmlReader object. The schema 
// provides the necessary type information.
XmlReaderSettings settings = new XmlReaderSettings();
settings.ValidationType = ValidationType.Schema;
settings.Schemas.Add("urn:empl-hire", "hireDate.xsd");
using (XmlReader reader = XmlReader.Create("hireDate.xml", settings)) {

  // Move to the hire-date element.
  reader.MoveToContent();
  reader.ReadToDescendant("hire-date");

  // Return the hire-date as a DateTime object.
  DateTime hireDate = reader.ReadElementContentAsDateTime();
  Console.WriteLine("Six Month Review Date: {0}", hireDate.AddMonths(6));
}