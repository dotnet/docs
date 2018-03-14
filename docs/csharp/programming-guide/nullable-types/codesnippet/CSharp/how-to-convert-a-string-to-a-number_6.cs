            // This snippet shows a couple of examples that extract number characters from the
            // beginning of the string to avoid TryParse errors.
            StringBuilder sb = new StringBuilder();
            var str = "  10FFxxx";
            foreach (char c in str) {
                // Check for numeric characters (hex in this case).  Add "." and "e" if float,
                // and remove letters.  Include initial space because it is harmless.
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f') || c == ' ') {
                    sb.Append(c);
                }
                else
                    break;
            }
            if (int.TryParse(sb.ToString(), System.Globalization.NumberStyles.HexNumber, null, out i))
                Console.WriteLine(sb.ToString());

            str = "   -10FFXXX";
            sb.Clear();
            foreach (char c in str) {
                // Check for numeric characters (allow negative in this case but no hex digits). 
                // Though we use int.TryParse in the previous example and this one, int.TryParse does NOT
                // allow a sign character (-) AND hex digits at the same time.
                // Include initial space because it is harmless.
                if ((c >= '0' && c <= '9') || c == ' ' || c == '-') {
                    sb.Append(c);
                } else
                    break;
            }
            if (int.TryParse(sb.ToString(), out i))
                Console.WriteLine(sb.ToString());