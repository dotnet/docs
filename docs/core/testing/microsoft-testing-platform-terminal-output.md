---
title: Microsoft.Testing.Platform terminal output
description: Learn about the built-in terminal test reporter in Microsoft.Testing.Platform, including output modes, ANSI support, and progress indicators.
author: evangelink
ms.author: amauryleve
ms.date: 02/25/2026
ai-usage: ai-assisted
---

# Terminal output

The terminal test reporter is the built-in implementation of status and progress reporting to the terminal (console). It's part of the core **Microsoft.Testing.Platform** and doesn't require any additional NuGet packages.

## Output modes

There are two output modes available:

- `Normal`, the output contains the banner, reports full failures of tests, warning messages, and writes summary of the run.
  ![Output with 1 failed test and a summary](./media/test-output-and-summary.png)

- `Detailed`, the same as `Normal` but it also reports `Passed` tests.
  ![Output with 1 failed, and 1 passed test and a summary](./media/test-output-and-summary-with-passed.png)

## ANSI

Internally there are 2 different output formatters that auto-detect the terminal capability to handle [ANSI escape codes](/windows/console/console-virtual-terminal-sequences).

- The ANSI formatter is used when the terminal is capable of rendering the escape codes.
- The non-ANSI formatter is used when the terminal can't handle the escape codes, when `--no-ansi` is used, or when output is redirected.

The default is to auto-detect the capabilities.

## Progress

A progress indicator is written to terminal. The progress indicator shows the number of passed tests, failed tests, and skipped tests, followed by the name of the tested assembly, its target framework, and architecture.

![A progress bar with 23 passed tests, 0 failed tests and 0 skipped tests](./media/test-progress-bar.png)

The progress bar is written based on the selected mode:

- ANSI, the progress bar is animated, sticking to the bottom of the screen and is refreshed every 500ms. The progress bar hides once test execution is done.
- non-ANSI, the progress bar is written to screen as is every 3 seconds. The progress remains in the output.

## Options

| Option | Description |
|---|---|
| `--no-progress` | Disable reporting progress to screen. |
| `--no-ansi` | Disable outputting ANSI escape characters to screen. |
| `--output` | Output verbosity when reporting tests. Valid values are `Normal` and `Detailed`. Default is `Normal`. |
