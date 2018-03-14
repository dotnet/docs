Imports System
Imports System.IO
Imports System.Xml
Imports System.Security
Imports System.Security.Policy
Imports System.Net
 
 public class Sample
  
   private shared filename as String = "http://localhost/data/books.xml"
    
   public shared sub Main () 
   
       Dim s as Stream  = CType(GetFile(filename, new XmlUrlResolver()), Stream)
       Dim reader as XmlTextReader = new XmlTextReader(s)
       
   end sub
 
   '  NOTE:  To test, replace www.contoso.com w/ the local string

   
' <snippet1>

   public shared function GetFile (fileURL as String , resolver as XmlResolver) as Object
    
     '  Generate the default PermissionSet using the file URL.
     Dim evidence as Evidence = XmlSecureResolver.CreateEvidenceForUrl(fileURL)
     Dim myPermissions as PermissionSet = SecurityManager.ResolvePolicy(evidence)

     '  Modify the PermissionSet to only allow access to http://www.contoso.com.
     '  Create a WebPermission that only allows access to http://www.contoso.com.
     Dim myWebPermission as WebPermission = new WebPermission(NetworkAccess.Connect, "http://www.contoso.com")
     '  Replace the existing WebPermission in myPermissions with the updated WebPermission.
     myPermissions.SetPermission(myWebPermission)

     '  Use the modified PermissionSet to construct the XmlSecureResolver.
     Dim sResolver as XmlSecureResolver = new XmlSecureResolver(resolver, myPermissions)

     '  Get the object.
     Dim fullUri as Uri = sResolver.ResolveUri(nothing, fileURL)
     return sResolver.GetEntity(fullUri, nothing, nothing)
   end function 
' </snippet1> 

end class