Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

public class Sample 

  public shared sub Main() 

    ' <snippet1>
    ' Set the reader settings.
    Dim settings as XmlReaderSettings = new XmlReaderSettings()
    settings.IgnoreComments = true
    settings.IgnoreProcessingInstructions = true
    settings.IgnoreWhitespace = true
    ' </snippet1>
    
    ' <snippet2>
    ' Create a resolver with default credentials.
    Dim resolver as XmlUrlResolver = new XmlUrlResolver()
    resolver.Credentials = System.Net.CredentialCache.DefaultCredentials

    ' Set the reader settings object to use the resolver.
    settings.XmlResolver = resolver

    ' Create the XmlReader object.
    Dim reader as XmlReader = XmlReader.Create("http://ServerName/data/books.xml", settings)
    ' </snippet2>

    ' Parse the file. 
    while reader.Read()
    end while
  end sub


end class
