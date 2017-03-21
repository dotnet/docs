        // Delete or close the new subkey.
        Console.Write("\nDelete newly created registry key? (Y/N) ");
        if(Char.ToUpper(Convert.ToChar(Console.Read())) == 'Y')
        {
            Registry.CurrentUser.DeleteSubKeyTree("Test9999");
            Console.WriteLine("\nRegistry key {0} deleted.", 
                test9999.Name);
        }
        else
        {
            Console.WriteLine("\nRegistry key {0} closed.", 
                test9999.ToString());
            test9999.Close();
        }