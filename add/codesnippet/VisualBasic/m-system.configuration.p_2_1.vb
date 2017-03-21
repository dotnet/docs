                ' Determine if the Validator can validate
                ' the type it contains.
                valBase = customValAttr.ValidatorInstance
                If valBase.CanValidate(resultTimeSpan.GetType()) Then
                    ' Validate the TimeSpan using a
                    ' custom PositiveTimeSpanValidator.
                    valBase.Validate(resultTimeSpan)
                End If