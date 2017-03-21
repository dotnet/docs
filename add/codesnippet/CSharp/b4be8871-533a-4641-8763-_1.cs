        ChannelServices.RegisterChannel(new HttpChannel());

        SampleService objectSample = (SampleService)Activator.GetObject(typeof(SampleService), 
            "http://localhost:9000/MySampleService/SampleService.soap");

        // The GetManuallyMarshaledObject() method uses RemotingServices.Marshal()
        // to create an ObjRef object for a SampleTwo object.
        ObjRef objRefSampleTwo = objectSample.GetManuallyMarshaledObject();

        SampleTwo objectSampleTwo = (SampleTwo)RemotingServices.Unmarshal(objRefSampleTwo);

        objectSampleTwo.PrintMessage("ObjRef successfuly unmarshaled."); 