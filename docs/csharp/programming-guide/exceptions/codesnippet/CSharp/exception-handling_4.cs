        int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch(System.IndexOutOfRangeException e)
            {
                throw new System.ArgumentOutOfRangeException(
                    "Parameter index is out of range.", e);
            }
        }
