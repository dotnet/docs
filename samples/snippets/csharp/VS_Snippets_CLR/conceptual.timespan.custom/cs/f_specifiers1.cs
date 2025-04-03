using System;

public class Example
{
   public static void Main()
   {
      FSpecifier();
      Console.WriteLine("-----");
      FFSpecifier();
      Console.WriteLine("-----");
      FFFSpecifier();
      Console.WriteLine("-----");
      FFFFSpecifier();
      Console.WriteLine("-----");
      FFFFFSpecifier();
      Console.WriteLine("-----");
      FFFFFFSpecifier();
      Console.WriteLine("-----");
      F7Specifier();
   }

   private static void FSpecifier()
   {
      // <Snippet21>
      Console.WriteLine("Formatting:");
      TimeSpan ts1 = TimeSpan.Parse("0:0:3.669");
      Console.WriteLine($"{ts1} ('%F') --> {ts1:%F}");

      TimeSpan ts2 = TimeSpan.Parse("0:0:3.091");
      Console.WriteLine($"{ts2} ('ss\\.F') --> {ts2:ss\\.F}");
      Console.WriteLine();

      Console.WriteLine("Parsing:");
      string[] inputs = { "0:0:03.", "0:0:03.1", "0:0:03.12" };
      string fmt = @"h\:m\:ss\.F";
      TimeSpan ts3;

      foreach (string input in inputs) {
         if (TimeSpan.TryParseExact(input, fmt, null, out ts3))
            Console.WriteLine($"{input} ('{fmt}') --> {ts3}");
         else
            Console.WriteLine($"Cannot parse {input} with '{fmt}'.");
      }
      // The example displays the following output:
      //       Formatting:
      //       00:00:03.6690000 ('%F') --> 6
      //       00:00:03.0910000 ('ss\.F') --> 03.
      //
      //       Parsing:
      //       0:0:03. ('h\:m\:ss\.F') --> 00:00:03
      //       0:0:03.1 ('h\:m\:ss\.F') --> 00:00:03.1000000
      //       Cannot parse 0:0:03.12 with 'h\:m\:ss\.F'.
      // </Snippet21>
   }

   private static void FFSpecifier()
   {
      // <Snippet22>
      Console.WriteLine("Formatting:");
      TimeSpan ts1 = TimeSpan.Parse("0:0:3.697");
      Console.WriteLine($"{ts1} ('FF') --> {ts1:FF}");

      TimeSpan ts2 = TimeSpan.Parse("0:0:3.809");
      Console.WriteLine($"{ts2} ('ss\\.FF') --> {ts2:ss\\.FF}");
      Console.WriteLine();

      Console.WriteLine("Parsing:");
      string[] inputs = { "0:0:03.", "0:0:03.1", "0:0:03.127" };
      string fmt = @"h\:m\:ss\.FF";
      TimeSpan ts3;

      foreach (string input in inputs) {
         if (TimeSpan.TryParseExact(input, fmt, null, out ts3))
            Console.WriteLine($"{input} ('{fmt}') --> {ts3}");
         else
            Console.WriteLine($"Cannot parse {input} with '{fmt}'.");
      }
      // The example displays the following output:
      //       Formatting:
      //       00:00:03.6970000 ('FF') --> 69
      //       00:00:03.8090000 ('ss\.FF') --> 03.8
      //
      //       Parsing:
      //       0:0:03. ('h\:m\:ss\.FF') --> 00:00:03
      //       0:0:03.1 ('h\:m\:ss\.FF') --> 00:00:03.1000000
      //       Cannot parse 0:0:03.127 with 'h\:m\:ss\.FF'.
      // </Snippet22>
   }

