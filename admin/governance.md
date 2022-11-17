# :octocat: Repository governance

This file contains notes on our tools and processes for working in this repo. It's meant as notes for the maintainers, but may be informative for other contributors as well.

## :gear: Workflows installed

We have the following workflows that run on most PRs:

- **OpenPublishing.Build** *required*: This builds published docs site using the changes from the PR. It's how we verify changes before publishing. We can see any changes in a staging site before publishing.
- **Snippets 5000 / snippets-build** *required*: This workflow scans the PR for any changes to source code. If any source code files are changed, it ensures the changes are part of a project, and then builds that project. We require all code snippets to be included in a project that produces a clean build on the current version of .NET (unless a config file pins that project to a known older version.)
- **MSDocs build verifier / MSDocs build verifier**  *required*: This action verifies links and other docfx syntax for our build.
- **OPS status checker / Look for build warnings** *required*: This action fails when the OPS build has warnings. That prevents auto-merge from merging PRs with warnings.
- **license/cla**: This ensures that any contributor making large scale changes to our docs has signed the Contributor License Agreement (CLA).
- **.github/workflows/live-protection.yml**: This action ensures that the only PRs that target the `live` branch use the `main` branch as the source. All work should take place against the `main` branch. Nothing should be merged to `live` that hasn't been published on the staging site in the `main` branch.
- **Markdownlint / lint**: We like our markdown clean and spiffy. Please keep it that way.
- **dependabot auto-approve and auto-merge**: We have dependabot installed to open PRs when referenced NuGet packages are updated. If the build is clean for those updates, those PRs are automatically merged by this action.

## :shield: Branch protection rules

We've also configured a variety of branch protection rules in place on the `main` branch:

- All changes to the `main` branch must be through a PR (no direct push privileges to `main`)
- All PRs must have at least one approval from a maintainer.
- All required checks must pass.
- All open conversations must be resolved.
- Protection rules apply to everyone, including administrators.

> On rare occasions, we may override the required checks. This should be rare, and only after exhausting other options.
>
> If you do need to override the required settings, turn off the "Do not allow bypassing the above settings*. Then, refresh the PR, merge it, and the reapply the "Do not allow bypassing" setting. This is only available to administrators.

If you change any branch protection rules, alert the @dotnet/docs team via email about the change.

## :white_check_mark: Automation we use

We have several other workflows installed to automate a variety of tasks:

- **dependabot-bot**: This regenerates our dependabot config file periodically.
- **no-response**: This action automatically closes PRs or issues where we've asked for clarification from the original poster (OP) and haven't heard any response. It will only happen when the `needs-more-info` label has been applied. Use that label with care.
- **quest**: This action links and synchronizes GitHub issues with an internal Azure DevOps instance used for reporting and planning.
- **version-sweep**: This action periodically checks for samples that use TFMs that are out of support. It helps us keep our samples up to date.
- **whats-new**: This action runs once a month to publish our "What's new" article.
- **repo-man**: This GitHub workflow examines issues and PRs and adds classification labels.

You can see the full details on configured GitHub actions in our [README.MD](https://github.com/dotnet/docs#octocat-github-action-workflows) file.

## :label: Labels for automation

- `needs-more-info`: We apply this label when we can't proceed without more information. An action will close this issue if there isn't a response. It will remove the label when a new comment from the OP is added.
- `rerun-action-*`: These labels trigger *repo-man* to apply classification labels.
- `:world_map: reQUEST`, `:pushpin: seQUESTered`: These labels trigger the Quest action to sync issues with our internal Azure DevOps board.

## :ledger: Labels for reporting

- `*/tech`, `*/prod`: These labels provide 1st and 2nd level organization to our content.
- `doc-*`, `product-*`: These provide classifications for what kind of issue is it.
- `okr-*`: These map to our internal OKR system.

## :heavy_plus_sign: Additional fields in projects

We're assigning values to the following additional properties using the new GitHub project system.

- *Size*: The relative size of work required.
- *Priority*: The relative priority of this issue. This should map to the `Pri?` labels.
