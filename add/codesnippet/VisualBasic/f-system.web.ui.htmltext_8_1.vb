         ' Create a markup class constructor that uses the
         ' DefaultTabString property to establish indent settings
         ' for the writer.
         Public Sub New(writer As TextWriter)
             me.New(writer, DefaultTabString)
         End Sub