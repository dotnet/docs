byte[] data = new byte[DATA_SIZE];
byte[] result;
SHA512 shaM = new SHA512Managed();
result = shaM.ComputeHash(data);