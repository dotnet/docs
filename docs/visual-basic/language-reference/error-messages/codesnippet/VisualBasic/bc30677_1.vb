        ' Assume that the class Wobject has an event named ThisEvent.
        Dim wObj As New Wobject
        ' Assume that this class has as method named ThisEventHandler.
        AddHandler wObj.ThisEvent, AddressOf Me.ThisEventHandler