//<Snippet1>
using System;
using System.Security.Permissions;
using System.CodeDom;
using System.IO;
using System.Text;
using System.Web.Services.Configuration;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;


// The YMLAttribute allows a developer to specify that the YML SOAP
// extension run on a per-method basis.  The Disabled property
// turns reversing the XML on and off. 

[AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
public class YMLAttribute : SoapExtensionAttribute {
    int priority = 0;
    bool disabled = false;
    
    public YMLAttribute() : this(false) {}
    public YMLAttribute(bool disabled) 
    {
        this.disabled = disabled;
    }
    
    public override Type ExtensionType 
    {
        get { return typeof(YMLExtension); }
    }
    public override int Priority 
    {
        get { return priority; }
        set { priority = value; }
    }

    public bool Disabled 
    { 
        get { return disabled; }
        set { disabled = value; }
    }
}

public class YMLExtension : SoapExtension {
    bool disabled = false;
    Stream oldStream;
    Stream newStream;

    public override object GetInitializer(LogicalMethodInfo methodInfo, 
        SoapExtensionAttribute attribute) 
    {
        YMLAttribute attr = attribute as YMLAttribute;
        if (attr != null) return attr.Disabled;
        return false;
    }

    public override object GetInitializer(Type serviceType) 
    {
        return false;
    }

    public override void Initialize(object initializer) 
    {
        if (initializer is Boolean) disabled = (bool)initializer;
    }

    public override Stream ChainStream(Stream stream) 
    {
        if (disabled) return base.ChainStream(stream);
        oldStream = stream;
        newStream = new MemoryStream();
        return newStream;
    }

    public override void ProcessMessage(SoapMessage message) 
    {
        if (disabled) return;
        switch (message.Stage) 
        {
        case SoapMessageStage.BeforeSerialize:
            Encode(message);
            break;
        case SoapMessageStage.AfterSerialize:
            newStream.Position = 0;
            Reverse(newStream, oldStream);
            break;
        case SoapMessageStage.BeforeDeserialize:
            Decode(message);
            break;
        case SoapMessageStage.AfterDeserialize:
            break;
        }
    }        

    void Encode(SoapMessage message) 
    {
        message.ContentType = "text/yml";
    }

    void Decode(SoapMessage message) 
    {
        if (message.ContentType != "text/yml") 
            throw new Exception(
                "invalid content type:" + message.ContentType);
        Reverse(oldStream, newStream);
        newStream.Position = 0;
        message.ContentType = "text/xml";
    }

    void Reverse(Stream from, Stream to) 
    {
        TextReader reader = new StreamReader(from);
        TextWriter writer = new StreamWriter(to);
        string line;
        while ((line = reader.ReadLine()) != null) 
        {
            StringBuilder builder = new StringBuilder();
            for (int i = line.Length - 1; i >= 0; i--) 
            {
                builder.Append(line[i]);
            }
            writer.WriteLine(builder.ToString());
        }
        writer.Flush();
    }
}
// The YMLReflector class is part of the YML SDFE, as it is
// called during the service description generation process.
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class YMLReflector : SoapExtensionReflector 
{
    public override void ReflectMethod() 
    {
        ProtocolReflector reflector = ReflectionContext;
        YMLAttribute attr = 
            (YMLAttribute)reflector.Method.GetCustomAttribute(
            typeof(YMLAttribute));
        // If the YMLAttribute has been applied to this XML Web service 
        // method, add the XML defined in the YMLOperationBinding class.
        if (attr != null) 
        {
            YMLOperationBinding yml = new YMLOperationBinding();
            yml.Reverse = !(attr.Disabled);
            reflector.OperationBinding.Extensions.Add(yml);
        }
    }
}



// The YMLImporter class is part of the YML SDFE, as it is called when a
// proxy class is generated for each XML Web service method the proxy class
// communicates with. The class checks whether the service description
// contains the XML that this SDFE adds to a service description. If it 
// exists, then the YMLExtension is applied to the method in the proxy class.
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class YMLImporter : SoapExtensionImporter 
{
    public override void ImportMethod(
        CodeAttributeDeclarationCollection metadata) 
    {
        SoapProtocolImporter importer = ImportContext;
        // Check whether the XML specified in the YMLOperationBinding 
        // is in the service description.
        YMLOperationBinding yml = 
           (YMLOperationBinding)importer.OperationBinding.Extensions.Find(
           typeof(YMLOperationBinding));
        if (yml != null)
        {
            // Only apply the YMLAttribute to the method when the XML should
            // be reversed.
            if (yml.Reverse)
            {
                CodeAttributeDeclaration attr = 
                    new CodeAttributeDeclaration(typeof(YMLAttribute).FullName);
                attr.Arguments.Add(
                    new CodeAttributeArgument(new CodePrimitiveExpression(true)));
                metadata.Add(attr);
            }
        }
    }
}

//<Snippet2>
// The YMLOperationBinding class is part of the YML SDFE, as it is the
// class that is serialized into XML and is placed in the service
// description.
[XmlFormatExtension("action", YMLOperationBinding.YMLNamespace, 
    typeof(OperationBinding))]
[XmlFormatExtensionPrefix("yml", YMLOperationBinding.YMLNamespace)]
public class YMLOperationBinding : ServiceDescriptionFormatExtension 
{
    private Boolean reverse;

    public const string YMLNamespace = "http://www.contoso.com/yml";

    [XmlElement("Reverse")]
    public Boolean Reverse 
    {
        get { return reverse; }
        set { reverse = value; }
    }
}
//</Snippet2>
//</Snippet1>
