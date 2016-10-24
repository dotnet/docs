        static string GetValueFromArray(string[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index is out of range: {0}", index);
                throw;
            }
        }