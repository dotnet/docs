namespace MyApp.Services;

class ValidationAndFormatting
{
    // <RegionExample>
    #region Validation methods
    static bool IsValidEmail(string email) =>
        email.Contains('@') && email.Contains('.');

    static bool IsValidAge(int age) =>
        age is > 0 and < 150;
    #endregion

    #region Formatting methods
    static string FormatName(string first, string last) =>
        $"{last}, {first}";

    static string FormatCurrency(decimal amount) =>
        amount.ToString("C");
    #endregion
    // </RegionExample>
}
