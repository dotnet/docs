        Sub BeginSave() Implements ITrackingPersonalizable.BeginSave
            _saving = True
            _trackingLog += "3. BeginSave" + vbCr + vbLf

        End Sub 'ITrackingPersonalizable.BeginSave
