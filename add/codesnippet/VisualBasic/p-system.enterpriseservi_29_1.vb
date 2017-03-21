            ' Check whether the ErrorInfo property of the RegistrationException object is null. 
            ' If there is no extended error information about 
            ' methods related to multiple COM+ objects ErrorInfo will be null.
            If Not (e.ErrorInfo Is Nothing) Then
                ' Gets an array of RegistrationErrorInfo objects describing registration errors
                Dim registrationErrorInfos As RegistrationErrorInfo() = e.ErrorInfo

                ' Iterate through the array of RegistrationErrorInfo objects and disply the 
                ' ErrorString for each object.
                Dim registrationErrorInfo As RegistrationErrorInfo
                For Each registrationErrorInfo In registrationErrorInfos
                    MsgBox(registrationErrorInfo.ErrorString)
                Next registrationErrorInfo
            End If