Dim phoneAttribute As XAttribute = 
  New XAttribute(XName.Get(phoneType), phoneNumber)
Dim contact5 As XElement = 
  <contact <%= phoneAttribute %>/>