   [ValidationPropertyAttribute("Message")]
   public class MessageControl : Label
   {
      private int _message = 0;
      public int Message
      {
         get 
         {
            return _message;
         }
         set
         {
            _message = value;
         }
      }
      
   }