---
name: Merge an article
agent: agent
description: "Copy the content from one article into another."
---

Migrate the content in one article to another.

Pay attention to the following pieces of information when merging the articles:

- Copy all sections and their content from the source article to the destination article.
- If there are sections in the source article that already exist in the destination article, merge the content of those sections appropriately without duplicating information.
- Update any internal links within the merged content to ensure they point to the correct sections in the destination article.
- Ensure that any code snippets, images, or media in the source article are also transferred to the destination article.

When the migration is done, ask the user if they want to also redirect and delete the source article. If they do, invoke the `redirect-article` skill.
