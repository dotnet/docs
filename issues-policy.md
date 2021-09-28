# GitHub issues process and policy

The goals of the process are:

1. Ensure errors or omissions in our docs are not blocking customer success.
1. Be responsive to customer feedback and concerns.
1. Continually improve the customer experience.
1. Learn more about customer experiences through open dialog on challenges and solutions.

The process uses two stages to ensure responsiveness while prioritizing work. The initial stage diagnoses and triages the issue. The second stage resolves the issue. When an issue is both easy and urgent, the two stages may be combined.

The process involves tasks with fixed time allocations:

- Each team member spends up to 1/2 hour each business day [classifying incoming issues](#diagnosis-phase), including initial responses. This ensures we are responsive to new issues.
- Each team member spends up to 1/2 day per week [updating documents](#resolution-phase) to address customer-generated GitHub issues.

## Diagnosis phase

Every team member spends up to 30 minutes per business day categorizing new issues. We answer the following questions:

- Is the issue a docs issue or a product issue?
- Is it not an issue, but a question better suited for a forum or support site?
- What priority is the issue?
- What area manages this issue?

If these questions can't be answered in the initial examination, we ask clarifying questions in the comments.

There are types of issues that are closed during the diagnosis and triage phase:

- **kudos**: We express thanks, and close the issue.
- **product issue**: Issues that are related to the product and not to its documentation are closed. We may also take additional actions, as described below.
- **CoC violations**: These issues are closed and reported if the [CoC violation](https://dotnetfoundation.org/code-of-conduct) merits reporting and blocking.
- **duplicates**: Duplicates are closed with a comment referencing the existing issue.
- **doc-ok**: The customer is incorrect, and the doc is correct.
- **forum**: Issues that are support or forum requests are directed to Stack Overflow or other support sites, and closed.

### Actions on product issues

Depending on the nature of the product issue, we may choose to:

- Transfer the issue to the appropriate product repository.
- Close the issue as a duplicate of existing product requests.
- Close the issue with a recommendation to open on the product repository.

Evaluating the correct course of action is subjective. The team members use their judgment on the correct action.

### Actions on content issues

For other issues, the team:

- Assigns a priority
- Assigns a milestone, usually "Backlog"
- Assesses if an issue is a good "up for grabs" issue, or the [Projects for .NET Community Contributors](https://github.com/dotnet/docs/projects/35)

Priority levels are based on the following guidelines but are subjective. The milestones are also subjective and are based on other priorities such as current product release schedules and upcoming launches.

- **P0**: A docs omission or error prevents customers from succeeding in a common scenario.
  - **P0** issues are addressed within the next three weeks, taking precedence over previously scheduled work.
- **P1**: A docs omission or error makes a common scenario much harder or blocks other well-known scenarios.
  - **P1** issues are scheduled in a timely manner. Often, P1 issues are planned for an upcoming milestone.
- **P2**: Issues that cause minor inconveniences, or affect a low page view article.
  - **P2** issues are generally fixed when an article is updated for higher-priority reasons.
- **P3**: Issues that are requests for edge case scenarios.
  - **P3** issues are placed in the backlog and are considered for update when articles are updated for higher-priority reasons.

Team members spend a limited amount of time on diagnosis and triage so they can make progress on scheduled tasks. Each team member spends at most 30 minutes per day in diagnosis and triage.

The **up-for-grabs** label is applied when an issue is a good candidate for a community member (possibly the author) to submit a fix. The team member that applies the **up-for-grabs** label will help or find someone to help community members work through the PR creation process. Issues that are "up for grabs" are often added to the [Community Contribution projects](https://github.com/dotnet/docs/projects/35)

> NOTE: We've only recently adopted the preceding convention. The person that added the label may refer you to another team member who will help.

## Resolution phase

Customer generated issues are weighted as part of scheduled task planning. Each team member allocates 4 hours per week to addressing the highest priority customer issues.

Issue resolution follows from the priority level set during diagnosis. The incoming customer issues are prioritized with other scheduled work of similar priority

- **P0**: As soon as is reasonable, during the next three weeks.
- **P1**: Scheduled with other planned P1 work. This usually means in the next three months.
- **P2**: Scheduled with other planned P2 work. P2 issues are scheduled regularly based on area and visibility. More often, P2 issues will be addressed when an article is updated.
- **P3**: No guarantee on fix date. When an article is updated, we examine the backlog for other issues on the same article.

Issues may be reprioritized based on new feedback and data about article visibility.