   private static void FFFSpecifier()
   {
      // <Snippet23>
      Console.WriteLine("Formatting:");
      TimeSpan ts1 = TimeSpan.Parse("0:0:3.6974");
      Console.WriteLine($"{ts1} ('FFF') --> {ts1:FFF}");

      TimeSpan ts2 = TimeSpan.Parse("0:0:3.8009");
      Console.WriteLine($"{ts2} ('ss\\.FFF') --> {ts2:ss\\.FFF}");
      Console.WriteLine();

      Console.WriteLine("Parsing:");
      string[] inputs = { "0:0:03.", "0:0:03.12", "0:0:03.1279" };
      string fmt = @"h\:m\:ss\.FFF";
      TimeSpan ts3;

      foreach (string input in inputs) {
         if (TimeSpan.TryParseExact(input, fmt, null, out ts3))
            Console.WriteLine($"{input} ('{fmt}') --> {ts3}");
         else
            Console.WriteLine($"Cannot parse {input} with '{fmt}'.");
      }
      // The example displays the following output:
      //       Formatting:
      //       00:00:03.6974000 ('FFF') --> 697
      //       00:00:03.8009000 ('ss\.FFF') --> 03.8
      //
      //       Parsing:
      //       0:0:03. ('h\:m\:ss\.FFF') --> 00:00:03
      //       0:0:03.12 ('h\:m\:ss\.FFF') --> 00:00:03.1200000
      //       Cannot parse 0:0:03.1279 with 'h\:m\:ss\.FFF'.
      // </Snippet23>
   }

   private static void FFFFSpecifier()
   {
      // <Snippet24>
      Console.WriteLine("Formatting:");
      TimeSpan ts1 = TimeSpan.Parse("0:0:3.69749");
      Console.WriteLine($"{ts1} ('FFFF') --> {ts1:FFFF}");

      TimeSpan ts2 = TimeSpan.Parse("0:0:3.80009");
      Console.WriteLine($"{ts2} ('ss\\.FFFF') --> {ts2:ss\\.FFFF}");
      Console.WriteLine();

      Console.WriteLine("Parsing:");
      string[] inputs = { "0:0:03.", "0:0:03.12", "0:0:03.12795" };
      string fmt = @"h\:m\:ss\.FFFF";
      TimeSpan ts3;

      foreach (string input in inputs) {
         if (TimeSpan.TryParseExact(input, fmt, null, out ts3))
            Console.WriteLine($"{input} ('{fmt}') --> {ts3}");
         else
            Console.WriteLine($"Cannot parse {input} with '{fmt}'.");
      }
      // The example displays the following output:
      //       Formatting:
      //       00:00:03.6974900 ('FFFF') --> 6974
      //       00:00:03.8000900 ('ss\.FFFF') --> 03.8
      //
      //       Parsing:
      //       0:0:03. ('h\:m\:ss\.FFFF') --> 00:00:03
      //       0:0:03.12 ('h\:m\:ss\.FFFF') --> 00:00:03.1200000
      //       Cannot parse 0:0:03.12795 with 'h\:m\:ss\.FFFF'.
      // </Snippet24>
   }

   private static void FFFFFSpecifier()
   {
      // <Snippet25>
      Console.WriteLine("Formatting:");
      TimeSpan ts1 = TimeSpan.Parse("0:0:3.697497");
      Console.WriteLine($"{ts1} ('FFFFF') --> {ts1:FFFFF}");

      TimeSpan ts2 = TimeSpan.Parse("0:0:3.800009");
      Console.WriteLine($"{ts2} ('ss\\.FFFFF') --> {ts2:ss\\.FFFFF}");
      Console.WriteLine();

      Console.WriteLine("Parsing:");
      string[] inputs = { "0:0:03.", "0:0:03.12", "0:0:03.127956" };
      string fmt = @"h\:m\:ss\.FFFFF";
      TimeSpan ts3;

      foreach (string input in inputs) {
         if (TimeSpan.TryParseExact(input, fmt, null, out ts3))
            Console.WriteLine($"{input} ('{fmt}') --> {ts3}");
         else
            Console.WriteLine($"Cannot parse {input} with '{fmt}'.");
      }
      // The example displays the following output:
      //       Formatting:
      //       00:00:03.6974970 ('FFFFF') --> 69749
      //       00:00:03.8000090 ('ss\.FFFFF') --> 03.8
      //
      //       Parsing:
      //       0:0:03. ('h\:m\:ss\.FFFF') --> 00:00:03
      //       0:0:03.12 ('h\:m\:ss\.FFFF') --> 00:00:03.1200000
      //       Cannot parse 0:0:03.127956 with 'h\:m\:ss\.FFFF'.
      // </Snippet25>
   }

