# GitHub issues process and policy

The goals of the process are:

1. Ensure errors or omissions in our docs are not blocking customer success.
1. Be responsive to customer feedback and concerns.
1. Continually improve the customer experience.
1. Learn more about customer experiences through dialogue in the open on challenges and solutions.

The process uses two stages to ensure responsiveness while prioritizing work. The initial stage diagnoses and triages the issue. The second stage resolves the issue. When an issue is both easy and urgent, the two stages may be combined.

The process involves two time boxed tasks:

- Each team member spends up to 1/2 hour each business day [classifying incoming issues](#diagnosis-phase), including initial response. This ensures we are responsive on new issues.
- Each team member spends up to 1.5 days per sprint [updating documents](#resolution-phase) fixing customer generated GitHub issues.

## Diagnosis phase

Every team member spends up to 30 minutes per business day categorizing new issues. We answer the following questions:

- Is the issue a docs issue, or a product issue?
- Is it not an issue, but a question better suited for a forum or support site?
- What priority is the issue?
- What area manages this issue?

If these questions can't be answered in the initial examination, we ask clarifying questions in the comments.

There are types of issues that are closed during the diagnosis and triage phase:

- **kudos**: Express thanks, and close the issue.
- **product issue**: Issues that request product changes are closed. We may also take additional actions, as described below.
- **CoC violations**: These issues are closed, and reported if the [CoC violation](https://dotnetfoundation.org/code-of-conduct) merits reporting and blocking.
- **duplicates**: Duplicates are closed with a comment referencing the existing issue.
- **doc-ok**: The customer is incorrect, and the doc is correct.
- **forum**: Issues that are support or forum requests are directed to Stack Overflow, or other support sites, and closed.

### Actions on product issues

Depending on the nature of the product issue, we may choose to:

- Transfer the issue to the appropriate product repository.
- Close the issue as a duplicate of existing product requests.
- Close the issue with a recommendation to open on the product repository.

Evaluating the correct course of action is subjective. The team members use their judgment on the correct action.

### Actions on content issues

For other issues, the team:

- assigns a priority
- assigns a milestone, usually "Backlog"
- reflects tier level support
- assesses if an issue is a good "up for grabs" issue.

Priority levels are based on the following guidelines, but are subjective. The milestones are also subjective, and will be based on other priorities such as current product release schedules and upcoming launches.

- **P0**: A docs omission or error prevents customers from succeeding in a common scenario.
  -  ***P0** issues are addressed in the current sprint, taking precedence over previously scheduled work.
- **P1**: A docs omission or error makes a common scenario much harder, or blocks other well-known scenarios.
  - **P1** issues are scheduled in a timely manner. Often, P1 issues are planned for an upcoming milestone.
- **P2**: Issues that cause minor inconveniences, or affect a low page view article.
  - **P2** issues are generally fixed when an article is updated for higher-priority reasons.
- **P3**: Issues that are requests for edge case scenarios.
  - **P3** issues are placed in the backlog and are considered for update when articles are updated for higher-priority reasons.

The diagnosis and triage activities are time-boxed to enable the team to make progress on tasks scheduled for each sprint. Each team member spends at most 30 minutes per day in diagnosis and triage. In order to stay current, diagnosis and triage cannot turn into a resolution session. At most, consider if a single sentence or two can answer a question and provide enough insight for a customer PR.

The **up-for-grabs** label is applied when an issue is a good candidate for a community member (possibly the author) to submit a fix. The team member that applies the **up-for-grabs** label has committed to help community members work through the PR creation process. Issues that are "up for grabs" are often added to the [Community Contribution projects](https://github.com/dotnet/docs/projects/35)

> NOTE: We've only recently adopted the preceding convention. The person that added the label refer you to another team member who will help.

## Resolution phase

Customer generated issues are weighted as part of sprint planning. Each team member allocates 4 hours per week to addressing the highest priority customer issues.

Issue resolution follows from the priority level set during diagnosis. The incoming customer issues are prioritized with other scheduled work of similar priority

- **P0**: As soon as is reasonable, during the current or subsequent sprint.
- **P1**: Scheduled with other planned P1 work. This usually means in the next three months.
- **P2**: Scheduled with other planned P2 work. Some P2 issues are handled in each sprint based on area and visibility. More often, P2 issues will be addressed when an article is updated.
- **P3**: No guarantee on fix date. When an article is updated, we examine the backlog for other issues on the same article.

Issues may be reprioritized based on new feedback and data about article visibility.
