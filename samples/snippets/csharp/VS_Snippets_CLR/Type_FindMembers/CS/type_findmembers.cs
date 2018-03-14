// <Snippet1>
using System;
using System.Reflection;

class MyFindMembersClass
{
    public static void Main()
    {
        Object objTest = new Object();
        Type objType = objTest.GetType ();
        MemberInfo[] arrayMemberInfo;
        try
        {
            //Find all static or public methods in the Object class that match the specified name.
            arrayMemberInfo = objType.FindMembers(MemberTypes.Method,
                BindingFlags.Public | BindingFlags.Static| BindingFlags.Instance,
                new MemberFilter(DelegateToSearchCriteria),
                "ReferenceEquals");

            for(int index=0;index < arrayMemberInfo.Length ;index++)
                Console.WriteLine ("Result of FindMembers -\t"+ arrayMemberInfo[index].ToString() +"\n");                 
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception : " + e.ToString() );            
        }           
    }
    public static bool DelegateToSearchCriteria(MemberInfo objMemberInfo, Object objSearch)
    {
        // Compare the name of the member function with the filter criteria.
        if(objMemberInfo.Name.ToString() == objSearch.ToString())
            return true;
        else 
            return false;
    }
}
// </Snippet1>