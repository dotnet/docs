	static public void MethodWithDefaultParam([System.Runtime.InteropServices.DefaultParameterValue("DEFAULT_PARAM_VALUE")] string var)
	{
		Console.WriteLine("The passed value is: " + var);
	}