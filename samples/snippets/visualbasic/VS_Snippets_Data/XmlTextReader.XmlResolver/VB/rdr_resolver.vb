'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Net

public class Sample 

  public shared sub Main() 

    ' Create the reader.
    Dim reader as XmlTextReader = new XmlTextReader("http://myServer/data/books.xml")
   
    ' Supply the credentials necessary to access the Web server.
    Dim resolver as XmlUrlResolver = new XmlUrlResolver()
    resolver.Credentials = CredentialCache.DefaultCredentials
    reader.XmlResolver = resolver

    ' Parse the file.
    while (reader.Read()) 
       ' Do any additional processing here.
    end while           
  
    ' Close the reader.
    reader.Close()     
  
  end sub
end class
'</snippet1>
