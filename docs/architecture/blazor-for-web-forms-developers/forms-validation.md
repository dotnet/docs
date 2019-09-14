---
title: Forms and validation
description: Build forms with client-side validation in Blazor.
author: danroth27
ms.author: daroth
ms.date: 09/19/2019
---

# Forms and validation

ASP.NET Web Forms includes a set of validation server controls that handle validating user input entered into a form (`RequiredFieldValidator`, `CompareValidator`, `RangeValidator`, and so on). ASP.NET Web Forms also supports model binding and validating the model based on data annotations (`[Required]`, `[StringLength]`, `[Range]`, and so on). The validation logic can be enforced both on the server and on the client using unobtrusive JavaScript-based validation. The `ValidationSummary` server control makes it easy to display a summary of the validation errors to the user.

One of the benefits of Blazor is that validation logic can be shared between both the client and the server. While ASP.NET provides pre-built JavaScript implementations of many common server validations, in many cases the developer still has to resort to writing JavaScript to fully implement their app-specific validation logic. In Blazor apps, the same model types, data annotations, and validation logic can be used on both the server and client.

Blazor provides a set of input components that handle binding field data to a model and validating the user input when the form is submitted.

Input component | Rendered as
--- | ---
`InputText` | `<input>`
`InputTextArea` | `<textarea>`
`InputSelect` | `<select>`
`InputNumber` | `<input type="number">`
`InputCheckbox` | `<input type="checkbox">`
`InputDate` | `<input type="date">`

The `EditForm` component wraps these input components and orchestrates the validation process through a `EditContext`. When creating an `EditForm` you specify what model instance to bind to using the `Model` parameter. How validation is performed is extensible, but is typically done using data annotations. To enable data annotation-based validation, add the `DataAnnotationsValidator` component as a child of the `EditForm`. The `EditForm` component provides convenient event for handling valid (`OnValidSubmit`) and invalid (`OnInvalidSubmit`) submits, as well as a more generic `OnSubmit` event that lets you trigger and handle the validation yourself.

To display a validation error summary, use the `ValidationSummary` component. To display validation messages for a specific input field, use the `ValidationMessage` component specifying a lambda expression for the `For` parameter that points to the desired model member.

The following model type defines a variety of validation rules using data annotations:

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class Starship
{
    [Required]
    [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
    public string Identifier { get; set; }

    public string Description { get; set; }

    [Required]
    public string Classification { get; set; }

    [Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
    public int MaximumAccommodation { get; set; }

    [Required]
    [Range(typeof(bool), "true", "true", 
        ErrorMessage = "This form disallows unapproved ships.")]
    public bool IsValidatedDesign { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }
}
```

The following component demonstrates building a form in Blazor based on the `Starship` model type:

```razor
<h1>New Ship Entry Form</h1>

<EditForm Model="@starship" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <p>
        <label for="identifier">Identifier: </label>
        <InputText id="identifier" @bind-Value="starship.Identifier" />
    </p>
    <p>
        <label for="description">Description (optional): </label>
        <InputTextArea id="description" @bind-Value="starship.Description" />
    </p>
    <p>
        <label for="classification">Primary Classification: </label>
        <InputSelect id="classification" @bind-Value="starship.Classification">
            <option value="">Select classification ...</option>
            <option value="Exploration">Exploration</option>
            <option value="Diplomacy">Diplomacy</option>
            <option value="Defense">Defense</option>
        </InputSelect>
    </p>
    <p>
        <label for="accommodation">Maximum Accommodation: </label>
        <InputNumber id="accommodation" 
            @bind-Value="starship.MaximumAccommodation" />
    </p>
    <p>
        <label for="valid">Engineering Approval: </label>
        <InputCheckbox id="valid" @bind-Value="starship.IsValidatedDesign" />
    </p>
    <p>
        <label for="productionDate">Production Date: </label>
        <InputDate id="productionDate" @bind-Value="starship.ProductionDate" />
    </p>

    <button type="submit">Submit</button>
</EditForm>

@code {
    private Starship starship = new Starship();

    private void HandleValidSubmit()
    {
        // Save the data
    }
}
```

After the form is successfully submitted, the model bound data still hasn't been saved to any data store, like a database. In a Blazor WebAssembly app, the data must still be sent to the server (using an HTTP POST request for example). In a Blazor Server app, the data is already on the server, but it must still be persisted. Handling data access in Blazor apps is the subject of the [Dealing with data](data.md) section.

## Addition resources

For more information on [forms and validation](/aspnet/core/blazor/forms-validation) in Blazor apps, see the Blazor documentation.
