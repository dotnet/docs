using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Snippets
{
    //<snippet0>
    [MessageContractAttribute] 
    public class CustomMessage 
    { 
        private Person internalPerson; 
        [MessageProperty] 
        private int a = 23; 
        [MessageBodyMember(Name="Person")] 
        public PersonType Data 
        { 
            get 
            { 
                return internalPerson; 
            } 
            set
            { 
                this.internalPerson = (Person)value; 
            } 
        } 
    }
    //</snippet0>
    public class Person : PersonType
    {
    };
    public class PersonType
    {
    };
    
}
