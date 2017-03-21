int Loop1;
String[] StateVars = new String[Application.Count];
 
for (Loop1 = 0; Loop1 < Application.Count; Loop1++)
{
   StateVars[Loop1] = Application.GetKey(Loop1);
}   