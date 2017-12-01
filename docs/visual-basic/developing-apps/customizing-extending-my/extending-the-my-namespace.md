---
title: "Extending the My Namespace in Visual Basic"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.AddingMyExtensions"
helpviewer_keywords: 
  - "My namespace [Visual Basic], customizing"
  - "My namespace"
  - "My namespace [Visual Basic], extending"
ms.assetid: 808e8617-b01c-4135-8b21-babe87389e8e
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Extending the My Namespace in Visual Basic
The `My` namespace in Visual Basic exposes properties and methods that enable you to easily take advantage of the power of the .NET Framework. The `My` namespace simplifies common programming problems, often reducing a difficult task to a single line of code. Additionally, the `My` namespace is fully extensible so that you can customize the behavior of `My` and add new services to its hierarchy to adapt to specific application needs. This topic discusses both how to customize existing members of the `My` namespace and how to add your own custom classes to the `My` namespace.  
  
 **Topic Contents**  
  
-   [Customizing Existing My Namespace Members](#customizing)  
  
-   [Adding Members to My Objects](#addingtoobjects)  
  
-   [Adding Custom Objects to the My Namespace](#addingcustom)  
  
-   [Adding Members to the My Namespace](#addingtonamespace)  
  
-   [Adding Events to Custom My Objects](#addingevents)  
  
-   [Design Guidelines](#design)  
  
-   [Designing Class Libraries for My](#designing)  
  
-   [Packaging and Deploying Extensions](#packaging)  
  
##  <a name="customizing"></a> Customizing Existing My Namespace Members  
 The `My` namespace in Visual Basic exposes frequently used information about your application, your computer, and more. For a complete list of the objects in the `My` namespace, see [My Reference](../../../visual-basic/language-reference/keywords/my-reference.md). You may have to customize existing members of the `My` namespace so that they better match the needs of your application. Any property of an object in the `My` namespace that is not read-only can be set to a custom value.  
  
 For example, assume that you frequently use the `My.User` object to access the current security context for the user running your application. However, your company uses a custom user object to expose additional information and capabilities for users within the company. In this scenario, you can replace the default value of the `My.User.CurrentPrincipal` property with an instance of your own custom principal object, as shown in the following example.  
  
 [!code-vb[VbVbcnExtendingMy#1](../../../visual-basic/developing-apps/customizing-extending-my/codesnippet/VisualBasic/extending-the-my-namespace_1.vb)]  
  
 Setting the `CurrentPrincipal` property on the `My.User` object changes the identity under which the application runs. The `My.User` object, in turn, returns information about the newly specified user.  
  
##  <a name="addingtoobjects"></a> Adding Members to My Objects  
 The types returned from `My.Application` and `My.Computer` are defined as `Partial` classes. Therefore, you can extend the `My.Application` and `My.Computer` objects by creating a `Partial` class named `MyApplication` or `MyComputer`. The class cannot be a `Private` class. If you specify the class as part of the `My` namespace, you can add properties and methods that will be included with the `My.Application` or `My.Computer` objects.  
  
 For example, the following example adds a property named `DnsServerIPAddresses` to the `My.Computer` object.  
  
 [!code-vb[VbVbcnExtendingMy#2](../../../visual-basic/developing-apps/customizing-extending-my/codesnippet/VisualBasic/extending-the-my-namespace_2.vb)]  
  
##  <a name="addingcustom"></a> Adding Custom Objects to the My Namespace  
 Although the `My` namespace provides solutions for many common programming tasks, you may encounter tasks that the `My` namespace does not address. For example, your application might access custom directory services for user data, or your application might use assemblies that are not installed by default with Visual Basic. You can extend the `My` namespace to include custom solutions to common tasks that are specific to your environment. The `My` namespace can easily be extended to add new members to meet growing application needs. Additionally, you can deploy your `My` namespace extensions to other developers as a Visual Basic template.  
  
###  <a name="addingtonamespace"></a> Adding Members to the My Namespace  
 Because `My` is a namespace like any other namespace, you can add top-level properties to it by just adding a module and specifying a `Namespace` of `My`. Annotate the module with the `HideModuleName` attribute as shown in the following example. The `HideModuleName` attribute ensures that IntelliSense will not display the module name when it displays the members of the `My` namespace.  
  
 [!code-vb[VbVbcnExtendingMy#3](../../../visual-basic/developing-apps/customizing-extending-my/codesnippet/VisualBasic/extending-the-my-namespace_3.vb)]  
  
 To add members to the `My` namespace, add properties as needed to the module. For each property added to the `My` namespace, add a private field of type `ThreadSafeObjectProvider(Of T)`, where the type is the type returned by your custom property. This field is used to create thread-safe object instances to be returned by the property by calling the `GetInstance` method. As a result, each thread that is accessing the extended property receives its own instance of the returned type. The following example adds a property named `SampleExtension` that is of type `SampleExtension` to the `My` namespace:  
  
 [!code-vb[VbVbcnExtendingMy#4](../../../visual-basic/developing-apps/customizing-extending-my/codesnippet/VisualBasic/extending-the-my-namespace_4.vb)]  
  
##  <a name="addingevents"></a> Adding Events to Custom My Objects  
 You can use the `My.Application` object to expose events for your custom `My` objects by extending the `MyApplication` partial class in the `My` namespace. For Windows-based projects, you can double-click the **My Project** node in for your project in **Solution Explorer**. In the Visual Basic **Project Designer**, click the `Application` tab and then click the `View Application Events` button. A new file that is named ApplicationEvents.vb will be created. It contains the following code for extending the `MyApplication` class.  
  
 [!code-vb[VbVbcnExtendingMy#5](../../../visual-basic/developing-apps/customizing-extending-my/codesnippet/VisualBasic/extending-the-my-namespace_5.vb)]  
  
 You can add event handlers for your custom `My` objects by adding custom event handlers to the `MyApplication` class. Custom events enable you to add code that will execute when an event handler is added, removed, or the event is raised. Note that the `AddHandler` code for a custom event runs only if code is added by a user to handle the event. For example, consider that the `SampleExtension` object from the previous section has a `Load` event that you want to add a custom event handler for. The following code example shows a custom event handler named `SampleExtensionLoad` that will be invoked when the `My.SampleExtension.Load` event occurs. When code is added to handle the new `My.SampleExtensionLoad` event, the `AddHandler` part of this custom event code is executed. The `MyApplication_SampleExtensionLoad` method is included in the code example to show an example of an event handler that handles the `My.SampleExtensionLoad` event. Note that the `SampleExtensionLoad` event will be available when you select the **My Application Events** option in the left drop-down list above the Code Editor when you are editing the ApplicationEvents.vb file.  
  
 [!code-vb[VbVbcnExtendingMy#6](../../../visual-basic/developing-apps/customizing-extending-my/codesnippet/VisualBasic/extending-the-my-namespace_6.vb)]  
  
##  <a name="design"></a> Design Guidelines  
 When you develop extensions to the `My` namespace, use the following guidelines to help minimize the maintenance costs of your extension components.  
  
-   **Include only the extension logic.** The logic included in the `My` namespace extension should include only the code that is needed to expose the required functionality in the `My` namespace. Because your extension will reside in user projects as source code, updating the extension component incurs a high maintenance cost and should be avoided if possible.  
  
-   **Minimize project assumptions.** When you create your extensions of the `My` namespace, do not assume a set of references, project-level imports, or specific compiler settings (for example, `Option Strict` off). Instead, minimize dependencies and fully qualify all type references by using the `Global` keyword. Also, ensure that the extension compiles with `Option Strict` on to minimize errors in the extension.  
  
-   **Isolate the extension code.** Placing the code in a single file makes your extension easily deployable as a Visual Studio item template. For more information, see "Packaging and Deploying Extensions" later in this topic. Placing all the `My` namespace extension code in a single file or a separate folder in a project will also help users locate the `My` namespace extension.  
  
##  <a name="designing"></a> Designing Class Libraries for My  
 As is the case with most object models, some design patterns work well in the `My` namespace and others do not. When designing an extension to the `My` namespace, consider the following principles:  
  
-   **Stateless methods.** Methods in the `My` namespace should provide a complete solution to a specific task. Ensure that the parameter values that are passed to the method provide all the input required to complete the particular task. Avoid creating methods that rely on prior state, such as open connections to resources.  
  
-   **Global instances.** The only state that is maintained in the `My` namespace is global to the project. For example, `My.Application.Info` encapsulates state that is shared throughout the application.  
  
-   **Simple parameter types.** Keep things simple by avoiding complex parameter types. Instead, create methods that either take no parameter input or that take simple input types such as strings, primitive types, and so on.  
  
-   **Factory methods.** Some types are necessarily difficult to instantiate. Providing factory methods as extensions to the `My` namespace enables you to more easily discover and consume types that fall into this category. An example of a factory method that works well is `My.Computer.FileSystem.OpenTextFileReader`. There are several stream types available in the .NET Framework. By specifying text files specifically, the `OpenTextFileReader` helps the user understand which stream to use.  
  
 These guidelines do not preclude general design principles for class libraries. Rather, they are recommendations that are optimized for developers who are using Visual Basic and the `My` namespace. For general design principles for creating class libraries, see [Framework Design Guidelines](../../../standard/design-guidelines/index.md).  
  
##  <a name="packaging"></a> Packaging and Deploying Extensions  
 You can include `My` namespace extensions in a Visual Studio project template, or you can package your extensions and deploy them as a Visual Studio item template. When you package your `My` namespace extensions as a Visual Studio item template, you can take advantage of additional capabilities provided by Visual Basic. These capabilities enable you to include an extension when a project references a particular assembly, or enable users to explicitly add your `My` namespace extension by using the **My Extensions** page of the Visual Basic Project Designer.  
  
 For details about how to deploy `My` namespace extensions, see [Packaging and Deploying Custom My Extensions](../../../visual-basic/developing-apps/customizing-extending-my/packaging-and-deploying-custom-my-extensions.md).  
  
## See Also  
 [Packaging and Deploying Custom My Extensions](../../../visual-basic/developing-apps/customizing-extending-my/packaging-and-deploying-custom-my-extensions.md)  
 [Extending the Visual Basic Application Model](../../../visual-basic/developing-apps/customizing-extending-my/extending-the-visual-basic-application-model.md)  
 [Customizing Which Objects are Available in My](../../../visual-basic/developing-apps/customizing-extending-my/customizing-which-objects-are-available-in-my.md)  
 [My Extensions Page, Project Designer](/visualstudio/ide/reference/my-extensions-page-project-designer-visual-basic)  
 [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic)  
 [Partial](../../../visual-basic/language-reference/modifiers/partial.md)
