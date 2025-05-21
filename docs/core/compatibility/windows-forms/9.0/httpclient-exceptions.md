---
title: "Breaking change: PictureBox raises HttpClient exceptions"
description: Learn about the breaking change in .NET 9 for Windows Forms where `PictureBox` raises HttpClient exceptions for network errors when loading an image from a URL.
ms.date: 07/09/2024
ms.topic: concept-article
---
# PictureBox raises HttpClient exceptions

When <xref:System.Windows.Forms.PictureBox> loads an image from a URL and a network error occurs, it now raises <xref:System.Net.Http.HttpClient> exceptions, such as <xref:System.Net.Http.HttpRequestException> and <xref:System.Threading.Tasks.TaskCanceledException>, instead of <xref:System.Net.WebException>.

## Version introduced

.NET 9 Preview 6

## Previous behavior

Previously, when <xref:System.Windows.Forms.PictureBox> failed to load an image from a URL due to a network error, a <xref:System.Net.WebException> was thrown.

## New behavior

Starting in .NET 9, when <xref:System.Windows.Forms.PictureBox> fails to load an image from a URL due to a network error, <xref:System.Net.Http.HttpRequestException> or <xref:System.Threading.Tasks.TaskCanceledException> is thrown.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

<xref:System.Net.WebClient> is obsolete.

## Recommended action

Update your code to catch <xref:System.Net.Http.HttpRequestException> and <xref:System.Threading.Tasks.TaskCanceledException> instead of <xref:System.Net.WebException>.

## Affected APIs

- <xref:System.Windows.Forms.PictureBox> control
