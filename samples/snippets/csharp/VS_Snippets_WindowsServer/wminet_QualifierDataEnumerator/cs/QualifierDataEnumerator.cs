//<Snippet1>
using System; 
using System.Management;
 
// This sample demonstrates how to 
// enumerate qualifiers of a ManagementClass 
// using QualifierDataEnumerator object.
class Sample_QualifierDataEnumerator 
{ 
    public static int Main(string[] args) 
    { 
        ManagementClass diskClass = 
            new ManagementClass("Win32_LogicalDisk"); 
        diskClass.Options.UseAmendedQualifiers = true; 
        QualifierDataCollection diskQualifier = 
            diskClass.Qualifiers;
        QualifierDataCollection.QualifierDataEnumerator 
            qualifierEnumerator = 
            diskQualifier.GetEnumerator();
        while(qualifierEnumerator.MoveNext()) 
        {
            Console.WriteLine(
                qualifierEnumerator.Current.Name + " = " +
                qualifierEnumerator.Current.Value);
        }
        return 0;
    }
}
//</Snippet1>