   protected override bool OnBubbleEvent(object sender, EventArgs e)
   {

      // Use the Context property to write text to the TraceContext object
      // associated with the current request.
      Context.Trace.Write("The ParentControl's OnBubbleEvent method is called.");
      Context.Trace.Write("The Source of event is: " + sender.ToString());

      return true;
   }