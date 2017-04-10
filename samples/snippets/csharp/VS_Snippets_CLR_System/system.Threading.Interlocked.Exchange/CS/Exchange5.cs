// <Snippet2>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Widget
{
   public Widget(String id)
   {
      this.Id = id;
   }

   public String Id { get; set; }
   public String Description { get; set; }
}


public class Example
{
   public static void Main()
   {
      Widget firstWidget = null;
      var tasks = new List<Task>();
      for (int ctr = 0; ctr <= 10; ctr++) {
         tasks.Add(Task.Run( () => { // Give each task its own random number generator.
                                     var rnd = new Random();
                                     for (int widgetIndex = 0; widgetIndex <= 100; widgetIndex++) {
                                        //Generate ten random characters from U+0041 to U+005A.
                                        String id = String.Empty;
                                        for (int charCtr = 0; charCtr <= 9; charCtr++)
                                           id += Convert.ToChar(rnd.Next(0x0041, 0x005B));

                                        var newWidget = new Widget(id);
                                        if (firstWidget == null)
                                           firstWidget = newWidget;
                                        else if (newWidget.Id.CompareTo(firstWidget.Id) < 0)
                                           Interlocked.Exchange(ref firstWidget, newWidget);

                                     }
                                   } ));
      }
      try {
         Task.WaitAll(tasks.ToArray());
         Console.WriteLine("The widget with the lowest id: {0}", firstWidget.Id);
      }
      catch (AggregateException ae) {
         foreach (var e in ae.InnerExceptions)
            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
      }
   }
}
// The example displays output like the following:
//   The widget with the lowest id: ACHZVFBYNU
// </Snippet2>