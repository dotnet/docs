       
        Class CredentialInfo
            Public uriObj As Uri
            Public authenticationType As [String]
            Public networkCredentialObj As NetworkCredential
            
            
            Public Sub New(uriObj As Uri, authenticationType As [String], networkCredentialObj As NetworkCredential)
                Me.uriObj = uriObj
                Me.authenticationType = authenticationType
                Me.networkCredentialObj = networkCredentialObj
            End Sub 'New
        End Class 'CredentialInfo
        
        Private arrayListObj As ArrayList
        
        
        Public Sub New()
            arrayListObj = New ArrayList()
        End Sub 'New
        
        
        Public Sub Add(uriObj As Uri, authenticationType As [String], credential As NetworkCredential)
            ' adds a 'CredentialInfo' object into a list
            arrayListObj.Add(New CredentialInfo(uriObj, authenticationType, credential))
        End Sub 'Add
        
        ' Remove the 'CredentialInfo' object from the list which matches to the given 'Uri' and 'AuthenticationType'
        Public Sub Remove(uriObj As Uri, authenticationType As [String])
            Dim index As Integer
            For index = 0 To arrayListObj.Count - 1
                Dim credentialInfo As CredentialInfo = CType(arrayListObj(index), CredentialInfo)
                If uriObj.Equals(credentialInfo.uriObj) And authenticationType.Equals(credentialInfo.authenticationType) Then
                    arrayListObj.RemoveAt(index)
                End If
            Next index
        End Sub 'Remove
        
        Public Function GetCredential(uriObj As Uri, authenticationType As [String]) As NetworkCredential  Implements ICredentials.GetCredential
            Dim index As Integer
            For index = 0 To arrayListObj.Count - 1
                Dim credentialInfoObj As CredentialInfo = CType(arrayListObj(index), CredentialInfo)
                If uriObj.Equals(credentialInfoObj.uriObj) And authenticationType.Equals(credentialInfoObj.authenticationType) Then
                    Return credentialInfoObj.networkCredentialObj
                End If
            Next index
            Return Nothing
        End Function 'GetCredential