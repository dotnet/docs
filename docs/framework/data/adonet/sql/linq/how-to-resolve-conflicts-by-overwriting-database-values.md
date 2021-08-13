---
description: "Learn more about: How to: Resolve Conflicts by Overwriting Database Values"
title: "How to: Resolve Conflicts by Overwriting Database Values"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: fd6db0b8-c29c-48ff-b768-31d28e7a148c
---
# How to: Resolve Conflicts by Overwriting Database Values

To reconcile differences between expected and actual database values before you try to resubmit your changes, you can use <xref:System.Data.Linq.RefreshMode.KeepCurrentValues> to overwrite database values. For more information, see [Optimistic Concurrency: Overview](optimistic-concurrency-overview.md).

> [!NOTE]
> In all cases, the record on the client is first refreshed by retrieving the updated data from the database. This action makes sure that the next update try will not fail on the same concurrency checks.

## Example

 In this scenario, an <xref:System.Data.Linq.ChangeConflictException> exception is thrown when User1 tries to submit changes, because User2 has in the meantime changed the Assistant and Department columns. The following table shows the situation.

| State                                                    | Manager | Assistant | Department |
| -------------------------------------------------------- | ------- | --------- | ---------- |
| Original database state when queried by User1 and User2. | Alfreds | Maria     | Sales      |
| User1 prepares to submit these changes.                  | Alfred  |           | Marketing  |
| User2 has already submitted these changes.               |         | Mary      | Service    |

 User1 decides to resolve this conflict by overwriting database values with the current client member values.

 When User1 resolves the conflict by using <xref:System.Data.Linq.RefreshMode.KeepCurrentValues>, the result in the database is as in following table:

| State                                | Manager                         | Assistant                    | Department                         |
| ------------------------------------ | ------------------------------- | ---------------------------- | ---------------------------------- |
| New state after conflict resolution. | Alfred<br /><br /> (from User1) | Maria<br /><br /> (original) | Marketing<br /><br /> (from User1) |

 The following example code shows how to overwrite database values with the current client member values. (No inspection or custom handling of individual member conflicts occurs.)

 [!code-csharp[System.Data.Linq.RefreshMode#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.refreshmode/cs/program.cs#2)]
 [!code-vb[System.Data.Linq.RefreshMode#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.refreshmode/vb/module1.vb#2)]

## See also

- [How to: Manage Change Conflicts](how-to-manage-change-conflicts.md)
