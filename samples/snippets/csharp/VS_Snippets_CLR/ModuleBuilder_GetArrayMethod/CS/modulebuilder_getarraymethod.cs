// System.Reflection.Emit.ModuleBuilder.GetArrayMethod
// System.Reflection.Emit.ModuleBuilder.GetArrayMethodToken
/*
The following example demonstrates 'GetArrayMethod' and 'GetArrayMethodToken'
methods of 'ModuleBuilder' class.
A dynamic assembly with a module having a runtime class, 'TempClass' is created. 
This class defines a method, 'SortArray', which sorts the elements of the array 
passed to it.The 'GetArrayMethod' method is used to obtain the 'MethodInfo' object 
corresponding to the 'Sort' method of the 'Array' .The token used to identify the 'Sort' 
method in dynamic module is displayed using 'GetArrayMethodToken' method.
*/
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;

   internal class CodeGenerator
   {
      AssemblyBuilder myAssemblyBuilder;
      internal CodeGenerator()
      {     
         AppDomain myCurrentDomain = AppDomain.CurrentDomain;
         AssemblyName myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "TempAssembly";
         // Define a dynamic assembly in the current application domain.
         myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly
                        (myAssemblyName, AssemblyBuilderAccess.RunAndSave);
// <Snippet1>
// <Snippet2>
         // Define a dynamic module in "TempAssembly" assembly.
         ModuleBuilder myModuleBuilder = myAssemblyBuilder.
                                       DefineDynamicModule("TempModule");
         // Define a runtime class with specified name and attributes.
         TypeBuilder myTypeBuilder = myModuleBuilder.DefineType
                                    ("TempClass",TypeAttributes.Public);
         Type[] paramArray = {typeof(Array)};
         // Add 'SortArray' method to the class, with the given signature.
         MethodBuilder myMethod = myTypeBuilder.DefineMethod("SortArray", 
                                   MethodAttributes.Public,typeof(Array),paramArray);

         Type[] myArrayClass = new Type[1];
         Type[] parameterTypes = {typeof(Array)};
         // Get the 'MethodInfo' object corresponding to 'Sort' method of 'Array' class.
         MethodInfo myMethodInfo=myModuleBuilder.GetArrayMethod(
                     myArrayClass.GetType(),"Sort",CallingConventions.Standard,
                                                                                  null,parameterTypes);
         // Get the token corresponding to 'Sort' method of 'Array' class.
         MethodToken myMethodToken=myModuleBuilder.GetArrayMethodToken(
                     myArrayClass.GetType(),"Sort",CallingConventions.Standard,
                                                                                 null,parameterTypes);
         Console.WriteLine("Token used by module to identify the 'Sort' method"
                                     + " of 'Array' class is : {0:x} ",myMethodToken.Token);

         ILGenerator methodIL = myMethod.GetILGenerator();
         methodIL.Emit(OpCodes.Ldarg_1);
         methodIL.Emit(OpCodes.Call,myMethodInfo);
         methodIL.Emit(OpCodes.Ldarg_1);
         methodIL.Emit(OpCodes.Ret);

         // Complete the creation of type.
         myTypeBuilder.CreateType();
// </Snippet1>
// </Snippet2>
      }
      public AssemblyBuilder MyBuilder
      {
         get
         {
            return this.myAssemblyBuilder;
         }
      }
   }

   public class TestClass
   {
      [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
      public static void Main()
      {
         CodeGenerator myCodeGenerator = new CodeGenerator();
         AssemblyBuilder myAssemblyBuilder = myCodeGenerator.MyBuilder;
         ModuleBuilder myModuleBuilder = myAssemblyBuilder.
                                                        GetDynamicModule("TempModule");
         Type myType = myModuleBuilder.GetType("TempClass");
         object myObject = Activator.CreateInstance(myType);
         MethodInfo sortArray = myType.GetMethod("SortArray");
         if (null != sortArray)
         {
            string[] arrayToSort = {"I","am","not","sorted"};
            Console.WriteLine("Array elements before sorting ");
            for(int i=0;i<arrayToSort.Length;i++)
            {
               Console.WriteLine("Array element {0} : {1} ",i,arrayToSort[i]);
            }
            object[] arguments = {arrayToSort};
            Console.WriteLine("Invoking our dynamically " 
                                     + "created SortArray method...");
            object myOutput=sortArray.Invoke(myObject, arguments);
            String[] mySortedArray=(String[])myOutput;
            Console.WriteLine("Array elements after sorting ");
            for(int i=0;i<mySortedArray.Length;i++)
            {
               Console.WriteLine("Array element {0} : {1} ",i,mySortedArray[i]);
            }
         }
      }
   }

