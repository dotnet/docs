using System;


class Program
{
	static void Main(string[] args)
	{

		// C# does not support default parameters,
		// so there is no point in calling the method.
		// In fact, there is no easy way to run this 
		// sample without calling it from C++ or COM.
		// This sample mainly needs to demonstrate the  
		// syntax of applying the attribute to a C# 
		// parameter.

		//
		// DO NOT CONVERT THIS SAMPLE TO ANY OTHER LANGUAGE!!!!
		// VB and C++ support default parameters.
		// 


	}
	//<snippet1>
	static public void MethodWithDefaultParam([System.Runtime.InteropServices.DefaultParameterValue("DEFAULT_PARAM_VALUE")] string var)
	{
		Console.WriteLine("The passed value is: " + var);
	}
	//</snippet1>

}