   const int INT_SIZE = 4;
   array<Int32>^ arr = gcnew array<Int32> { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
   Buffer::BlockCopy(arr, 0 * INT_SIZE, arr, 3 * INT_SIZE, 4 * INT_SIZE);
   for each (int value in arr)
      Console::Write("{0}  ", value);
   // The example displays the following output:
   //       2  4  6  2  4  6  8  16  18  20