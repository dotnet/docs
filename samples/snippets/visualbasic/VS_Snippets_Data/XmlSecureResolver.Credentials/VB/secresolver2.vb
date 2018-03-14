' <snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Net

public class Sample 

  public shared sub Main() 

    ' Create the reader.
    Dim reader as XmlTextReader = new XmlTextReader("http://myServer/data/books.xml")
   
    ' Create a secure resolver with default credentials.
    Dim resolver as XmlUrlResolver = new XmlUrlResolver()
    Dim sResolver as XmlSecureResolver = new XmlSecureResolver(resolver, "http://myServer/data/")
    sResolver.Credentials = CredentialCache.DefaultCredentials

    ' Use the secure resolver to resolve resources.
    reader.XmlResolver = sResolver

    ' Parse the file.
    while (reader.Read()) 
       ' Do any additional processing here.
    end while           
  
    ' Close the reader.
    reader.Close()     
  
  end sub
end class
' </snippet1>