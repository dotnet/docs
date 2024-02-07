using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

class Validation
{
    public static void RunIt(params string[] args)
    {
        // <InjectValidation>
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.Configure<FirstModelNoNamespace>(
            builder.Configuration.GetSection("some string"));

        builder.Services.AddSingleton<
            IValidateOptions<FirstModelNoNamespace>, FirstValidatorNoNamespace>();
        builder.Services.AddSingleton<
            IValidateOptions<SecondModelNoNamespace>, SecondValidatorNoNamespace>();
        // </InjectValidation>
    }
}

// <ValidatorClasses>
public class FirstModelNoNamespace
{
    [Required]
    [MinLength(5)]
    public string P1 { get; set; } = string.Empty;

    [Microsoft.Extensions.Options.ValidateObjectMembers(
        typeof(SecondValidatorNoNamespace))]
    public SecondModelNoNamespace? P2 { get; set; }
}

public class SecondModelNoNamespace
{
    [Required]
    [MinLength(5)]
    public string P4 { get; set; } = string.Empty;
}

[OptionsValidator]
public partial class FirstValidatorNoNamespace
    : IValidateOptions<FirstModelNoNamespace>
{
}

[OptionsValidator]
public partial class SecondValidatorNoNamespace
    : IValidateOptions<SecondModelNoNamespace>
{
}
// </ValidatorClasses>
