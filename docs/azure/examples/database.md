---
title: Provision an Azure MySQL database using the Azure SDK libraries
description: Use the management libraries in the Azure SDK libraries for Python to provision an Azure MySQL, PostgresSQL, or MariaDB database.
ms.date: 06/02/2020
ms.topic: conceptual
---

# Example: Use the Azure libraries to provision a database

This example demonstrates how to use the Azure SDK management libraries in a Python script to provision an Azure MySQL database. ([Equivalent Azure CLI commands](#for-reference-equivalent-azure-cli-commands) are given at later in this article.) It also provides a simple script to query the database using the mysql-connector library (not part of the Azure SDK).

You can use similar code to provision a PostgreSQL or MariaDB database.

All the commands in this article work the same in Linux/Mac OS bash and Windows command shells unless noted.

## 1: Set up your local development environment

If you haven't already, follow all the instructions on [Configure your local Python dev environment for Azure](configure-local-development-environment.md).

Be sure to create a service principal for local development, and create and activate a virtual environment for this project.

## 2: Install the needed Azure library packages

Create a file named *requirements.txt* with the following contents:

```text
azure-mgmt-resource
azure-mgmt-rdbms
azure-cli-core
mysql
mysql-connector
```

In a terminal or command prompt with the virtual environment activated, install the requirements:

```cmd
pip install -r requirements.txt
```

> [!NOTE]
> On Windows, attempting to install the mysql library into a 32-bit Python library produces an error about the *mysql.h* file. In this case, install a 64-bit version of Python and try again.

## 3: Write code to provision the database

Create a Python file named *provision_db.py* with the following code. The comments explain the details.

```python
import random, os
from azure.common.client_factory import get_client_from_cli_profile
from azure.mgmt.resource import ResourceManagementClient

# For PostgreSQL, use the PostgreSQLManagement class.
# For MariaDB, use the MariaDBManagement class.
from azure.mgmt.rdbms.mysql import MySQLManagementClient

from azure.mgmt.rdbms.mysql.models import ServerForCreate, ServerPropertiesForDefaultCreate, ServerVersion

# Retrieve subscription ID from environment variable
subscription_id = os.environ["AZURE_SUBSCRIPTION_ID"]

# Constants we need in multiple places: the resource group name and the region
# in which we provision resources. You can change these values however you want.
RESOURCE_GROUP_NAME = 'PythonAzureExample-DB-rg'
LOCATION = "westus"

# Step 1: Provision the resource group.
resource_client = get_client_from_cli_profile(ResourceManagementClient)

rg_result = resource_client.resource_groups.create_or_update(RESOURCE_GROUP_NAME,
    { "location": LOCATION })

print(f"Provisioned resource group {rg_result.name}")

# For details on the previous code, see Example: Provision a resource group
# at https://docs.microsoft.com/azure/developer/python/azure-sdk-example-resource-group


# Step 2: Provision the database server

# We use a random number to create a reasonably unique database server name.
# If you've already provisioned a database and need to re-run the script, set
# the DB_SERVER_NAME environment variable to that name instead.
#
# Also set DB_USER_NAME and DB_USER_PASSWORD variables to avoid using the defaults.

db_server_name = os.environ.get("DB_SERVER_NAME", f"PythonAzureExample-MySQL-{random.randint(1,100000):05}")
db_admin_name = os.environ.get("DB_ADMIN_NAME", "azureuser")
db_admin_password = os.environ.get("DB_ADMIN_PASSWORD", "ChangePa$$w0rd24")

# Obtain the management client object
mysql_client = get_client_from_cli_profile(MySQLManagementClient)

# Provision the server and wait for the result
poller = mysql_client.servers.create(RESOURCE_GROUP_NAME,
    db_server_name,
    ServerForCreate(
        location=LOCATION,
        properties=ServerPropertiesForDefaultCreate(
            administrator_login=db_admin_name,
            administrator_login_password=db_admin_password,
            version=ServerVersion.five_full_stop_seven
        )
    )
)

server = poller.result()

print(f"Provisioned MySQL server {server.name}")

# Step 3: Provision a firewall rule to allow the local workstation to connect

RULE_NAME = "allow_ip"
ip_address = os.environ["PUBLIC_IP_ADDRESS"]

# For the above code, create an environment variable named PUBLIC_IP_ADDRESS that
# contains your workstation's public IP address as reported by a site like
# https://whatismyipaddress.com/.

# Provision the rule and wait for completion
poller = mysql_client.firewall_rules.create_or_update(RESOURCE_GROUP_NAME,
    db_server_name, RULE_NAME,
    ip_address,  # Start ip range
    ip_address   # End ip range
)

firewall_rule = poller.result()

print(f"Provisioned firewall rule {firewall_rule.name}")

# Step 4: Provision a database on the server

DB_NAME = "example-db1"

poller = mysql_client.databases.create_or_update(RESOURCE_GROUP_NAME,
    db_server_name, DB_NAME)

db_result = poller.result()

print(f"Provisioned MySQL database {db_result.name} with ID {db_result.id}")
```

You must create an environment variable named `PUBLIC_IP_ADDRESS` with your workstation's IP address for this sample to run.

This code uses the CLI-based authentication methods (`get_client_from_cli_profile`) because it demonstrates actions that you might otherwise do with the Azure CLI directly. In both cases you're using the same identity for authentication.

To use such code in a production script, you should instead use `DefaultAzureCredential` (recommended) or a service principal based method as describe in [How to authenticate Python apps with Azure services](azure-sdk-authenticate.md).

### Reference links for classes used in the code

- [ResourceManagementClient (azure.mgmt.resource)](/python/api/azure-mgmt-resource/azure.mgmt.resource.resourcemanagementclient?view=azure-python)
- [MySQLManagementClient (azure.mgmt.rdbms.mysql)](/python/api/azure-mgmt-rdbms/azure.mgmt.rdbms.mysql.mysqlmanagementclient?view=azure-python)
- [ServerForCreate (azure.mgmt.rdbms.mysql.models)](/python/api/azure-mgmt-rdbms/azure.mgmt.rdbms.mysql.models.serverforcreate?view=azure-python)
- [ServerPropertiesForDefaultCreate (azure.mgmt.rdbms.mysql.models)](/python/api/azure-mgmt-rdbms/azure.mgmt.rdbms.mysql.models.serverpropertiesfordefaultcreate?view=azure-python)
- [ServerVersion (azure.mgmt.rdbms.mysql.models)](/python/api/azure-mgmt-rdbms/azure.mgmt.rdbms.mysql.models.serverversion?view=azure-python)

Also see:
    - [PostgreSQLManagementClient (azure.mgmt.rdbms.postgresql)](/python/api/azure-mgmt-rdbms/azure.mgmt.rdbms.postgresql.postgresqlmanagementclient?view=azure-python)
    - [MariaDBManagementClient (azure.mgmt.rdbms.mariadb)](/python/api/azure-mgmt-rdbms/azure.mgmt.rdbms.mariadb.mariadbmanagementclient?view=azure-python)

## 4: Run the script

```cmd
python provision_db.py
```

## 5: Insert a record and query the database

Create a file named *use_db.py* with the following code. Note the dependencies on the `DB_SERVER_NAME`, `DB_ADMIN_NAME`, and `DB_ADMIN_PASSWORD` environment variables, which should be populated with the values from the provisioning code.

This code work only for MySQL; you use different libraries for PostgreSQL and MariaDB.

```python
import os
import mysql.connector

db_server_name = os.environ["DB_SERVER_NAME"]
db_admin_name = os.environ.get("DB_ADMIN_NAME", "azureuser")
db_admin_password = os.environ.get("DB_ADMIN_PASSWORD", "ChangePa$$w0rd24")

DB_NAME = "example-db"

connection = mysql.connector.connect(user=f"{db_admin_name}@{db_server_name}",
    password=db_admin_password, host=f"{db_server_name}.mysql.database.azure.com", port=3306,
    database=DB_NAME)

cursor = connection.cursor()

table_name = "ExampleTable1"

sql_create = f"CREATE TABLE {table_name} (name varchar(255), code int)"

cursor.execute(sql_create)
print(f"Successfully created table {table_name}")

sql_insert = f"INSERT INTO {table_name} (name, code) VALUES ('Azure', 1)"
insert_data = "('Azure', 1)"

cursor.execute(sql_insert)
print("Successfully inserted data into table")

sql_select_values= f"SELECT * FROM {table_name}"

cursor.execute(sql_select_values)
row = cursor.fetchone()

while row:
    print(str(row[0]) + " " + str(row[1]))
    row = cursor.fetchone()

connection.commit()
```

All of this code uses the mysql.connector API. The only Azure-specific part is the full host domain for MySQL server (mysql.database.azure.com).

Then run the code:

```cmd
python use_db.py
```

## 6: Clean up resources

```azurecli
az group delete -n PythonAzureExample-DB-rg
```

Run this command if you don't need to keep the resources provisioned in this example and would like to avoid ongoing charges in your subscription.

You can also use the [`ResourceManagementClient.resource_groups.delete`](/python/api/azure-mgmt-resource/azure.mgmt.resource.resources.v2019_10_01.operations.resourcegroupsoperations?view=azure-python#delete-resource-group-name--custom-headers-none--raw-false--polling-true----operation-config-) method to delete a resource group from code.

### For reference: equivalent Azure CLI commands

The following Azure CLI commands complete the same provisioning steps as the Python script. For a PostgreSQL database, use [`az postgres`](/cli/azure/postgres?view=azure-cli-latest) commands; for MariaDB, use [`az mariadb`](/cli/azure/mariadb?view=azure-cli-latest) commands.

# [cmd](#tab/cmd)

```azurecli
az group create -l centralus -n PythonAzureExample-DB-rg

az mysql server create -l westus -g PythonAzureExample-DB-rg -n PythonAzureExample-MySQL-12345 ^
    -u azureuser -p ChangePa$$w0rd24 --sku-name B_Gen5_1

# Change the IP address to the public IP address of your workstation, that is, the address shown
# by a site like https://whatismyipaddress.com/. 

az mysql server firewall-rule create -g PythonAzureExample-DB-rg --server PythonAzureExample-MySQL-12345 ^
    -n allow_ip --start-ip-address 10.11.12.13 --end-ip-address 10.11.12.13

az mysql db create -g PythonAzureExample-DB-rg --server PythonAzureExample-MySQL-12345 -n example-db
```

# [bash](#tab/bash)

```azurecli
az group create -l centralus -n PythonAzureExample-DB-rg

az mysql server create -l westus -g PythonAzureExample-DB-rg -n PythonAzureExample-MySQL-12345 \
    -u azureuser -p ChangePa$$w0rd24 --sku-name B_Gen5_1

# Change the IP address to the public IP address of your workstation, that is, the address shown
# by a site like https://whatismyipaddress.com/. 

az mysql server firewall-rule create -g PythonAzureExample-DB-rg --server PythonAzureExample-MySQL-12345 \
    -n allow_ip --start-ip-address 10.11.12.13 --end-ip-address 10.11.12.13

az mysql db create -g PythonAzureExample-DB-rg --server PythonAzureExample-MySQL-12345 -n example-db
```

---

## See also

- [Example: Provision a resource group](azure-sdk-example-resource-group.md)
- [Example: Provision Azure Storage](azure-sdk-example-storage.md)
- [Example: Use Azure Storage](azure-sdk-example-storage-use.md)
- [Example: Provision a virtual machine](azure-sdk-example-virtual-machines.md)
- [Example: Provision and deploy a web app](azure-sdk-example-web-app.md)
