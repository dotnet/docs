//<Snippet1>
using System;

namespace DesignLibrary
{
   public enum Actions
   {
      Unknown,
      Discard,
      ForwardToManagement,
      ForwardToDeveloper
   }

   public enum TypeOfFeedback
   {
      Complaint, 
      Praise,
      Suggestion,
      Incomprehensible
   }

   public class BadRefAndOut
   {
      // Violates rule: DoNotPassTypesByReference.

      public static bool ReplyInformation (TypeOfFeedback input, 
         out string reply, ref Actions action)
      {
         bool returnReply = false;
         string replyText = "Your feedback has been forwarded " + 
                            "to the product manager.";

         reply = String.Empty;
         switch (input)
         {
            case TypeOfFeedback.Complaint:
            case TypeOfFeedback.Praise :
               action = Actions.ForwardToManagement;
               reply = "Thank you. " + replyText;
               returnReply = true;
               break;
            case TypeOfFeedback.Suggestion:
               action = Actions.ForwardToDeveloper;
               reply = replyText;
               returnReply = true;
               break;
            case TypeOfFeedback.Incomprehensible:
            default:
               action = Actions.Discard;
               returnReply = false;
               break;
         }
         return returnReply;
      }
   }

   // Redesigned version does not use out or ref parameters;
   // instead, it returns this container type.

   public class ReplyData
   {
      string reply;
      Actions action;
      bool returnReply;
      
      // Constructors.
      public ReplyData()
      {
         this.reply = String.Empty;
         this.action = Actions.Discard;
         this.returnReply = false;
      }

      public ReplyData (Actions action, string reply, bool returnReply)
      {
         this.reply = reply;
         this.action = action;
         this.returnReply = returnReply;
      }

      // Properties.
      public string Reply { get { return reply;}}
      public Actions Action { get { return action;}}

      public override string ToString()
      {
         return String.Format("Reply: {0} Action: {1} return? {2}", 
            reply, action.ToString(), returnReply.ToString());
      }
   }

   public class RedesignedRefAndOut
   {
      public static ReplyData ReplyInformation (TypeOfFeedback input)
      {
         ReplyData answer;
         string replyText = "Your feedback has been forwarded " + 
            "to the product manager.";

         switch (input)
         {
            case TypeOfFeedback.Complaint:
            case TypeOfFeedback.Praise :
               answer = new ReplyData(
                  Actions.ForwardToManagement,
                  "Thank you. " + replyText,
                  true);
               break;
            case TypeOfFeedback.Suggestion:
               answer =  new ReplyData(
                  Actions.ForwardToDeveloper,
                  replyText,
                  true);
               break;
            case TypeOfFeedback.Incomprehensible:
            default:
               answer = new ReplyData();
               break;
         }
         return answer;
      }
   }
}
//</Snippet1>
