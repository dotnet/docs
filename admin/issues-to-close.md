---
title: Issue closure recommendations
ai-usage: ai-generated
---

# Issue closure recommendations

Recommend closing the following issues because current documentation addresses the request, an authoritative answer resolves the documentation question, the affected sample has been superseded, or another tracked issue covers the same work. These are recommendations only: no issues have been closed, commented on, labeled, or assigned.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Order:** Issue creation time, oldest first, not most recent activity.
- **Completed batches:** The 100 oldest open issues, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#24691](https://github.com/dotnet/docs/issues/24691), opened June 16, 2021.
- **Results:** 19 closure candidates and 25 [clearly defined fixes](issues-with-defined-fixes.md) (22 assignment candidates and 3 fixes with open implementation PRs).
- **Latest batch:** Issues 76-100, from [dotnet/docs#23596](https://github.com/dotnet/docs/issues/23596) through dotnet/docs#24691: 6 closure candidates, 8 new assignment candidates, and 1 fix with an existing PR that needs correction.
- **Remaining:** 748 issues from this snapshot are unreviewed. Resume with [dotnet/docs#24735](https://github.com/dotnet/docs/issues/24735), opened June 18, 2021. Refresh issue states before the next batch; don't skip later issues just because their numbers are lower.
- **Evidence:** Issue bodies, complete comment threads, relevant current documentation, and candidate cross-reference timelines. Local source matched upstream `main` at commit `81cd030da804aa06cfbd8f23474cbbacba597c72` during this review. External sources were checked where noted.

Age, inactivity, an out-of-support version, a `won't fix` label, or a stale-bot closure in another repository doesn't establish that an issue no longer applies. Partial coverage alone isn't sufficient either. Issues that don't fit either candidate category are omitted for a future task.

## Closure candidates

### dotnet/docs#2608: Documentation on creating ETW events

**Opened:** July 12, 2017. **Confidence:** High. **Reason:** The requested documentation now exists.

The original request asks for documentation about how applications create their own ETW events, beyond scattered blog posts and API examples. The [EventSource getting-started tutorial](../docs/core/diagnostics/eventsource-getting-started.md#log-an-event) now defines a custom `EventSource`, declares an event, and emits it from an application. The companion [trace collection tutorial](../docs/core/diagnostics/eventsource-collect-and-view-traces.md#perfview) demonstrates ETW collection and inspection with PerfView. The [instrumentation guide](../docs/core/diagnostics/eventsource-instrumentation.md) supplies the broader authoring guidance.

These articles address both event creation and consumption, not just runtime-generated diagnostic events. A [comment on the issue](https://github.com/dotnet/docs/issues/2608#issuecomment-4137511089) independently identifies the same documentation suite. The earlier stale-bot closure and subsequent reopening aren't the basis for this recommendation.

**Suggested closure explanation:** The EventSource documentation now covers custom events, instrumentation, and ETW trace collection. Link to the getting-started and collection tutorials; no documentation change is needed for the original request.

### dotnet/docs#18405: Create a page for how the SDK and Visual Studio work together

**Opened:** May 13, 2020. **Confidence:** High. **Reason:** Existing guidance now covers the requested relationship and SDK selection.

The issue asks which SDK Visual Studio uses when several SDKs or Visual Studio versions are installed, and how `global.json` affects the build. The dedicated [.NET SDK, MSBuild, and Visual Studio versioning article](../docs/core/porting/versioning-sdk-msbuild-vs.md) explains the relationship, the SDK bundled with each Visual Studio installation, separately installed SDKs, compatibility requirements, and the support matrix.

The [global.json overview](../docs/core/tools/global-json.md) now distinguishes the CLI muxer from the MSBuild project SDK resolver, explains their search locations, documents version matching, and describes Visual Studio's prerelease selection behavior. The [version-selection guide](../docs/core/versions/selection.md#the-sdk-uses-the-latest-installed-version) provides the general selection rules and links to `global.json`.

Together, these pages supply the bridge and selection guidance requested by the issue. The original observation that `global.json` was discouraged shouldn't become new guidance: current documentation explicitly supports its use to constrain SDK selection.

**Suggested closure explanation:** The SDK/MSBuild/Visual Studio relationship and `global.json` resolution rules are now documented. Link to the versioning article and `global.json` overview rather than create another overlapping page.

### dotnet/docs#19006: Need for a sample or clarification on how to use PFI with AutoML in ML.NET

**Opened:** June 18, 2020. **Confidence:** High for the current AutoML workflow. **Reason:** A dedicated AutoML example and a discoverability link now exist.

The issue asks how to use permutation feature importance (PFI) with an AutoML model. The current [AutoML guide's Determine feature importance section](../docs/machine-learning/how-to-guides/how-to-use-the-automl-api.md#determine-feature-importance) retrieves the best model, transforms the dataset, calls `PermutationFeatureImportance`, and orders the results. The [PFI article's next steps](../docs/machine-learning/how-to-guides/explain-machine-learning-model-permutation-feature-importance-ml-net.md#next-steps) directly links to that AutoML example, at the location the issue proposed.

The request predates that documented workflow. Don't copy the issue's original cast sequence into current guidance: the discussion itself explains that transformer nesting varies, and the current example uses a different API shape.

**Suggested closure explanation:** Current documentation includes a step-by-step AutoML/PFI example and a link from the PFI guide. Close the general documentation request as addressed; a reproducible failure with a specific legacy model or package version would need a separate, version-specific report. The issue is currently assigned to `luisquintanilla`; retain that context when the maintainer reviews the recommendation.

### dotnet/docs#20590: Tutorial for immutable types

**Opened:** September 11, 2020. **Confidence:** High. **Reason:** The requested feature guidance and practical exploration now exist.

The issue requests updated immutable-type guidance for `init` accessors and an exploration of C# 9 immutable types. The [lightweight immutable-class how-to](../docs/csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties.md) now lists `init` as an alternative to getter-only properties or private setters. The [`init` reference](../docs/csharp/language-reference/keywords/init.md) explains initialization-only assignment, compares the alternatives, and supplies examples.

The [record tutorial](../docs/csharp/fundamentals/tutorials/records.md) supplies a practical exploration of immutable data models and nondestructive mutation. The [record-type overview](../docs/csharp/fundamentals/types/records.md) explicitly distinguishes the `init`-only properties of record classes and readonly record structs from the mutable defaults of record structs. The coverage has advanced beyond C# 9 without losing the requested concepts.

**Suggested closure explanation:** Immutable-type guidance now includes `init` accessors, and the record tutorial demonstrates immutable models and `with` expressions. Link to those articles; another C# 9-specific tutorial isn't needed. The issue is currently assigned to `BillWagner`.

### dotnet/docs#20935: Add a page for undocumented Visual Basic compiler messages

**Opened:** October 6, 2020. **Confidence:** High. **Reason:** The requested fallback page already exists.

The issue asks for a Visual Basic counterpart to the C# catch-all diagnostic article. [Sorry, we don't have specifics on this Visual Basic error](../docs/visual-basic/misc/sorry-we-don-t-have-specifics-on-this-visual-basic-error.md) provides that counterpart, including extensive `f1_keywords` metadata and advice for readers who reach an undocumented diagnostic.

The issue explicitly excludes automatic F1-keyword generation from its scope. The existence of a separate automation request therefore doesn't keep this page-creation request open. The page's old metadata date isn't the evidence of completion; its actual content and diagnostic metadata are.

**Suggested closure explanation:** The Visual Basic fallback diagnostic page exists and contains F1 mappings. Close this page-creation request as already satisfied. Any specific missing diagnostic mapping or automation work should remain a separate task.

### dotnet/docs#21827: Legacy hosting sample fails with non-ASCII paths

**Opened:** December 4, 2020. **Confidence:** High that the reported sample is superseded; no claim that its historical implementation was fixed.

The [runtime-owner diagnosis](https://github.com/dotnet/docs/issues/21827#issuecomment-767211822) identifies incorrect non-ASCII path handling in the old `HostWithCoreClrHost` sample. The current [hosting tutorial](../docs/core/tutorials/netcore-hosting.md) instead teaches `nethost`/`hostfxr` and links to the replacement [.NET hosting sample](https://github.com/dotnet/samples/tree/main/core/hosting). The old `core/hosting/HostWithCoreClrHost` directory is no longer present in the current `dotnet/samples` tree.

The replacement [sample source](https://github.com/dotnet/samples/blob/main/core/hosting/src/NativeHost/nativehost.cpp) uses `char_t` strings, a Windows `wmain` entry point, and `GetFullPathNameW`, rather than the old CoreCLR delegate workflow. The [local snippet used by the tutorial](../samples/snippets/core/tutorials/netcore-hosting/csharp/HostWithHostFxr/src/NativeHost/nativehost.cpp) uses the same wide-character approach.

**Suggested closure explanation:** The report concerns a retired sample at a historical commit. Current documentation uses the replacement hostfxr sample, so no change to the retired example is needed for the current tutorial. Link to the replacement and request a new reproduction only if that sample fails. Don't claim a successful non-ASCII-path execution test or a fix to the historical sample. The issue is currently assigned to `vitek-karas`.

### dotnet/docs#22075: Conflicting Materialized View guidance

**Opened:** December 17, 2020. **Confidence:** High. **Reason:** The linked architecture guidance no longer contains the reported prohibition.

The issue identifies a direct contradiction: the .NET microservices guide recommends materialized views, while the linked Azure pattern article reportedly says not to use them with microservices. The current [Azure Materialized View pattern article](https://learn.microsoft.com/azure/architecture/patterns/materialized-view#when-to-use-this-pattern) now explicitly says that materialized views can consolidate data from loosely coupled microservices. It distinguishes application-maintained projections from database-native views and discusses refresh strategies, consistency, and operational trade-offs.

The [.NET distributed-data guide](../docs/architecture/microservices/architect-microservice-container-applications/distributed-data-management.md) already compares API aggregation, CQRS/read tables, and reporting stores. It explains the extra development effort and eventual consistency involved in precomputed query data. Together, the two current pages also address the issue's request for context on when to select these approaches.

**Suggested closure explanation:** The Azure pattern article now explicitly supports the applicable microservices scenario and explains the trade-offs. The original contradiction is gone; link to its current guidance and the existing .NET discussion without changing either page.

### dotnet/docs#22155: ETW payload types differ in tracerpt output

**Opened:** December 25, 2020. **Confidence:** High for the documentation answer; no claim that the Windows utility was fixed.

The report compares incorrectly shifted fields in `tracerpt` output with correctly decoded fields from `TdhFormatProperty`. The [runtime-owner reply](https://github.com/dotnet/docs/issues/22155#issuecomment-755026050) confirms that the documented PDB age fields really are `UInt32`, identifies the runtime manifest as the source of truth, and recommends TraceEvent for .NET ETW parsing. The owner treats the Windows utility's output as a separate investigation, not evidence that the documentation should change its field types.

The current [loader-event reference](../docs/framework/performance/loader-etw-events.md#module-events) still correctly lists `ManagedPdbAge` and `NativePdbAge` as `win:UInt32`, the signatures as GUIDs, and the reserved field before the paths.

**Suggested closure explanation:** The documentation question has an authoritative answer: retain the documented types and use the runtime manifest or TraceEvent to interpret the payload. Close this docs issue as answered, without claiming that the separate `tracerpt` decoding problem was resolved.

### dotnet/docs#23379: Exclude modifiers from a naming rule

**Opened:** March 18, 2021. **Confidence:** High. **Reason:** The requested exception mechanism and a worked example are documented.

The issue asks how to apply a private-field convention without applying it to private static readonly fields. The [naming-rule guide](../docs/fundamentals/code-analysis/style-rules/naming-rules.md#example-private-instance-fields-with-underscore) now explicitly explains that symbol groups express required modifiers, not absent modifiers. Its worked example pairs a general private-field rule with a more specific static-field rule whose severity is `none`.

The same guide explains that a symbol must have all the required modifiers and that more specific rules take precedence. Those rules supply the requested static-plus-readonly exception without an invented negative-modifier option. The [original code-style overview](../docs/fundamentals/code-analysis/code-style-rule-options.md) also links to the naming-rule guide, and its configuration example now includes naming rules and symbol groups rather than only naming styles.

**Suggested closure explanation:** Link to the modifier-exception example and rule-order guidance. The example uses an underscore convention, but its two-rule mechanism applies equally to the requested camelCase convention and a static/readonly intersection.

### dotnet/docs#23440: Hosted services in distributed deployments

**Opened:** March 22, 2021. **Confidence:** High. **Reason:** The core documentation gap duplicates an older issue already retained for a defined fix.

Both this issue and [dotnet/docs#19827](https://github.com/dotnet/docs/issues/19827) ask how the same hosted-service article behaves when multiple application replicas run behind a load balancer. The older issue is already retained in [the assignment brief](issues-with-defined-fixes.md#dotnetdocs19827-clarify-hosted-service-behavior-across-replicas), which requires an explicit per-host lifecycle explanation, separates background coordination from HTTP load balancing, and avoids an exactly-once guarantee.

The newer discussion adds useful concerns about the polling example and separate worker deployments. Those comments remain relevant context for the retained issue; they aren't proof that the sample provides distributed coordination.

**Suggested closure explanation:** Close as a duplicate of dotnet/docs#19827 and link to this discussion from the retained work. Don't say the documentation gap is already fixed or silently discard the additional deployment questions. Use one clarification task rather than assign two agents to the same article and explanation.

### dotnet/docs#23449: Missing Visual Basic syntax extension methods

**Opened:** March 23, 2021. **Confidence:** High. **Reason:** The missing entries now appear on the published API page.

The current [AsClauseSyntax extension-method table](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.visualbasic.syntax.asclausesyntax?view=roslyn-dotnet-5.3.0#extension-methods) includes both `Type(AsClauseSyntax)` and `Attributes(AsClauseSyntax)`, which the issue identifies as absent. The live page also links to the Visual Basic `SyntaxExtensions.Type` API. This recommendation follows the published table, not just the presence of XML source or an internal publishing bug.

The [maintainer explanation](https://github.com/dotnet/docs/issues/23449#issuecomment-806070917) also notes that a C# extension on the shared `SyntaxNode` base type can legitimately appear for a Visual Basic-derived node. Its presence alone doesn't prove an incorrect redirect.

**Suggested closure explanation:** The specifically missing Visual Basic extensions are now visible on the type page. Close that publishing-gap report as addressed. Don't claim that every extension link across the entire Roslyn API reference has been audited.

### dotnet/docs#23473: Document experimental IDE rules

**Opened:** March 24, 2021. **Confidence:** High. **Reason:** The requested experimental formatting rules now have published articles and index entries.

The linked Roslyn source identifies the IDE2000-series experimental formatting rules. Merged [dotnet/docs#48011](https://github.com/dotnet/docs/pull/48011) added documentation for IDE2000-IDE2006. The current [style-rule index](../docs/fundamentals/code-analysis/style-rules/index.md) links to all seven articles, and [IDE2000](../docs/fundamentals/code-analysis/style-rules/ide2000.md) explicitly warns that the rule is experimental and subject to change or removal.

The issue's recent comment points to that PR, but the merged state, current rule pages, and current index supply the evidence for closure.

**Suggested closure explanation:** The experimental rules referenced by the request are documented, including their experimental status. Close as addressed by dotnet/docs#48011; don't extend the request to every future experimental diagnostic.

### dotnet/docs#23582: Linux development certificates

**Opened:** April 1, 2021. **Confidence:** High for the general tooling-and-guidance request.

The [.NET development-certificate tool](../docs/core/tools/dotnet-dev-certs.md) documents certificate creation, export, trust, and verification. Its troubleshooting link leads to the current [ASP.NET Core certificate guidance](https://learn.microsoft.com/aspnet/core/security/enforcing-ssl#troubleshoot-certificate-problems-certificate-not-trusted), which now includes Linux-specific trust instructions rather than only Windows and macOS instructions.

That guide describes the community-supported `linux-dev-certs` tool and provides explicit SLES/openSUSE and RHEL workflows for certificate export, browser trust, and OpenSSL clients. It also states where `dotnet dev-certs https --trust` isn't officially supported. The [self-signed certificate overview](../docs/core/additional-tools/self-signed-certificates-guide.md) already introduces the CLI and OpenSSL alternatives.

**Suggested closure explanation:** Linux certificate tooling and documented installation/trust workflows now exist. Link to the relevant platform-specific instructions. Don't promise universal Linux trust support or describe the community tool as Microsoft-supported; a failure on a specific distribution or browser would need a separate reproduction.

### dotnet/docs#23597: Scalar query must select a single field

**Opened:** April 2, 2021. **Confidence:** High for the documentation answer. **Reason:** The owner explains why the existing query is intentional and valid.

The report proposes replacing `SELECT *` with `SELECT value` because the deferred-transaction example calls `ExecuteScalar`. The [data-owner answer](https://github.com/dotnet/docs/issues/23597#issuecomment-812618066) and [follow-up](https://github.com/dotnet/docs/issues/23597#issuecomment-812621481) explain that the API returns the first column of the first row and keeps this transaction example concise. A single-column result set isn't a prerequisite.

The current [transaction guide](../docs/standard/data/sqlite/transactions.md#deferred-transactions) references the [same sample](../samples/snippets/standard/data/sqlite/DeferredTransactionSample/Program.cs), which creates a one-column `data` table before the scalar read. The owner would accept an optional wording/query improvement, but that invitation doesn't establish a remaining correctness bug.

**Suggested closure explanation:** Close as answered: the sample's scalar read is valid and intentional. Selecting the column explicitly would be an optional clarity improvement, not a required fix to transaction behavior.

### dotnet/docs#23703: .NET Standard 2.1 support for UWP and Unity

**Opened:** April 8, 2021. **Confidence:** High. **Reason:** Both previously undecided table entries now have explicit answers.

The current [.NET Standard overview](../docs/standard/net-standard.md#net-implementation-support) uses the [version selector](../includes/net-standard-selector.md). Its [.NET Standard 2.1 table](../includes/net-standard-2.1.md) lists Unity 2021.2 and marks UWP as `N/A`, with a footnote that UWP doesn't support .NET Standard 2.1.

Merged [dotnet/docs#27837](https://github.com/dotnet/docs/pull/27837) addresses the Unity entry. That merge alone wouldn't resolve the last comment about UWP on the separate product website. The current [product page](https://dotnet.microsoft.com/platform/dotnet-standard) now links to the Learn documentation instead of displaying the old support table; its former `TBD` entries aren't the current guidance.

**Suggested closure explanation:** Link to the .NET Standard 2.1 table: Unity support begins with 2021.2, and UWP support is explicitly unavailable. Close the unresolved-table-entry request without implying that UWP gained .NET Standard 2.1 support.

### dotnet/docs#23708: Defaults for custom build configurations

**Opened:** April 8, 2021. **Confidence:** High. **Reason:** The compiler-options guide explicitly documents both requested defaults.

The [DebugType section](../docs/csharp/language-reference/compiler-options/code-generation.md#debugtype) states that `portable` is the default for Debug and Release and that PDB files are generated by default for all configurations. The [Optimize section](../docs/csharp/language-reference/compiler-options/code-generation.md#optimize) states that optimization is enabled for Release and disabled for Debug and any other build configuration.

Those statements answer the original custom-configuration question and the later request to document the PDB default. The presence of both defaults matters; a general Debug/Release comparison alone wouldn't answer the issue.

**Suggested closure explanation:** The current project/compiler-options guidance explicitly covers custom configurations. Link to both sections; don't generalize these MSBuild project defaults to a direct invocation of `csc` without project configuration.

### dotnet/docs#23756: Undeclared AutoML progress handler

**Opened:** April 12, 2021. **Confidence:** High for the reported missing declaration. **Reason:** The current tutorial replaces the obsolete progress-handler workflow and declares its replacement.

The report identifies an undeclared `progressHandler` in an older AutoML experiment example. The current [experiment-monitor section](../docs/machine-learning/how-to-guides/how-to-use-the-automl-api.md#configure-experiment-monitoring) instead supplies an `AutoMLMonitor : IMonitor` implementation, constructs `monitor`, and calls `experiment.SetMonitor(monitor)`. The following example declares a cancellation-token source before it calls `RunAsync`.

The old undeclared handler isn't part of the current article. This recommendation follows the actual replacement instructions, not just the absence of the old variable name.

**Suggested closure explanation:** The current AutoML guide defines and registers its experiment monitor before use. Close the obsolete missing-variable report and link to that section. Don't claim that every sample in the guide was executed or that the historical API example was repaired. The issue is currently assigned to `luisquintanilla`.

### dotnet/docs#24276: Install Windows services with modern .NET

**Opened:** May 18, 2021. **Confidence:** High. **Reason:** Dedicated modern .NET creation and installation guidance now exists.

The [Windows service tutorial](../docs/core/extensions/windows-service.md) teaches a Worker Service rather than the .NET Framework component designer. It covers the Windows Services hosting package, application publication, `sc.exe create`, verification, start/stop commands, and service deletion. Its installation section also links to [the installer tutorial](../docs/core/extensions/windows-service-with-installer.md).

The requested capability isn't limited to the old `InstallUtil.exe` workflow. The original issue suggests PowerShell's `New-Service`, but doesn't require that command instead of the documented Service Control Manager command. The existing [Framework installation page](../docs/framework/windows-services/how-to-install-and-uninstall-services.md) also explicitly scopes its instructions to .NET Framework.

**Suggested closure explanation:** Link to the modern Worker Service tutorial and its installation section. The requested modern .NET workflow is documented; no Framework designer workaround or duplicate installation article is needed.

### dotnet/docs#24559: Migration overview cleanup coordination

**Opened:** June 8, 2021. **Confidence:** Moderate; confirm with the current owner. **Reason:** Follow-up tasks exist, and the original overview-cleanup plan has been superseded.

The issue asks for follow-up issues based on [the proposed migration TOC](https://github.com/dotnet/docs/issues/23215), with instructions to move detailed topics out of the overview. That TOC now links to those follow-up tasks. In particular, [dotnet/docs#25237](https://github.com/dotnet/docs/issues/25237) explicitly requests a guide overview and says the detailed topics belong elsewhere.

The current [upgrade overview](../docs/core/porting/index.md), rewritten in June 2026, describes upgrade decisions, paths, and tools and links to separate Framework migration, dependency, compatibility, and modernization pages. The [current migration TOC](../docs/navigate/migration-guide/toc.yml) also navigates to those separate topics. Reopening the 2021 coordination exercise against the former overview would duplicate planning rather than define a new content fix.

**Suggested closure explanation:** With assignee `StephenBonikowsky`, close this coordination ticket as superseded by the follow-up tasks and the redesigned overview. Don't claim that the entire migration revamp is complete or automatically close its still-open child issues; evaluate those requests separately when their snapshot positions are reached.
