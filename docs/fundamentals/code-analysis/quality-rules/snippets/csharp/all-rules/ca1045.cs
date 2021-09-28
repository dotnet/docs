using System;

namespace ca1045
{
    //<snippet1>
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

        public static bool ReplyInformation(TypeOfFeedback input,
           out string reply, ref Actions action)
        {
            bool returnReply = false;
            string replyText = "Your feedback has been forwarded " +
                               "to the product manager.";

            reply = String.Empty;
            switch (input)
            {
                case TypeOfFeedback.Complaint:
                case TypeOfFeedback.Praise:
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

        public ReplyData(Actions action, string reply, bool returnReply)
        {
            this.reply = reply;
            this.action = action;
            this.returnReply = returnReply;
        }

        // Properties.
        public string Reply { get { return reply; } }
        public Actions Action { get { return action; } }

        public override string ToString()
        {
            return String.Format("Reply: {0} Action: {1} return? {2}",
               reply, action.ToString(), returnReply.ToString());
        }
    }

    public class RedesignedRefAndOut
    {
        public static ReplyData ReplyInformation(TypeOfFeedback input)
        {
            ReplyData answer;
            string replyText = "Your feedback has been forwarded " +
               "to the product manager.";

            switch (input)
            {
                case TypeOfFeedback.Complaint:
                case TypeOfFeedback.Praise:
                    answer = new ReplyData(
                       Actions.ForwardToManagement,
                       "Thank you. " + replyText,
                       true);
                    break;
                case TypeOfFeedback.Suggestion:
                    answer = new ReplyData(
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
    //</snippet1>

    //<snippet2>
    public class UseComplexMethod
    {
        static void UseTheComplicatedClass()
        {
            // Using the version with the ref and out parameters. 
            // You do not have to initialize an out parameter.

            string[] reply = new string[5];

            // You must initialize a ref parameter.
            Actions[] action = {Actions.Unknown,Actions.Unknown,
                             Actions.Unknown,Actions.Unknown,
                             Actions.Unknown,Actions.Unknown};
            bool[] disposition = new bool[5];
            int i = 0;

            foreach (TypeOfFeedback t in Enum.GetValues(typeof(TypeOfFeedback)))
            {
                // The call to the library.
                disposition[i] = BadRefAndOut.ReplyInformation(
                   t, out reply[i], ref action[i]);
                Console.WriteLine("Reply: {0} Action: {1}  return? {2} ",
                   reply[i], action[i], disposition[i]);
                i++;
            }
        }

        static void UseTheSimplifiedClass()
        {
            ReplyData[] answer = new ReplyData[5];
            int i = 0;
            foreach (TypeOfFeedback t in Enum.GetValues(typeof(TypeOfFeedback)))
            {
                // The call to the library.
                answer[i] = RedesignedRefAndOut.ReplyInformation(t);
                Console.WriteLine(answer[i++]);
            }
        }

        public static void Main1045()
        {
            UseTheComplicatedClass();

            // Print a blank line in output.
            Console.WriteLine("");

            UseTheSimplifiedClass();
        }
    }
    //</snippet2>

    //<snippet3>
    public class ReferenceTypesAndParameters
    {
        // The following syntax will not work. You cannot make a
        // reference type that is passed by value point to a new
        // instance. This needs the ref keyword.

        public static void BadPassTheObject(string argument)
        {
            argument = argument + " ABCDE";
        }

        // The following syntax will work, but is considered bad design.
        // It reassigns the argument to point to a new instance of string.
        // Violates rule DoNotPassTypesByReference.

        public static void PassTheReference(ref string argument)
        {
            argument = argument + " ABCDE";
        }

        // The following syntax will work and is a better design.
        // It returns the altered argument as a new instance of string.

        public static string BetterThanPassTheReference(string argument)
        {
            return argument + " ABCDE";
        }
    }
    //</snippet3>

    //<snippet4>
    public class Test
    {
        public static void Main1045()
        {
            string s1 = "12345";
            string s2 = "12345";
            string s3 = "12345";

            Console.WriteLine("Changing pointer - passed by value:");
            Console.WriteLine(s1);
            ReferenceTypesAndParameters.BadPassTheObject(s1);
            Console.WriteLine(s1);

            Console.WriteLine("Changing pointer - passed by reference:");
            Console.WriteLine(s2);
            ReferenceTypesAndParameters.PassTheReference(ref s2);
            Console.WriteLine(s2);

            Console.WriteLine("Passing by return value:");
            s3 = ReferenceTypesAndParameters.BetterThanPassTheReference(s3);
            Console.WriteLine(s3);
        }
    }
    //</snippet4>
}
