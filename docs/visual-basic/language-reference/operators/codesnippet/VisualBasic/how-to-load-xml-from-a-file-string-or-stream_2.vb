    Dim xmlString = "<Book id=""bk102"">" & vbCrLf & 
                    "  <Author>Garcia, Debra</Author>" & vbCrLf & 
                    "  <Title>Writing Code</Title>" & vbCrLf & 
                    "  <Price>5.95</Price>" & vbCrLf & 
                    "</Book>"
    Dim xmlElem = XElement.Parse(xmlString)
    Console.WriteLine(xmlElem)