using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Text;

namespace Microsoft.Samples.Entity
{
    class EntitySQL
    {
        public static void TestEntitySQL()
        {
            Dictionary<string, object> pc = new Dictionary<string, object>();
            /*
            //<snippetADD>
            SELECT VALUE product FROM AdventureWorksEntities.Products AS product
                where product.ListPrice =  @price1 + @price2
            //</snippetADD>
             */
            string queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product
                where product.ListPrice = @price1 + @price2";

            pc.Add("price1", 120);
            pc.Add("price2", 5);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetSelectProduct>
            SELECT VALUE Product FROM AdventureWorksEntities.Products AS Product
            //</snippetSelectProduct>
             */
            queryString = "SELECT VALUE Product FROM AdventureWorksEntities.Products AS Product";

            /*
            //<snippetCONCAT>
              SELECT VALUE 'Name=[' + e.Name + ']' FROM
                  AdventureWorksEntities.Products AS e
            //</snippetCONCAT>
             */
            queryString = @"SELECT VALUE 'Name=[' + e.Name + ']' FROM
                    AdventureWorksEntities.Products AS e";

            TestProduct(queryString, pc);

            /*
            //<snippetNEGATIVE>
              SELECT VALUE product FROM AdventureWorksEntities.Products
                  AS product where product.ListPrice = -(-@price)
            //</snippetNEGATIVE>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice = -(-@price)";

            pc.Add("price", 120);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetSUBTRACT>
              SELECT VALUE product FROM AdventureWorksEntities.Products
                  AS product where product.ListPrice = @price1 - @price2
            //</snippetSUBTRACT>
            */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice = @price1 - @price2";
            pc.Add("price1", 127);
            pc.Add("price2", 2);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetMULTIPLY>
              SELECT VALUE product FROM AdventureWorksEntities.Products
                  AS product where product.ListPrice = @price1 * @price2
            //</snippetMULTIPLY>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice = @price1 * @price2";
            pc.Add("price1", 25);
            pc.Add("price2", 5);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetDIVIDE>
              SELECT VALUE product FROM AdventureWorksEntities.Products
                  AS product where product.ListPrice =  @price1 / @price2
            //</snippetDIVIDE>
            */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                  AS product where product.ListPrice = @price1 / @price2";
            pc.Add("price1", 120);
            pc.Add("price2", 2);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetMODULO>
              SELECT VALUE product FROM AdventureWorksEntities.Products
                  AS product where product.ListPrice = @price1 % @price2
            //</snippetMODULO>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                  AS product where product.ListPrice = @price1 % @price2";
            pc.Add("price1", 125);
            pc.Add("price2", 1);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetAND>
            -- AND
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice >  @price1 AND product.ListPrice <  @price2
            -- &&
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice > @price1 && product.ListPrice < @price2
            //</snippetAND>
            */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice > @price1 AND product.ListPrice < @price2";

            pc.Add("price1", 10);
            pc.Add("price2", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetOR>
            -- OR
            SELECT VALUE product FROM AdventureWorksEntities.Products
                                                AS product where product.ListPrice = @price1 OR product.ListPrice = @price2
            -- ||
            SELECT VALUE product FROM AdventureWorksEntities.Products
                                                AS product where product.ListPrice = @price1 || product.ListPrice = @price2
            //</snippetOR>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                                                AS product where product.ListPrice = @price1 OR product.ListPrice = @price2";
            pc.Add("price1", 40);
            pc.Add("price2", 125);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetNOT>
            -- NOT
            SELECT VALUE product FROM AdventureWorksEntities.Products
                        AS product where product.ListPrice > @price1 AND NOT (product.ListPrice = @price2)
            -- !
            SELECT VALUE product FROM AdventureWorksEntities.Products
                        AS product where product.ListPrice > @price1 AND ! (product.ListPrice = @price2)
            //</snippetNOT>
            */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                        AS product where product.ListPrice > @price1 AND NOT (product.ListPrice = @price2)";
            pc.Add("price1", 50);
            pc.Add("price2", 90);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetEQUALS>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice = @price
            //</snippetEQUALS>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice = @price";

            pc.Add("price", 125);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetGREATER>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice > @price
            //</snippetGREATER>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice > @price";
            pc.Add("price", 125);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetGREATER_OR_EQUALS>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice >= @price
            //</snippetGREATER_OR_EQUALS>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice >= @price";
            pc.Add("price", 125);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetLESS>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice < @price
            //</snippetLESS>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice < @price";
            pc.Add("price", 125);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetLESS_OR_EQUALS>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice <= @price
            //</snippetLESS_OR_EQUALS>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice <= @price";
            pc.Add("price", 125);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetNOT_EQUALS>
            -- !=
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice != @price
            -- <>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice <> @price
            //</snippetNOT_EQUALS>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice != @price";

            pc.Add("price", 0);
            TestProduct(queryString, pc);
            pc.Clear();

            //    member access  add example
            /*
            //<snippetCOMMENT>
            SELECT VALUE product FROM AdventureWorksEntities.Products AS product -- add a comment here
            //</snippetCOMMENT>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product -- add a comment here";
            /*
            //<snippetANYELEMENT>
            ANYELEMENT((SELECT VALUE product from AdventureWorksEntities.Products as
                                    product where product.ListPrice = @price))
            //</snippetANYELEMENT>
             */
            queryString = @"ANYELEMENT((SELECT VALUE product from AdventureWorksEntities.Products as
                                    product where product.ListPrice = @price))";
            pc.Add("price", 125);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetBETWEEN>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice BETWEEN @price1 AND @price2
            //</snippetBETWEEN>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product where product.ListPrice BETWEEN @price1 AND @price2";
            pc.Add("price1", 50);
            pc.Add("price2", 90);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetCASE_WHEN_THEN_ELSE>
            CASE WHEN AVG({@score1,@score2,@score3}) < @total THEN TRUE ELSE FALSE END
            //</snippetCASE_WHEN_THEN_ELSE>
             */
            queryString = @"CASE WHEN AVG({@score1,@score2,@score3}) < @total THEN TRUE ELSE FALSE END";
            pc.Add("score1", 25);
            pc.Add("score2", 12);
            pc.Add("score3", 11);
            pc.Add("total", 100);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetCAST>
            SELECT VALUE cast(p.ListPrice as Edm.Int32)
                FROM AdventureWorksEntities.Products as p order by p.ListPrice
            //</snippetCAST>
             */
            queryString = @"SELECT VALUE cast(p.ListPrice as Edm.Int32)
                FROM AdventureWorksEntities.Products as p order by p.ListPrice";
            /*
            //<snippetCREATEREF>
            SELECT VALUE Key(CreateRef(AdventureWorksEntities.Products,
                row(p.ProductID))) FROM AdventureWorksEntities.Products as p
            //</snippetCREATEREF>
             */
            queryString = @"SELECT VALUE Key(CreateRef(AdventureWorksEntities.Products,
                row(p.ProductID))) FROM AdventureWorksEntities.Products as p";
            /*
            //<snippetDEREF>
            SELECT VALUE DEREF(REF(p)).Name FROM AdventureWorksEntities.Products
                as p
            //</snippetDEREF>
             */
            queryString = @"SELECT VALUE DEREF(REF(p)).Name FROM AdventureWorksEntities.Products as p";

            /*
            //<snippetEXCEPT>
            (SELECT product from AdventureWorksEntities.Products as product
                WHERE product.ListPrice  > @price1 ) except
                (select product from AdventureWorksEntities.Products as product
                WHERE product.ListPrice > @price2)
            //</snippetEXCEPT>
             */
            queryString = @"(SELECT product from AdventureWorksEntities.Products as product
                WHERE product.ListPrice  > @price1 ) except
                (select product from AdventureWorksEntities.Products as product
                WHERE product.ListPrice > @price2)";
            pc.Add("price1", 20);
            pc.Add("price2", 50);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetEXISTS>
            SELECT VALUE name from AdventureWorksEntities.Products
                AS name where exists(SELECT A from AdventureWorksEntities.Products
                as A WHERE A.ListPrice < @price1)
            //</snippetEXISTS>
             */
            queryString = @"SELECT VALUE name from AdventureWorksEntities.Products
                AS name where exists(SELECT A from AdventureWorksEntities.Products
                as A WHERE A.ListPrice < @price)";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetFLATTEN>
            FLATTEN(SELECT VALUE c.SalesOrderHeaders From
                AdventureWorksEntities.Contacts as c)
            //</snippetFLATTEN>
             */
            queryString = @"FLATTEN(SELECT VALUE c.SalesOrderHeaders From
                AdventureWorksEntities.Contacts as c)";

            /*
            //<snippetFUNCTION1>
            USING Microsoft.Samples.Entity;
            FUNCTION Products(listPrice Int32) AS
            (
            SELECT VALUE p FROM AdventureWorksEntities.Products AS p WHERE p.ListPrice >= listPrice
            )
            select p from Products(@price) as p
             //</snippetFUNCTION1>
             */
            queryString = @"USING Microsoft.Samples.Entity;
            FUNCTION Products(listPrice Int32) AS
            (
            SELECT VALUE p FROM AdventureWorksEntities.Products AS p WHERE p.ListPrice >= listPrice
            )
            select p from Products(@price) as p";
            pc.Add("price", 100);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetFUNCTION2>
            USING Microsoft.Samples.Entity;
            FUNCTION GetSpecificContacts(Ids Collection(Int32)) AS
            (
            SELECT VALUE id FROM Ids AS id WHERE id < @price
            )
            GetSpecificContacts(SELECT VALUE c.ContactID FROM AdventureWorksEntities.Contacts as c)
            //</snippetFUNCTION2>
             */
            queryString = @"
            USING Microsoft.Samples.Entity;
            FUNCTION GetSpecificContacts(Ids Collection(Int32)) AS
            (
            SELECT VALUE id FROM Ids AS id WHERE id < @price
            )
            GetSpecificContacts(SELECT VALUE c.ContactID FROM AdventureWorksEntities.Contacts as c)
            ";
            pc.Add("price", 10);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetGROUPBY>
            SELECT VALUE name FROM AdventureWorksEntities.Products
                as P GROUP BY P.Name HAVING MAX(P.ListPrice) > @price
            //</snippetGROUPBY>
             */
            queryString = @"SELECT VALUE name FROM AdventureWorksEntities.Products
                as P GROUP BY P.Name HAVING MAX(P.ListPrice) > @price";
            pc.Add("price", 10);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetHAVING>
            SELECT VALUE name FROM AdventureWorksEntities.Products
                as P GROUP BY P.Name HAVING MAX(P.ListPrice) > @price
            //</snippetHAVING>
             */
            queryString = @"SELECT VALUE name FROM AdventureWorksEntities.Products
                as P GROUP BY P.Name HAVING MAX(P.ListPrice) > @price";
            pc.Add("price", 10);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetKEY>
            SELECT VALUE Key(CreateRef(AdventureWorksEntities.Products,
                row(p.ProductID))) FROM AdventureWorksEntities.Products as p
            //</snippetKEY>
             */
            queryString = @"SELECT VALUE Key(CreateRef(AdventureWorksEntities.Products,
                row(p.ProductID))) FROM AdventureWorksEntities.Products as p";
            /*
            //<snippetIN>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product WHERE product.ListPrice IN {125, 300}
            //</snippetIN>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product WHERE product.ListPrice IN {@price1, @price2}";
            pc.Add("price1", 125);
            pc.Add("price2", 300);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetINTERSECT>
            (SELECT product from AdventureWorksEntities.Products as product where product.ListPrice > @price1 )
                intersect (select product from AdventureWorksEntities.Products as
                product where product.ListPrice > @price2)
            //</snippetINTERSECT>
             */
            queryString = @"(SELECT product from AdventureWorksEntities.Products as product where product.ListPrice > @price1 )
                intersect (select product from AdventureWorksEntities.Products as
                product where product.ListPrice > @price2)";
            pc.Add("price1", 10);
            pc.Add("price2", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetISNULL>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product WHERE product.Color IS NOT NULL
            //</snippetISNULL>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product WHERE product.Color IS NOT NULL";
            /*
            //<snippetLIKE>
            -- LIKE and ESCAPE
            -- If an AdventureWorksEntities.Products contained a Name
            -- with the value 'Down_Tube', the following query would find that
            -- value.
            Select value P.Name FROM AdventureWorksEntities.Products
                as P where P.Name LIKE 'DownA_%' ESCAPE 'A'

            -- LIKE
            Select value P.Name FROM AdventureWorksEntities.Products
                as P where P.Name like 'BB%'
             //</snippetLIKE>
             */
            queryString = @"Select value P.Name FROM AdventureWorksEntities.Products
                as P where P.Name like 'BB%'";
            /*
            //<snippetLIMIT>
            SELECT VALUE p FROM AdventureWorksEntities.Products
                                        AS p order by p.ListPrice LIMIT(@limit)
             //</snippetLIMIT>
             */
            queryString = @"SELECT VALUE p FROM AdventureWorksEntities.Products
                                        AS p order by p.ListPrice LIMIT(@limit)";
            pc.Add("limit", 5);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetMULTISET>
            SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product WHERE product.ListPrice IN MultiSet (@price1, @price2)
             //</snippetMULTISET>
             */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
                AS product WHERE product.ListPrice IN MultiSet (@price1, @price2)";
            pc.Add("price1", 125);
            pc.Add("price2", 300);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetNAMED_TYPE_CONSTRUCTOR>
            SELECT VALUE AdventureWorksModel.SalesOrderDetail
                (o.SalesOrderID, o.SalesOrderDetailID, o.CarrierTrackingNumber,
                o.OrderQty, o.ProductID, o.SpecialOfferID, o.UnitPrice,
                o.UnitPriceDiscount, o.LineTotal, o.rowguid, o.ModifiedDate)
                FROM AdventureWorksEntities.SalesOrderDetails AS o
             //</snippetNAMED_TYPE_CONSTRUCTOR>
             */

            queryString = @"SELECT VALUE AdventureWorksModel.SalesOrderDetail
                (o.SalesOrderID, o.SalesOrderDetailID, o.CarrierTrackingNumber,
                o.OrderQty, o.ProductID, o.SpecialOfferID, o.UnitPrice,
                o.UnitPriceDiscount, o.LineTotal, o.rowguid, o.ModifiedDate)
                FROM AdventureWorksEntities.SalesOrderDetails AS o";
            /*
            //<snippetNAVIGATE>
            SELECT address.AddressID, (SELECT VALUE DEREF(soh)
            FROM NAVIGATE(address,     AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) AS soh)
                FROM AdventureWorksEntities.Addresses AS address
            //</snippetNAVIGATE>
             */
            queryString = @"SELECT address.AddressID, (SELECT VALUE DEREF(soh)
            FROM NAVIGATE(address,     AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) AS soh)
                FROM AdventureWorksEntities.Addresses AS address";
            /*
            //<snippetOFTYPE>
            SELECT onsiteCourse.Location FROM
                OFTYPE(SchoolEntities.Courses, SchoolModel.OnsiteCourse)
                AS onsiteCourse
            //</snippetOFTYPE>
             */
            queryString = @"SELECT onsiteCourse.Location FROM
                OFTYPE(SchoolEntities.Courses, SchoolModel.OnsiteCourse)
                AS onsiteCourse";
            /*
            //<snippetORDERBY>
            SELECT VALUE p FROM AdventureWorksEntities.Products
                AS p order by p.ListPrice
            //</snippetORDERBY>
            */
            queryString = @"SELECT VALUE p FROM AdventureWorksEntities.Products
                AS p order by p.ListPrice";
            /*
            //<snippetOVERLAPS>
            SELECT value P from AdventureWorksEntities.Products
                as P WHERE ((select P from AdventureWorksEntities.Products
                as P WHERE P.ListPrice > @price1) overlaps (select P from
                AdventureWorksEntities.Products as P WHERE P.ListPrice < @price2))
            //</snippetOVERLAPS>
            */
            queryString = @"SELECT value P from AdventureWorksEntities.Products
                as P WHERE ((select P from AdventureWorksEntities.Products
                as P WHERE P.ListPrice > @price1) overlaps (select P from
                AdventureWorksEntities.Products as P WHERE P.ListPrice < @price2))";
            pc.Add("price1", 10);
            pc.Add("price2", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetREF>
            SELECT VALUE REF(p).Name FROM AdventureWorksEntities.Products as p
            //</snippetREF>
            */
            queryString = @"SELECT VALUE REF(p).Name FROM AdventureWorksEntities.Products as p";

            /*
            //<snippetREF2>
            SELECT REF(p) FROM AdventureWorksEntities.Products as p
            //</snippetREF2>
            */
            queryString = @"SELECT REF(p) FROM AdventureWorksEntities.Products as p";

            /*
            //<snippetREF3>
            SELECT REF(p) FROM AdventureWorksEntities.Products as p WHERE p.ProductID == @productID
            //</snippetREF3>
            */
            queryString = @"SELECT REF(p) FROM AdventureWorksEntities.Products as p WHERE p.ProductID == @productID";
            pc.Add("productID", 10);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetROW>
            SELECT VALUE ROW (product.ProductID as ProductID,
                product.Name as ProductName) FROM AdventureWorksEntities.Products
                AS product
            //</snippetROW>
            */
            queryString = @"SELECT VALUE ROW (product.ProductID as ProductID,
                product.Name as ProductName) FROM AdventureWorksEntities.Products
                AS product";
            /*
            //<snippetSET>
            SET(SELECT VALUE P.Name FROM AdventureWorksEntities.Products AS P)
            //</snippetSET>
            */
            queryString = @"SET(SELECT VALUE P.Name FROM AdventureWorksEntities.Products AS P)";
            /*
            //<snippetSKIP>
            SELECT VALUE p FROM AdventureWorksEntities.Products
                AS p order by p.ListPrice SKIP(@price)
            //</snippetSKIP>
            */
            queryString = @"SELECT VALUE p FROM AdventureWorksEntities.Products
                AS p order by p.ListPrice SKIP(@price)";
            pc.Add("price", 10);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetTOP>
            SELECT VALUE TOP(1) contact FROM AdventureWorksEntities.Contacts AS contact
            //</snippetTOP>
            */
            queryString = @"SELECT VALUE TOP(1) contact FROM AdventureWorksEntities.Contacts AS contact";
            /*
            //<snippetTREAT_ISOF>
             SELECT VALUE TREAT (course as SchoolModel.OnsiteCourse)
                FROM SchoolEntities.Courses as course
                WHERE course IS OF( SchoolModel.OnsiteCourse)
            //</snippetTREAT_ISOF>
            */
            queryString = @"SELECT VALUE TREAT (course as SchoolModel.OnsiteCourse)
                FROM SchoolEntities.Courses as course
                WHERE course IS OF( SchoolModel.OnsiteCourse)";
            /*
            //<snippetUNION>
            (SELECT VALUE P from AdventureWorksEntities.Products
                as P WHERE P.Name LIKE 'C%') Union All
                ( SELECT VALUE A from AdventureWorksEntities.Products
                as A WHERE A.ListPrice > @price)
            //</snippetUNION>
            */
            queryString = @"(SELECT VALUE P from AdventureWorksEntities.Products
                as P WHERE P.Name LIKE 'C%') Union All
                ( SELECT VALUE A from AdventureWorksEntities.Products
                as A WHERE A.ListPrice > @price)";
            pc.Add("price", 10);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetEDM_AVG>
            SELECT VALUE AVG(p.ListPrice) FROM AdventureWorksEntities.Products as p
            //</snippetEDM_AVG>
            */
            queryString = @"SELECT VALUE AVG(p.ListPrice) FROM AdventureWorksEntities.Products as p ";
            /*
            //<snippetEDM_BIGCOUNT>
            SELECT VALUE BigCount(p.ProductID) FROM AdventureWorksEntities.Products as p
            //</snippetEDM_BIGCOUNT>
            */
            queryString = @"SELECT VALUE BigCount(p.ProductID) FROM AdventureWorksEntities.Products as p ";
            /*
            //<snippetEDM_COUNT>
            SELECT VALUE Count(p.ProductID) FROM AdventureWorksEntities.Products as p
            //</snippetEDM_COUNT>
            */
            queryString = @"SELECT VALUE Count(p.ProductID) FROM AdventureWorksEntities.Products as p ";
            /*
            //<snippetEDM_MAX>
            SELECT VALUE MAX(p.ListPrice) FROM AdventureWorksEntities.Products as p
            //</snippetEDM_MAX>
            */
            queryString = @"SELECT VALUE MAX(p.ListPrice) FROM AdventureWorksEntities.Products as p ";
            /*
            //<snippetEDM_MIN>
            SELECT VALUE MIN(p.ListPrice) FROM AdventureWorksEntities.Products as p
            //</snippetEDM_MIN>
            */
            queryString = @"SELECT VALUE MIN(p.ListPrice) FROM AdventureWorksEntities.Products as p ";
            /*
            //<snippetEDM_STDEV>
            SELECT VALUE StDev(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            where product.ListPrice > @price
            //</snippetEDM_STDEV>
            */
            queryString = @"SELECT VALUE StDev(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            where product.ListPrice > @price";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetEDM_STDEVP>
            SELECT VALUE StDevP(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            where product.ListPrice > @price
            //</snippetEDM_STDEVP>
            */
            queryString = @"SELECT VALUE StDevP(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            where product.ListPrice > @price";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetEDM_SUM>
            SELECT VALUE Sum(p.ListPrice) FROM AdventureWorksEntities.Products as p
            //</snippetEDM_SUM>
            */
            queryString = @"SELECT VALUE Sum(p.ListPrice) FROM AdventureWorksEntities.Products as p ";
            /*
            //<snippetEDM_VAR>
            SELECT VALUE Var(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > @price
            //</snippetEDM_VAR>
            */
            queryString = @"SELECT VALUE Var(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > @price";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetEDM_VARP>
            SELECT VALUE VarP(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > @price
            //</snippetEDM_VARP>
            */
            queryString = @"SELECT VALUE VarP(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > @price";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetEDM_CEILING>
            SELECT VALUE product FROM AdventureWorksEntities.Products AS product
            WHERE CEILING(product.ListPrice) == FLOOR(product.ListPrice)
            //</snippetEDM_CEILING>
            */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product
            WHERE CEILING(product.ListPrice) == FLOOR(product.ListPrice)";
            /*
            //<snippetEDM_FLOOR>
            SELECT VALUE product FROM AdventureWorksEntities.Products AS product
            WHERE FLOOR(product.ListPrice) == CEILING(product.ListPrice)
            //</snippetEDM_FLOOR>
            */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products AS product
            WHERE FLOOR(product.ListPrice) == CEILING(product.ListPrice)";

            /*
            //<snippetSQLSERVER_AVG>
            SELECT VALUE SqlServer.AVG(p.ListPrice) FROM
            AdventureWorksEntities.Products as p
            //</snippetSQLSERVER_AVG>
            */
            queryString = @"SELECT VALUE SqlServer.AVG(p.ListPrice) FROM
            AdventureWorksEntities.Products as p ";
            /*
            //<snippetSQLSERVER_CHECKSUM>
            SELECT VALUE SqlServer.Checksum_Agg(cast(product.ListPrice as Int32))
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal)
            //</snippetSQLSERVER_CHECKSUM>
            */
            queryString = @"SELECT VALUE SqlServer.Checksum_Agg(cast(product.ListPrice as Int32))
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal) ";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetSQLSERVER_COUNT>
            ANYELEMENT(SELECT VALUE SqlServer.COUNT(product.ProductID)
            FROM AdventureWorksEntities.Products AS product
            WHERE SqlServer.CEILING(product.ListPrice) ==
            SqlServer.FLOOR(product.ListPrice))
            //</snippetSQLSERVER_COUNT>
            */
            queryString = @"ANYELEMENT(SELECT VALUE SqlServer.COUNT(product.ProductID)
            FROM AdventureWorksEntities.Products AS product
            WHERE SqlServer.CEILING(product.ListPrice) ==
            SqlServer.FLOOR(product.ListPrice)) ";
            /*
            //<snippetSQLSERVER_COUNTBIG>
            ANYELEMENT(SELECT VALUE SqlServer.COUNT_BIG(product.ProductID)
            FROM AdventureWorksEntities.Products AS product
            WHERE SqlServer.CEILING(product.ListPrice) ==
            SqlServer.FLOOR(product.ListPrice))
            //</snippetSQLSERVER_COUNTBIG>
            */
            queryString = @"ANYELEMENT(SELECT VALUE SqlServer.COUNT_BIG(product.ProductID)
            FROM AdventureWorksEntities.Products AS product
            WHERE SqlServer.CEILING(product.ListPrice) ==
            SqlServer.FLOOR(product.ListPrice)) ";
            /*
            //<snippetSQLSERVER_MAX>
            SELECT VALUE SqlServer.MAX(p.ListPrice)
            FROM AdventureWorksEntities.Products as p
            //</snippetSQLSERVER_MAX>
            */
            queryString = @"SELECT VALUE SqlServer.MAX(p.ListPrice)
            FROM AdventureWorksEntities.Products as p";
            /*
            //<snippetSQLSERVER_MIN>
            SELECT VALUE SqlServer.MIN(p.ListPrice)
            FROM AdventureWorksEntities.Products as p
            //</snippetSQLSERVER_MIN>
            */
            queryString = @"SELECT VALUE SqlServer.MIN(p.ListPrice)
            FROM AdventureWorksEntities.Products as p";
            /*
            //<snippetSQLSERVER_STDEV>
            SELECT VALUE SqlServer.STDEV(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal)
            //</snippetSQLSERVER_STDEV>
            */
            queryString = @"SELECT VALUE SqlServer.STDEV(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal) ";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetSQLSERVER_STDEVP>
            SELECT VALUE SqlServer.STDEVP(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal)
            //</snippetSQLSERVER_STDEVP>
            */
            queryString = @"SELECT VALUE SqlServer.STDEVP(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal) ";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetSQLSERVER_SUM>
            SELECT VALUE SqlServer.SUM(p.ListPrice)
            FROM AdventureWorksEntities.Products as p
            //</snippetSQLSERVER_SUM>
            */
            queryString = @"SELECT VALUE SqlServer.SUM(p.ListPrice)
            FROM AdventureWorksEntities.Products as p";
            /*
            //<snippetSQLSERVER_VAR>
            SELECT VALUE SqlServer.VAR(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal)
            //</snippetSQLSERVER_VAR>
            */
            queryString = @"SELECT VALUE SqlServer.VAR(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal)";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();

            /*
            //<snippetSQLSERVER_VARP>
            SELECT VALUE SqlServer.VARP(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal)
            //</snippetSQLSERVER_VARP>
            */
            queryString = @"SELECT VALUE SqlServer.VARP(product.ListPrice)
            FROM AdventureWorksEntities.Products AS product
            WHERE product.ListPrice > cast(@price as Decimal) ";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();
            /*
            //<snippetSQLSERVER_CEILING>
            SELECT VALUE product FROM AdventureWorksEntities.Products
            AS product WHERE product.ListPrice ==
            SqlServer.CEILING(product.ListPrice)
            //</snippetSQLSERVER_CEILING>
            */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
            AS product WHERE product.ListPrice ==
            SqlServer.CEILING(product.ListPrice) ";
            /*
            //<snippetSQLSERVER_FLOOR>
            SELECT VALUE product FROM AdventureWorksEntities.Products
            AS product WHERE product.ListPrice ==
            SqlServer.FLOOR(product.ListPrice)
            //</snippetSQLSERVER_FLOOR>
            */
            queryString = @"SELECT VALUE product FROM AdventureWorksEntities.Products
            AS product WHERE product.ListPrice ==
            SqlServer.FLOOR(product.ListPrice) ";
            /*
            //<snippetCollection_GroupPartition>
            USING Microsoft.Samples.Entity
            Function MyAvg(dues Collection(Decimal)) AS
            (
                    Avg(select value due from dues as due where due > @price)
            )
            SELECT TOP(10) contactID, MyAvg(GroupPartition(order.TotalDue))
            FROM AdventureWorksEntities.SalesOrderHeaders  AS order
            GROUP BY order.Contact.ContactID as contactID;
            //</snippetCollection_GroupPartition>
            */
            queryString = @"USING Microsoft.Samples.Entity;
            Function MyAvg(dues Collection(Decimal)) AS
            (
                    Avg(SELECT VALUE due FROM dues as due WHERE due > @price)
            )
            SELECT TOP(10) contactID, MyAvg(GroupPartition(order.TotalDue))
                            FROM AdventureWorksEntities.SalesOrderHeaders
                            AS order GROUP BY order.Contact.ContactID as contactID;
            ";
            pc.Add("price", 20);
            TestProduct(queryString, pc);
            pc.Clear();
        }

        static void TestProduct(string esqlQuery, Dictionary<string, object> parameters)
        {
            using (EntityConnection conn =
                new EntityConnection("name=AdventureWorksEntities"))
            {
                conn.Open();

                try
                {
                    // Create an EntityCommand.
                    using (EntityCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = esqlQuery;
                        foreach (KeyValuePair<string, object> kvp in parameters)
                        {
                            cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                        }

                        // Execute the command.
                        using (EntityDataReader rdr =
                            cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                        {
                            // The result returned by this query contains
                            // Address complex Types.
                            while (rdr.Read())
                            {
                                int col = rdr.FieldCount;
                                if (rdr.FieldCount > 3)
                                    col = 3;
                                for (int i = 0; i < col; i++)
                                    Console.Write("{0}   ", rdr[i]);
                                Console.WriteLine();
                                if (rdr.Depth > 0)
                                {
                                    // Display Address information.
                                    DbDataRecord nestedRecord =
                                        rdr[0] as DbDataRecord;
                                    for (int i = 0; i < nestedRecord.FieldCount; i++)
                                    {
                                        Console.WriteLine("  " + nestedRecord.GetName(i) +
                                            ": " + nestedRecord.GetValue(i));
                                    }
                                }
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
        }
    }
}
