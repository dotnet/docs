---
uid: System.Text.Encoding.UTF8
summary: '*You can override summary for the API here using *MARKDOWN* syntax'
---

*Please type below more information about this API:*

The UTF8Encoding object that is returned by this property might not have the appropriate behavior for your app.
- It returns a UTF8Encoding object that provides a Unicode byte order mark (BOM). To instantiate a UTF8 encoding that doesn't provide a BOM, call any overload of the UTF8Encoding constructor.
- It returns a UTF8Encoding object that uses replacement fallback to replace each string that it can't encode and each byte that it can't decode with a question mark ("?") character. Instead, you can call the UTF8Encoding.UTF8Encoding(Boolean, Boolean) constructor to instantiate a UTF8Encoding object whose fallback is either an EncoderFallbackException or a DecoderFallbackException.
