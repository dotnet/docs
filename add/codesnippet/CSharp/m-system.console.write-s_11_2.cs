public class FormatConverter {
    public static void Main(string[] args) {
        string lineInput;
        while ((lineInput = Console.ReadLine()) != null) {
            string[] fields = lineInput.Split(new char[] {'\t'});
            bool isFirstField = true;
            foreach(string item in fields) {
                if (isFirstField)
                    isFirstField = false;
                else
                    Console.Write(',');
                // If the field represents a boolean, replace with a numeric representation.
                try {
                    Console.Write(Convert.ToByte(Convert.ToBoolean(item)));
                }
                catch(FormatException) {
                    Console.Write(item);
                }
            }
            Console.WriteLine();
        }
    }
}