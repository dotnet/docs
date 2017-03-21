        void ITrackingPersonalizable.BeginSave()
        {
            _saving = true;
            _trackingLog += "3. BeginSave\r\n";
        }