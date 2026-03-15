using System;
using System.Diagnostics;
using System.Threading.Tasks;

// <RuntimeAsyncStackTrace>
// To enable runtime async, add the following to your .csproj:
//   <Features>runtime-async=on</Features>
//   <EnablePreviewFeatures>true</EnablePreviewFeatures>

await OuterAsync();

static async Task OuterAsync()
{
    await Task.CompletedTask;
    await MiddleAsync();
}

static async Task MiddleAsync()
{
    await Task.CompletedTask;
    await InnerAsync();
}

static async Task InnerAsync()
{
    await Task.CompletedTask;
    Console.WriteLine(new StackTrace(fNeedFileInfo: true));
}
// </RuntimeAsyncStackTrace>
