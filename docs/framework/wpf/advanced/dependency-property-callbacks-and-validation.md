---
title: "Dependency Property Callbacks and Validation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dependency properties [WPF], validation"
  - "coerce value callbacks [WPF]"
  - "callbacks [WPF], validation"
  - "dependency properties [WPF], callbacks"
  - "validation of dependency properties [WPF]"
ms.assetid: 48db5fb2-da7f-49a6-8e81-3540e7b25825
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Dependency Property Callbacks and Validation
This topic describes how to create dependency properties using alternative custom implementations for property-related features such as validation determination, callbacks that are invoked whenever the property's effective value is changed, and overriding possible outside influences on value determination. This topic also discusses scenarios where expanding on the default property system behaviors by using these techniques is appropriate.  
  
  
  
<a name="prerequisites"></a>   
## Prerequisites  
 This topic assumes that you understand the basic scenarios of implementing a dependency property, and how metadata is applied to a custom dependency property. See [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md) and [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md) for context.  
  
<a name="Validation_Callbacks"></a>   
## Validation Callbacks  
 Validation callbacks can be assigned to a dependency property when you first register it. The validation callback is not part of property metadata; it is a direct input of the <xref:System.Windows.DependencyProperty.Register%2A> method. Therefore, once a validation callback is created for a dependency property, it cannot be overridden by a new implementation.  
  
 [!code-csharp[DPCallbackOverride#CurrentDefinitionWithWrapper](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DPCallbackOverride/CSharp/SDKSampleLibrary/class1.cs#currentdefinitionwithwrapper)]
 [!code-vb[DPCallbackOverride#CurrentDefinitionWithWrapper](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DPCallbackOverride/visualbasic/sdksamplelibrary/class1.vb#currentdefinitionwithwrapper)]  
  
 The callbacks are implemented such that they are provided an object value. They return `true` if the provided value is valid for the property; otherwise, they return `false`. It is assumed that the property is of the correct type per the type registered with the property system, so checking type within the callbacks is not ordinarily done. The callbacks are used by the property system in a variety of different operations. This includes the initial type initialization by default value, programmatic change by invoking <xref:System.Windows.DependencyObject.SetValue%2A>, or attempts to override metadata with new default value provided. If the validation callback is invoked by any of these operations, and returns `false`, then an exception will be raised. Application writers must be prepared to handle these exceptions. A common use of validation callbacks is validating enumeration values, or constraining values of integers or doubles when the property sets measurements that must be zero or greater.  
  
 Validation callbacks specifically are intended to be class validators, not instance validators. The parameters of the callback do not communicate a specific <xref:System.Windows.DependencyObject> on which the properties to validate are set. Therefore the validation callbacks are not useful for enforcing the possible "dependencies" that might influence a property value, where the instance-specific value of a property is dependent on factors such as instance-specific values of other properties, or run-time state.  
  
 The following is example code for a very simple validation callback scenario: validating that a property that is typed as the <xref:System.Double> primitive is not <xref:System.Double.PositiveInfinity> or <xref:System.Double.NegativeInfinity>.  
  
 [!code-csharp[DPCallbackOverride#ValidateValueCallback](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DPCallbackOverride/CSharp/SDKSampleLibrary/class1.cs#validatevaluecallback)]
 [!code-vb[DPCallbackOverride#ValidateValueCallback](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DPCallbackOverride/visualbasic/sdksamplelibrary/class1.vb#validatevaluecallback)]  
  
<a name="Coerce_Value_Callbacks_and_Property_Changed_Events"></a>   
## Coerce Value Callbacks and Property Changed Events  
 Coerce value callbacks do pass the specific <xref:System.Windows.DependencyObject> instance for properties, as do <xref:System.Windows.PropertyChangedCallback> implementations that are invoked by the property system whenever the value of a dependency property changes. Using these two callbacks in combination, you can create a series of properties on elements where changes in one property will force a coercion or reevaluation of another property.  
  
 A typical scenario for using a linkage of dependency properties is when you have a user interface driven property where the element holds one property each for the minimum and maximum value, and a third property for the actual or current value. Here, if the maximum was adjusted in such a way that the current value exceeded the new maximum, you would want to coerce the current value to be no greater than the new maximum, and a similar relationship for minimum to current.  
  
 The following is very brief example code for just one of the three dependency properties that illustrate this relationship. The example shows how the `CurrentReading` property of a Min/Max/Current set of related *Reading properties is registered. It uses the validation as shown in the previous section.  
  
 [!code-csharp[DPCallbackOverride#CurrentDefinitionWithWrapper](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DPCallbackOverride/CSharp/SDKSampleLibrary/class1.cs#currentdefinitionwithwrapper)]
 [!code-vb[DPCallbackOverride#CurrentDefinitionWithWrapper](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DPCallbackOverride/visualbasic/sdksamplelibrary/class1.vb#currentdefinitionwithwrapper)]  
  
 The property changed callback for Current is used to forward the change to other dependent properties, by explicitly invoking the coerce value callbacks that are registered for those other properties:  
  
 [!code-csharp[DPCallbackOverride#OnPCCurrent](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DPCallbackOverride/CSharp/SDKSampleLibrary/class1.cs#onpccurrent)]
 [!code-vb[DPCallbackOverride#OnPCCurrent](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DPCallbackOverride/visualbasic/sdksamplelibrary/class1.vb#onpccurrent)]  
  
 The coerce value callback checks the values of properties that the current property is potentially dependent upon, and coerces the current value if necessary:  
  
 [!code-csharp[DPCallbackOverride#CoerceCurrent](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DPCallbackOverride/CSharp/SDKSampleLibrary/class1.cs#coercecurrent)]
 [!code-vb[DPCallbackOverride#CoerceCurrent](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DPCallbackOverride/visualbasic/sdksamplelibrary/class1.vb#coercecurrent)]  
  
> [!NOTE]
>  Default values of properties are not coerced. A property value equal to the default value might occur if a property value still has its initial default, or through clearing other values with <xref:System.Windows.DependencyObject.ClearValue%2A>.  
  
 The coerce value and property changed callbacks are part of property metadata. Therefore, you can change the callbacks for a particular dependency property as it exists on a type that you derive from the type that owns the dependency property, by overriding the metadata for that property on your type.  
  
<a name="Advanced"></a>   
## Advanced Coercion and Callback Scenarios  
  
### Constraints and Desired Values  
 The <xref:System.Windows.PropertyMetadata.CoerceValueCallback%2A> callbacks will be used by the property system to coerce a value in accordance to the logic you declare, but a coerced value of a locally set property will still retain a "desired value" internally. If the constraints are based on other property values that may change dynamically during the application lifetime, the coercion constraints are changed dynamically also, and the constrained property can change its value to get as close to the desired value as possible given the new constraints. The value will become the desired value if all constraints are lifted. You can potentially introduce some fairly complicated dependency scenarios if you have multiple properties that are dependent on one another in a circular manner. For instance, in the Min/Max/Current scenario, you could choose to have Minimum and Maximum be user settable. If so, you might need to coerce that Maximum is always greater than Minimum and vice versa. But if that coercion is active, and Maximum coerces to Minimum, it leaves Current in an unsettable state, because it is dependent on both and is constrained to the range between the values, which is zero. Then, if Maximum or Minimum are adjusted, Current will seem to "follow" one of the values, because the desired value of Current is still stored and is attempting to reach the desired value as the constraints are loosened.  
  
 There is nothing technically wrong with complex dependencies, but they can be a slight performance detriment if they require large numbers of reevaluations, and can also be confusing to users if they affect the UI directly. Be careful with property changed and coerce value callbacks and make sure that the coercion being attempted can be treated as unambiguously as possible, and does not "overconstrain".  
  
### Using CoerceValue to Cancel Value Changes  
 The property system will treat any <xref:System.Windows.CoerceValueCallback> that returns the value <xref:System.Windows.DependencyProperty.UnsetValue> as a special case. This special case means that the property change that resulted in the <xref:System.Windows.CoerceValueCallback> being called should be rejected by the property system, and that the property system should instead report whatever previous value the property had. This mechanism can be useful to check that changes to a property that were initiated asynchronously are still valid for the current object state, and suppress the changes if not. Another possible scenario is that you can selectively suppress a value depending on which component of property value determination is responsible for the value being reported. To do this, you can use the <xref:System.Windows.DependencyProperty> passed in the callback and the property identifier as input for <xref:System.Windows.DependencyPropertyHelper.GetValueSource%2A>, and then process the <xref:System.Windows.ValueSource>.  
  
## See Also  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md)  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)
