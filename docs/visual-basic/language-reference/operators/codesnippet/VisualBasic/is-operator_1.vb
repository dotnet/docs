        Dim myObject As New Object
        Dim otherObject As New Object
        Dim yourObject, thisObject, thatObject As Object
        Dim myCheck As Boolean
        yourObject = myObject
        thisObject = myObject
        thatObject = otherObject
        ' The following statement sets myCheck to True.
        myCheck = yourObject Is thisObject
        ' The following statement sets myCheck to False.
        myCheck = thatObject Is thisObject
        ' The following statement sets myCheck to False.
        myCheck = myObject Is thatObject
        thatObject = myObject
        ' The following statement sets myCheck to True.
        myCheck = thisObject Is thatObject