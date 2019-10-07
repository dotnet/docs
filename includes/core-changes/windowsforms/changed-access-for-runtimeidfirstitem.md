### Change of access for AccessibleObject.RuntimeIDFirstItem

Starting in .NET Core 3.0 RC1, the accessibility of `AccessibleObject.RuntimeIDFirstItem` has changed from `protected` to `internal`.

#### Change description

Starting with .NET Core 3.0 Preview 4, the `AccessibleObject.RuntimeIDFirstItem` field was `protected`. Starting with .NET Core 3.0 RC1, it has changed from `protected` to `internal` to align with the accessibility of the field in the .NET Framework.

#### Version introduced

3.0 RC1

#### Recommended action

The change can affect you if you've developed a .NET Core app with a type that derives from <xref:System.Windows.Forms.AccessibleObject> and accesses the `RuntimeIDFirstItem` field. If this is the case, you can define a local constant as follows:

```csharp
const int RuntimeIDFirstItem = 0x2a;
```

#### Category

Windows Forms

#### Affected APIs

- Not detectable via API analysis.

<!-- 

### Affected APIs

- Not detectable via API analysis.

-->
