      ' Create the 'HttpAddressBinding' object.
      Dim postAddressBinding As New HttpAddressBinding()
      
      postAddressBinding.Location = "http://localhost/Service1.asmx"
      
      ' Add the 'HttpAddressBinding' to the 'Port'.
      postPort.Extensions.Add(postAddressBinding)