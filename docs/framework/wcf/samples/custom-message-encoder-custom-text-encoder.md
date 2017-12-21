---
title: "Custom Message Encoder: Custom Text Encoder"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 68ff5c74-3d33-4b44-bcae-e1d2f5dea0de
caps.latest.revision: 28
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Message Encoder: Custom Text Encoder
This sample demonstrates how to implement a custom text message encoder using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)].  
  
> [!WARNING]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\MessageEncoder\Text`  
  
 The <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement> of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports only the UTF-8, UTF-16 and Big Endean Unicode encodings. The custom text message encoder in this sample supports all platform-supported character encoding that may be required for interoperability. The sample consists of a client console program (.exe), a service library (.dll) hosted by Internet Information Services (IIS) and a text message encoder library (.dll). The service implements a contract that defines a request-reply communication pattern. The contract is defined by the `ICalculator` interface, which exposes math operations (Add, Subtract, Multiply, and Divide). The client makes synchronous requests to a given math operation and the service replies with the result. Both client and service uses the `CustomTextMessageEncoder` instead of the default <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>.  
  
 The custom encoder implementation consists of a message encoder factory, a message encoder, a message encoding binding element and a configuration handler, and demonstrates the following:  
  
-   Building a custom encoder and encoder factory.  
  
-   Creating a binding element for a custom encoder.  
  
-   Using the custom binding configuration for integrating custom binding elements.  
  
-   Developing a custom configuration handler to allow file configuration of a custom binding element.  
  
### To set up, build, and run the sample  
  
1.  Install [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] 4.0 using the following command.  
  
    ```  
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable  
    ```  
  
2.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
3.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
4.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
## Message Encoder Factory and the Message Encoder  
 When the <xref:System.ServiceModel.ServiceHost> or the client channel is opened, the design time component `CustomTextMessageBindingElement` creates the `CustomTextMessageEncoderFactory`. The factory creates the `CustomTextMessageEncoder`. The message encoder operates both in the streaming mode and the buffered mode. It uses the <xref:System.Xml.XmlReader> and <xref:System.Xml.XmlWriter> to read and write the messages respectively. As opposed to the optimized XML readers and writers of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] that support only UTF-8, UTF-16 and Big-Endean Unicode these readers and writers support all platform supported encoding.  
  
 The following code example shows the CustomTextMessageEncoder.  
  
```csharp  
public class CustomTextMessageEncoder : MessageEncoder  
{  
    private CustomTextMessageEncoderFactory factory;  
    private XmlWriterSettings writerSettings;  
    private string contentType;  
  
    public CustomTextMessageEncoder(CustomTextMessageEncoderFactory factory)  
    {  
        this.factory = factory;  
  
        this.writerSettings = new XmlWriterSettings();  
        this.writerSettings.Encoding = Encoding.GetEncoding(factory.CharSet);  
        this.contentType = string.Format("{0}; charset={1}",   
            this.factory.MediaType, this.writerSettings.Encoding.HeaderName);  
    }  
  
    public override string ContentType  
    {  
        get  
        {  
            return this.contentType;  
        }  
    }  
  
    public override string MediaType  
    {  
        get   
        {  
            return factory.MediaType;  
        }  
    }  
  
    public override MessageVersion MessageVersion  
    {  
        get   
        {  
            return this.factory.MessageVersion;  
        }  
    }  
  
    public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)  
    {     
        byte[] msgContents = new byte[buffer.Count];  
        Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);  
        bufferManager.ReturnBuffer(buffer.Array);  
  
        MemoryStream stream = new MemoryStream(msgContents);  
        return ReadMessage(stream, int.MaxValue);  
    }  
  
    public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)  
    {  
        XmlReader reader = XmlReader.Create(stream);  
        return Message.CreateMessage(reader, maxSizeOfHeaders, this.MessageVersion);  
    }  
  
    public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)  
    {  
        MemoryStream stream = new MemoryStream();  
        XmlWriter writer = XmlWriter.Create(stream, this.writerSettings);  
        message.WriteMessage(writer);  
        writer.Close();  
  
        byte[] messageBytes = stream.GetBuffer();  
        int messageLength = (int)stream.Position;  
        stream.Close();  
  
        int totalLength = messageLength + messageOffset;  
        byte[] totalBytes = bufferManager.TakeBuffer(totalLength);  
        Array.Copy(messageBytes, 0, totalBytes, messageOffset, messageLength);  
  
        ArraySegment<byte> byteArray = new ArraySegment<byte>(totalBytes, messageOffset, messageLength);  
        return byteArray;  
    }  
  
    public override void WriteMessage(Message message, Stream stream)  
    {  
        XmlWriter writer = XmlWriter.Create(stream, this.writerSettings);  
        message.WriteMessage(writer);  
        writer.Close();  
    }  
}  
```  
  
 The following code example shows how to build the message encoder factory.  
  
```csharp  
public class CustomTextMessageEncoderFactory : MessageEncoderFactory  
{  
    private MessageEncoder encoder;  
    private MessageVersion version;  
    private string mediaType;  
    private string charSet;  
  
