// <Snippet1>
using System;
using System.IO;
using System.Reflection;
using System.Text;

public class Sample
{
    protected bool ShowMethods;
    protected StreamWriter myWriter;
 
    private void DumpMethods(Type aType)
    {
        if (!ShowMethods)
            return;
        MethodInfo[] mInfo = aType.GetMethods();
        myWriter.WriteLine("Methods"); 
        bool found = false;            
        if (mInfo.Length != 0)
        {
            for (int i=0; i < mInfo.Length; i++)
            {
                // Only display methods declared in this type. Also 
                // filter out any methods with special names, because these
                // cannot be generally called by the user. That is, their 
                // functionality is usually exposed in other ways, for example,
                // property get/set methods are exposed as properties.
                if (mInfo[i].DeclaringType == aType && !mInfo[i].IsSpecialName)
                {        
                    found = true;
                    StringBuilder modifiers = new StringBuilder();
                    if (mInfo[i].IsStatic)   {modifiers.Append("static ");}     
                    if (mInfo[i].IsPublic)   {modifiers.Append("public ");}     
                    if (mInfo[i].IsFamily)   {modifiers.Append("protected ");}     
                    if (mInfo[i].IsAssembly) {modifiers.Append("internal ");}     
                    if (mInfo[i].IsPrivate)  {modifiers.Append("private ");}     
                    myWriter.WriteLine("{0} {1}", modifiers, mInfo[i]);
                }
            }                      
        }                    
        if (!found)
        {
            myWriter.WriteLine("(none)");
        }
    }
}
// </Snippet1>

