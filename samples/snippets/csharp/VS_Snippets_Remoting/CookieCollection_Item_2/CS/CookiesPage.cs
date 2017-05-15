/*
** This program is used as the server for 
** the programs demonstrating the use of 
** cookies. If the initial request from the 
** client has cookies, the server uses these
** cookies to generate a page structured with
** the information provided. Otherwise the 
** server sends a page to the client requesting
** some information, this information is used
** to structure the subsequent page that is sent
** to the client alongwith the cookies that need
** to be stored by the client for any subsequent
** communication with the server.
*/

using System;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;

public class CookiesPage : Page {

	private HtmlForm myForm;

	private TextBox userNameTextBox;

	private TextBox dateBirthTextBox;

	private TextBox placeBirthTextBox;

	// Associate the event handlers with the events.
	public CookiesPage() : base() {
		Load += new EventHandler(GenerateCookies);
		Error += new EventHandler(UnhandledException);
		Init += new EventHandler(PageInit);
	}

	// Create the controls for the web page.
	private void PageInit(Object Sender, EventArgs e) {
		userNameTextBox = new TextBox();
		userNameTextBox.ID = "UserName";
		dateBirthTextBox = new TextBox();
		dateBirthTextBox.ID = "DateOfBirth";
		placeBirthTextBox = new TextBox();
		placeBirthTextBox.ID = "PlaceOfBirth";
		placeBirthTextBox.AutoPostBack = true;
		myForm = new HtmlForm();
		myForm.Method = "POST";
	}


	private void UnhandledException(Object Sender, EventArgs e) {
		Response.Write("There was an unhandled exception on this page");
	}

	private void GenerateCookies(Object Sender, EventArgs e) {
		bool noCookieHeader = false;
		if(Request.Cookies["UserName"] == null)
			noCookieHeader = true;

		// If there is no cookies in the request then send a web page querying info.
		if(noCookieHeader) {			
			// Compose a page with the info sent from the client as a post back.
			if(IsPostBack) {
				RemoveControls();
				HttpCookie myHttpCookie = new HttpCookie("UserName", Request.Form["UserName"]);
				myHttpCookie.Domain = Request.Url.Host;
				myHttpCookie.Path = Request.Path;
				myHttpCookie.Expires = DateTime.Now.AddHours(-12);
				myHttpCookie.Secure = false;
				Response.Cookies.Add(myHttpCookie);
				myHttpCookie = new HttpCookie("DateOfBirth", Request.Form["DateOfBirth"]);
				myHttpCookie.Domain = Request.Url.Host;
				myHttpCookie.Path = Request.Path;
				myHttpCookie.Expires = DateTime.Now.AddHours(-12);
				myHttpCookie.Secure = false;
				Response.Cookies.Add(myHttpCookie);
				myHttpCookie = new HttpCookie("PlaceOfBirth", Request.Form["PlaceOfBirth"]);
				myHttpCookie.Domain = Request.Url.Host;
				myHttpCookie.Path = Request.Path;
				myHttpCookie.Expires = DateTime.Now.AddHours(-12);
				myHttpCookie.Secure = false;
				Response.Cookies.Add(myHttpCookie);
				Response.Write(Request.Form["UserName"] + 
							   " , was born on " + 
							   Request.Form["DateOfBirth"] + 
							   " at " +
							   Request.Form["PlaceOfBirth"]);
			}
			// Request information from the client.
			else
			{
				AddControls();
				Response.Write("Please enter the values : ");
			}
		}
		// Compose a page with the information in the cookies sent over.
		else {
			Response.Write(Request.Cookies["UserName"].Value + 
				           " , was born on " + 
						   Request.Cookies["DateOfBirth"].Value + 
						   " at " + 
						   Request.Cookies["PlaceOfBirth"].Value);
		}
	}

	protected void AddControls() {
		Controls.Add(myForm);
		myForm.Controls.Add(userNameTextBox);
		myForm.Controls.Add(dateBirthTextBox);
		myForm.Controls.Add(placeBirthTextBox);	
	}

	protected void RemoveControls() {
		Controls.Remove(myForm);
		myForm.Controls.Remove(userNameTextBox);
		myForm.Controls.Remove(dateBirthTextBox);
		myForm.Controls.Remove(placeBirthTextBox);
	}
};
