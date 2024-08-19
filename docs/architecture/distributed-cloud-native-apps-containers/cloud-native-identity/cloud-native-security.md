---
title: Cloud-native security
description: Architecting Cloud Native .NET Apps for Azure | Cloud-native security
ms.date: 04/06/2022
---

# Cloud-native security

[!INCLUDE [download-alert](includes/download-alert.md)]

Not a day goes by without the news of a company being hacked or somehow losing their customers' data. Even countries and large jurisdictions aren't immune to the problems created by treating security as an afterthought. For years, companies have treated the security of customer data and, in fact, of their entire networks as something of a "nice to have". Windows servers were left unpatched, ancient versions of PHP kept running, and databases left wide open to the world.

However, real-world consequences are now almost inevitable for not maintaining a security mindset when building and deploying applications. Many companies learned the hard way what can happen when servers and desktops aren't patched during the 2017 outbreak of [NotPetya](https://www.wired.com/story/notpetya-cyberattack-ukraine-russia-code-crashed-the-world/). The cost of these attacks has easily reached into the billions, with some estimates putting the losses from this single attack at 10 billion US dollars.

Even governments aren't immune to hacking incidents. The city of Baltimore was held ransom by [criminals](https://www.vox.com/recode/2019/5/21/18634505/baltimore-ransom-robbinhood-mayor-jack-young-hackers) making it impossible for citizens to pay their bills or use city services.

There has also been an increase in legislation that mandates certain data protections for personal data. In Europe, GDPR has been in effect since 2018 and, in the same year, California created their own version called the California Consumer Privacy Act (CCPA), which came into effect January 1, 2020. The fines under GDPR can be so punishing as to put companies out of business. Google has already been fined 50 million Euros for violations, but that's just a drop in the ocean compared with the potential fines.

In short, security is serious business. Cloud native apps have their own security challenges. For example, if a user is authenticated by one microservice, how do you authorize them to access other microservices.

In this chapter you will learn about identity, authorization, and authentication, how security is provided on-premises and in the cloud, as well as about security products, both from Microsoft and third-party open-source providers.

>[!div class="step-by-step"]
>[Previous]
>[Next](identity.md)
