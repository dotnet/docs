byte[] data = new byte[DATA_SIZE];
byte[] result;
SHA1 shaM = new SHA1Managed();
result = shaM.ComputeHash(data);