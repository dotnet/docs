// <Snippet3>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Random rnd = new Random();
      var cts = new CancellationTokenSource();
      CancellationToken token = cts.Token;
      Timer timer = new Timer(Elapsed, cts, 5000, Timeout.Infinite);

      var t = Task.Run( () => { List<int> product33 = new List<int>();
                                for (int ctr = 1; ctr < Int16.MaxValue; ctr++) {
                                   if (token.IsCancellationRequested) {
                                      Console.WriteLine("\nCancellation requested in antecedent...\n");
                                      token.ThrowIfCancellationRequested();
                                   }
                                   if (ctr % 2000 == 0) {
                                      int delay = rnd.Next(16,501);
                                      Thread.Sleep(delay);
                                   }

                                   if (ctr % 33 == 0)
                                      product33.Add(ctr);
                                }
                                return product33.ToArray();
                              }, token);

      Task continuation = t.ContinueWith(antecedent => { Console.WriteLine("Multiples of 33:\n");
                                                         var arr = antecedent.Result;
                                                         for (int ctr = 0; ctr < arr.Length; ctr++)
                                                         {
                                                            if (token.IsCancellationRequested) {
                                                               Console.WriteLine("\nCancellation requested in continuation...\n");
                                                               token.ThrowIfCancellationRequested();
                                                            }

                                                            if (ctr % 100 == 0) {
                                                               int delay = rnd.Next(16,251);
                                                               Thread.Sleep(delay);
                                                            }
                                                            Console.Write("{0:N0}{1}", arr[ctr],
                                                                          ctr != arr.Length - 1 ? ", " : "");
                                                            if (Console.CursorLeft >= 74)
                                                               Console.WriteLine();
                                                         }
                                                         Console.WriteLine();
                                                       } , token);

      try {
          continuation.Wait();
      }
      catch (AggregateException e) {
         foreach (Exception ie in e.InnerExceptions)
            Console.WriteLine("{0}: {1}", ie.GetType().Name,
                              ie.Message);
      }
      finally {
         cts.Dispose();
      }

      Console.WriteLine("\nAntecedent Status: {0}", t.Status);
      Console.WriteLine("Continuation Status: {0}", continuation.Status);
  }

   private static void Elapsed(object state)
   {
      CancellationTokenSource cts = state as CancellationTokenSource;
      if (cts == null) return;

      cts.Cancel();
      Console.WriteLine("\nCancellation request issued...\n");
   }
}
// The example displays the following output:
//    Multiples of 33:
//
//    33, 66, 99, 132, 165, 198, 231, 264, 297, 330, 363, 396, 429, 462, 495, 528,
//    561, 594, 627, 660, 693, 726, 759, 792, 825, 858, 891, 924, 957, 990, 1,023,
//    1,056, 1,089, 1,122, 1,155, 1,188, 1,221, 1,254, 1,287, 1,320, 1,353, 1,386,
//    1,419, 1,452, 1,485, 1,518, 1,551, 1,584, 1,617, 1,650, 1,683, 1,716, 1,749,
//    1,782, 1,815, 1,848, 1,881, 1,914, 1,947, 1,980, 2,013, 2,046, 2,079, 2,112,
//    2,145, 2,178, 2,211, 2,244, 2,277, 2,310, 2,343, 2,376, 2,409, 2,442, 2,475,
//    2,508, 2,541, 2,574, 2,607, 2,640, 2,673, 2,706, 2,739, 2,772, 2,805, 2,838,
//    2,871, 2,904, 2,937, 2,970, 3,003, 3,036, 3,069, 3,102, 3,135, 3,168, 3,201,
//    3,234, 3,267, 3,300, 3,333, 3,366, 3,399, 3,432, 3,465, 3,498, 3,531, 3,564,
//    3,597, 3,630, 3,663, 3,696, 3,729, 3,762, 3,795, 3,828, 3,861, 3,894, 3,927,
//    3,960, 3,993, 4,026, 4,059, 4,092, 4,125, 4,158, 4,191, 4,224, 4,257, 4,290,
//    4,323, 4,356, 4,389, 4,422, 4,455, 4,488, 4,521, 4,554, 4,587, 4,620, 4,653,
//    4,686, 4,719, 4,752, 4,785, 4,818, 4,851, 4,884, 4,917, 4,950, 4,983, 5,016,
//    5,049, 5,082, 5,115, 5,148, 5,181, 5,214, 5,247, 5,280, 5,313, 5,346, 5,379,
//    5,412, 5,445, 5,478, 5,511, 5,544, 5,577, 5,610, 5,643, 5,676, 5,709, 5,742,
//    5,775, 5,808, 5,841, 5,874, 5,907, 5,940, 5,973, 6,006, 6,039, 6,072, 6,105,
//    6,138, 6,171, 6,204, 6,237, 6,270, 6,303, 6,336, 6,369, 6,402, 6,435, 6,468,
//    6,501, 6,534, 6,567, 6,600, 6,633, 6,666, 6,699, 6,732, 6,765, 6,798, 6,831,
//    6,864, 6,897, 6,930, 6,963, 6,996, 7,029, 7,062, 7,095, 7,128, 7,161, 7,194,
//    7,227, 7,260, 7,293, 7,326, 7,359, 7,392, 7,425, 7,458, 7,491, 7,524, 7,557,
//    7,590, 7,623, 7,656, 7,689, 7,722, 7,755, 7,788, 7,821, 7,854, 7,887, 7,920,
//    7,953, 7,986, 8,019, 8,052, 8,085, 8,118, 8,151, 8,184, 8,217, 8,250, 8,283,
//    8,316, 8,349, 8,382, 8,415, 8,448, 8,481, 8,514, 8,547, 8,580, 8,613, 8,646,
//    8,679, 8,712, 8,745, 8,778, 8,811, 8,844, 8,877, 8,910, 8,943, 8,976, 9,009,
//    9,042, 9,075, 9,108, 9,141, 9,174, 9,207, 9,240, 9,273, 9,306, 9,339, 9,372,
//    9,405, 9,438, 9,471, 9,504, 9,537, 9,570, 9,603, 9,636, 9,669, 9,702, 9,735,
//    9,768, 9,801, 9,834, 9,867, 9,900, 9,933, 9,966, 9,999, 10,032, 10,065, 10,098,
//    10,131, 10,164, 10,197, 10,230, 10,263, 10,296, 10,329, 10,362, 10,395, 10,428,
//    10,461, 10,494, 10,527, 10,560, 10,593, 10,626, 10,659, 10,692, 10,725, 10,758,
//    10,791, 10,824, 10,857, 10,890, 10,923, 10,956, 10,989, 11,022, 11,055, 11,088,
//    11,121, 11,154, 11,187, 11,220, 11,253, 11,286, 11,319, 11,352, 11,385, 11,418,
//    11,451, 11,484, 11,517, 11,550, 11,583, 11,616, 11,649, 11,682, 11,715, 11,748,
//    11,781, 11,814, 11,847, 11,880, 11,913, 11,946, 11,979, 12,012, 12,045, 12,078,
//    12,111, 12,144, 12,177, 12,210, 12,243, 12,276, 12,309, 12,342, 12,375, 12,408,
//    12,441, 12,474, 12,507, 12,540, 12,573, 12,606, 12,639, 12,672, 12,705, 12,738,
//    12,771, 12,804, 12,837, 12,870, 12,903, 12,936, 12,969, 13,002, 13,035, 13,068,
//    13,101, 13,134, 13,167, 13,200, 13,233, 13,266,
//    Cancellation requested in continuation...
//
//
//    Cancellation request issued...
//
//    TaskCanceledException: A task was canceled.
//
//    Antecedent Status: RanToCompletion
//    Continuation Status: Canceled
// </Snippet3>