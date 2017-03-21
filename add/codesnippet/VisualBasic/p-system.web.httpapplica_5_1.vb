Dim AppState2 As HttpApplicationState
 
AppState2 = Application.Contents
 
Dim StateVars(AppState2.Count) As String
StateVars = AppState2.AllKeys
