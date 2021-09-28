﻿
using System;
// <Snippet1>
using System.Configuration;

class Program
{
    static void Main()
    {
        GetConnectionStrings();
        Console.ReadLine();
    }

    static void GetConnectionStrings()
    {
        ConnectionStringSettingsCollection settings =
            ConfigurationManager.ConnectionStrings;

        if (settings != null)
        {
            foreach(ConnectionStringSettings cs in settings)
            {
                Console.WriteLine(cs.Name);
                Console.WriteLine(cs.ProviderName);
                Console.WriteLine(cs.ConnectionString);
            }
        }
    }
}
// </Snippet1>
