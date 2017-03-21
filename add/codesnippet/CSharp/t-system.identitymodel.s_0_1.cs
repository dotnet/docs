        public class MyCustomUserNameValidator : UserNamePasswordValidator
        {
            // This method validates users. It allows two users, test1 and test2 
            // with passwords 1tset and 2tset respectively.
            // This code is for illustration purposes only and 
            // MUST NOT be used in a production environment because it is NOT secure.	
            public override void Validate(string userName, string password)
            {
                if (null == userName || null == password)
                {
                    throw new ArgumentNullException();
                }

                if (!(userName == "test1" && password == "1tset") && !(userName == "test2" && password == "2tset"))
                {
                    throw new SecurityTokenException("Unknown Username or Password");
                }
            }
        }