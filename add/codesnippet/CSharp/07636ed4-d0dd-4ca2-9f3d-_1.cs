        // securityMode is Message
        // reliableSessionEnabled is true
        WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message, true);
        binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;