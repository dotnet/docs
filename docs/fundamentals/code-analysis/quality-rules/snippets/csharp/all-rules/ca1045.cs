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
            string replyText = """
                Your feedback has been forwarded to the product manager.
                """;

            reply = string.Empty;
            bool returnReply;
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

    public record class ReplyData(string Reply, Actions Action, bool ReturnReply = false)
    {
        public override string ToString()
        {
            return string.Format("Reply: {0} Action: {1} return? {2}",
               Reply, Action.ToString(), ReturnReply.ToString());
        }
    }

    public class RedesignedRefAndOut
    {
        public static ReplyData? ReplyInformation(TypeOfFeedback input)
        {
            string replyText = "Your feedback has been forwarded " +
               "to the product manager.";
            ReplyData? answer = input switch
            {
                TypeOfFeedback.Complaint or TypeOfFeedback.Praise => new ReplyData(
                                       "Thank you. " + replyText,
                                       Actions.ForwardToManagement,
                                       true),
                TypeOfFeedback.Suggestion => new ReplyData(
                                       replyText,
                                       Actions.ForwardToDeveloper,
                                       true),
                _ => null,
            };
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
            Actions[] action = [Actions.Unknown,Actions.Unknown,
                             Actions.Unknown,Actions.Unknown,
                             Actions.Unknown,Actions.Unknown];
            bool[] disposition = new bool[5];
            int i = 0;

            foreach (TypeOfFeedback t in Enum.GetValues<TypeOfFeedback>())
            {
                // The call to the library.
                disposition[i] = BadRefAndOut.ReplyInformation(
                   t, out reply[i], ref action[i]);
                Console.WriteLine($"Reply: {reply[i]} Action: {action[i]}  return? {disposition[i]} ");
                i++;
            }
        }

        static void UseTheSimplifiedClass()
        {
            ReplyData[] answer = new ReplyData[5];
            int i = 0;
            foreach (TypeOfFeedback t in Enum.GetValues<TypeOfFeedback>())
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
