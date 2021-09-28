---
title: "Breaking change: WinForms objects not accessible from native code"
description: Learn about the breaking change in .NET 5 where Windows Forms objects are no longer accessible from native code.
ms.date: 01/29/2021
---
# Native code can't access Windows Forms objects

Starting in .NET 5, you can no longer access Windows Forms objects from native code.

## Change description

In previous .NET versions, some Windows Forms types were decorated as visible to COM interop, and thus were accessible to native code. Starting in .NET 5, no Windows Forms API are visible to COM interop or accessible to native code. The .NET runtime no longer supports creating custom type libraries out of the box. In addition, the .NET runtime can't depend on the type library for .NET Framework (which would require maintaining the shape of classes as they were in .NET Framework).

## Reason for change

- Removal of `ComVisible(true)` from enumerations that were used for type library (TLB file) generation and lookup: Since there is no WinForms TLB provided by .NET Core, there's no value in keeping this attribute.
- Removal of `ComVisible(true)` from `AccessibleObject` classes: The classes are not CoCreateable (they have no parameterless constructor), and exposing an already existing instance to COM does not require that attribute.
- Removal of `ComVisible(true)` from `Control` and `Component` classes: This was used to allow hosting of WinForms controls via OLE/ActiveX, for example in VB6 or MFC. However, this requires a TLB for WinForms, which is no longer provided, as well as registry-based activation, which also would not work out of the box. Generally, there was no maintenance of COM-based hosting of WinForms controls, so support was removed instead of leaving it in an unsupported state.
- Removal of `ClassInterface` attributes from controls: If hosting via OLE/ActiveX is not supported, these attributes aren't needed anymore. They are kept in other places where objects are still exposed to COM and the attribute may be relevant.
- Removal of `ComVisible(true)` from `EventArgs`: They were most likely used with OLE/ActiveX hosting, which is no longer supported. They are not CoCreateable either, so the attribute has no purpose. Also, exposing existing instances without providing a TLB makes no sense.
- Removal of `ComVisible(true)` from delegates: Purpose is unknown, but since ActiveX hosting of WinForms Controls is no longer supported, it's unlikely to have any usefulness.
- Removal of `ComVisible(true)` from some non-public code: The only potential consumer would be the new Visual Studio designer, but without a GUID specified, it's unlikely that it's still needed.
- Removal of `ComVisible(true)` from some arbitrary public designer classes: The old Visual Studio designer may have been using COM interop to talk to these classes. However, the old designer doesn't support .NET Core, so few people would need these as `ComVisible`.
- `IWin32Window` defined the same GUID that was defined in .NET Framework, which has dangerous consequences. If you require interop with .NET Framework, use `ComImport`.
- The WinForms managed `IDataObject` was made `ComVisible`. This is not required, there is a separate `ComImport` interface declaration for `IDataObject` COM interop. It's counterproductive to have the managed `IDataObject` be `ComVisible`, since no TLB is provided and marshaling will always fail. Also, the GUID was not specified and differed from .NET Framework, so its unlikely that removing an undocumented IID will affect customers negatively.
- Removal of `ComVisible(false)`: Those are placed in seemingly arbitrary places and are redundant when the default is to not expose classes to COM interop.

## Version introduced

.NET 5.0

## Recommended action

The following example works on .NET Framework and .NET Core 3.1. This example relies on the .NET Framework type library, which allows the JavaScript to call back into the form subclass via reflection.

```cs
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
[System.Runtime.InteropServices.ComVisibleAttribute(true)]
public class Form1 : Form
{
    private WebBrowser webBrowser1 = new WebBrowser();

    protected override void OnLoad(EventArgs e)
    {
        webBrowser1.AllowWebBrowserDrop = false;
        webBrowser1.IsWebBrowserContextMenuEnabled = false;
        webBrowser1.WebBrowserShortcutsEnabled = false;
        webBrowser1.ObjectForScripting = this;

        webBrowser1.DocumentText =
            "<html><body><button " +
            "onclick=\"window.external.Test('called from script code')\">" +
            "call client code from script code</button>" +
            "</body></html>";
    }

    public void Test(String message)
    {
        MessageBox.Show(message, "client code");
    }
}
```

There are two possible ways to make the example work on .NET 5 and later versions:

- Introduce a user-declared `ObjectForScripting` object that supports `IDispatch` (which is applied by default, unless changed explicitly at the project level).

  ```cs
  public class MyScriptObject
  {
      private Form1 _form;

      public MyScriptObject(Form1 form)
      {
          _form = form;
      }

      public void Test(string message)
      {
          MessageBox.Show(message, "client code");
      }
  }

  public partial class Form1 : Form
  {
      protected override void OnLoad(EventArgs e)
      {
          ...

          // Works correctly.
          webBrowser1.ObjectForScripting = new MyScriptObject(this);

          ...
      }
  }
  ```

- Declare an interface with the methods to expose.

  ```cs
  public interface IForm1
  {
      void Test(string message);
  }

  [ComDefaultInterface(typeof(IForm1))]
  public partial class Form1 : Form, IForm1
  {
      protected override void OnLoad(EventArgs e)
      {
          ...

          // Works correctly.
          webBrowser1.ObjectForScripting = this;

          ...
      }
  }
  ```

## Affected APIs

All Windows Forms APIs.

<!--

### Category

- Windows Forms

-->
