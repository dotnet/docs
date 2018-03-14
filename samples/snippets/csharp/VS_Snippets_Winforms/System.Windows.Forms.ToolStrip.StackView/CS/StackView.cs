// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace StackViewCS
{
    public class StackView : UserControl
    {
        private ToolStrip stackStrip;
        private ToolStripButton mailStackButton;
        private ToolStripButton calendarStackButton;
        private ToolStripButton contactsStackButton;
        private ToolStripButton tasksStackButton;

        private System.ComponentModel.IContainer components = null;

        // <snippet2>
        private static Bitmap mailBmp;
        private static Bitmap calendarBmp;
        private static Bitmap contactsBmp;
        private static Bitmap tasksBmp;

        private static string mailBmpEnc = @"Qk32BgAAAAAAADYAAAAoAAAA"+
            "GAAAABgAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAA7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7uv4yFvouE"+
            "vYmDu4eBuYV/t4N9tYB7s355sXt3tntxsnhwsHZurXNsrHFrp21pomln"+
            "oGdlnmVjnWNi7u7u7u7u7u7u7u7u7u7uwY6H9N3C/vDa/ejM+tSp+cye"+
            "98OS9bqI87F/87KA8qt68KRy76Bu7phl7ZVi7JVi54xb0ntSoGVj7u7u"+
            "7u7u7u7u7u7u7u7uwo+Ix6WZ9ujb//bn/u/b/OfL++HA+9iv+tev+tSr"+
            "+tKo+cyg+Mic9b+S9LqM8al35ZZmoXBSoWdk7u7u7u7u7u7u7u7u7u7u"+
            "xZSN9ejayaOY9uvh//js/vXo/e/a/evS/OfL/OTF+927+9u1+tSq+tKl"+
            "+cqW8buFqHZa7JVdn2hm7u7u7u7u7u7u7u7u7u7uxZSN//ns9ercxqKV"+
            "+O7k//nw//fu//fr/vTl/u/c/uvU/eLB/N+7+tev8b6Hq3pe+Lh6/69q"+
            "oWpp7u7u7u7u7u7u7u7u7u7ux5eP//vv//vw9OncxKOX9+7m//v1//nz"+
            "//jx//bs/+7Z/erQ/eTC8syiqntg+M6a/9Oh/8CFom1s7u7u7u7u7u7u"+
            "7u7u7u7uypqS//z4//v28ebYza2evp6V7+Lb8uzl8+3l8uvk9Ore9ejZ"+
            "6NO/poVyt4xx5b2T/9ap/8ybpXFw7u7u7u7u7u7u7u7u7u7uzJ2V///8"+
            "7uPbzaye/fv6/fv5v6GTvKCQvJ+Nu5qIupmJt5uKsZWE+u3e+unYo4Jq"+
            "572O/9KjqHd17u7u7u7u7u7u7u7u7u7uzqCX7OHbzKud/fr58url5tnQ"+
            "5dfO5dfN5dfM5NbM49TI3Mq+3Mm93Mm8382/+unbrIJp57WGrH597u7u"+
            "7u7u7u7u7u7u7u7uz6GZ0LGj6uHa/fv67OLc6+Hb7eTd7ePd7eLb7eLb"+
            "7uPb9e7l9evk9uvj9+zh/PHlzr61r4VtsoWC7u7u7u7u7u7u7u7u7u7u"+
            "0aKXfdb/8uzn///////////////////////+//37/Pn3+fXv9fHp8+vl"+
            "8enk7uXe1si/L6f3tYeC7u7u7u7u7u7u7u7u7u7uy6mkdM3/+vf1////"+
            "/////////////////fz8/Pv69fPx7vDw7O/w2OfvxN/swt/thMXnK6ft"+
            "r4SC7u7u7u7u7u7u7u7u7u7u1KeevuX6nNf2rN/7nNz9h9X+b8z+VMb/"+
            "RsT/RsT/PsP/Obz7NLT2MbL0K6vuJ6XpKKfrLqrvr4J/7u7u7u7u7u7u"+
            "7u7u7u7u28jC0rSo0O36yOv7x+r7v+f8suP9o97+jtj+idn+htX/e83/"+
            "a8f/XcD/Tbn/SLf/R7b/rJKJ7u7u7u7u7u7u7u7u7u7u7u7u7u7u6ePi"+
            "07ew29zd1e/61O/60e77y+z8vun9reH+mNn+gdH/ccj/ZMP/Vr3/t7/C"+
            "uKCX7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u6uXk2b621rux1fH6"+
            "3fL61/L7y+/8u+f9pt7+jNT+cMn/XcH/rZyW1c3L7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u6N/d07Op3d7f2/P60vD7xez8"+
            "r+H9k9X+kr/cv6Wb7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u6uXk2L612cG31e73yOv7seL8uKWezLex7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u6eHg1LOpzaeayaqh4dvb7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u";

        private static string calendarBmpEnc = @"Qk32BgAAAAAAADYAAAAo"+
            "AAAAGAAAABgAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAA7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7uuKOUkXxqemNO"+
            "alM8YEgwYEgwYkoxYUgwYEgwY0szYkoxYEgwYEgwYEgwYEgwZEszYUgw"+
            "YEgwY0oyYUgwYEgwYEgw7u7u7u7uuqWW6tPE27qlxKCLu5d837OUzKGC"+
            "t41xsYpt37OUzKGCt41xrodq37OUzKGCt41xrodq37OUzKGCt41xrodq"+
            "Zk447u7u7u7uvKaX//fz/+3i/NvFwJl6/+nb/d3H+c+1vJV2/+HP/tW8"+
            "/MWluZJz/9vG/9Gw+8OfuJFy/86y/sKf97eSuJFyYEgw7u7u7u7uvaiZ"+
            "//j2//Hq/OTY0qiL/+7h/+TR/N3J0KWI/+TU/9vE/9S4zqOF/+LR/9zE"+
            "/sywzaKE/9e//8yt/sWizaKEYEgw7u7u7u7uv6qb//v5//j1//bx5Lug"+
            "//Ho//Dl/+nb5Lqg/+fZ/+LQ/97I5Lqf/+XU/+HN/9zF5Lqf/9bC/9S7"+
            "/9C05LqfYEgw7u7u7u7uwauc4bib1ayOxZyBvpd74LaY0qiKwJd7uJF1"+
            "4LWWz6WGvJJ2D0XuBTnjBjXQAiy8ACm137OUzKGCt41xrodqYEgw7u7u"+
            "7u7uxK6f//v6/Ozg/eHQx6CC/+/m+uHQ+tjDwpt9/+re/+DM/9O4I1Tz"+
            "/9zG/9O5/86wASu4/9fC98Sm87uYuJFyYEgw7u7u7u7uxrCh//39//n0"+
            "/One1qyQ//v4/vHn+uHR06mM//Pt/+rc/+HMPGr0/+TU/93H/9i/AzHJ"+
            "/+LP/9i++curzaKEYEgw7u7u7u7ux7Kj//39//38/fbw5Luh//z7/vj1"+
            "/uzh5Lug//fx//bv/+vgWoH2/+/m/+vd/+PQAzTa/+XU/+XU/97J5Lqf"+
            "YUkx7u7u7u7uybOk47yh3rab1q2SzaWL4bqe2a+SzKKHwpqA4bmd1q2O"+
            "x52CbY/5WYD3OWb0IFP0Aj3t4Lib06iJwJV5sopwYEgw7u7u7u7uzbep"+
            "//39//n1//Dn1a2S/vv6+uvh9+DPyqKG//Tt+eXX+eDSxJx//One+tzH"+
            "+dC3v5d6/9/K+9C1+8akuI9yalM97u7u7u7u0Lyu//39//r3//f03bWa"+
            "//7+/vXx+urg1q2R//f0/O3i+eTV06mM//fy/+7i+NfCz6WI/+zg/+DM"+
            "/9CzyZ6Adl5I7u7u7u7u0sCy//38//39//395L2j//7+//79/vn45L2j"+
            "//38//n2/vLr5L2j//37//n2/unf5L2j/+/l/+nc/+DN5L2jf2dS7u7u"+
            "7u7u6KaG6KaG6KSE56OB56B+55565pt25phy5ZVt5ZJp5I5k5Itf5Iha"+
            "44RV44FR4n5M4ntI4XhE23I812w00mkzyGAo7u7u7u7u6amK/93L/dfD"+
            "/9a+/s+2/syy/sis/sSl/cGh/byb/LeV+7SO+rCJ+auC+ad9+KN3+KBx"+
            "95xu95pq9pdn9pVkyGAo7u7u7u7u662P/+LQ/t/M/t3K/drG/dfC/dK8"+
            "/c63/Mqx/Mer+sKk+r6f+bqY+LaT+LGM96yG9qmA9aV69aB19J1w9Jps"+
            "yGAo7u7u7u7u7LKV7LKV662P6aeG56F/559855x45pp05pdw5ZRs5ZFo"+
            "5I5j5Itf5Ihb44VW44JS4n9O4nxK4XpG4XdC4XU/2Ws27u7u7u7upJqU"+
            "////pJqU////n5aQ////mZCL////kYmF////iIJ+////fnp2////dXJv"+
            "////bGpo////ZGNi////XV5c////7u7u7u7u7u7uICUg6enpICUg6enp"+
            "ICUg6enpICUg6enpICUg6enpICUg6enpICUg3t7eICUg0NDQICUgvb29"+
            "ICUguLi4ICUg7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u";

        private static string contactsBmpEnc = @"Qk32BgAAAAAAADYAAAAo"+
            "AAAAGAAAABgAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAA7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7uuqWWh3FeeWJN"+
            "alM8YEgwYEgwYEgwYEgwYEgwYEgwYEgwYEgwYEgwYEgwYEgwYEgwYEgw"+
            "YEgwYEgwYEgwYEgwYEgw7u7u7u7uuqWW//bx7t3T7trO7tfI79LB7865"+
            "8Mqy8MWq8cCi8buZ8raR8rKJ862C86l69KV09KFt9Z5o9Zxk9Zph9Zph"+
            "YEgw7u7u7u7uu6aX//n2//fy//Xv//Lr//Dn/+3j/+re/+ja/+XW/+LR"+
            "/+DN/93J/9rF/9jB/9W9/9O5/9G2/8+z/86x9ZphYEgw7u7u7u7uvKiZ"+
            "//z6//r30M/SGlmtA0uuA0WfAz+RATmHADV9zr23/+PTs4t1roRuqX1m"+
            "pHhgoXRcoXRcoXRc/9C09Z1mYEgw7u7u7u7uvqqb//79//z7FFe3N3rV"+
            "SYrkQ4XeA0OaGW3eC02nGkF4/+fZ/+TV/+LQ/9/M/9zI/9rE/9fA/9W8"+
            "/9O59KFtYEgw7u7u7u7uwKyd//////7+E1i3Z57pUZDoTY7nA0SbGGze"+
            "E2DIAzmD/+vfuZJ9s4t1roRuqX1mpHhgoXRcoXRc/9a99KV0YEgw7u7u"+
            "7u7uwq6f////////GF69gKvkX5flA0WeGW7iA0+3GWzgEk+j/+7l/+zh"+
            "/+nc/+bY/+TT/+HP/97L/9zH/9nD86t9YEgw7u7u7u7uxLCh////////"+
            "tcDPE1StGly1yNXZ+fryBVG5BkGOz8rK//LqvpiEuZJ9s4t1roRuqX1m"+
            "pHhgoXRc/93I87CHYEgw7u7u7u7uxrKk////////9fX1zdDTYWZsVFVW"+
            "YWFhBkunubzC//jz//Xw//Ps//Do/+7k/+vf/+jb/+bX/+PS/+DO8raR"+
            "YEgw7u7u7u7ux7Sm////////xMTEAAAAwcHBoqKihYWFVVVVn56d//r3"+
            "//j0//bx//Tt//Hp/+/l/+zh/+nd/+fY/+TU8b2cYEgw7u7u7u7uybao"+
            "////////ODg4LCws1tbWwcHBoqKihYWFZGRk//37//v5//n2//fy//Xv"+
            "//Lr//Dn/+3j/+re/+ja8MOmYEgw7u7u7u7uy7iq////////U1NTSUlJ"+
            "tLS01dXVwcHBoqKidXV1///+//38/LeL+7SI+q+D+ap++KV496Bz9p1w"+
            "/+vg8MmxZk437u7u7u7uzbqs////////fn5+Y2NjXV1dbW1tWFhYwcHB"+
            "hISE//////////79//z7//v4//n1//bx//Tu//Lq/+/m78+6b1dB7u7u"+
            "7u7uz7yu////////xcXFbGxsgoKCoaGhjo6OVVVVra2t/////////LeL"+
            "+7SI+q+D+ap++KV496Bz9p1w//Pr79TEeWJN7u7u7u7u0L6w////////"+
            "8vLyuLi4jY2NiIiIhYWFtLS08fHx//////////////////////38//z6"+
            "//r3//j0//bw7tnMgm1Z7u7u7u7u0b+x////////////////////////"+
            "//////////////////////////////////////79//z7//v4//n1//fy"+
            "i3Zj7u7u7u7u0sCy0b+x0L6wz72vzrutzLqsy7iqybeoyLWmxrOkxLGi"+
            "w6+hwa2fv6udvqmbvKiZu6aXuaWWuKOUt6KTtqGStaCR7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u"+
            "7u7u";

        private static string tasksBmpEnc = @"Qk32BgAAAAAAADYAAAAoAAA"+
            "AGAAAABgAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAA7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u3N3fkXxqeGB"+
            "LalE5cVc/c1lBf2JKl3RZiWhMe1xBb1M5aE42Zkw0Zk01aE42YUkxYkk"+
            "xYkkxkod97u7u7u7u7u7u7u7u7u7uv62e+ezi69nQ7M6+7Miz6L+prI+"+
            "rWFKqmHyk7rWU77OO77CM8LCK8bCH8a2F8qp98aV13pZnZkwz7u7u7u7"+
            "u7u7u7u7u7u7uv62e//37/vr3/vTw+uvkwLnaJDO/BhmzJjTDybTG99K"+
            "8+NC49syy9sms9sao9cOl8LiV8KR0aU417u7u7u7u7u7u7u7u7u7uwK6"+
            "f//7+//z7/Pj3xcTmLDvBFynIMEXkIDbXVGHO6dHO+tzJ+tjD+dW++dK"+
            "5+c+19sWn8qd2Y0kx7u7u7u7u7u7u7u7u7u7uw7Gj/////Pv9wcTsKDj"+
            "FFCnMRVjuZHX1PlPoFzHSeHPJ+d3O+tzI+tjD+dS9+dG59seq8ayEaEw"+
            "07u7u7u7u7u7u7u7u7u7uxrWm9vf9pKzoJjjNGi7TR1nreoj/j5v8ZXf"+
            "0N0zlJjTPv7LP+t7O+tvI+tfC+dS998qv8K+LaU427u7u7u7u7u7u7u7"+
            "u7u7u08W619v5Kz7XJjrfTl/ze4v/tLr59/Dyoab2Znb0LUPmNUTO1sX"+
            "R+9/N+tvH+tjC99C277GNbVI47u7u7u7u7u7u7u7u7u7uy7qt6+3+kp7"+
            "4UGT4c4P/sbj+/Pr5/vj16ePykpz5Y3T0KDzfbHHR6dTS++HQ+tvG+dn"+
            "D8bqabVI57u7u7u7u7u7u7u7u7u7uybeo////9ff/qLL/wsr//Pz///3"+
            "8/vv5/ff09e7wpav4YnP0KDzajYzQ6NPT/N7O+NrG8b+idFlA7u7u7u7"+
            "u7u7u7u7u7u7uyriq////////+Pn//v7///////////38/vr2/vj08er"+
            "wmaL6WWvyMELXmJbS9OPb+d/Q88mxc1Y97u7u7u7u7u7u7u7u7u7uzLq"+
            "s//////////////////////////7+//36/vr3/vn0+fDvsLT1WmruNUb"+
            "Qta/V+uXX9M+6hWdP7u7u7u7u7u7u7u7u7u7uzryt///////////////"+
            "///////////////7+//79//v3/vj0+O7wurz0TV3sSFTS08fa9t7PmXl"+
            "h7u7u7u7u7u7u7u7u7u7uz72v/////////////////////fj1+Orh9uH"+
            "W89TD88+78sew9NK99drNm5/xVWbwYWvV6dzgrIlw7u7u7u7u7u7u7u7"+
            "u7u7u0L6w////////////////X4ycVYGSTHaIS21/SGN0SGJySF9vdnd"+
            "9pZWQ89TDt7n1TF3oZGvOuJ2L7u7u7u7u7u7u7u7u7u7u0b+x///////"+
            "/////////dJmou+Xsmd3ofs/fdcXVcMHSbrrNbbHCbHJ69dTD++3nw8H"+
            "uNUjqZGjJ7u7u7u7u7u7u7u7u7u7u0b+x////////////////i6q2pMn"+
            "StuzzYYycdLG+fs/ed8jaXY2eRl1t8uDU++je/O7mzsnmUFCX7u7u7u7"+
            "u7u7u7u7u7u7u0sCy////////////////3ufqdZuqx+30V3aFXoCPaZW"+
            "kjdDeTWx8v7Ko/vr2/fTv/fTu+/XxnZSu7u7u7u7u7u7u7u7u7u7u6ur"+
            "r2Mq/0b+x0L6wz72vyLeqc5qpoMHLxfD3v+zzruXvkMjVaX6GwK6ewrC"+
            "hwa+gwK6fv62e4OHi7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u5ObnfKa1eaOxcpyrcJWkboiW4+Pj7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7"+
            "u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u7u";

        // Static constructor to initialize
        // the form's static fields.
        static StackView()
        {
            // Create the static bitmaps from Base64 encoding.
            CreateBitmaps();
        }

        // <snippet5>
        public StackView()
        {
            this.InitializeComponent();

            // Assign icons to ToolStripButton controls.
            this.InitializeImages();

            // Set up renderers.
            this.stackStrip.Renderer = new StackRenderer();
        }
        // </snippet5>

        // This utility method assigns icons to each
        // ToolStripButton control.
        private void InitializeImages()
        {
            this.mailStackButton.Image = mailBmp;
            this.calendarStackButton.Image = calendarBmp;
            this.contactsStackButton.Image = contactsBmp;
            this.tasksStackButton.Image = tasksBmp;
        }

        // This utility method creates bitmaps for all the icons.
        // It uses a utility method called DeserializeFromBase64
        // to decode the Base64 image data.
        private static void CreateBitmaps()
        {
            mailBmp = DeserializeFromBase64(mailBmpEnc);
            calendarBmp = DeserializeFromBase64(calendarBmpEnc);
            contactsBmp = DeserializeFromBase64(contactsBmpEnc);
            tasksBmp = DeserializeFromBase64(tasksBmpEnc);
        }

        // This utility method cretes a bitmap from 
        // a Base64-encoded string. 
        internal static Bitmap DeserializeFromBase64(string data)
        {
            // Decode the string and create a memory stream 
            // on the decoded string data.
            MemoryStream stream =
                new MemoryStream(Convert.FromBase64String(data));

            // Create a new bitmap from the stream.
            Bitmap b = new Bitmap(stream);

            return b;
        }
        // </snippet2>

        // <snippet3>
        // This method handles the Load event for the UserControl.
        private void StackView_Load(object sender, EventArgs e)
        {
            // Dock bottom.
            this.Dock = DockStyle.Bottom;

            // Set AutoSize.
            this.AutoSize = true;
        }
        // </snippet3>

        // <snippet4>
        // This method handles the Click event for all
        // the ToolStripButton controls in the StackView.
        private void stackButton_Click(object sender, EventArgs e)
        {
            // Define a "one of many" state, similar to
            // the logic of a RadioButton control.
            foreach (ToolStripItem item in this.stackStrip.Items)
            {
                if ((item != sender) &&
                    (item is ToolStripButton))
                {
                    ((ToolStripButton)item).Checked = false;
                }
            }
        }
        // </snippet4>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // <snippet10>
        internal class StackRenderer : ToolStripProfessionalRenderer
        {
            private static Bitmap titleBarGripBmp;
            private static string titleBarGripEnc = @"Qk16AQAAAAAAADYAAAAoAAAAIwAAAAMAAAABABgAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAAuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5uGMyuGMy+/n5+/n5ANj+RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5wm8/RzIomHRh+/n5ANj+RzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMzHtMRzIoRzIozHtMANj+";

            // Define titlebar colors.
            private static Color titlebarColor1 = Color.FromArgb(89, 135, 214);
            private static Color titlebarColor2 = Color.FromArgb(76, 123, 204);
            private static Color titlebarColor3 = Color.FromArgb(63, 111, 194);
            private static Color titlebarColor4 = Color.FromArgb(50, 99, 184);
            private static Color titlebarColor5 = Color.FromArgb(38, 88, 174);
            private static Color titlebarColor6 = Color.FromArgb(25, 76, 164);
            private static Color titlebarColor7 = Color.FromArgb(12, 64, 154);
            private static Color borderColor = Color.FromArgb(0, 0, 128);

            static StackRenderer()
            {
                titleBarGripBmp = StackView.DeserializeFromBase64(titleBarGripEnc);
            }

            public StackRenderer()
            {
            }

            private void DrawTitleBar(Graphics g, Rectangle rect)
            {
                // Assign the image for the grip.
                Image titlebarGrip = titleBarGripBmp;

                // Fill the titlebar. 
                // This produces the gradient and the rounded-corner effect.
                g.DrawLine(new Pen(titlebarColor1), rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                g.DrawLine(new Pen(titlebarColor2), rect.X, rect.Y + 1, rect.X + rect.Width, rect.Y + 1);
                g.DrawLine(new Pen(titlebarColor3), rect.X, rect.Y + 2, rect.X + rect.Width, rect.Y + 2);
                g.DrawLine(new Pen(titlebarColor4), rect.X, rect.Y + 3, rect.X + rect.Width, rect.Y + 3);
                g.DrawLine(new Pen(titlebarColor5), rect.X, rect.Y + 4, rect.X + rect.Width, rect.Y + 4);
                g.DrawLine(new Pen(titlebarColor6), rect.X, rect.Y + 5, rect.X + rect.Width, rect.Y + 5);
                g.DrawLine(new Pen(titlebarColor7), rect.X, rect.Y + 6, rect.X + rect.Width, rect.Y + 6);

                // Center the titlebar grip.
                g.DrawImage(
                    titlebarGrip,
                    new Point(rect.X + ((rect.Width / 2) - (titlebarGrip.Width / 2)),
                    rect.Y + 1));
            }

            // This method handles the RenderGrip event.
            protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
            {
                DrawTitleBar(
                    e.Graphics,
                    new Rectangle(0, 0, e.ToolStrip.Width, 7));
            }

            // This method handles the RenderToolStripBorder event.
            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                DrawTitleBar(
                    e.Graphics,
                    new Rectangle(0, 0, e.ToolStrip.Width, 7));
            }

            // This method handles the RenderButtonBackground event.
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                Graphics g = e.Graphics;
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);

                Color gradientBegin = Color.FromArgb(203, 225, 252);
                Color gradientEnd = Color.FromArgb(125, 165, 224);

                ToolStripButton button = e.Item as ToolStripButton;
                if (button.Pressed || button.Checked)
                {
                    gradientBegin = Color.FromArgb(254, 128, 62);
                    gradientEnd = Color.FromArgb(255, 223, 154);
                }
                else if (button.Selected)
                {
                    gradientBegin = Color.FromArgb(255, 255, 222);
                    gradientEnd = Color.FromArgb(255, 203, 136);
                }

                using (Brush b = new LinearGradientBrush(
                    bounds,
                    gradientBegin,
                    gradientEnd,
                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(b, bounds);
                }

                e.Graphics.DrawRectangle(
                    SystemPens.ControlDarkDark,
                    bounds);

                g.DrawLine(
                    SystemPens.ControlDarkDark,
                    bounds.X,
                    bounds.Y,
                    bounds.Width - 1,
                    bounds.Y);

                g.DrawLine(
                    SystemPens.ControlDarkDark,
                    bounds.X,
                    bounds.Y,
                    bounds.X,
                    bounds.Height - 1);

                ToolStrip toolStrip = button.Owner;
                ToolStripButton nextItem = button.Owner.GetItemAt(
                    button.Bounds.X,
                    button.Bounds.Bottom + 1) as ToolStripButton;

                if (nextItem == null)
                {
                    g.DrawLine(
                        SystemPens.ControlDarkDark,
                        bounds.X,
                        bounds.Height - 1,
                        bounds.X + bounds.Width - 1,
                        bounds.Height - 1);
                }
            }
        }
        // </snippet10>

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.stackStrip = new System.Windows.Forms.ToolStrip();
            this.mailStackButton = new System.Windows.Forms.ToolStripButton();
            this.calendarStackButton = new System.Windows.Forms.ToolStripButton();
            this.contactsStackButton = new System.Windows.Forms.ToolStripButton();
            this.tasksStackButton = new System.Windows.Forms.ToolStripButton();
            this.stackStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackStrip
            // 
            this.stackStrip.CanOverflow = false;
            this.stackStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stackStrip.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.stackStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stackStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mailStackButton,
            this.calendarStackButton,
            this.contactsStackButton,
            this.tasksStackButton});
            this.stackStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.stackStrip.Location = new System.Drawing.Point(0, 11);
            this.stackStrip.Name = "stackStrip";
            this.stackStrip.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.stackStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.stackStrip.Size = new System.Drawing.Size(150, 139);
            this.stackStrip.TabIndex = 0;
            this.stackStrip.Text = "toolStrip1";
            // 
            // mailStackButton
            // 
            this.mailStackButton.CheckOnClick = true;
            this.mailStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mailStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mailStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.mailStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.mailStackButton.Name = "mailStackButton";
            this.mailStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.mailStackButton.Size = new System.Drawing.Size(149, 27);
            this.mailStackButton.Text = " Mail";
            this.mailStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mailStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // calendarStackButton
            // 
            this.calendarStackButton.CheckOnClick = true;
            this.calendarStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.calendarStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.calendarStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.calendarStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.calendarStackButton.Name = "calendarStackButton";
            this.calendarStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.calendarStackButton.Size = new System.Drawing.Size(149, 27);
            this.calendarStackButton.Text = " Calendar";
            this.calendarStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.calendarStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // contactsStackButton
            // 
            this.contactsStackButton.CheckOnClick = true;
            this.contactsStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactsStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contactsStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.contactsStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.contactsStackButton.Name = "contactsStackButton";
            this.contactsStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.contactsStackButton.Size = new System.Drawing.Size(149, 27);
            this.contactsStackButton.Text = " Contacts";
            this.contactsStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contactsStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // tasksStackButton
            // 
            this.tasksStackButton.CheckOnClick = true;
            this.tasksStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tasksStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tasksStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tasksStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.tasksStackButton.Name = "tasksStackButton";
            this.tasksStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.tasksStackButton.Size = new System.Drawing.Size(149, 27);
            this.tasksStackButton.Text = " Tasks";
            this.tasksStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tasksStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // StackView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackStrip);
            this.Name = "StackView";
            this.Load += new System.EventHandler(this.StackView_Load);
            this.stackStrip.ResumeLayout(false);
            this.stackStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}
// </snippet1>