    ' Demonstrates SetData, ContainsData, and GetData.
    Public Function SwapClipboardFormattedData( _
        ByVal format As String, ByVal data As Object) As Object

        Dim returnObject As Object = Nothing

        If (Clipboard.ContainsData(format)) Then
            returnObject = Clipboard.GetData(format)
            Clipboard.SetData(format, data)
        End If

        Return returnObject

    End Function