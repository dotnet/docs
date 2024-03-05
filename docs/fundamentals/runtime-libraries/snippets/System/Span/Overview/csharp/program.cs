class SpanSliceExample
{
	static void Main(string[] args)
	{
		// Create a 10-element integer array
		int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

		// Create a slice of the middle five elements
		Span<int> middleSlice = new Span<int>(numbers, 2, 5);

		// Double the values of each integer in the slice
		for (int i = 0; i < middleSlice.Length; i++)
		{
			middleSlice[i] *= 2;
		}

		// Print the original array
		Console.WriteLine("new array:");
		foreach (int number in numbers)
		{
			Console.Write(number + " ");
		}

		// Output: 
		//new array:
		// 1 2 6 8 10 12 14 8 9 10
	}
}
