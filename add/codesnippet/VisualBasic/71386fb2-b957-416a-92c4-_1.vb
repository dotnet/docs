   ' Initializes the provider.
    Public Overrides Sub Initialize(ByVal name As String, _
    ByVal config As NameValueCollection)
        MyBase.Initialize(name, config)

        ' Get the configuration information.
        providerName = name
        buffer = SampleUseBuffering.ToString()
        bufferModality = SampleBufferMode

        customInfo.AppendLine(String.Format( _
        "Provider name: {0}", providerName))
        customInfo.AppendLine(String.Format( _
        "Buffering: {0}", buffer))
        customInfo.AppendLine(String.Format( _
        "Buffering modality: {0}", bufferModality))
    End Sub 'Initialize
   