// @ts-check

import jsoncParse from "./jsonc-parse.mjs";
import yamlParse from "./yaml-parse.mjs";

/**
 * Array of parser objects ordered by priority.
 */
const parsers = [
  jsoncParse,
  yamlParse
];

export default parsers;
