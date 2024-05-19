> [!NOTE]
> **.NET Core running on Linux and macOS systems only:** The collation behavior for the C and Posix cultures is always case-sensitive because these cultures do not use the expected Unicode collation order. We recommend that you use a culture other than C or Posix for performing culture-sensitive, case-insensitive sorting operations.  
