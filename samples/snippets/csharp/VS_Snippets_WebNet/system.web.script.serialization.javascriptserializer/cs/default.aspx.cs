// <snippet1>
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace ExampleApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var RegisteredUsers = new List<Person>();
            RegisteredUsers.Add(new Person() { PersonID = 1, Name = "Bryon Hetrick", Registered = true });
            RegisteredUsers.Add(new Person() { PersonID = 2, Name = "Nicole Wilcox", Registered = true });
            RegisteredUsers.Add(new Person() { PersonID = 3, Name = "Adrian Martinson", Registered = false });
            RegisteredUsers.Add(new Person() { PersonID = 4, Name = "Nora Osborn", Registered = false });

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(RegisteredUsers);
            // Produces string value of:
            // [
            //     {"PersonID":1,"Name":"Bryon Hetrick","Registered":true},
            //     {"PersonID":2,"Name":"Nicole Wilcox","Registered":true},
            //     {"PersonID":3,"Name":"Adrian Martinson","Registered":false},
            //     {"PersonID":4,"Name":"Nora Osborn","Registered":false}
            // ]

            var deserializedResult = serializer.Deserialize<List<Person>>(serializedResult);
            // Produces List with 4 Person objects
        }
    }
}
// </snippet1>    