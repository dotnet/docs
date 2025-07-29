#!/usr/bin/env node

import { "main" as markdownlintCli2 } from "./markdownlint-cli2.mjs";

const params = {
  "argv": process.argv.slice(2),
  "logMessage": console.log,
  "logError": console.error,
  "allowStdin": true
};
try {
  process.exitCode = await markdownlintCli2(params);
} catch (error) {
  console.error(error);
  process.exitCode = 2;
}
