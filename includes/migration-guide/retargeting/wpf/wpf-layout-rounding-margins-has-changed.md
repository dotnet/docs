### WPF layout rounding of margins has changed

#### Details

The way in which margins are rounded and borders and the background inside of them has changed. As a result of this change:

- The width or height of elements may grow or shrink by at most one pixel.
- The placement of an object can move by at most one pixel.
- Centered elements can be vertically or horizontally off center by at most one pixel.
By default, this new layout is enabled only for apps that target the .NET Framework 4.6.

#### Suggestion

Since this modification tends to eliminate clipping of the right or bottom of WPF controls at high DPIs, apps that target earlier versions of the .NET Framework but are running on the .NET Framework 4.6 can opt into this new behavior by adding the following line to the `<runtime>` section of the app.config file:

```xml
<AppContextSwitchOverrides value==Switch.MS.Internal.DoNotApplyLayoutRoundingToMarginsAndBorderThickness=false= />&#39;
```

Apps that target the .NET Framework 4.6 but want WPF controls to render using the previous layout algorithm can do so by adding the following line to the `<runtime>` section of the app.config file:

```xml
<AppContextSwitchOverrides value==Switch.MS.Internal.DoNotApplyLayoutRoundingToMarginsAndBorderThickness=true= />&#39;.
```

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.6         |
| Type    | Retargeting |
