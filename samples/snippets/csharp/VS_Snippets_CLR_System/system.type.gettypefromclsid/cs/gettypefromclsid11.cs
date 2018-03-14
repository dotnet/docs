// <Snippet11>
using System;
using System.Runtime.InteropServices;

[assembly:ComVisible(true)]

// Define two classes, and assign one an explicit GUID.
[GuidAttribute("d055cba3-1f83-4bd7-ba19-e22b1b8ec3c4")]
public class ExplicitGuid
{ }

public class NoExplicitGuid
{ }

public class Example
{
   public static void Main()
   {
      Type explicitType = typeof(ExplicitGuid);
      Guid explicitGuid = explicitType.GUID;
      
      // Get type of ExplicitGuid from its GUID.
      Type explicitCOM = Type.GetTypeFromCLSID(explicitGuid);
      Console.WriteLine("Created {0} type from CLSID {1}",
                        explicitCOM.Name, explicitGuid);
                        
      // Compare the two type objects.
      Console.WriteLine("{0} and {1} equal: {2}",
                        explicitType.Name, explicitCOM.Name,
                        explicitType.Equals(explicitCOM));                  
      
      // Instantiate an ExplicitGuid object.
      try {
         Object obj = Activator.CreateInstance(explicitCOM);
         Console.WriteLine("Instantiated a {0} object", obj.GetType().Name);
      } 
      catch (COMException e) {
         Console.WriteLine("COM Exception:\n{0}\n", e.Message);   
      } 
        
      Type notExplicit = typeof(NoExplicitGuid);
      Guid notExplicitGuid = notExplicit.GUID;
      
      // Get type of ExplicitGuid from its GUID.
      Type notExplicitCOM = Type.GetTypeFromCLSID(notExplicitGuid);
      Console.WriteLine("Created {0} type from CLSID {1}",
                        notExplicitCOM.Name, notExplicitGuid);
                        
      // Compare the two type objects.
      Console.WriteLine("{0} and {1} equal: {2}",
                        notExplicit.Name, notExplicitCOM.Name,
                        notExplicit.Equals(notExplicitCOM));                  
      
      // Instantiate an ExplicitGuid object.
      try {
         Object obj = Activator.CreateInstance(notExplicitCOM);
         Console.WriteLine("Instantiated a {0} object", obj.GetType().Name);
      } 
      catch (COMException e) {
         Console.WriteLine("COM Exception:\n{0}\n", e.Message);   
      }   
   }
}
// The example displays the following output:
//       Created __ComObject type from CLSID d055cba3-1f83-4bd7-ba19-e22b1b8ec3c4
//       ExplicitGuid and __ComObject equal: False
//       COM Exception:
//       Retrieving the COM class factory for component with CLSID 
//       {D055CBA3-1F83-4BD7-BA19-E22B1B8EC3C4} failed due to the following error: 
//       80040154 Class not registered 
//       (Exception from HRESULT: 0x80040154 (REGDB_E_CLASSNOTREG)).
//       
//       Created __ComObject type from CLSID 74f03346-a718-3516-ac78-f351c7459ffb
//       NoExplicitGuid and __ComObject equal: False
//       COM Exception:
//       Retrieving the COM class factory for component with CLSID 
//       {74F03346-A718-3516-AC78-F351C7459FFB} failed due to the following error: 
//       80040154 Class not registered 
//       (Exception from HRESULT: 0x80040154 (REGDB_E_CLASSNOTREG)).
// </Snippet11>
