            // Create the 'InputBinding' object for the 'SOAP' protocol.
            InputBinding myInput = new InputBinding();
            SoapBodyBinding mySoapBinding1 = new SoapBodyBinding();
            mySoapBinding1.PartsString = "parameters";
            mySoapBinding1.Use= SoapBindingUse.Literal;
            myInput.Extensions.Add(mySoapBinding1);
            // Assign the 'InputBinding' to 'OperationBinding'.
            myOperationBinding.Input = myInput;
            // Create the 'OutputBinding' object' for the 'SOAP' protocol..
            OutputBinding myOutput = new OutputBinding();
            myOutput.Extensions.Add(mySoapBinding1);
             // Assign the 'OutPutBinding' to 'OperationBinding'.
            myOperationBinding.Output = myOutput; 