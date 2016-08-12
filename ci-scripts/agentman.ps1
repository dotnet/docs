$jnlpProcess = Get-Process java -ErrorAction SilentlyContinue

if (!$jnlpProcess) {