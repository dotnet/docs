--<snippetADD>
SELECT VALUE product FROM AdventureWorksEntities.Products AS product 
    WHERE product.ListPrice =  @price1 + @price2
--</snippetADD>

--<snippetSelectProduct>
SELECT VALUE Product FROM AdventureWorksEntities.Products AS Product
--</snippetSelectProduct>

--<snippetCONCAT>
  SELECT VALUE 'Name=[' + e.Name + ']' FROM 
      AdventureWorksEntities.Products AS e
--</snippetCONCAT>

--<snippetNEGATIVE>
  SELECT VALUE product FROM AdventureWorksEntities.Products 
      AS product WHERE product.ListPrice = -(-@price)
--</snippetNEGATIVE>

--<snippetSUBTRACT>
  SELECT VALUE product FROM AdventureWorksEntities.Products 
      AS product WHERE product.ListPrice = @price1 - @price2
--</snippetSUBTRACT>

--<snippetMULTIPLY>
  SELECT VALUE product FROM AdventureWorksEntities.Products 
      AS product WHERE product.ListPrice = @price1 * @price2
--</snippetMULTIPLY>

--<snippetDIVIDE>
  SELECT VALUE product FROM AdventureWorksEntities.Products 
      AS product WHERE product.ListPrice =  @price1 / @price2
--</snippetDIVIDE>

--<snippetMODULO>
  SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice = @price1 % @price2
--</snippetMODULO>

--<snippetAND>
-- AND
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product 
WHERE product.ListPrice >  @price1 AND product.ListPrice <  @price2
-- && 
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product 
WHERE product.ListPrice > @price1 && product.ListPrice < @price2
--</snippetAND>

--<snippetOR>
-- OR
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product 
WHERE product.ListPrice = @price1 OR product.ListPrice = @price2
-- || 
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product 
WHERE product.ListPrice = @price1 || product.ListPrice = @price2
--</snippetOR>

--<snippetNOT>
-- NOT
SELECT VALUE product FROM AdventureWorksEntities.Products 
AS product WHERE product.ListPrice > @price1 AND NOT (product.ListPrice = @price2)
-- !
SELECT VALUE product FROM AdventureWorksEntities.Products 
AS product WHERE product.ListPrice > @price1 AND ! (product.ListPrice = @price2)
--</snippetNOT>

--<snippetEQUALS>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice = @price
--</snippetEQUALS>

--<snippetGREATER>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice > @price
--</snippetGREATER>

--<snippetGREATER_OR_EQUALS>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice >= @price
--</snippetGREATER_OR_EQUALS>

--<snippetLESS>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice < @price
--</snippetLESS>

--<snippetLESS_OR_EQUALS>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice <= @price
--</snippetLESS_OR_EQUALS>

--<snippetNOT_EQUALS>
-- !=
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice != @price
-- <>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice <> @price
--</snippetNOT_EQUALS>

--<snippetCOMMENT>
SELECT VALUE product 
FROM AdventureWorksEntities.Products 
    AS product -- add a comment here
--</snippetCOMMENT>

--<snippetANYELEMENT>
ANYELEMENT((SELECT VALUE product 
    FROM AdventureWorksEntities.Products AS product 
    WHERE product.ListPrice = @price))
--</snippetANYELEMENT>

--<snippetBETWEEN>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice BETWEEN @price1 AND @price2
--</snippetBETWEEN>

--<snippetCASE_WHEN_THEN_ELSE>
CASE WHEN AVG({@score1,@score2,@score3}) < @total THEN TRUE ELSE FALSE END
--</snippetCASE_WHEN_THEN_ELSE>

--<snippetCAST>
SELECT VALUE cASt(p.ListPrice AS Edm.Int32) 
FROM AdventureWorksEntities.Products AS p 
ORDER BY p.ListPrice
--</snippetCAST>

--<snippetCREATEREF>
SELECT VALUE Key(CreateRef(AdventureWorksEntities.Products, 
    row(p.ProductID))) 
FROM AdventureWorksEntities.Products AS p
--</snippetCREATEREF>

--<snippetDEREF>
SELECT VALUE DEREF(REF(p)).Name 
FROM AdventureWorksEntities.Products AS p
--</snippetDEREF>

