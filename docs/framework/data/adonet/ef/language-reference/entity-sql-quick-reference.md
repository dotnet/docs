---
description: "Learn more about: Entity SQL Quick Reference"
title: "Entity SQL Quick Reference"
ms.date: "03/30/2017"
ms.assetid: e53dad9e-5e83-426e-abb4-be3e78e3d6dc
---
# Entity SQL Quick Reference

This topic provides a quick reference to Entity SQL queries. The queries in this topic are based on the AdventureWorks Sales model.

## Literals

### String

 There are Unicode and non-Unicode character string literals. Unicode strings are prepended with N. For example, `N'hello'`.

 The following is an example of a Non-Unicode string literal:

```sql
'hello'
--same as
"hello"
```

 Output:

|Value|
|-----------|
|hello|

### DateTime

 In DateTime literals, both date and time parts are mandatory. There are no default values.

 Example:

```sql
DATETIME '2006-12-25 01:01:00.000'
--same as
DATETIME '2006-12-25 01:01'
```

 Output:

|Value|
|-----------|
|12/25/2006 1:01:00 AM|

### Integer

 Integer literals can be of type Int32 (123), UInt32 (123U), Int64 (123L), and UInt64 (123UL).

 Example:

```sql
--a collection of integers
{1, 2, 3}
```

 Output:

|Value|
|-----------|
|1|
|2|
|3|

### Other

 Other literals supported by Entity SQL are Guid, Binary, Float/Double, Decimal, and `null`. Null literals in Entity SQL are considered to be compatible with every other type in the conceptual model.

## Type Constructors

### ROW

 [ROW](row-entity-sql.md) constructs an anonymous, structurally-typed (record) value as in: `ROW(1 AS myNumber, 'Name' AS myName).`

 Example:

```sql
SELECT VALUE row (product.ProductID AS ProductID, product.Name
    AS ProductName) FROM AdventureWorksEntities.Product AS product
```

 Output:

|ProductID|Name|
|---------------|----------|
|1|Adjustable Race|
|879|All-Purpose Bike Stand|
|712|AWC Logo Cap|
|...|...|

### MULTISET

 [MULTISET](multiset-entity-sql.md) constructs collections, such as:

 `MULTISET(1,2,2,3)` `--same as`-`{1,2,2,3}.`

 Example:

```sql
SELECT VALUE product FROM AdventureWorksEntities.Product AS product WHERE product.ListPrice IN MultiSet (125, 300)
```

 Output:

|ProductID|Name|ProductNumber|…|
|---------------|----------|-------------------|-------|
|842|Touring-Panniers, Large|PA-T100|…|

### Object

 [Named Type Constructor](named-type-constructor-entity-sql.md) constructs (named) user-defined objects, such as `person("abc", 12)`.

 Example:

```sql
SELECT VALUE AdventureWorksModel.SalesOrderDetail (o.SalesOrderDetailID, o.CarrierTrackingNumber, o.OrderQty,
o.ProductID, o.SpecialOfferID, o.UnitPrice, o.UnitPriceDiscount,
o.rowguid, o.ModifiedDate) FROM AdventureWorksEntities.SalesOrderDetail
AS o
```

 Output:

|SalesOrderDetailID|CarrierTrackingNumber|OrderQty|ProductID|...|
|------------------------|---------------------------|--------------|---------------|---------|
|1|4911-403C-98|1|776|...|
|2|4911-403C-98|3|777|...|
|...|...|...|...|...|

## References

### REF

 [REF](ref-entity-sql.md) creates a reference to an entity type instance. For example, the following query returns references to each Order entity in the Orders entity set:

```sql
SELECT REF(o) AS OrderID FROM Orders AS o
```

 Output:

|Value|
|-----------|
|1|
|2|
|3|
|...|

 The following example uses the property extraction operator (.) to access a property of an entity. When the property extraction operator is used, the reference is automatically dereferenced.

 Example:

```sql
SELECT VALUE REF(p).Name FROM
    AdventureWorksEntities.Product AS p
```

 Output:

|Value|
|-----------|
|Adjustable Race|
|All-Purpose Bike Stand|
|AWC Logo Cap|
|...|

### DEREF

 [DEREF](deref-entity-sql.md) dereferences a reference value and produces the result of that dereference. For example, the following query produces the Order entities for each Order in the Orders entity set: `SELECT DEREF(o2.r) FROM (SELECT REF(o) AS r FROM LOB.Orders AS o) AS o2`..

 Example:

```sql
SELECT VALUE DEREF(REF(p)).Name FROM
    AdventureWorksEntities.Product AS p
```

 Output:

|Value|
|-----------|
|Adjustable Race|
|All-Purpose Bike Stand|
|AWC Logo Cap|
|...|

