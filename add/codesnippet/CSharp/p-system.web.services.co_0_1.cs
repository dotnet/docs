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