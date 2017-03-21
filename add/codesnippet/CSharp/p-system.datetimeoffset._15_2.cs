      DateTimeOffset dto;
      int ctr = 0;
      int ms = 0;
      do {
         dto = DateTimeOffset.Now;
         if (dto.Millisecond != ms)
         {
            ms = dto.Millisecond;
            Console.WriteLine("{0}:{1:d3} ms. {2}", 
                              dto.ToString("M/d/yyyy h:mm:ss"), 
                              ms, dto.ToString("zzz"));
            ctr++;
         }
      } while (ctr < 100);