### CREATEREF AND KEY

 [CREATEREF](createref-entity-sql.md) creates a reference passing a key. [KEY](key-entity-sql.md) extracts the key portion of an expression with type reference.

 Example:

```sql
SELECT VALUE Key(CreateRef(AdventureWorksEntities.Product, row(p.ProductID)))
    FROM AdventureWorksEntities.Product AS p
```

 Output:

|ProductID|
|---------------|
|980|
|365|
|771|
|...|

## Functions

### Canonical

 The namespace for [canonical functions](canonical-functions.md) is Edm, as in `Edm.Length("string")`. You do not have to specify the namespace unless another namespace is imported that contains a function with the same name as a canonical function. If two namespaces have the same function, the user should specify the full name.

 Example:

```sql
SELECT Length(c. FirstName) AS NameLen FROM
    AdventureWorksEntities.Contact AS c
    WHERE c.ContactID BETWEEN 10 AND 12
```

 Output:

|NameLen|
|-------------|
|6|
|6|
|5|

### Microsoft Provider-Specific

 [Microsoft provider-specific functions](../sqlclient-for-ef-functions.md) are in the `SqlServer` namespace.

 Example:

```sql
SELECT SqlServer.LEN(c.EmailAddress) AS EmailLen FROM
    AdventureWorksEntities.Contact AS c WHERE
    c.ContactID BETWEEN 10 AND 12
```

 Output:

|EmailLen|
|--------------|
|27|
|27|
|26|

## Namespaces

 [USING](using-entity-sql.md) specifies namespaces used in a query expression.

 Example:

```sql
using SqlServer; LOWER('AA');
```

 Output:

|Value|
|-----------|
|aa|

## Paging

 Paging can be expressed by declaring a [SKIP](skip-entity-sql.md) and [LIMIT](limit-entity-sql.md) sub-clauses to the [ORDER BY](order-by-entity-sql.md) clause.

 Example:

```sql
SELECT c.ContactID as ID, c.LastName AS Name FROM
    AdventureWorks.Contact AS c ORDER BY c.ContactID SKIP 9 LIMIT 3;
```

 Output:

|ID|Name|
|--------|----------|
|10|Adina|
|11|Agcaoili|
|12|Aguilar|

## Grouping

 [GROUPING BY](group-by-entity-sql.md) specifies groups into which objects returned by a query ([SELECT](select-entity-sql.md)) expression are to be placed.

 Example:

```sql
SELECT VALUE name FROM AdventureWorksEntities.Product AS P
    GROUP BY P.Name HAVING MAX(P.ListPrice) > 5
```

 Output:

|name|
|----------|
|LL Mountain Seat Assembly|
|ML Mountain Seat Assembly|
|HL Mountain Seat Assembly|
|...|

## Navigation

 The relationship navigation operator allows you to navigate over the relationship from one entity (from end) to another (to end). [NAVIGATE](navigate-entity-sql.md) takes the relationship type qualified as \<namespace>.\<relationship type name>. Navigate returns Ref\<T> if the cardinality of the to end is 1. If the cardinality of the to end is n, the Collection<Ref\<T>> will be returned.

 Example:

```sql
SELECT a.AddressID, (SELECT VALUE DEREF(v) FROM
    NAVIGATE(a, AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) AS v)
    FROM AdventureWorksEntities.Address AS a
```

 Output:

|AddressID|
|---------------|
|1|
|2|
|3|
|...|

## SELECT VALUE AND SELECT

### SELECT VALUE

 Entity SQL provides the SELECT VALUE clause to skip the implicit row construction. Only one item can be specified in a SELECT VALUE clause. When such a clause is used, no row wrapper is constructed around the items in the SELECT clause, and a collection of the desired shape can be produced, for example: `SELECT VALUE a`.

 Example:

```sql
SELECT VALUE p.Name FROM AdventureWorksEntities.Product AS p
```

 Output:

|Name|
|----------|
|Adjustable Race|
|All-Purpose Bike Stand|
|AWC Logo Cap|
|...|

### SELECT

 Entity SQL also provides the row constructor to construct arbitrary rows. SELECT takes one or more elements in the projection and results in a data record with fields, for example: `SELECT a, b, c`.

 Example:

 SELECT p.Name, p.ProductID FROM AdventureWorksEntities.Product as p Output:

|Name|ProductID|
|----------|---------------|
|Adjustable Race|1|
|All-Purpose Bike Stand|879|
|AWC Logo Cap|712|
|...|...|

## CASE EXPRESSION

 The [case expression](case-entity-sql.md) evaluates a set of Boolean expressions to determine the result.

 Example:

```sql
CASE WHEN AVG({25,12,11}) < 100 THEN TRUE ELSE FALSE END
```

 Output:

|Value|
|-----------|
|TRUE|

## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Entity SQL Overview](entity-sql-overview.md)