   private static void FFFFFFSpecifier()
   {
      // <Snippet26>
      Console.WriteLine("Formatting:");
      TimeSpan ts1 = TimeSpan.Parse("0:0:3.6974974");
      Console.WriteLine($"{ts1} ('FFFFFF') --> {ts1:FFFFFF}");

      TimeSpan ts2 = TimeSpan.Parse("0:0:3.8000009");
      Console.WriteLine($"{ts2} ('ss\\.FFFFFF') --> {ts2:ss\\.FFFFFF}");
      Console.WriteLine();

      Console.WriteLine("Parsing:");
      string[] inputs = { "0:0:03.", "0:0:03.12", "0:0:03.1279569" };
      string fmt = @"h\:m\:ss\.FFFFFF";
      TimeSpan ts3;

      foreach (string input in inputs) {
         if (TimeSpan.TryParseExact(input, fmt, null, out ts3))
            Console.WriteLine($"{input} ('{fmt}') --> {ts3}");
         else
            Console.WriteLine($"Cannot parse {input} with '{fmt}'.");
      }
      // The example displays the following output:
      //       Formatting:
      //       00:00:03.6974974 ('FFFFFF') --> 697497
      //       00:00:03.8000009 ('ss\.FFFFFF') --> 03.8
      //
      //       Parsing:
      //       0:0:03. ('h\:m\:ss\.FFFFFF') --> 00:00:03
      //       0:0:03.12 ('h\:m\:ss\.FFFFFF') --> 00:00:03.1200000
      //       Cannot parse 0:0:03.1279569 with 'h\:m\:ss\.FFFFFF'.
      // </Snippet26>
   }

   private static void F7Specifier()
   {
      // <Snippet27>
      Console.WriteLine("Formatting:");
      TimeSpan ts1 = TimeSpan.Parse("0:0:3.6974974");
      Console.WriteLine($"{ts1} ('FFFFFFF') --> {ts1:FFFFFFF}");

      TimeSpan ts2 = TimeSpan.Parse("0:0:3.9500000");
      Console.WriteLine($"{ts2} ('ss\\.FFFFFFF') --> {ts2:ss\\.FFFFFFF}");
      Console.WriteLine();

      Console.WriteLine("Parsing:");
      string[] inputs = { "0:0:03.", "0:0:03.12", "0:0:03.1279569" };
      string fmt = @"h\:m\:ss\.FFFFFFF";
      TimeSpan ts3;

      foreach (string input in inputs) {
         if (TimeSpan.TryParseExact(input, fmt, null, out ts3))
            Console.WriteLine($"{input} ('{fmt}') --> {ts3}");
         else
            Console.WriteLine($"Cannot parse {input} with '{fmt}'.");
      }
      // The example displays the following output:
      //    Formatting:
      //    00:00:03.6974974 ('FFFFFFF') --> 6974974
      //    00:00:03.9500000 ('ss\.FFFFFFF') --> 03.95
      //
      //    Parsing:
      //    0:0:03. ('h\:m\:ss\.FFFFFFF') --> 00:00:03
      //    0:0:03.12 ('h\:m\:ss\.FFFFFFF') --> 00:00:03.1200000
      //    0:0:03.1279569 ('h\:m\:ss\.FFFFFFF') --> 00:00:03.1279569
      // </Snippet27>
   }
}
