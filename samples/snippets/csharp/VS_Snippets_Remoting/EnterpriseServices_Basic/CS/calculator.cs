// <snippet1>
using System;
using System.EnterpriseServices;

[assembly: ApplicationName("Calculator")]
[assembly: ApplicationActivation(ActivationOption.Library)]
[assembly: System.Reflection.AssemblyKeyFile("Calculator.snk")]
public class Calculator : ServicedComponent
{
    public int Add (int x, int y)
    {
        return(x+y);
    }
}
// </snippet1>
