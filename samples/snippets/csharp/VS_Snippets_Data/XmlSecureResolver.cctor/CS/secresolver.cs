using System;
using System.IO;
using System.Xml;
using System.Security;
using System.Security.Policy;
using System.Net;
 
 public class Sample
 {
  
   private const String filename = @"http://localhost/data/books.xml";
    
   public static void Main () {
   
       Stream s = (Stream) GetFile(filename, new XmlUrlResolver());
       XmlTextReader reader = new XmlTextReader(s);
       
   }
 
   // NOTE:  To test, replace www.contoso.com w/ the local string

   
//<snippet1>

   public static Object GetFile (String fileURL, XmlResolver resolver) {
    
     // Generate the default PermissionSet using the file URL.
     Evidence evidence = XmlSecureResolver.CreateEvidenceForUrl(fileURL);
     PermissionSet myPermissions = SecurityManager.ResolvePolicy(evidence);

     // Modify the PermissionSet to only allow access to http://www.contoso.com.
     // Create a WebPermission which only allows access to http://www.contoso.com.
     WebPermission myWebPermission = new WebPermission(NetworkAccess.Connect, "http://www.contoso.com");
     // Replace the existing WebPermission in myPermissions with the updated WebPermission.
     myPermissions.SetPermission(myWebPermission);

     // Use the modified PermissionSet to construct the XmlSecureResolver.
     XmlSecureResolver sResolver = new XmlSecureResolver(resolver, myPermissions);

     // Get the object.
     Uri fullUri = sResolver.ResolveUri(null, fileURL);
     return sResolver.GetEntity(fullUri, null, null);
   } 
//</snippet1> 
 
 }