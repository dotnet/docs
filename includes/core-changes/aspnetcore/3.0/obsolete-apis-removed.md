### Obsolete Antiforgery, CORS, Diagnostics, MVC, and Routing APIs removed

Items that were `Obsolete` or compatibility switches in ASP.NET Core 2.2 were removed.

#### Version introduced

3.0

#### Old behavior

APIs existed, but warned because they were obsolete.

#### New behavior

APIs no longer exist.

#### Reason for change

Improvement of API surface over time.

#### Recommended action

While targeting .NET Core 2.2, follow the guidance in the Obsolete build messages to adopt new APIs instead.

#### Category

ASP.NET Core

#### Affected APIs

All types and members that were marked `Obsolete` for 2.1 and 2.2.

##### Types

- `Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue`
- `Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView`
- `Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult`
- `Microsoft.AspNetCore.Diagnostics.Views.WelcomePage`
- `Microsoft.AspNetCore.Diagnostics.Views.AttributeValue`
- `Microsoft.AspNetCore.Diagnostics.Views.BaseView`
- `Microsoft.AspNetCore.Routing.IRouteValuesAddressMetadata`
- `Microsoft.AspNetCore.Routing.RouteValuesAddressMetadata`
- `Microsoft.AspNetCore.Mvc.Formatters.Xml.ProblemDetails21Wrapper`
- `Microsoft.AspNetCore.Mvc.Formatters.Xml.ValidationProblemDetails21Wrapper`
- `Microsoft.AspNetCore.Mvc.Razor.Compilation.ViewsFeatureProvider`
- `Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.PageArgumentBinder`
- `Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.DefaultPageArgumentBinder`

##### Properties and methods

