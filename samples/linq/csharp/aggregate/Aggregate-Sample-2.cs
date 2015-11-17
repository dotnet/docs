using System.Linq;
using System;

namespace Aggregate
{
	public static class AggregateSample2
	{
		//This sample uses Aggregate to create a running account balance that subtracts each 
		// withdrawal from the initial balance of 100, as long as the balance never drops below 0.
		//Output: 
		// Ending balance: 20
		public static void MethodSyntaxExample() 
		{ 
			double startBalance = 100.0; 

			int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 }; 

			double endBalance = 
				attemptedWithdrawals.Aggregate(startBalance, 
				(balance, nextWithdrawal) => 
				((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance)); 

			Console.WriteLine($"Ending balance: {endBalance}"); 
		 }
	}
}