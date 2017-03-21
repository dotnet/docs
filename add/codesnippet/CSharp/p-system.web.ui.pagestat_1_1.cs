        //
        // Load ViewState and ControlState.
        //
        public override void Load()
        {
            Stream stateStream = GetSecureStream();

            // Read the state string, using the StateFormatter.
            StreamReader reader = new StreamReader(stateStream);

            IStateFormatter formatter = this.StateFormatter;
            string fileContents = reader.ReadToEnd();

            // Deserilize returns the Pair object that is serialized in
            // the Save method.
            Pair statePair = (Pair)formatter.Deserialize(fileContents);

            ViewState = statePair.First;
            ControlState = statePair.Second;
            reader.Close();
            stateStream.Close();
        }