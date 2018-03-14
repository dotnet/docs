// <Snippet1>
using System;
using System.Reflection;

public class FieldInfo_GetFieldFromHandle
{
    public string x;
    public char y;
    public float a;
    public int b;

    public static void Main()
    {
        // Get the type of the FieldInfo_GetFieldFromHandle class.
        Type myType = typeof(FieldInfo_GetFieldFromHandle);
        // Get the fields of the FieldInfo_GetFieldFromHandle class.
        FieldInfo [] myFieldInfoArray = myType.GetFields();
        Console.WriteLine("\nThe field information of the declared" +
            " fields x, y, a, and b is:\n");
        RuntimeFieldHandle myRuntimeFieldHandle;
        for(int i = 0; i < myFieldInfoArray.Length; i++)
        {
            // Get the RuntimeFieldHandle of myFieldInfoArray.
            myRuntimeFieldHandle = myFieldInfoArray[i].FieldHandle;
            // Call the GetFieldFromHandle method. 
            FieldInfo myFieldInfo = FieldInfo.GetFieldFromHandle(myRuntimeFieldHandle);
            // Display the FieldInfo of myFieldInfo.
            Console.WriteLine("{0}", myFieldInfo);
        }
    }
}
// </Snippet1>
