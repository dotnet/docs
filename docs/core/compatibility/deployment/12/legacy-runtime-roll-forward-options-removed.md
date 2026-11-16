---
title: "Breaking change: `rollForwardOnNoCandidateFx` and `applyPatches` no longer supported"
description: "Learn about the breaking change in .NET 12 where legacy runtime roll-forward settings are no longer supported."
ms.date: 10/13/2026
ai-usage: ai-assisted
---

# `rollForwardOnNoCandidateFx` and `applyPatches` no longer supported

The .NET host no longer supports the `rollForwardOnNoCandidateFx` and `applyPatches` runtime configuration settings. The host also no longer supports the `--roll-forward-on-no-candidate-fx` command-line option or the `DOTNET_ROLL_FORWARD_ON_NO_CANDIDATE_FX` environment variable.

## Version introduced

.NET 12 Preview 1

## Previous behavior

Previously, `rollForwardOnNoCandidateFx` controlled framework roll-forward. A value of `0` allowed roll-forward to the latest patch, `1` allowed roll-forward to a minor version, and `2` allowed roll-forward to a major version. The default value was `1`.

The `applyPatches` setting controlled patch roll-forward. Its default value, `true`, selected the latest patch. When set to `false`, the host selected the matching patch or the lowest higher patch.

## New behavior

Starting in .NET 12, the host no longer recognizes `rollForwardOnNoCandidateFx` or `applyPatches`. The `--roll-forward-on-no-candidate-fx` command-line option and `DOTNET_ROLL_FORWARD_ON_NO_CANDIDATE_FX` environment variable are also no longer supported.

When you don't set a replacement option, the host keeps the default behavior: it allows minor-version roll-forward and uses the latest patch.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The `rollForwardOnNoCandidateFx` and `applyPatches` settings haven't been the recommended way to configure framework resolution since .NET Core 3.0. They remained supported for a transition period to preserve backward compatibility.

For more information, see [dotnet/runtime#131611](https://github.com/dotnet/runtime/issues/131611) and [dotnet/runtime#135233](https://github.com/dotnet/runtime/pull/135233).

## Recommended action

Replace `rollForwardOnNoCandidateFx` with the `rollForward` setting. The values map as follows:

- Set `rollForward` to `LatestPatch` to replace `rollForwardOnNoCandidateFx` value `0`.
- Set `rollForward` to `Minor` to replace value `1`.
- Set `rollForward` to `Major` to replace value `2`.

For example, set `rollForward` in the `runtimeOptions` section of the *.runtimeconfig.json* file:

```json
{
  "runtimeOptions": {
    "rollForward": "Minor"
  }
}
```

To set the policy from the command line or an environment variable, use `--roll-forward` or `DOTNET_ROLL_FORWARD`. Remove `applyPatches` to keep the default behavior of using the latest patch. To require the exact framework version, set `rollForward` to `Disable`; the app won't start if that version isn't available.

## Affected APIs

None.

## See also

- [Select which .NET version to use](../../../versions/selection.md#control-roll-forward-behavior)
- [.NET runtime configuration settings](../../../runtime-config/index.md)
- [dotnet command-line reference: --roll-forward](../../../tools/dotnet.md#rollforward)
- [DOTNET_ROLL_FORWARD environment variable](../../../tools/dotnet-environment-variables.md#dotnet_roll_forward)
