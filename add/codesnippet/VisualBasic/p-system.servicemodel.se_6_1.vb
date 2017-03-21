            Dim binding As New WSHttpBinding()
            binding.Security.Mode = SecurityMode.Message
            binding.Security.Message.AlgorithmSuite = _
            System.ServiceModel.Security.SecurityAlgorithmSuite.Basic256