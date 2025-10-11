namespace ca1823
{
    //<snippet1>
    public class User
    {
        private readonly string _firstName;
        private readonly string _lastName;

        // CA1823: Unused field '_age'
        private readonly int _age;

        public User(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string GetFullName()
        {
            return $"My name is {_firstName} {_lastName}";
        }
    }
    //</snippet1>
}
