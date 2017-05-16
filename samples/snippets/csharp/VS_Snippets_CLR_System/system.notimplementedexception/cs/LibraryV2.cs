// <Snippet3>
namespace Utilities
{
   public class StringLibrary
   {
      public static Version { get; } = new Version("2.0");
      
      public static String GetEndOfLineCharacter()
      {
         return Environment.Newline;
      }
   }
}
// </Snippet3>

