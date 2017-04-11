using System;
using System.Collections;
using System.Web.UI;


// Compile this same using the following command line:
//   csc /t:exe /out:objectstateformattertest.exe objectstateformattertest.cs
public class ObjectStateFormatterTest {

    public static void Main () {


    string SortDirection = "ASC";
    string SelectedColumn = "Employee";
    int CurrentPage = 1;

// <snippet1>

    ArrayList controlProperties = new ArrayList(3);

    controlProperties.Add( SortDirection );
    controlProperties.Add( SelectedColumn );
    controlProperties.Add( CurrentPage.ToString() );

    // Create an ObjectStateFormatter to serialize the ArrayList.
    ObjectStateFormatter formatter = new ObjectStateFormatter();

    // Call the Serialize method to serialize the ArrayList to a Base64 encoded string.
    string base64StateString = formatter.Serialize(controlProperties);
// </snippet1>
    }


// <snippet2>
    private ICollection LoadControlProperties (string serializedProperties) {

        ICollection controlProperties = null;

        // Create an ObjectStateFormatter to deserialize the properties.
        ObjectStateFormatter formatter = new ObjectStateFormatter();

        // Call the Deserialize method.
        controlProperties = (ArrayList) formatter.Deserialize(serializedProperties);

        return controlProperties;
    }
// </snippet2>

}
