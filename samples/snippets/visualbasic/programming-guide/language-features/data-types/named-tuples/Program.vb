
Module Program
    Sub Main()
       CallExplicitlyNamed()
       Console.WriteLine()
       CallImplicitlyNamed()
    End Sub

    Private Sub CallExplicitlyNamed()
        ' <Snippet1>
        Dim state = "MI"
	    Dim stateName = "Michigan"
	    Dim capital = "Lansing"
        Dim stateInfo = ( state:=state, stateName:=stateName, capital:=capital )
        Console.WriteLine($"{stateInfo.stateName}: 2-letter code: {stateInfo.State}, Capital {stateInfo.capital}")   
        ' The example displays the following output:
        '      Michigan: 2-letter code: MI, Capital Lansing
        ' </Snippet1>
    End Sub

    Private Sub CallImplicitlyNamed()
        ' <Snippet2>
        Dim state = "MI"
	    Dim stateName = "Michigan"
	    Dim capital = "Lansing"
        Dim stateInfo = ( state, stateName, capital )
        Console.WriteLine($"{stateInfo.stateName}: 2-letter code: {stateInfo.State}, Capital {stateInfo.capital}")   
        ' The example displays the following output:
        '      Michigan: 2-letter code: MI, Capital Lansing
        ' </Snippet2>
    End Sub
End Module

