// @ts-check

const sliceSize = 1000;

/**
 * Efficiently appends the source array to the destination array.
 * @param {object[]} destination Destination Array.
 * @param {object[]} source Source Array.
 * @returns {void}
 */
const appendToArray = (destination, source) => {
  // NOTE: destination.push(...source) throws "RangeError: Maximum call stack
  // size exceeded" for sufficiently lengthy source arrays
  let index = 0;
  let slice = null;
  while ((slice = source.slice(index, index + sliceSize)).length > 0) {
    destination.push(...slice);
    index += sliceSize;
  }
};

export default appendToArray;
export { sliceSize };
