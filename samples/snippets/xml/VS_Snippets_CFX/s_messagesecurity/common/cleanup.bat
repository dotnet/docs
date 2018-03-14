echo off
set CLIENT_NAME=client.com
set SERVER_NAME=localhost

echo ****************
echo Cleanup starting
echo ****************

echo -------------------------
echo del client certs
echo -------------------------
certmgr -del -r CurrentUser -s My -c -n %CLIENT_NAME%
certmgr -del -r CurrentUser -s TrustedPeople -c -n %SERVER_NAME%

echo -------------------------
echo del service certs
echo -------------------------
certmgr -del -r LocalMachine -s My -c -n %SERVER_NAME%
certmgr -del -r LocalMachine -s TrustedPeople -c -n %CLIENT_NAME%

echo *****************
echo Cleanup completed
echo *****************


