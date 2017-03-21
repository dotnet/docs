byte[] data = new byte[DATA_SIZE];
byte[] result;
SHA384 shaM = new SHA384Managed();
result = shaM.ComputeHash(data);