- `Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.CookieName { get; set; }`
- `Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.CookiePath { get; set; }`
- `Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.CookieDomain { get; set; }`
- `Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions.RequireSsl { get; set; }`
- `Microsoft.AspNetCore.Cors.CorsService.ctor(IOptions<CorsService> options)`
- `Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.ctor(ILoggerFactory, UrlEncoder, ObjectPool<UriBuildingContext>, IInlineConstraintResolver )`
- `Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext.OutputFormatterCanWriteContext()`
- `Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider.ctor(IOptions<MvcOptions> optionsAccessor, IInlineConstraintResolver constraintResolver, IModelMetadataProvider modelMetadataProvider);`
- `Microsoft.AspNetCore.Mvc.ApiExplorer.DefaultApiDescriptionProvider.ctor(IOptions<MvcOptions> optionsAccessor, IInlineConstraintResolver constraintResolver, IModelMetadataProvider modelMetadataProvider, IActionResultTypeMapper mapper)`
- `Microsoft.AspNetCore.Mvc.Formatters.FormatFilter.ctor(IOptions<MvcOptions> options)`
- `Microsoft.AspNetCore.Mvc.LocalRedirectResult.ExecuteResult(ActionContext context)`
- `Microsoft.AspNetCore.Mvc.RedirectResult.ExecuteResult(ActionContext context)`
- `Microsoft.AspNetCore.Mvc.RedirectToActionResult.ExecuteResult(ActionContext context)`
- `Microsoft.AspNetCore.Mvc.RedirectToPageResult.ExecuteResult(ActionContext context)`
- `Microsoft.AspNetCore.Mvc.RedirectToRouteResult.ExecuteResult(ActionContext context)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder.ctor(IModelBinder elementBinder)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ByteArrayModelBinder.ctor()`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder.ctor()`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ComplexTypeModelBinder.ctor(IDictionary<ModelMetadata, IModelBinder> propertyBinders)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DictionaryModelBinder.ctor(IModelBinder keyBinder, IModelBinder valueBinder)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.DoubleModelBinder.ctor(NumberStyles supportedStyles)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.FloatModelBinder.ctor(NumberStyles supportedStyles)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.FormCollectionModelBinder.ctor()`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.FormFileModelBinder.ctor()`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.HeaderModelBinder.ctor()`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.KeyValuePairModelBinder.ctor(IModelBinder keyBinder, IModelBinder valueBinder)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder.ctor(Type type)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.ctor(IEnumerable<object> typeAttributes)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.ctor(IEnumerable<object> propertyAttributes, IEnumerable<object> typeAttributes)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderFactory.ctor(IModelMetadataProvider metadataProvider, IOptions<MvcOptions> options)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.ParameterBinder.ctor(IModelMetadataProvider modelMetadataProvider, IModelBinderFactory modelBinderFactory, IObjectModelValidator validator)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.ParameterBinder.BindModelAsync(ActionContext actionContext, IValueProvider valueProvider, ParameterDescriptor parameter)`
- `Microsoft.AspNetCore.Mvc.ModelBinding.ParameterBinder.BindModelAsync(ActionContext actionContext, IValueProvider valueProvider, ParameterDescriptor parameter, object value)`
- `Microsoft.AspNetCore.Mvc.Routing.KnownRouteValueConstraint.ctor()`
- `Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerInputFormatter.ctor()`
- `Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerInputFormatter.ctor(bool suppressInputFormatterBuffering)`
- `Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerInputFormatter.ctor(MvcOptions options)`
- `Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerInputFormatter.ctor()`
- `Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerInputFormatter.ctor(bool suppressInputFormatterBuffering)`
- `Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerInputFormatter.ctor(MvcOptions options)`
- `Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.ctor(IHostingEnvironment hostingEnvironment, IMemoryCache cache, HtmlEncoder htmlEncoder, IUrlHelperFactory urlHelperFactory)`
- `Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper.ctor(IHostingEnvironment hostingEnvironment, IMemoryCache cache, HtmlEncoder htmlEncoder, JavaScriptEncoder javaScriptEncoder, IUrlHelperFactory urlHelperFactory)`
- `Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper.ctor(IHostingEnvironment hostingEnvironment, IMemoryCache cache, HtmlEncoder htmlEncoder, JavaScriptEncoder javaScriptEncoder, IUrlHelperFactory urlHelperFactory)`
- `Microsoft.AspNetCore.Mvc.CookieTempDataProviderOptions.Path { get; set; }`
- `Microsoft.AspNetCore.Mvc.CookieTempDataProviderOptions.Domain { get; set; }`
- `Microsoft.AspNetCore.Mvc.CookieTempDataProviderOptions.CookieName { get; set; }`
- `Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAdapter.ctor(RazorPageBase page)`
- `Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressUseValidationProblemDetailsForInvalidModelStateResponses { get; set; }`
- `Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.AllowInferringBindingSourceForCollectionTypesAsFromQuery { get; set; }`
- `Microsoft.AspNetCore.Mvc.ApplicationModels.InferParameterBindingInfoConvention.AllowInferringBindingSourceForCollectionTypesAsFromQuery { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcOptions.AllowCombiningAuthorizeFilters { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcOptions.AllowBindingHeaderValuesToNonStringModelTypes { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcOptions.AllowValidatingTopLevelNodes { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcOptions.InputFormatterExceptionPolicy { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcOptions.SuppressBindingUndefinedValueToEnumType { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcOptions.AllowShortCircuitingValidationWhenNoValidatorsArePresent { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcDataAnnotationsLocalizationOptions.AllowDataAnnotationsLocalizationForEnumDisplayAttributes { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcXmlOptions.AllowRfc7807CompliantProblemDetailsFormat { get; set; }`
- `Microsoft.AspNetCore.Mvc.RazorPages.RazorPagesOptions.AllowAreas { get; set; }`
- `Microsoft.AspNetCore.Mvc.RazorPages.RazorPagesOptions.AllowMappingHeadRequestsToGetHandler { get; set; }`
- `Microsoft.AspNetCore.Mvc.RazorPages.RazorPagesOptions.AllowDefaultHandlingForOptionsRequests { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcViewOptions.SuppressTempDataAttributePrefix { get; set; }`
- `Microsoft.AspNetCore.Mvc.MvcViewOptions.AllowRenderingMaxLengthAttribute { get; set; }`

<!--

#### Affected APIs



-->