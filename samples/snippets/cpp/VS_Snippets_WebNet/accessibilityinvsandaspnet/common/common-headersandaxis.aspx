<%--<Snippet4>--%>
<%@ Page %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>

<head id="Head1" runat="server">
  <title>Red Line Subway Schedule</title>
  <style type="text/css">
    caption {color:white;background-color:red;font-size:xx-large}
    table {width:500px;border-collapse:collapse}
    td,th {padding:5px}
    td {border:1px solid black}
    tbody th {text-align:right}
    .headerRow th {font-size:x-large;text-align:left}    
  </style>
</head>

<body>
  <form id="form1" runat="server">
  <div>

  <table summary="This table contains the schedule of train 
                  departures for the Red Line">
    <caption>Red Line Schedule</caption>
    <thead>
      <tr>
        <th></th>
        <th id="hdrFirstTrain" axis="train">First Train</th>
        <th id="hdrLastTrain" axis="train">Last Train</th>
      </tr>
    </thead>
    <tbody>
      <tr class="headerRow">
          <th id="hdrWeekday" axis="day" colspan="3">Weekday</th>
      </tr>
      <tr>
        <th id="hdrAlewife1" axis="location">Alewife</th>
        <td headers="hdrAlwife1 hdrWeekday hdrFirstTrain">5:24am</td>
        <td headers="hdrAlwife1 hdrWeekday hdrLastTrain">12:15am</td>
      </tr>
      <tr>
        <th id="hdrBraintree1" axis="location">Braintree</th>
        <td headers="hdrBraintree1 hdrWeekday hdrFirstTrain">
          5:15am
        </td>
        <td headers="hdrBraintree1 hdrWeekday hdrLastTrain">
          12:18am
        </td>
      </tr>  
      <tr class="headerRow">
        <th id="hdrSaturday" axis="day" colspan="3">Saturday</th>
      </tr>
      <tr>
        <th id="hdrAlewife2" axis="location">Alewife</th>
        <td headers="hdrAlewife2 hdrSaturday hdrFirstTrain">8:24am</td>
        <td headers="hdrAlewife2 hdrSaturday hdrLastTrain">11:15pm</td>
      </tr>
      <tr>
        <th id="hdrBraintree2" axis="location">Braintree</th>
        <td headers="hdrBraintree2 hdrSaturday hdrFirstTrain">
          7:16am
        </td>
        <td headers="hdrBraintree2 hdrSaturday hdrLastTrain">
          10:18pm
        </td>
      </tr>  
    </tbody>      
  </table>

  </div>
  </form>
</body>
</html>
<%--</Snippet4>--%>
