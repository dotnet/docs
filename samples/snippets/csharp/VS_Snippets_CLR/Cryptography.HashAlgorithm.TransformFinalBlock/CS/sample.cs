// <Snippet1>
using System;
using System.Security.Cryptography;
using System.Text;

class MainClass
{
	public static void Main()
	{
		RandomNumberGenerator rnd = RandomNumberGenerator.Create();

		byte[] input = new byte[20];
		rnd.GetBytes(input);

		Console.WriteLine("Input        : {0}\n", BytesToStr(input));
		PrintHash(input);
		PrintHashOneBlock(input);
		PrintHashMultiBlock(input, 1);
		PrintHashMultiBlock(input, 2);
		PrintHashMultiBlock(input, 3);
		PrintHashMultiBlock(input, 5);
		PrintHashMultiBlock(input, 10);
		PrintHashMultiBlock(input, 11);
		PrintHashMultiBlock(input, 19);
		PrintHashMultiBlock(input, 20);
		PrintHashMultiBlock(input, 21);
	}

	public static string BytesToStr(byte[] bytes)
	{
		StringBuilder str = new StringBuilder();

		for (int i = 0; i < bytes.Length; i++)
			str.AppendFormat("{0:X2}", bytes[i]);

		return str.ToString();
	}

	public static void PrintHash(byte[] input)
	{
		SHA256Managed sha = new SHA256Managed();
		Console.WriteLine("ComputeHash  : {0}", BytesToStr(sha.ComputeHash(input)));
	}

	public static void PrintHashOneBlock(byte[] input)
	{
		SHA256Managed sha = new SHA256Managed();
		sha.TransformFinalBlock(input, 0, input.Length);
		Console.WriteLine("FinalBlock   : {0}", BytesToStr(sha.Hash));
	}

	public static void PrintHashMultiBlock(byte[] input, int size)
	{
		SHA256Managed sha = new SHA256Managed();
		int offset = 0;

		while (input.Length - offset >= size)
			offset += sha.TransformBlock(input, offset, size, input, offset);

		sha.TransformFinalBlock(input, offset, input.Length - offset);
		Console.WriteLine("MultiBlock {0:00}: {1}", size, BytesToStr(sha.Hash));
	}

}
// </Snippet1>