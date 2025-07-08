using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Security.Policy;
using System.Security;
using System.Security.Permissions;
using System.Net;
using System.Reflection;

class XmlSecureResolver_Samples
{
    static void Main()
    {
    }

    public void Assembly_Evidence()
    {
        //<snippet1>
        Evidence myEvidence = this.GetType().Assembly.Evidence;
        XmlSecureResolver myResolver;
        myResolver = new XmlSecureResolver(new XmlUrlResolver(), myEvidence);
        //</snippet1>
    }

    //==============================
    //
    static void URI_Evidence()
    {
        string sourceURI = "http://serverName/data";
        //<snippet2>

        Evidence myEvidence = XmlSecureResolver.CreateEvidenceForUrl(sourceURI);
        XmlSecureResolver myResolver = new XmlSecureResolver(new XmlUrlResolver(), myEvidence);
        //</snippet2>
    }
    //==============================
    //
    static void Use_URL()
    {
        //<snippet3>
        XmlSecureResolver myResolver = new XmlSecureResolver(new XmlUrlResolver(), "http://myLocalSite/");
        //</snippet3>
    }

    //==============================
    //
    static void Use_PermissionSet()
    {
        //<snippet4a>
        WebPermission myWebPermission = new WebPermission(PermissionState.None);
        //</snippet4a>
        //<snippet4b>
        myWebPermission.AddPermission(NetworkAccess.Connect, "http://www.contoso.com/");
        myWebPermission.AddPermission(NetworkAccess.Connect, "http://litwareinc.com/data/");
        //</snippet4b>
        //<snippet4c>
        PermissionSet myPermissions = new PermissionSet(PermissionState.None);
        myPermissions.AddPermission(myWebPermission);
        //</snippet4c>
        //<snippet4d>
        XmlSecureResolver myResolver = new XmlSecureResolver(new XmlUrlResolver(), myPermissions);
        //</snippet4d>
    }

    //==============================
    //
    static void Reader_Resolver()
    {
        XmlSecureResolver myResolver = new XmlSecureResolver(new XmlUrlResolver(), "http://myLocalSite/");
        //<snippet5a>
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.XmlResolver = myResolver;
        //</snippet5a>
        //<snippet5b>
        XmlReader reader = XmlReader.Create("books.xml", settings);
        //</snippet5b>
    }

    //==============================
    //
    static void XSLT_Resolver()
    {
        XmlSecureResolver myResolver = new XmlSecureResolver(new XmlUrlResolver(), "http://myLocalSite/");
        //<snippet6>
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("http://serverName/data/xsl/sort.xsl", null, myResolver);
        //</snippet6>
    }
}
