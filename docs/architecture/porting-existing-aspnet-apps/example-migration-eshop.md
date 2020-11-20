---
title: Example migration of eShop to ASP.NET Core
description: A walkthrough of a migrating an existing ASP.NET MVC app to ASP.NET Core, using a sample online store app as a reference.
author: ardalis
ms.date: 11/13/2020
---

# Example migration of eShop to ASP.NET Core

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

In this chapter you'll see how to migrate a .NET Framework app to .NET Core. The chapter will examine a sample online store app written for ASP.NET 5 and will go leverage many of the concepts and tools described earlier in this book. You'll find the starting point application in the [eShopModernizing GitHub repository](https://github.com/dotnet-architecture/eShopModernizing). There are several different starting point apps; this chapter will focus on the `eShopLegacyMVCSolution`.

The initial version of the project is shown in Figure 4-1. It's a fairly standard ASP.NET MVC 5 app.

![Figure 4-1](media/Figure4-1.png)

**Figure 4-1. The eShopModernizing MVC sample project structure.**

## Run ApiPort to identify problematic APIs

The first step in preparing to migrate is to run the ApiPort tool to get a sense of how many .NET Framework APIs the app calls, and how many of these have .NET Standard or .NET Core equivalents. Focus primarily on your own app's logic, not third party dependencies, and pay attention to System.Web dependencies that will need to be ported. The ApiPort tool was introduced in the last chapter on [understanding and updating dependencies](/understand-update-dependencies.md).

After [installing and configuring the ApiPort tool](https://docs.microsoft.com/dotnet/standard/analyzers/portability-analyzer), run the analysis from within Visual Studio, as shown in Figure 4-2.

![Figure 4-2](media/Figure4-2.png)

**Figure 4-2. Analyze assembly portability in Visual Studio.**

Choose the web project's assembly from the project's `/bin` folder, as shown in Figure 4-3.

![Figure 4-3](media/Figure4-3.png)

**Figure 4-3. Choose the project's web assembly.**

If your solution includes several projects, you can choose all of them. The eShop sample includes just a single MVC project.

Once the report is generated, open the file and review the results. The summary provides a high level view of what percentage of .NET Framework calls your app is making have compatible versions. Figure 4-4 shows the summary for the eShop MVC project.

![Figure 4-4](media/Figure4-4.png)

**Figure 4-4. ApiPort summary.**

For this app, about 80% of the .NET Framework calls are compatible, meaning 20% will need to be addressed in some way as part of the porting process. Viewing the details reveals that all of the incompatible calls are part of `System.Web`, which is an expected incompatibility. The dependencies on `System.Web` calls will be addressed when the app's controllers and related classes are migrated in a later step. Figure 4-5 lists some of the specific types found by the tool:

![Figure 4-5](media/Figure4-5.png)

**Figure 4-5. ApiPort incompatible type details.**

Most of the incompatible types refer to `Controller` and various related attributes that have equivalents in ASP.NET Core.

## Update project files and NuGet reference syntax

The next step is to migrate from the older .csproj file structure to the newer, simpler one introduced with .NET Core. In doing so, you will also migrate from using a `packages.config` file for NuGet references to using `<PackageReference>` elements in the project file.

The original project's `eShopLegacyMVC.csproj` file is 418 lines long. A sample of it is shown in Figure 4-6, which includes a miniature view of the entire file on the right side to offer a sense of its overall size and complexity.

![Figure 4-6](media/Figure4-6.png)

**Figure 4-6. The eShopLegacyMVC.csproj file structure.**

A common way to create a new project file for an existing ASP.NET project is to create a new ASP.NET Core app using `dotnet new` or `File - New - Project` in Visual Studio. Then files can be copied from the old project to the new one to complete the migration.

In addition to the C# project file, NuGet dependencies are stored in a separate 45 line long `packages.config` file, shown in Figure 4-7.

![Figure 4-7](media/Figure4-7.png)

**Figure 4-7. The packages.config file.**

After upgrading to the new csproj file format, you can migrate `packages.config` in class library projects using Visual Studio (this functionality doesn't work with ASP.NET projects, however). [Learn more about migrating package.config to PackageReference in Visual Studio](https://docs.microsoft.com/nuget/consume-packages/migrate-packages-config-to-package-reference). If you have a large number of projects to migrate, [this community tool may help](https://github.com/MarkKharitonov/NuGetPCToPRMigrator).

## Create new ASP.NET Core project

Add a new ASP.NET Core project to the existing app's solution to make moving files easier, as most of the work can be done from within Visual Studio's Solution Explorer. In Visual Studio, right-click on your app's solution and choose Add New Project. Choose ASP.NET Core web application, and give the new project a name as shown in Figure 4-8.

![Figure 4-8](media/Figure4-8.png)

**Figure 4-8. Add new ASP.NET Core web application.**

The next dialog will ask you to choose which template to use. Select the Empty template, and be sure to also change the dropdown from .NET Core to .NET Framework, and select ASP.NET Core 2.2 as shown in Figure 4-9.

![Figure 4-9](media/Figure4-9.png)

**Figure 4-9. Choose an Empty project template targeting .NET Framework with ASP.NET Core 2.2.**

### Migrating NuGet Packages

Since the built-in migration tool for migrating `packages.config` to PackageReference doesn't work on ASP.NET projects, you can use a community tool instead, or migrate by hand. A community tool I've used is available here and uses an XSL sheet to transform from one format to the other. To use it, first copy the `packages.config` file to the newly created ASP.NET Core project folder. Make a backup of your files (this script will remove the `package.config` file from all folders under where you run the script). Then run these commands from the project folder (or for the entire solution if you prefer):

```powershell
iwr https://git.io/vdKaV -OutFile Convert-ToPackageReference.ps1
iwr https://git.io/vdKar -OutFile  Convert-ToPackageReference.xsl
./Convert-ToPackageReference.ps1 | Out-Null
```

The first two commands download files so that they exist locally; the last line runs the script. After running it, try to build the new project. You'll most likely get some errors. To resolve them, you'll want to eliminate some references (like most of the `Microsoft.AspNet` and `System` packages), and you may need to remove some `xmlns` attributes.

In most ASP.NET MVC apps, many client-side dependencies like Bootstrap and jQuery were deployed using NuGet packages. In .NET Core, NuGet packages are only used for server side functionality; client files should be managed through other means. Review the list of `PackageReference` elements added and remove and make note of any that are for client libraries, including:

- bootstrap
- jQuery
- jQuery.Validation
- Modernizr
- popper.js
- Respond

The static client files installed by NuGet for these packages will be copied over to the new project's `wwwroot` folder and hosted from there. It's worth considering whether these files are still needed by the app, and whether it makes sense to continue hosting them or to use a content delivery network (CDN) instead. Managing versions of these libraries can be done at build time using tools like [LibMan](https://docs.microsoft.com/aspnet/core/client-side/libman/) or [npm](https://www.npmjs.com/). Figure 4-10 shows the full eShopPorted.csproj file after migrating package references using the conversion tool shown and removing unnecessary packages.

![Figure 4-10](media/Figure4-10.png)

**Figure 4-10. Package References in the eShopPorted.csproj file.**

Note that the package references can be further compacted by making the `<Version>1.0.0.0</Version>` element a `Version=1.0.0.0` attribute on `<PackageReference>`.

### Migrate static files

Any static files the app uses, including third party scripts and frameworks but also custom images and stylesheets, must be copied from the old project to the new one. In ASP.NET MVC apps, files were typically accessed based on their location within the project folder. In ASP.NET Core apps, these static files will be accessed based on their location within the `wwwroot` folder. For the eShop project, there are static files in the `Content`, `fonts`, `Images`, `Pics`, and `Scripts` folders. The empty project template used in the previous step doesn't include this folder by default, or the middleware needed for it to work, so you'll need to add them.

Add a `wwwroot` folder to the root of the project.

Add `Microsoft.AspNetCore.StaticFiles` NuGet package (version 2.2.0).

In `Startup.cs` add a call to `app.UseStaticFiles()` to the `Configure` method:

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseStaticFiles();
```

Copy the `Content` folder from the ASP.NET MVC app to the new project's `wwwroot` folder.

Run the app and navigate to its `/Content/base.css` folder to verify that the static file is served correctly from its expected path. Continue copying the rest of the folders containing static files to the new project. You'll also want to copy the `favicon.ico` file from the project's root to the `wwwroot` folder. Figure 11 shows the results after these files and their folders have all been copied.

![Figure 4-11](media/Figure4-11.png)

**Figure 4-11. Static folders copied over to wwwroot folder.**

### Migrate C# files

Next, copy over the C# files used by the app, including standard MVC folders and their contents like `Controllers`, `Models`, `ViewModel`, and `Services`. There will most likely be some changes needed in these files, so it's best to copy one folder (or subfolder) at a time and compile to see what errors need to be addressed as you go.

For the eShop sample, the first folder I choose to migrate is the `Models` folder, which includes C# entities and Entity Framework classes. This folder's classes are used by most of the others, so they won't work until these classes have been copied. After copying the folder and building, the compiler revealed errors related to missing namespace `System.Web.Hosting`, related access to `HostingEnvironment`, and a reference to `ConfigurationManager.AppSettings`. The solution to these issues will be to pass in the necessary path data; for now the breaking lines are commented out and a `TODO:` comment is added to each one to track it. After changing five lines, the Task List shows five items and the project builds.

Next the `ViewModel` folder, with its one class, is copied over. It's an easy one, and builds immediately.

Next the `Services` folder is copied over. This folder's classes depend on Entity Framework classes from the `Models` folder, which is why it needed to be copied after that folder. Fortunately, it too builds without errors.

That leaves the `Controllers` folder and its two `Controller` classes. After copying the folder to the new project and building, there are seven build errors. Four of them are related to `ViewBag` access and say `Missing compiler required member 'Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo.Create'` which I solve by adding a NuGet package reference to C#:

```xml
    <PackageReference Include="Microsoft.CSharp" Version="4.7.0" />
```

The remaining three errors specify types that are defined in an assembly that isn't referenced. Specifically these types:

- `HttpServerUtilityBase`
- `RouteValueDictionary`
- `HttpRequestBase`

Let's look at each error one by one. The first error occurs while trying to reference the `Server` property of `Controller` which no longer exists. The goal of the operation is to get the path to an image file in the app:

```csharp
if (item != null)
{
    var webRoot = Server.MapPath("~/Pics"); // compiler error on this line
    var path = Path.Combine(webRoot, item.PictureFileName);

    string imageFileExtension = Path.GetExtension(item.PictureFileName);
    string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);

    var buffer = System.IO.File.ReadAllBytes(path);

    return File(buffer, mimetype);
}
```

There are two possible solutions to this problem. The first is to keep the functionality as it is, in which case rather than using `Server.MapPath` a fixed path referencing the image files' location in `wwwroot` should be used. Alternately, since the only purpose of this action method is to return a static image file, the references to this action in view files can be updated to reference the static files directly, which has the advantage of better runtime performance. Since no processing is being done as part of this action, there's no reason not to just serve the files directly. If it's not tenable to update all references to this action, the action could be rewritten to produce a redirect to the static file's location.

The next two errors both occur in the same private method in the same line of code:

```csharp
private void AddUriPlaceHolder(CatalogItem item)
{
    item.PictureUri = this.Url.RouteUrl(PicController.GetPicRouteName, new { catalogItemId = item.Id }, this.Request.Url.Scheme);
}
```

Both `this.Url` and `this.Request` cause compiler errors. Looking at how this code is used, its purpose is to build a link to the `PicController` action that renders image files. The same one we just discovered could probably be replace with direct links to the static files located in `wwwroot`. For now it's worth commenting this out and adding a `TODO:` comment to reference the pics another way.

 It's worth noting here that the base `Controller` class used by the `CatalogController` class in which this code appears is still referring to `System.Web.Mvc.Controller`. No doubt there will be more errors to fix once we update this to use ASP.NET Core. First, remove the `using System.Web.Mvc;` line from the list of using statements in `CatalogController`. Next, add the NuGet package `Microsoft.AspNetCore.Mvc`. Finally, add a new using statement, `using Microsoft.AspNetCore.Mvc;` and build the app again.

This time there are 16 errors:

- `Include` is not a valid named attribute argument (2)
- `HttpStatusCodeResult` not found (3)
- `HttpNotFound` does not exist (3)
- `SelectList` not found (8)

Once more let's review these errors one by one. First, `SelectList` can be fixed by adding `using Microsoft.AspNetCore.Mvc.Rendering;` which eliminates half of the errors.

All references to `return HttpNotFound();` should be replaced with `return NotFound();`.

All references to `return new HttpStatusCodeResult(HttpStatusCode.BadRequest);` should be replaced with `return BadRequest();`.

That just leaves the use of `Include` with a `Bind` attribute on a couple of action methods that look like this:

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PictureFileName,CatalogTypeId,CatalogBrandId,AvailableStock,RestockThreshold,MaxStockThreshold,OnReorder")] CatalogItem catalogItem)
{
```

The preceding code restricts model binding to the properties listed in the `Include` string. In ASP.NET Core MVC, the `Bind` attribute still exists, but no longer needs the `Include =` argument. Simply pass the list of properties directly to the `Bind` attribute:

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind("Id,Name,Description,Price,PictureFileName,CatalogTypeId,CatalogBrandId,AvailableStock,RestockThreshold,MaxStockThreshold,OnReorder")] CatalogItem catalogItem)
{
```

With these changes, the project compiles once more. Note that it's generally a better practice to use separate model types for controller inputs, rather than using model binding directly to your domain model or data model types.

## Migrate views

The two biggest ASP.NET Core MVC features related to views are [Razor Pages](https://docs.microsoft.com/aspnet/core/razor-pages/) and [Tag Helpers](https://docs.microsoft.com/aspnet/core/mvc/views/tag-helpers/built-in/). For the initial migration, we won't be leveraging either of these, but you should keep them mind if you intend to continue supporting the app once it's been migrated. The next step is simply to copy the `Views` folder from the original project into the new one. After building, there are nine errors.

- HttpContext does not exist (2)
- Scripts does not exist (5)
- Styles does not exist (1)
- HtmlString could not be found(1)

Investigating these errors finds that most of them are in the main `_Layout.cshtml`, with several related to rendering script and style tags, or displaying when the server hosting the app was last restarted. The following code listing shows problem areas in the `_Layout.cshtml` file:

```razor
// other lines omitted; only errors shown
@Styles.Render("~/Content/css")
@Scripts.Render("~/bundles/modernizr")

@{ var sessionInfo = new HtmlString($"{HttpContext.Current.Session["MachineName"]}, {HttpContext.Current.Session["SessionStartTime"]}");}

@Scripts.Render("~/bundles/jquery")
@Scripts.Render("~/bundles/bootstrap")
```

The reference to modernizr can be removed. The references to bootstrap and jquery can be replaced with CDN links to the appropriate version.

Replace `@Styles.Render` line with

```html
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
```

Replace the last two `Scripts.Render` lines with:

```html
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
```

Finally, after the bootstrap `<link>` add additional `<link>` elements for local styles your app uses. For eShop, the result is shown here:

```html
<link rel="stylesheet" href="~/Content/custom.css" />
<link rel="stylesheet" href="~/Content/base.css" />
<link rel="stylesheet" href="~/Content/Site.css" />
```

To determine the order in which these should appear, look at your original app's rendered HTML, or review `BundleConfig.cs`, which for the eShop sample includes this line of code indicating the appropriate sequence:

```csharp
bundles.Add(new StyleBundle("~/Content/css").Include(
          "~/Content/bootstrap.css",
          "~/Content/custom.css",
          "~/Content/base.css",
          "~/Content/site.css"));
```

Building again reveals one more error loading jQuery validation on the Create and Edit views. Replace it with this script:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.17.0/jquery.validate.min.js" integrity="sha512-O/nUTF5mdFkhEoQHFn9N5wmgYyW323JO6v8kr6ltSRKriZyTr/8417taVWeabVS4iONGk2V444QD0P2cwhuTkg==" crossorigin="anonymous"></script>
```

The last thing to fix in the views is the reference to `Session` to display how long the app has been running, and on which machine. We can collect the data for this in `Startup` as static variables and then display them on the layout page. Add these two properties to `Startup.cs`:

```csharp
public static DateTime StartTime { get; } = DateTime.UtcNow;
public static string MachineName { get; } = Environment.MachineName;
```

Then replace the content of the footer in the layout with code:

```razor
<section class="col-sm-6">
    <img class="esh-app-footer-text hidden-xs" src="~/images/main_footer_text.png" width="335" height="26" alt="footer text image" />
    <br />
<small>@eShopPorted.Startup.MachineName - @eShopPorted.Startup.StartTime.ToString() UTC</small>
</section>
```

At this point, the app once more builds successfully. However, trying to run it just yields "Hello World!" because the empty ASP.NET Core template is only configured to display that in response to any request. In the next section I complete the migration by configuring the app to use ASP.NET Core MVC, including dependency injection and configuration. Once that's in place, the app should run, and then it will be time to fix the `TODO:` tasks that were created earlier.

## Migrate app startup components

The last step in migrating is to take the app startup tasks from `Global.asax` and the classes it calls and migrate these to their ASP.NET Core equivalents. These include configuration of MVC itself, setting up dependency injection, and working with the new configuration system.

- Migrate Global.asax items
  - Show migrations for CORS, filters, route constraints, etc.
  - Show how to configure MVC with binders, formatters, areas, DI
- Migrate DI (if present previously)
  - Integrating Autofac with eShop and updating it for .NET Core
- Migrate configuration (web.config to appsettings.json etc.)
  - Show strategies to co-exist old and new config especially if needed by dependent (.NET Standard) libraries
  - Update framework features that depended on configuration (WCF client, tracing) to be configured in code instead
  
## Data access considerations

- Data access with EF
  - Migrating EF6 as-is
  - Pros and Cons of EF6 vs. EF Core
  - Upgrading to EF Core
- Discuss other data providers

## Fix all TODO tasks

## References

- [eShopModernizing GitHub repository](https://github.com/dotnet-architecture/eShopModernizing)
- [Your API and ViewModels Should Not Reference Domain Models](https://ardalis.com/your-api-and-view-models-should-not-reference-domain-models/)

>[!div class="step-by-step"]
>[Previous](strategies-migrating-in-production.md)
>[Next](deployment-scenarios.md)
