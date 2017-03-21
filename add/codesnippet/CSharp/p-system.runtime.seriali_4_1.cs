    [DataContract]
    public class Employee
    {
        // The CLR default for as string is a null value.
        // This will be written as <employeeName xsi:nill="true" />
        [DataMember]
        public string EmployeeName = null;

        // This will be written as <employeeID>0</employeeID>
        [DataMember]
        public int employeeID = 0;

        // The next three will not be written because the EmitDefaultValue = false.
        [DataMember(EmitDefaultValue = false)]
        public string position = null;
        [DataMember(EmitDefaultValue = false)]
        public int salary = 0;
        [DataMember(EmitDefaultValue = false)]
        public int? bonus = null;

        // This will be written as <targetSalary>57800</targetSalary> 
        [DataMember(EmitDefaultValue = false)]
        public int targetSalary = 57800;
    }