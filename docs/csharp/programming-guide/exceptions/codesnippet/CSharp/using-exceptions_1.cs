
        class CustomException : Exception
        {
            public CustomException(string message)
            {
               
            }
 
        }
        private static void TestThrow()
        {
            CustomException ex =
                new CustomException("Custom exception in TestThrow()");

            throw ex;
        }