    internal CustomTextMessageEncoderFactory(string mediaType, string charSet,  
        MessageVersion version)  
    {  
        this.version = version;  
        this.mediaType = mediaType;  
        this.charSet = charSet;  
        this.encoder = new CustomTextMessageEncoder(this);  
    }  
  
    public override MessageEncoder Encoder  
    {  
        get   
        {   
            return this.encoder;  
        }  
    }  
  
    public override MessageVersion MessageVersion  
    {  
        get   
        {   
            return this.version;  
        }  
    }  
  
    internal string MediaType  
    {  
        get  
        {  
            return this.mediaType;  
        }  
    }  
  
    internal string CharSet  
    {  
        get  
        {  
            return this.charSet;  
        }  
    }  
}  
```  
  
## Message Encoding Binding Element  
 The binding elements allow the configuration of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] run-time stack. To use the custom message encoder in a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application, a binding element is required that creates the message encoder factory with the appropriate settings at the appropriate level in the run-time stack.  
  
 The `CustomTextMessageBindingElement` derives from the <xref:System.ServiceModel.Channels.BindingElement> base class and inherits from the <xref:System.ServiceModel.Channels.MessageEncodingBindingElement> class. This allows other [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] components to recognize this binding element as being a message encoding binding element. The implementation of <xref:System.ServiceModel.Channels.MessageEncodingBindingElement.CreateMessageEncoderFactory%2A> returns an instance of the matching message encoder factory with appropriate settings.  
  
 The `CustomTextMessageBindingElement` exposes settings for `MessageVersion`, `ContentType`, and `Encoding` through properties. The encoder supports both Soap11Addressing and Soap12Addressing1 versions. The default is Soap11Addressing1. The default value of the `ContentType` is "text/xml". The `Encoding` property allows you to set the value of the desired character encoding. The sample client and service uses the ISO-8859-1 (Latin1) character encoding, which is not supported by the <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement> of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 The following code shows how to programmatically create the binding using the custom text message encoder.  
  
```  
ICollection<BindingElement> bindingElements = new List<BindingElement>();  
HttpTransportBindingElement httpBindingElement = new HttpTransportBindingElement();  
CustomTextMessageBindingElement textBindingElement = new CustomTextMessageBindingElement();  
bindingElements.Add(textBindingElement);  
bindingElements.Add(httpBindingElement);  
CustomBinding binding = new CustomBinding(bindingElements);  
```  
  
## Adding Metadata Support to the Message Encoding Binding Element  
 Any type that derives from <xref:System.ServiceModel.Channels.MessageEncodingBindingElement> is responsible for updating the version of the SOAP binding in the WSDL document generated for the service. This is done by implementing the `ExportEndpoint` method on the <xref:System.ServiceModel.Description.IWsdlExportExtension> interface and then modifying the generated WSDL. In this sample, the `CustomTextMessageBindingElement` uses the WSDL export logic from the `TextMessageEncodingBinidngElement`.  
  
 For this sample, the client configuration is hand configured. You cannot use Svcutil.exe to generate the client configuration because the `CustomTextMessageBindingElement` does not export a policy assertion to describe its behavior. You should generally implement the <xref:System.ServiceModel.Description.IPolicyExportExtension> interface on a custom binding element to export a custom policy assertion that describes the behavior or capability implemented by the binding element. For an example of how to export a policy assertion for a custom binding element, see the [Transport: UDP](../../../../docs/framework/wcf/samples/transport-udp.md) sample.  
  
## Message Encoding Binding Configuration Handler  
 The previous section shows how to use the custom text message encoder programmatically. The `CustomTextMessageEncodingBindingSection` implements a configuration handler that allows you to specify the use of a custom text message encoder within a configuration file. The `CustomTextMessageEncodingBindingSection` class derives from the <xref:System.ServiceModel.Configuration.BindingElementExtensionElement> class. The `BindingElementType` property informs the configuration system of the type of binding element to create for this section.  
  
 All of the settings defined by `CustomTextMessageBindingElement` are exposed as the properties in the `CustomTextMessageEncodingBindingSection`. The <xref:System.Configuration.ConfigurationPropertyAttribute> assists in mapping the configuration element attributes to the properties and setting default values if the attribute is not set. After the values from configuration are loaded and applied to the properties of the type, the <xref:System.ServiceModel.Configuration.BindingElementExtensionElement.CreateBindingElement%2A> method is called, which converts the properties into a concrete instance of a binding element.  
  
 This configuration handler maps to the following representation in the App.config or Web.config for the service or client.  
  
```xml  
<customTextMessageEncoding encoding="utf-8" contentType="text/xml" messageVersion="Soap11Addressing1" />  
```  
  
 The sample uses the ISO-8859-1 encoding.  
  
 To use this configuration handler it must be registered using the following configuration element.  
  
```xml  
<extensions>  
    <bindingElementExtensions>  
        <add name="customTextMessageEncoding" type="   
Microsoft.ServiceModel.Samples.CustomTextMessageEncodingBindingSection,   
                  CustomTextMessageEncoder" />  
    </bindingElementExtensions>  
</extensions>  
```  
  
## See Also
