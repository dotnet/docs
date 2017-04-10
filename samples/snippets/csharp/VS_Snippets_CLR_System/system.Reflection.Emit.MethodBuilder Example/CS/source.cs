// <Snippet1>

using System;
using System.Reflection;
using System.Reflection.Emit;

class DemoMethodBuilder 
{
    public static void AddMethodDynamically (TypeBuilder myTypeBld,
                                             string mthdName,
                                             Type[] mthdParams, 
                                             Type returnType,
                                             string mthdAction) 
    {
    
        MethodBuilder myMthdBld = myTypeBld.DefineMethod(
                                             mthdName,
                                             MethodAttributes.Public |
                                             MethodAttributes.Static,
                                             returnType,
                                             mthdParams);        

        ILGenerator ILout = myMthdBld.GetILGenerator();
        
        int numParams = mthdParams.Length;

        for (byte x=0; x < numParams; x++) 
        {
            ILout.Emit(OpCodes.Ldarg_S, x);
        }

        if (numParams > 1) 
        {
            for (int y=0; y<(numParams-1); y++) 
            {
                switch (mthdAction) 
                {
                    case "A": ILout.Emit(OpCodes.Add);
                              break;
                    case "M": ILout.Emit(OpCodes.Mul);
                              break;
                    default: ILout.Emit(OpCodes.Add);
                              break;
                }
            }
        }
        ILout.Emit(OpCodes.Ret);
    }

    public static void Main()
    {
        AppDomain myDomain = AppDomain.CurrentDomain;
        AssemblyName asmName = new AssemblyName();
        asmName.Name = "MyDynamicAsm";
        
        AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
                                       asmName, 
                                       AssemblyBuilderAccess.RunAndSave);

        ModuleBuilder myModule = myAsmBuilder.DefineDynamicModule("MyDynamicAsm",
                                                                  "MyDynamicAsm.dll");

        TypeBuilder myTypeBld = myModule.DefineType("MyDynamicType",
                                                    TypeAttributes.Public);           

        // Get info from the user to build the method dynamically.
        Console.WriteLine("Let's build a simple method dynamically!");
        Console.WriteLine("Please enter a few numbers, separated by spaces.");
        string inputNums = Console.ReadLine();
        Console.Write("Do you want to [A]dd (default) or [M]ultiply these numbers? ");
        string myMthdAction = Console.ReadLine().ToUpper();
        Console.Write("Lastly, what do you want to name your new dynamic method? ");
        string myMthdName = Console.ReadLine();
        
        // Process inputNums into an array and create a corresponding Type array 
        int index = 0;
        string[] inputNumsList = inputNums.Split();

        Type[] myMthdParams = new Type[inputNumsList.Length];
        object[] inputValsList = new object[inputNumsList.Length];
           
       
        foreach (string inputNum in inputNumsList) 
        {
            inputValsList[index] = (object)Convert.ToInt32(inputNum);
                myMthdParams[index] = typeof(int);
                index++;
        } 

        // Now, call the method building method with the parameters, passing the 
        // TypeBuilder by reference.
        AddMethodDynamically(myTypeBld,
                             myMthdName,
                             myMthdParams,
                             typeof(int),        
                             myMthdAction);

        Type myType = myTypeBld.CreateType();

        Console.WriteLine("---");
        Console.WriteLine("The result of {0} the inputted values is: {1}",
                          ((myMthdAction == "M") ? "multiplying" : "adding"),
                          myType.InvokeMember(myMthdName,
                          BindingFlags.InvokeMethod | BindingFlags.Public |
                          BindingFlags.Static,
                          null,
                          null,
                          inputValsList));
        Console.WriteLine("---");

        // Let's take a look at the method we created.
        // If you are interested in seeing the MSIL generated dynamically for the method
        // your program generated, change to the directory where you ran the compiled
        // code sample and type "ildasm MyDynamicAsm.dll" at the prompt. When the list
        // of manifest contents appears, click on "MyDynamicType" and then on the name of
        // of the method you provided during execution.

        myAsmBuilder.Save("MyDynamicAsm.dll");

        MethodInfo myMthdInfo = myType.GetMethod(myMthdName);
        Console.WriteLine("Your Dynamic Method: {0};", myMthdInfo.ToString());    
    }
}
// </Snippet1>
