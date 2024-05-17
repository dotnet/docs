namespace WarningWaves;
public class WaveSix
{
    // <PartialMethodDeclaration>
    public partial class PartialType
    {
        public partial void M1(int x);

        public partial T M2<T>(string s) where T : struct;

        public partial void M3(string s);


        public partial void M4(object o);
        public partial void M5(dynamic o);
        public partial void M6(string? s);
    }
    // </PartialMethodDeclaration>

    // <PartialMethodDefinition>
    public partial class PartialType
    {
        // Different parameter names:
        public partial void M1(int y) { }

        // Different type parameter names:
        public partial TResult M2<TResult>(string s) where TResult : struct => default;

        // Relaxed nullability
        public partial void M3(string? s) { }


        // Mixing object and dynamic
        public partial void M4(dynamic o) { }

        // Mixing object and dynamic
        public partial void M5(object o) { }

        // Note: This generates CS8611 (nullability mismatch) not CS8826
        public partial void M6(string s) { }
    }
    // </PartialMethodDefinition>

}
