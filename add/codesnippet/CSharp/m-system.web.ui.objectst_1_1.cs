        //
        // Persist any ViewState and ControlState.
        //
        public override void Save()
        {

            if (ViewState != null || ControlState != null)
            {
                if (Page.Session != null)
                {
                    Stream stateStream = GetSecureStream();

                    StreamWriter writer = new StreamWriter(stateStream);

                    IStateFormatter formatter = this.StateFormatter;
                    Pair statePair = new Pair(ViewState, ControlState);

                    // Serialize the statePair object to a string.
                    string serializedState = formatter.Serialize(statePair);

                    writer.Write(serializedState);
                    writer.Close();
                    stateStream.Close();
                }
                else
                    throw new InvalidOperationException("Session needed for StreamPageStatePersister.");
            }
        }