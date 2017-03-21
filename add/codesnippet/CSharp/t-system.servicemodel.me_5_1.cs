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