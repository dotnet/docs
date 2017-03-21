        // Get all current Controls in the collection.
        for (int i = 0; i < pagesSection.Controls.Count; i++)
        {
          Console.WriteLine("Control {0}:", i);
          Console.WriteLine("  TagPrefix = '{0}' ",
              pagesSection.Controls[i].TagPrefix);
          Console.WriteLine("  TagName = '{0}' ",
              pagesSection.Controls[i].TagName);
          Console.WriteLine("  Source = '{0}' ",
              pagesSection.Controls[i].Source);
          Console.WriteLine("  Namespace = '{0}' ",
              pagesSection.Controls[i].Namespace);
          Console.WriteLine("  Assembly = '{0}' ",
              pagesSection.Controls[i].Assembly);
        }