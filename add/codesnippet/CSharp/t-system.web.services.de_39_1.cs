
               // Create the 'HttpAddressBinding' object.
               HttpAddressBinding postAddressBinding = new HttpAddressBinding();

               postAddressBinding.Location = "http://localhost/Service1.asmx";

               // Add the 'HttpAddressBinding' to the 'Port'.
               postPort.Extensions.Add(postAddressBinding);