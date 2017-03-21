ref class Person;
ref class Job;
ref class Group
{
public:
   array<Person^>^Staff;
};


[XmlType(TypeName="Employee",
Namespace="http://www.cpandl.com")]
public ref class Person
{
public:
   String^ PersonName;
   Job^ Position;
};


[XmlType(TypeName="Occupation",
Namespace="http://www.cohowinery.com")]
public ref class Job
{
public:
   String^ JobName;
};
