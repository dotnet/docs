public override void ProcessMessage(SoapMessage message) {
        switch (message.Stage) {

        case SoapMessageStage.BeforeSerialize:
            break;

        case SoapMessageStage.AfterSerialize:
            WriteOutput( message );
            break;

        case SoapMessageStage.BeforeDeserialize:
            WriteInput( message );
            break;

        case SoapMessageStage.AfterDeserialize:
            break;

        }
}
