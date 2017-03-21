        for (int i = 0; i < 3; i++)
        {
            try
            {
                LargeObject large = lazyLargeObject.Value;
                large.Data[11] = 89;
            }
            catch (ApplicationException aex)
            {
                Console.WriteLine("Exception: {0}", aex.Message);
            }
        }