  Function updateSales(ByVal thisSale As Decimal) As Decimal
      Static totalSales As Decimal = 0
      totalSales += thisSale
      Return totalSales
  End Function