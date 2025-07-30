// @ts-check

import { parse, printParseErrorCode } from "jsonc-parser";

/**
 * Parses a JSONC string, returning the corresponding object.
 * @param {string} text String to parse as JSONC.
 * @returns {object} Corresponding object.
 */
const jsoncParse = (text) => {
  const errors = [];
  const result = parse(text, errors, { "allowTrailingComma": true });
  if (errors.length > 0) {
    const aggregate = errors.map(
      (error) => `${printParseErrorCode(error.error)} (offset ${error.offset}, length ${error.length})`
    ).join(", ");
    throw new Error(`Unable to parse JSONC content, ${aggregate}`);
  }
  return result;
};

export default jsoncParse;
