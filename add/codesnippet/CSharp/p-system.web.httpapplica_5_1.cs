
HttpApplicationState AppState2;
 
AppState2 = Application.Contents;
 
String[] StateVars = new String[AppState2.Count];
StateVars = AppState2.AllKeys;
