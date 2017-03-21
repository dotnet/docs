                WSHttpBinding binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.Message;
                binding.Security.Message.AlgorithmSuite =
                    System.ServiceModel.Security.SecurityAlgorithmSuite.Basic256;