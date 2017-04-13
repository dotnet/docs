// <Snippet1>
using System;
using System.Xml;
using System.Reflection;

public class MyFindInterfacesSample 
{
    public static void Main()
    {
        try
        {
            XmlDocument myXMLDoc = new XmlDocument();
            myXMLDoc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" +
                "<title>Pride And Prejudice</title>" + "</book>");
            Type myType = myXMLDoc.GetType();

            // Specify the TypeFilter delegate that compares the 
            // interfaces against filter criteria.
            TypeFilter myFilter = new TypeFilter(MyInterfaceFilter);
            String[] myInterfaceList = new String[2] 
                {"System.Collections.IEnumerable", 
                "System.Collections.ICollection"};
            for(int index=0; index < myInterfaceList.Length; index++)
            {
                Type[] myInterfaces = myType.FindInterfaces(myFilter, 
                    myInterfaceList[index]);
                if (myInterfaces.Length > 0) 
                {
                    Console.WriteLine("\n{0} implements the interface {1}.",
                        myType, myInterfaceList[index]);	
                    for(int j =0;j < myInterfaces.Length;j++)
                        Console.WriteLine("Interfaces supported: {0}.", 
                            myInterfaces[j].ToString());
                }
                else
                    Console.WriteLine(
                        "\n{0} does not implement the interface {1}.", 
                        myType,myInterfaceList[index]);	
            }
        }
        catch(ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: " + e.Message);
        }
        catch(TargetInvocationException e)
        {
            Console.WriteLine("TargetInvocationException: " + e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
      
    public static bool MyInterfaceFilter(Type typeObj,Object criteriaObj)
    {
        if(typeObj.ToString() == criteriaObj.ToString())
            return true;
        else
            return false;
    }
}
// </Snippet1>