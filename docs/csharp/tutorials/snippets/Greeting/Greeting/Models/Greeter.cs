using System;
using Greeting.Contracts;

namespace Greeting.Models
{
	public class Greeter : IGreet
	{
        public string GetGreeting(int hour)
        {
            return hour switch
            {
                >= 5 and <= 11 => "Good morning!",
                >= 12 and <= 17 => "Good afternoon!",
                >= 18 and <= 22 => "Good evening!",
                _ => "Good night!"

            };
        }
    }
}