--<snippetEXCEPT>
(SELECT product FROM AdventureWorksEntities.Products AS product 
    WHERE product.ListPrice  > @price1 ) except 
    (select product FROM AdventureWorksEntities.Products AS product 
    WHERE product.ListPrice > @price2)
--</snippetEXCEPT>

--<snippetEXISTS>
SELECT VALUE name FROM AdventureWorksEntities.Products 
    AS name WHERE exists(SELECT A FROM AdventureWorksEntities.Products 
    AS A WHERE A.ListPrice < @price1)
--</snippetEXISTS>

--<snippetFLATTEN>
FLATTEN(SELECT VALUE c.SalesOrderHeaders From 
    AdventureWorksEntities.Contacts AS c)
--</snippetFLATTEN>

--<snippetFUNCTION1>
USING Microsoft.Samples.Entity;
FUNCTION Products(listPrice Int32) AS 
(
SELECT VALUE p FROM AdventureWorksEntities.Products AS p 
    WHERE p.ListPrice >= listPrice
)
select p FROM Products(@price) AS p
 --</snippetFUNCTION1>

--<snippetFUNCTION2>
USING Microsoft.Samples.Entity;
FUNCTION GetSpecificContacts(Ids Collection(Int32)) AS 
(
SELECT VALUE id FROM Ids AS id WHERE id < @price
)
GetSpecificContacts(SELECT VALUE c.ContactID 
    FROM AdventureWorksEntities.Contacts AS c)
--</snippetFUNCTION2>

--<snippetGROUPBY>
SELECT VALUE name FROM AdventureWorksEntities.Products 
    AS P GROUP BY P.Name HAVING MAX(P.ListPrice) > @price
--</snippetGROUPBY>

--<snippetHAVING>
SELECT VALUE name FROM AdventureWorksEntities.Products 
    AS P GROUP BY P.Name HAVING MAX(P.ListPrice) > @price
--</snippetHAVING>

--<snippetKEY>
SELECT VALUE Key(CreateRef(AdventureWorksEntities.Products, 
    row(p.ProductID))) FROM AdventureWorksEntities.Products AS p
--</snippetKEY>

--<snippetIN>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.ListPrice IN {125, 300}
--</snippetIN>

--<snippetINTERSECT>
(SELECT product 
    FROM AdventureWorksEntities.Products AS product 
    WHERE product.ListPrice > @price1 ) 
    intersect (SELECT product FROM AdventureWorksEntities.Products AS 
    product WHERE product.ListPrice > @price2)
--</snippetINTERSECT>

--<snippetISNULL>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product WHERE product.Color IS NOT NULL
--</snippetISNULL>

--<snippetLIKE>
-- LIKE and ESCAPE
-- If an AdventureWorksEntities.Products contained a Name 
-- with the value 'Down_Tube', the following query would find that 
-- value.
Select value P.Name FROM AdventureWorksEntities.Products AS P 
WHERE P.Name LIKE 'DownA_%' ESCAPE 'A'

-- LIKE
Select value P.Name FROM AdventureWorksEntities.Products AS P 
WHERE P.Name LIKE 'BB%'
 --</snippetLIKE>

--<snippetLIMIT>
SELECT VALUE p FROM AdventureWorksEntities.Products AS p 
ORDER BY p.ListPrice LIMIT(@limit)
 --</snippetLIMIT>

--<snippetMULTISET>
SELECT VALUE product FROM AdventureWorksEntities.Products 
    AS product 
WHERE product.ListPrice IN MultiSet (@price1, @price2)
 --</snippetMULTISET>

--<snippetNAMED_TYPE_CONSTRUCTOR>
SELECT VALUE AdventureWorksModel.SalesOrderDetail
    (o.SalesOrderID, o.SalesOrderDetailID, o.CarrierTrackingNumber,
    o.OrderQty, o.ProductID, o.SpecialOfferID, o.UnitPrice,
    o.UnitPriceDiscount, o.LineTotal, o.rowguid, o.ModifiedDate)
FROM AdventureWorksEntities.SalesOrderDetails AS o
 --</snippetNAMED_TYPE_CONSTRUCTOR>

