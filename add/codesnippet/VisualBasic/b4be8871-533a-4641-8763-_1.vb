      ChannelServices.RegisterChannel(New HttpChannel())

      Dim objectSample As SampleService = CType(Activator.GetObject(GetType(SampleService), _ 
            "http://localhost:9000/MySampleService/SampleService.soap"), SampleService)

      ' The GetManuallyMarshaledObject() method uses RemotingServices.Marshal()
      ' to create an ObjRef object for a SampleTwo object.
      Dim objRefSampleTwo As ObjRef = objectSample.GetManuallyMarshaledObject()

      Dim objectSampleTwo As SampleTwo = CType(RemotingServices.Unmarshal(objRefSampleTwo), SampleTwo)

      objectSampleTwo.PrintMessage("I successfully unmarshaled your ObjRef.  Thanks.")