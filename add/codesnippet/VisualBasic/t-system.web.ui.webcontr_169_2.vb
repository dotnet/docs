    ' A transformer that transforms a row to a string.
    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    <WebPartTransformer(GetType(IWebPartRow), GetType(IString))> _
    Public Class RowToStringTransformer
        Inherits WebPartTransformer
        Implements IString

        Private _provider As IWebPartRow
        Private _callback As StringCallback

        Private Sub GetRowData(ByVal rowData As Object)
            Dim props As PropertyDescriptorCollection = _provider.Schema

            If ((Not (props Is Nothing)) AndAlso (props.Count > 0) _
              AndAlso (Not (rowData Is Nothing))) Then
                Dim returnValue As String = String.Empty
                For Each prop As PropertyDescriptor In props
                    If Not (prop Is props(0)) Then
                        returnValue += ", "
                    End If
                    returnValue += prop.DisplayName.ToString() + ": " + _
                        prop.GetValue(rowData).ToString()
                Next
                _callback(returnValue)
            Else
                _callback(Nothing)
            End If
        End Sub

        Public Overrides Function Transform(ByVal providerData As Object) As Object
            _provider = CType(providerData, IWebPartRow)
            Return Me
        End Function


        Sub GetStringValue(ByVal callback As StringCallback) _
           Implements IString.GetStringValue
            If (callback Is Nothing) Then
                Throw New ArgumentNullException("callback")
            End If

            If (Not (_provider Is Nothing)) Then
                _callback = callback
                _provider.GetRowData(New RowCallback(AddressOf GetRowData))
            Else
                callback(Nothing)
            End If
        End Sub
    End Class