--<snippetNAVIGATE>
SELECT address.AddressID, (SELECT VALUE DEREF(soh) 
FROM NAVIGATE(address, 
    AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) 
    AS soh)
FROM AdventureWorksEntities.Addresses AS address
--</snippetNAVIGATE>

--<snippetOFTYPE>
SELECT onsiteCourse.Location FROM 
    OFTYPE(SchoolEntities.Courses, SchoolModel.OnsiteCourse) 
    AS onsiteCourse
--</snippetOFTYPE>

--<snippetORDERBY>
SELECT VALUE p FROM AdventureWorksEntities.Products 
    AS p ORDER BY p.ListPrice
--</snippetORDERBY>

--<snippetOVERLAPS>
SELECT value P FROM AdventureWorksEntities.Products 
    AS P WHERE ((SELECT P FROM AdventureWorksEntities.Products 
    AS P WHERE P.ListPrice > @price1) overlaps (SELECT P FROM
    AdventureWorksEntities.Products AS P WHERE P.ListPrice < @price2))
--</snippetOVERLAPS>

--<snippetREF>
SELECT VALUE REF(p).Name FROM AdventureWorksEntities.Products AS p
--</snippetREF>

--<snippetREF2>
SELECT REF(p) FROM AdventureWorksEntities.Products AS p
--</snippetREF2>

--<snippetREF3>
SELECT REF(p) FROM AdventureWorksEntities.Products AS p 
WHERE p.ProductID == @productID
--</snippetREF3>

--<snippetROW>
SELECT VALUE ROW (product.ProductID AS ProductID,
    product.Name AS ProductName) FROM AdventureWorksEntities.Products
    AS product
--</snippetROW>

--<snippetSET>
SET(SELECT VALUE P.Name FROM AdventureWorksEntities.Products AS P)
--</snippetSET>

--<snippetSKIP>
SELECT VALUE p FROM AdventureWorksEntities.Products AS p 
ORDER BY p.ListPrice SKIP(@price)
--</snippetSKIP>

--<snippetTOP>
SELECT VALUE TOP(1) contact FROM AdventureWorksEntities.Contacts AS contact
--</snippetTOP>

--<snippetTREAT_ISOF>
 SELECT VALUE TREAT (course AS SchoolModel.OnsiteCourse) 
    FROM SchoolEntities.Courses AS course
    WHERE course IS OF( SchoolModel.OnsiteCourse)
--</snippetTREAT_ISOF>

--<snippetUNION>
(SELECT VALUE P FROM AdventureWorksEntities.Products 
    AS P WHERE P.Name LIKE 'C%') UNION ALL 
    (SELECT VALUE A FROM AdventureWorksEntities.Products 
    AS A WHERE A.ListPrice > @price)
--</snippetUNION>

--<snippetEDM_AVG>
SELECT VALUE AVG(p.ListPrice) 
FROM AdventureWorksEntities.Products AS p 
--</snippetEDM_AVG>

--<snippetEDM_BIGCOUNT>
SELECT VALUE BigCount(p.ProductID) 
FROM AdventureWorksEntities.Products AS p 
--</snippetEDM_BIGCOUNT>

--<snippetEDM_COUNT>
SELECT VALUE Count(p.ProductID) 
FROM AdventureWorksEntities.Products AS p 
--</snippetEDM_COUNT>

--<snippetEDM_MAX>
SELECT VALUE MAX(p.ListPrice) 
FROM AdventureWorksEntities.Products AS p 
--</snippetEDM_MAX>

--<snippetEDM_MIN>
SELECT VALUE MIN(p.ListPrice) 
FROM AdventureWorksEntities.Products AS p 
--</snippetEDM_MIN>

--<snippetEDM_STDEV>
SELECT VALUE StDev(product.ListPrice) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > @price
--</snippetEDM_STDEV>

--<snippetEDM_STDEVP>
SELECT VALUE StDevP(product.ListPrice) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > @price
--</snippetEDM_STDEVP>

--<snippetEDM_SUM>
SELECT VALUE Sum(p.ListPrice) 
FROM AdventureWorksEntities.Products AS p 
--</snippetEDM_SUM>

--<snippetEDM_VAR>
SELECT VALUE Var(product.ListPrice) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > @price
--</snippetEDM_VAR>

