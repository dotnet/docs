---
title: Feature Flags
description: Architecting Cloud Native .NET Apps for Azure | Cloud Native DevOps
ms.date: 05/02/2020
---

# Feature Flags

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

In chapter 1, we proclaimed that cloud native is much about speed and agility. Applications have become increasingly complex with users demanding more and more. Users expect rapid responsiveness, innovative features, and zero downtime. `Feature flags` are a software technique that allow you to "light up," or enable, functionality upon demand,without deploying new code. They separate feature releases from code deployment.

Feature flags are built upon conditional logic that control visibility of functionality for users at runtime. In cloud-based systems, it's common to push out new features into production early, but test them with limited user audience. As the confidence, increases, the features can then be incrementally rolled out to a wider audiences. As a best practice, feature flag configuration must be kept independent of your codebase. Then, at anytime, flags can be reconfigured to allow additional users visibility.

Feature flags can also be used to restrict functionality to specific customer groups, such as premium customers who are willing to pay higher subscription fees. If a feature were to become problematic, it could be disabled without having to stop the system. Likewise, an optional feature with high resource consumption could always be disabled during peak usage periods.

## Implementing feature flags

> talk about feature flags in Azure and Azure Config. 



enable new and experimental features




Feature flags are used to change runtime behavior of a program without restarting it. While they are essential in a cloud native environment, the must be used judiciously. In the past, they could be fairly tricky to implement across an organization's microservices, but Kubernetes has made them trivial to impleme


But when I say feature flags, sometimes called feature toggles or ops-toggles, I’m talking about a very different thing. I’m referring to making a dynamic decision in my code — live. I’m deciding which way I’m going to send a user, without having to push new code and without having to change a config file. It’s not static, like those other examples of flags. It’s a user-by-user, session-by-session decision.



replaces preprocessor commands

Can revert problematic releases quickly by flipping flag This
idea of “killing” a feature is better than having to do an emergency
fix or a code rollback.
Use

feature flag to turn off expensive subsystems when
under heavy traffic, and product managers wanting to expose some
features to only premium customers 



Directing Traffic
One simple way to think of a feature flag is as a traffic cop directing users. Maybe that traffic cop is sending 10 percent of the population to a new feature, and the rest are being sent around that feature — in other words, they are not getting that feature. This is what you do in a gradual rollout based on percentages of users. You can also roll out features to internal users, beta testers, free-tier users, or people who have opted in to get early updates – or any number of other attributes within a target population.

In a feature rollout, you put that traffic cop — the feature flag — into your code. Once you’ve done that, you control who goes where dynamically using rules that are edited externally. Deployed code isn’t necessarily released code. And when the code is released, it can be turned off without a rollback or a new deployment.

That’s the key with feature flags: they allow you to separate deployment from release. This unlocks a lot of power for you in terms of being able to gradually roll out individual pieces of your code — and do it without “canary releasing” to separate servers and routing traffic to them. It also enables you to conduct experiments. In both cases, you are simply routing some users one way and some users another way, and then observing the differences between the two groups.

>[!div class="step-by-step"]
>[Previous](azure-security.md)
>[Next](infrastructure-as-code.md)
