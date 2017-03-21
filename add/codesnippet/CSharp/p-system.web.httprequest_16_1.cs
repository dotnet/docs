int count;
String[] userLang = Request.UserLanguages;    
 
for (count = 0; count < userLang.Length; count++) 
{
   Response.Write("User Language " + count +": " + userLang[count] + "<br>");
}
   