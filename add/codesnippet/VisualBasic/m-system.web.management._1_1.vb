    ' Raises the SampleWebBaseEvent.
    Public Overrides Sub Raise()
        ' Perform custom processing. 
        customRaisedMsg = String.Format( _
        "Event raised at: {0}", DateTime.Now.TimeOfDay.ToString())

        ' Raise the event.
        MyBase.Raise()

    End Sub 'Raise
