' Topic: How to: Load XML from Files (Visual Basic)

Public Class Samples15
  Public Shared Sub Main()
    '<Snippet43>
    Dim books = 
        XDocument.Load(My.Application.Info.DirectoryPath & 
                       "\..\..\Data\books.xml")
    Console.WriteLine(books)
    '</Snippet43>

    '<Snippet47>
    Dim xmlString = "<Book id=""bk102"">" & vbCrLf & 
                    "  <Author>Garcia, Debra</Author>" & vbCrLf & 
                    "  <Title>Writing Code</Title>" & vbCrLf & 
                    "  <Price>5.95</Price>" & vbCrLf & 
                    "</Book>"
    Dim xmlElem = XElement.Parse(xmlString)
    Console.WriteLine(xmlElem)
    '</Snippet47>

    '<Snippet46>
    Dim reader = 
      System.Xml.XmlReader.Create(My.Application.Info.DirectoryPath & 
                                  "\..\..\Data\books.xml")
    reader.MoveToContent()
    Dim inputXml = XDocument.ReadFrom(reader)
    Console.WriteLine(inputXml)
    '</Snippet46>


  End Sub
End Class