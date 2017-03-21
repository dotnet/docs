            SoapHeaderBinding mySoapHeaderBinding=new SoapHeaderBinding();
            // Set the Message within the XML Web service to which the 
            // 'SoapHeaderBinding' applies.
            mySoapHeaderBinding.Message=
                           new XmlQualifiedName("s0:HelloMyHeader");
            mySoapHeaderBinding.Part="MyHeader";
            mySoapHeaderBinding.Use=SoapBindingUse.Literal;
            // Add mySoapHeaderBinding to the 'myInputBinding' object. 
            myInputBinding.Extensions.Add(mySoapHeaderBinding);