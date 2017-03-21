            // Create a SurrogateSelector.
            SurrogateSelector ss = new SurrogateSelector();

            // Tell the SurrogateSelector that Employee objects are serialized and deserialized 
            // using the EmployeeSerializationSurrogate object.
            ss.AddSurrogate(typeof(Employee),
            new StreamingContext(StreamingContextStates.All),
            new EmployeeSerializationSurrogate());