// <RegisterServiceWithDI>
using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.TryAddSingleton<AzureEventSourceLogForwarder>();

builder.Services.AddDataProtection()
    .PersistKeysToAzureBlobStorage("<connection_string>", "<container_name>", "keys.xml")
    .ProtectKeysWithAzureKeyVault(new Uri("<uri>"), new DefaultAzureCredential());
// </RegisterServiceWithDI>

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