--<snippetEDM_VARP>
SELECT VALUE VarP(product.ListPrice) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > @price
--</snippetEDM_VARP>

--<snippetEDM_CEILING>
SELECT VALUE product FROM AdventureWorksEntities.Products AS product 
WHERE CEILING(product.ListPrice) == FLOOR(product.ListPrice)
--</snippetEDM_CEILING>

--<snippetEDM_FLOOR>
SELECT VALUE product FROM AdventureWorksEntities.Products AS product 
WHERE FLOOR(product.ListPrice) == CEILING(product.ListPrice)
--</snippetEDM_FLOOR>

--<snippetSQLSERVER_AVG>
SELECT VALUE SqlServer.AVG(p.ListPrice) 
FROM AdventureWorksEntities.Products AS p 
--</snippetSQLSERVER_AVG>

--<snippetSQLSERVER_CHECKSUM>
SELECT VALUE SqlServer.Checksum_Agg(cast(product.ListPrice AS Int32)) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > cast(@price AS Decimal) 
--</snippetSQLSERVER_CHECKSUM>

--<snippetSQLSERVER_COUNT>
ANYELEMENT(SELECT VALUE SqlServer.COUNT(product.ProductID) 
FROM AdventureWorksEntities.Products AS product 
WHERE SqlServer.CEILING(product.ListPrice) == 
SqlServer.FLOOR(product.ListPrice)) 
--</snippetSQLSERVER_COUNT>

--<snippetSQLSERVER_COUNTBIG>
ANYELEMENT(SELECT VALUE SqlServer.COUNT_BIG(product.ProductID) 
FROM AdventureWorksEntities.Products AS product 
WHERE SqlServer.CEILING(product.ListPrice) == 
SqlServer.FLOOR(product.ListPrice)) 
--</snippetSQLSERVER_COUNTBIG>

--<snippetSQLSERVER_MAX>
SELECT VALUE SqlServer.MAX(p.ListPrice) 
FROM AdventureWorksEntities.Products AS p
--</snippetSQLSERVER_MAX>

--<snippetSQLSERVER_MIN>
SELECT VALUE SqlServer.MIN(p.ListPrice) 
FROM AdventureWorksEntities.Products AS p
--</snippetSQLSERVER_MIN>

--<snippetSQLSERVER_STDEV>
SELECT VALUE SqlServer.STDEV(product.ListPrice) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > cast(@price AS Decimal) 
--</snippetSQLSERVER_STDEV>

--<snippetSQLSERVER_STDEVP>
SELECT VALUE SqlServer.STDEVP(product.ListPrice) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > cast(@price AS Decimal) 
--</snippetSQLSERVER_STDEVP>

--<snippetSQLSERVER_SUM>
SELECT VALUE SqlServer.SUM(p.ListPrice) 
FROM AdventureWorksEntities.Products AS p
--</snippetSQLSERVER_SUM>

--<snippetSQLSERVER_VAR>
SELECT VALUE SqlServer.VAR(product.ListPrice) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > cast(@price AS Decimal) 
--</snippetSQLSERVER_VAR>

--<snippetSQLSERVER_VARP>
SELECT VALUE SqlServer.VARP(product.ListPrice) 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice > cast(@price AS Decimal) 
--</snippetSQLSERVER_VARP>

--<snippetSQLSERVER_CEILING>
SELECT VALUE product 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice == 
SqlServer.CEILING(product.ListPrice) 
--</snippetSQLSERVER_CEILING>

--<snippetSQLSERVER_FLOOR>
SELECT VALUE product 
FROM AdventureWorksEntities.Products AS product 
WHERE product.ListPrice == 
SqlServer.FLOOR(product.ListPrice) 
--</snippetSQLSERVER_FLOOR>

--<snippetCollection_GroupPartition>
USING Microsoft.Samples.Entity
Function MyAvg(dues Collection(Decimal)) AS
(
    Avg(SELECT value due FROM dues AS due WHERE due > @price)
)
SELECT TOP(10) contactID, MyAvg(GroupPartition(order.TotalDue)) 
FROM AdventureWorksEntities.SalesOrderHeaders AS order 
GROUP BY order.Contact.ContactID AS contactID;
--</snippetCollection_GroupPartition>