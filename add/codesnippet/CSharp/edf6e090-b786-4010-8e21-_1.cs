        NetTcpBinding portsharingBinding = new NetTcpBinding();
        hostDefault.AddServiceEndpoint(
      typeof(CalculatorService),
      portsharingBinding,
      "net.tcp://localhost/MyService");
