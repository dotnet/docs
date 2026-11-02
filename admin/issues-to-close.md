---
title: Issue closure recommendations
ai-usage: ai-generated
---

# Issue closure recommendations

Recommend closing the following issues because current documentation addresses the request, an authoritative answer resolves the documentation question, the affected sample has been superseded, or another tracked issue covers the same work. These are recommendations only: no issues have been closed, commented on, labeled, or assigned.

## Review coverage

- **Repository and snapshot:** `dotnet/docs`, November 2, 2026; 848 open issues, excluding pull requests.
- **Order:** Issue creation time, oldest first, not most recent activity.
- **Completed batches:** The 225 oldest open issues, from [dotnet/docs#2608](https://github.com/dotnet/docs/issues/2608), opened July 12, 2017, through [dotnet/docs#28632](https://github.com/dotnet/docs/issues/28632), opened March 11, 2022.
- **Results:** 41 closure candidates and 85 [clearly defined fixes](issues-with-defined-fixes.md) (76 assignment candidates and 9 fixes with open implementation PRs).
- **Latest batch:** Issues 201-225, from [dotnet/docs#27653](https://github.com/dotnet/docs/issues/27653) through dotnet/docs#28632: 7 closure candidates and 9 new assignment candidates.
- **Remaining:** 623 issues from this snapshot are unreviewed. Resume with [dotnet/docs#28635](https://github.com/dotnet/docs/issues/28635), opened March 11, 2022. Refresh issue states before the next batch; don't skip later issues just because their numbers are lower.
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

### dotnet/docs#24800: Run MSTest in an Azure DevOps pipeline

**Opened:** June 23, 2021. **Confidence:** High for the general pipeline documentation request. **Reason:** Current guidance supplies the requested MSTest/Azure pipeline workflow.

The [MSTest SDK guide's CI section](../docs/core/testing/unit-testing-mstest-sdk.md#update-your-ci) includes an Azure Pipelines `DotNetCoreCLI@2` example and explains the test-report, result-directory, and coverage arguments for that configuration. The [MSTest execution guide](../docs/core/testing/unit-testing-mstest-running-tests.md) distinguishes runner modes and covers CI execution. The authoritative [Azure Pipelines .NET guide](https://learn.microsoft.com/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops#run-your-tests) explicitly supports MSTest and provides test-task and test-result publication examples.

The recommendation rests on that concrete coverage, not on .NET Core 3.1 reaching end of support. It doesn't establish that the reporter's historical project has been executed successfully, or that VSTest and Microsoft.Testing.Platform arguments are interchangeable.

**Suggested closure explanation:** Link to the MSTest CI example and Azure Pipelines test guidance. The requested pipeline instructions now exist; a reproducible failure with a particular project or runner configuration would need separate troubleshooting.

### dotnet/docs#24828: Refresh the Model Builder sentiment tutorial

**Opened:** June 24, 2021. **Confidence:** High for the specified content changes. **Reason:** A merged replacement implements the requested tutorial update.

The current [sentiment-analysis Model Builder tutorial](../docs/machine-learning/tutorials/sentiment-analysis-model-builder.md) explicitly creates `SentimentAnalysis.mbconfig`, uses the Model Builder 2.0 scenario image, and no longer contains the Visual Studio 2017 branch. It also describes the generated consumption, training, and model files.

The actual patch in merged [dotnet/docs#32011](https://github.com/dotnet/docs/pull/32011) adds the config-file section, replaces the scenario image reference, and removes the Visual Studio 2017-specific instructions. The older linked [dotnet/docs#25407](https://github.com/dotnet/docs/pull/25407) closed without merge and isn't completion evidence. The recommendation doesn't claim a fresh execution of every current Model Builder UI step.

**Suggested closure explanation:** With assignee `luisquintanilla`, close the specified refresh as addressed by the merged tutorial replacement and current content. Track any newly reproducible UI or training failure separately.

### dotnet/docs#24903: Explain Windows Forms and WPF trimming limitations

**Opened:** June 29, 2021. **Confidence:** High for the requested technical explanation. **Reason:** A dedicated incompatibility guide now explains both frameworks.

The [WPF section](../docs/core/deploying/trimming/incompatibilities.md#wpf) explains the framework's extensive reflection and runtime inspection and why the SDK disables trimming. The [Windows Forms section](../docs/core/deploying/trimming/incompatibilities.md#windows-forms) explains its dependence on built-in COM marshalling and links to the framework's tracking issue. The same guide separately explains why automatic COM marshalling conflicts with trimming analysis.

Both `aka.ms/dotnet-illink/wpf` and `aka.ms/dotnet-illink/windows-forms` still land on [the trimming overview](../docs/core/deploying/trimming/trim-self-contained.md), whose warning links to the detailed incompatibility guide. Don't claim the aliases now target framework-specific anchors. The substantive explanation exists in one shared guide rather than two separate pages.

**Suggested closure explanation:** Link directly to the WPF and Windows Forms explanations. The requested reasons and framework follow-up links are documented; duplicate explanation pages aren't necessary. Any desired change to the external short-link destinations is a separate routing refinement, not a missing technical explanation.

### dotnet/docs#25237: Rewrite the migration-guide overview

**Opened:** July 20, 2021. **Confidence:** High. **Reason:** The redesigned overview follows the requested structure.

The current [upgrade overview](../docs/core/porting/index.md) explains upgrade decisions, support, paths, and tools, then links to separate Framework migration, pre-migration, dependency, compatibility, and modernization guidance. The [migration TOC](../docs/navigate/migration-guide/toc.yml) exposes those dedicated topics rather than require the overview to contain their full instructions.

The issue explicitly requests an overview with detailed topics moved elsewhere. The current content addresses that structural request; another rewrite against the 2021 outline would duplicate the completed redesign.

**Suggested closure explanation:** With assignee `StephenBonikowsky`, close the overview-restructure request as addressed by the current overview and linked topic pages. Don't treat this recommendation as completion of every migration-guide follow-up.

### dotnet/docs#25242: Explain .NET releases and servicing

**Opened:** July 20, 2021. **Confidence:** High. **Reason:** A dedicated release-and-support article now covers the requested subject.

The [.NET releases, patches, and support guide](../docs/core/releases-and-support.md) explains release categories, SDK feature bands, runtime roll-forward, LTS/STS support, monthly servicing, patch requirements, and operating-system support. The [upgrade overview](../docs/core/porting/index.md) directly links to that guide for release dates and patch guidance.

The issue proposes content based on a public release-and-support explanation. Current documentation supplies the substantive guidance and a migration entry point; another article adapted from the older blog isn't needed. This recommendation isn't a claim that every lifecycle date elsewhere in the documentation has been audited.

**Suggested closure explanation:** Link to the existing release-and-support guide and close the overlapping content request as addressed.

### dotnet/docs#25245: Explain the move from Windows-only to cross-platform .NET

**Opened:** July 20, 2021. **Confidence:** High. **Reason:** Connected migration guidance covers platform dependencies and the Compatibility Pack.

The [Framework migration overview](../docs/core/porting/framework-overview.md) explains cross-platform considerations, Windows desktop limitations, native dependencies, compatibility mode, and technologies unavailable in modern .NET. The [Windows Compatibility Pack guide](../docs/core/porting/windows-compat-pack.md) distinguishes Windows-only APIs from cross-platform APIs and explains whether to remove, replace, or guard platform-specific calls with analyzer assistance.

Those pages address the issue's requested separation of .NET from Windows, remaining Windows dependencies, and the role of the Compatibility Pack. Both are part of the current migration navigation. Neither implies that a WPF or Windows Forms application becomes cross-platform merely because it targets modern .NET.

**Suggested closure explanation:** Link to the migration overview and Compatibility Pack guide. The requested platform explanation now exists; no duplicate Windows-to-cross-platform overview is needed.

### dotnet/docs#25249: Introduce project-portability assessment

**Opened:** July 20, 2021. **Confidence:** High for the requested expectations and advance assessment. **Reason:** Current migration guidance covers both purposes.

The issue asks readers to set realistic expectations and analyze a project before they commit to an upgrade. The [Framework migration overview](../docs/core/porting/framework-overview.md) distinguishes relatively straightforward upgrades from app-model changes and identifies desktop, native-library, dependency, and unavailable-technology risks. Its assessment-tool guidance leads to [the upgrade workflow](../docs/core/porting/github-copilot-upgrade/concepts.md#stage-1-assessment), which explicitly analyzes the dependency graph, package compatibility, breaking APIs, test coverage, complexity, and risk before the planning and execution stages.

The [dependency-assessment guide](../docs/core/porting/third-party-deps.md) also supports manual analysis. The recommendation doesn't require the retired portability analyzer or claim that automated assessment guarantees a successful migration.

**Suggested closure explanation:** Link to the existing overview, dependency analysis, and assessment workflow. The requested expectations and analyze-before-upgrade guidance now exist; a second generic assessment overview isn't necessary.

### dotnet/docs#25478: Document backward-compatible library consumption

**Opened:** August 5, 2021. **Confidence:** High. **Reason:** The remaining documentation gap duplicates an older issue already retained for a defined fix.

The issue asks whether a newer-target application can consume a library compiled for an older .NET target and distinguishes that scenario from runtime roll-forward. [dotnet/docs#25018](https://github.com/dotnet/docs/issues/25018) asks the same question. Its [assignment brief](issues-with-defined-fixes.md#dotnetdocs25018-explain-how-newer-applications-consume-older-target-libraries) already requires a direct compatibility explanation, package asset-selection evidence, runtime-selection distinctions, and appropriate dependency/platform caveats.

The newer issue adds explicit support-confirmation context, which the retained brief now preserves. The recommendation doesn't claim that the missing paragraph has already been written or that all cross-version binaries are compatible.

**Suggested closure explanation:** With assignee `StephenBonikowsky`, close as a duplicate of dotnet/docs#25018 and preserve the request for an explicit support statement in that task. Use one documentation change rather than assign two agents to the same compatibility explanation.

### dotnet/docs#25929: Roslyn API page fails with an invalid version moniker

**Opened:** September 2, 2021. **Confidence:** High for the reported URL. **Reason:** The exact invalid-moniker request now falls back to a valid API page.

The discussion retracts an early claim that the problem was fixed: the important case was the literal `view=roslyn-dotnet` query, not simply whether the API existed. A live request to [the reported URL](https://learn.microsoft.com/dotnet/api/microsoft.codeanalysis.compilation.issymbolaccessiblewithin?view=roslyn-dotnet) now redirects to the `roslyn-dotnet-5.3.0` view with `viewFallbackFrom=roslyn-dotnet`. The response contains the `Compilation.IsSymbolAccessibleWithin` definition, signatures, source metadata, and version choices instead of the reported broken page.

**Suggested closure explanation:** The exact invalid-version URL now resolves through the API browser's version fallback. Close the reported routing failure as addressed. The check doesn't establish that every Roslyn version URL or external search result is correct.

### dotnet/docs#26035: Analyzer template creates an out-of-support .NET Core 2.0 test project

**Opened:** September 10, 2021. **Confidence:** High for the original template defect. **Reason:** The template's target has changed, with a merged product fix and current source evidence.

The final discussion identifies [dotnet/roslyn-sdk#884](https://github.com/dotnet/roslyn-sdk/pull/884). That PR merged on October 29, 2021, and its actual patch changes the diagnostic test template from `netcoreapp2.0` to `netcoreapp3.1`. More importantly, the [current template on the explicit `main` branch](https://github.com/dotnet/roslyn-sdk/blob/main/src/RoslynSdk/VisualStudio.Roslyn.SDK/Roslyn.SDK/ProjectTemplates/CSharp/Diagnostic/Test/Test.csproj) now targets `net8.0`. The [documentation tutorial](../docs/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix.md) doesn't hardcode the obsolete `netcoreapp2.0` target.

**Suggested closure explanation:** The reported .NET Core 2.0 template target was corrected upstream and isn't present in the current template source. Close the original defect rather than add instructions that preserve that target. The recommendation doesn't claim that previously generated projects or every installed extension version update automatically.

### dotnet/docs#26335: Update ML.NET deployment guides for minimal APIs and Azure Functions v4

**Opened:** October 1, 2021. **Confidence:** High for the original update request. **Reason:** Both explicitly requested deployment changes are present.

The issue's complete scope is the .NET 6-era update to minimal APIs and Azure Functions v4. The [Web API deployment guide](../docs/machine-learning/how-to-guides/serve-model-web-api-ml-net.md) now uses top-level statements, `WebApplication.CreateBuilder`, and `app.MapPost("/predict", predictionHandler)` rather than the old controller/startup workflow. The [Functions deployment guide](../docs/machine-learning/how-to-guides/serve-model-serverless-azure-functions-ml-net.md) links to a [sample project](https://github.com/dotnet/machinelearning-samples/blob/main/samples/csharp/end-to-end-apps/ScalableMLModelOnAzureFunction/SentimentAnalysisFunctionsApp/SentimentAnalysisFunctionsApp.csproj) whose actual project file targets `net6.0` and declares `AzureFunctionsVersion` as `v4`.

**Suggested closure explanation:** With assignee `luisquintanilla`, close the original minimal-API/Functions-v4 conversion request as addressed. The recommendation relies on those concrete changes, not on the age of .NET 6. It doesn't endorse .NET 6 as currently supported or claim that the older in-process Functions sample is a current isolated-worker tutorial.

### dotnet/docs#26349: Update ML.NET API tutorials and remove Visual Studio 2017 instructions

**Opened:** October 1, 2021. **Confidence:** High for the requested version/prerequisite refresh. **Reason:** Current API tutorials use newer prerequisites and project targets.

The issue asks for two changes: remove Visual Studio 2017 instructions and update tutorials to .NET 6. Current API tutorials instead require Visual Studio 2022 or later and create .NET 8 projects. Examples include [sentiment analysis](../docs/machine-learning/tutorials/sentiment-analysis.md), [price prediction](../docs/machine-learning/tutorials/predict-prices.md), [clustering](../docs/machine-learning/tutorials/iris-clustering.md), and [image classification](../docs/machine-learning/tutorials/image-classification-api-transfer-learning.md). The same newer prerequisite/target pattern appears across the regression, recommendation, anomaly, TensorFlow, and ONNX API walkthroughs.

No Visual Studio 2017 instructions remain in the tutorial Markdown searched; occurrences of 2017 in dataset citations aren't IDE prerequisites. Some introductions still mention Visual Studio 2019, but their actual prerequisites/project instructions use Visual Studio 2022 and .NET 8.

**Suggested closure explanation:** With assignee `luisquintanilla`, close the original Visual Studio 2017/.NET 6 refresh request as superseded by the newer tutorial instructions. The recommendation doesn't claim that every external sample was executed or that unrelated tutorial defects are resolved.

### dotnet/docs#26507: Clarify multiline if and match formatting

**Opened:** October 14, 2021. **Confidence:** High. **Reason:** Current guidance includes the layout accepted in the final discussion.

The discussion ultimately favors a newline after `if` or `match` for a long multiline condition/expression, one indentation level for that expression, and aligned `if`/`then` or `match`/`with` keywords. The current [if-expression guidance](../docs/fsharp/style-guide/formatting.md#formatting-if-expressions) states that rule and demonstrates it. The [pattern-matching guidance](../docs/fsharp/style-guide/formatting.md#formatting-pattern-matching) supplies the corresponding `match` example and recommends a separate binding when that improves clarity.

**Suggested closure explanation:** Link to both current formatting sections. They now document the final requested layout; the earlier objections in the discussion don't represent the final position. No new formatting-policy decision is needed for this request.

### dotnet/docs#27116: Make qualification simplification configurable

**Opened:** November 17, 2021. **Confidence:** High for the request to retain qualification. **Reason:** The current rule reference documents how to opt out.

The issue asks to make IDE0002 configurable so that explicit qualification can remain. The [IDE0002 suppression section](../docs/fundamentals/code-analysis/style-rules/ide0002.md#suppress-a-warning) now shows both a local pragma and `dotnet_diagnostic.IDE0002.severity = none` for a file, folder, or project. That configuration preserves the static-type qualification illustrated by the article.

The article still correctly says that the rule has no associated code-style options. Severity configuration isn't a new per-member style preference, and `this`/`base` qualification shouldn't be conflated with every case covered by IDE0002.

**Suggested closure explanation:** Link to the existing opt-out configuration. The requested ability to retain qualification doesn't require a documentation change. A request for a new, finer-grained analyzer preference would need its own explicit product requirements; don't describe such a feature as already implemented.

### dotnet/docs#27217: Explain single-file extraction after .NET 5

**Opened:** November 22, 2021. **Confidence:** High for the general documentation question. **Reason:** Current guidance explicitly distinguishes the extraction modes and cache location.

The [single-file guide's native-libraries section](../docs/core/deploying/single-file/overview.md#native-libraries) distinguishes managed assemblies loaded from the bundle in memory from native libraries embedded with `IncludeNativeLibrariesForSelfExtract`. It also states that `IncludeAllContentForSelfExtract` extracts all files, including managed assemblies. The same section identifies `%TEMP%/.net` as the default Windows extraction location and explains `DOTNET_BUNDLE_EXTRACT_BASE_DIR`.

**Suggested closure explanation:** Answer with the existing explanation and ask the reader to inspect the two extraction properties and the files actually extracted. A .NET 6-or-later target doesn't disable intentional native/content extraction. The recommendation doesn't diagnose the original project's unspecified publish settings or claim that a reproducible extraction bug has been fixed.

### dotnet/docs#27860: Link regex Unicode categories and named blocks

**Opened:** January 15, 2022. **Confidence:** High. **Reason:** The requested quick-reference links and supported-value lists already exist.

The [character-class quick-reference table](../docs/standard/base-types/regular-expression-language-quick-reference.md#character-classes) links both `\p{name}` and `\P{name}` explanations to the detailed character-class article. Its [Unicode category/block section](../docs/standard/base-types/character-classes-in-regular-expressions.md#unicode-category-or-unicode-block-p) links directly to the supported general-category and named-block tables. The latter explicitly includes `IsCyrillic`, the example raised in the issue.

**Suggested closure explanation:** Link to the existing category and block tables. The requested discoverability path now exists; don't introduce POSIX `Alnum` as though it were a supported .NET Unicode category or block name.

### dotnet/docs#27933: Remove the missing Startup.cs step from the ML.NET Web API guide

**Opened:** January 23, 2022. **Confidence:** High. **Reason:** The current walkthrough uses the modern Program.cs application model throughout.

The [Web API deployment guide](../docs/machine-learning/how-to-guides/serve-model-web-api-ml-net.md) now configures `PredictionEnginePool` through `builder.Services` after `WebApplication.CreateBuilder(args)` and maps the prediction endpoint with `app.MapPost`. It no longer directs readers to a nonexistent `Startup.cs` or `ConfigureServices` method. Those concrete changes address the template mismatch, rather than merely replace the prerequisite version.

**Suggested closure explanation:** With assignee `luisquintanilla`, close the original missing-Startup-file report as addressed by the Program.cs/minimal-API walkthrough. No instruction to create a legacy Startup class is needed.

### dotnet/docs#27938: Link API reference pages to implementation source

**Opened:** January 24, 2022. **Confidence:** High for the core-library source-link request. **Reason:** The published reference now includes source links, and the maintainer confirmed the change.

The [maintainer's resolution comment](https://github.com/dotnet/docs/issues/27938#issuecomment-2037771885) states that core-library API pages now link to source. The live [String.Chars reference](https://learn.microsoft.com/dotnet/api/system.string.chars?view=net-8.0), which the discussion uses as an example, exposes **Source** links to `String.cs` at specific GitHub revisions and line ranges. These are implementation-source links, not just links to the API documentation XML.

**Suggested closure explanation:** The core API reference supplies the requested source navigation. Close the documentation-platform request as implemented; don't claim every external or .NET Framework API has a corresponding public implementation link.

### dotnet/docs#28027: Consolidate the duplicate C# topic hierarchies

**Opened:** January 31, 2022. **Confidence:** High for the duplicated hierarchies identified in the issue. **Reason:** The current navigation and redirects consolidate the reported examples.

The [current C# TOC](../docs/csharp/toc.yml) no longer presents the old parallel **C# concepts** and **C# Programming guide** sections. It places the detailed [LINQ guide](../docs/csharp/linq/index.md) in one hierarchy and [expression trees](../docs/csharp/advanced-topics/expression-trees/index.md) under advanced topics. The [C# redirects](../.openpublishing.redirection.csharp.json) send the old programming-guide LINQ index to `/dotnet/csharp/linq/` and both former expression-tree entry points to the advanced-topic destination.

The maintainer's 2022 preference for the programming-guide hierarchy was explicitly temporary, pending reorganization. It shouldn't become a new instruction to recreate the old hierarchy.

**Suggested closure explanation:** Close the original overlapping-navigation question as superseded by the consolidated topic structure and preserved old URLs. The recommendation doesn't declare all possible C# content duplication resolved; any remaining concrete overlap can be identified separately.

### dotnet/docs#28046: Document compiler error CS8112

**Opened:** February 2, 2022. **Confidence:** High. **Reason:** A dedicated diagnostic explanation and help metadata now exist.

The [local-function errors article](../docs/csharp/language-reference/compiler-messages/local-function-errors.md#local-function-bodies) lists CS8112, explains the missing-body condition, and directs readers to add a block/expression body or use a valid `static extern` declaration for an externally supplied implementation. The article also includes CS8112 in its F1/help metadata. The error code is identifiable in the original issue's help URL even though its title is generic.

**Suggested closure explanation:** Link to the CS8112 local-function-body explanation. The missing diagnostic documentation now exists; no new standalone error page is needed.

### dotnet/docs#28331: Clarify whether source-generated logging methods require this

**Opened:** February 21, 2022. **Confidence:** High. **Reason:** The guide explicitly distinguishes ordinary static methods from optional extension methods.

The [current basic-usage section](../docs/core/extensions/logging/source-generation.md#basic-usage) says that a static logging method receives `ILogger` as an argument and that adding `this` makes the method an extension method. Its separate `StaticLog.cs` and `ExtensionLog.cs` snippets match that explanation. Instance methods retrieve the logger from instance state instead.

**Suggested closure explanation:** Link to the existing optional-extension explanation. The other static examples aren't missing a required modifier; don't add `this` to every logger parameter or break the valid example where `ILogger` isn't the first parameter.

### dotnet/docs#28417: Explain compiler error CS8862

**Opened:** February 27, 2022. **Confidence:** High. **Reason:** The constructor reference now documents the diagnostic and its correction.

The [primary-constructor declaration guidance](../docs/csharp/language-reference/compiler-messages/constructor-errors.md#primary-constructor-declaration) includes the CS8862 message and explicitly tells readers to add a `: this(...)` initializer that passes appropriate arguments to the primary constructor. CS8862 also appears in the article's diagnostic inventory and F1/help metadata.

**Suggested closure explanation:** The previously missing explanation now exists in the consolidated constructor-errors article. Link to the constructor-chaining guidance instead of create a duplicate record-constructor error page.
