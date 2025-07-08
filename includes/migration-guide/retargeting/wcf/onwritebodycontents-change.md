### Writing binary output using BodyWriter

#### Details

If you're deriving from the class <xref:System.ServiceModel.Channels.BodyWriter?displayProperty=fullName> and using the implementation of `OnWriteBodyContents(XmlDictionaryWriter writer)` to write binary output, some changes may need to be made when you retarget to .NET Framework 4.5. Check the write state, and if it's `WriterState.Start`, emit the `Binary` wrapping XML element as shown in the following code snippet.

```csharp
protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
{
    bool wroteStartElement = false;
    if (writer.WriteState == WriteState.Start)
    {
        writer.WriteStartElement("Binary", string.Empty);
        wroteStartElement = true;
    }
    writer.WriteBase64(buffer, offset, count);
    if (wroteStartElement)
    {
        writer.WriteEndElement();
    }
}
```

In addition, if you're deriving from the class `System.ServiceModel.Channels.StreamBodyWriter` and have overridden the method `OnWriteBodyContents(XmlDictionaryWriter writer)`, some changes may be required. When targeting .NET Framework 4.0, it was necessary to explicitly write the `Binary` element when overriding this method. This is no longer needed when you target .NET Framework 4.5, and doing so causes the body to not be written.
