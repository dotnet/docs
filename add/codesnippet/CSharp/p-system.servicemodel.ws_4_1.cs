            WSDualHttpBinding binding3 = new WSDualHttpBinding();
            binding3.Security.Mode = WSDualHttpSecurityMode.None;
            binding3.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256;
            binding3.MessageEncoding = WSMessageEncoding.Mtom;