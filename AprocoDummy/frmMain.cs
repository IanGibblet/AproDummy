using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientCore.Controller;
using ClientCore.Exceptions;
using ClientCore.Model;
using Newtonsoft.Json.Linq;
using DevelopmentCoreTest;



using ClientCore;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using RestfulEA.Models;
using System.Net.Http;

namespace AprocoDummy
{
    public partial class frmMain : Form
    {

        static string CurrentSpaceName = "Aprocone"; //The Current Working Space Name

        public frmMain()
        {
            InitializeComponent();
        }



        public static JObject SearchSoftTypeItem(SoftType type, string searchTerm, string searchOn, StringComparison caseSensitivity)
        {
            Console.WriteLine("Searching for all " + type.Name + " with " + searchOn + ": " + searchTerm + " \nSearch URI:" + type.SearchAllHref);
            try
            {
                Search study = new Search(new Uri(type.SearchAllHref));
                JObject match = study.SearchAllPages(searchTerm, searchOn, caseSensitivity);
                if (match != null) //Found a Match
                {
                    return match;
                }
                else//Data was not found
                {
                    Console.WriteLine("No " + type.Name + " found with " + searchOn + ": " + searchTerm);
                }
            }
          //  catch (HttpRequestException) { throw new SearchException("Failed to Get item."); }
            catch (System.Net.WebException) { throw new ConnectionException("Unable to connect to the remote server. A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond. Please ensure there is a working internet connection and the host name provided is correct."); }
            catch (JsonReaderException) { throw new SearchException("The Request response is invalid JSON"); } //The requested space cannot be found            
            catch (UriFormatException) { throw new SearchException("Some invalid URI encountered"); }
            return null;
        }

        private void GetGetSaSObject(object sender, EventArgs e)
        {
            //First wipe the data grid view
            dgvBreakDownElements.Rows.Clear();



            string URI = txtSaS_URI.Text;
            statusStrip.Text = "Attempting to log in to " + URI;

            Client.Host = new Uri(URI); //Accessing on Port 443 (HTTPS)
            var isLoggedIn = Client.SignIn("admin@eurostep.com", "pAssw0rd", Client.Host); //Login to ShareAspace
            //USE MY OWN CREDENTIALS



            if (isLoggedIn) //Is Logged In?
            {

                statusStrip.Text = "Successfully Logged in as admin@eurostep.com";
              
                try
                {
                    Client.SetWorkingSpace(Client.Auth, CurrentSpaceName);

                    //Example code to get a single software type
                    /*  SoftType type;
                      Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("BDABreakdownElement", out type); //Set the Search Softtype 
                      JObject J = SearchSoftTypeItem(type, "IanTestBreakdown", "name", StringComparison.InvariantCultureIgnoreCase);

                      string href = (string)J["data"]["id"];
                      */

                    SoftType type;

                    Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("BDABreakdownElement", out type);
                    var results = SearchAllItemsOfType(type);

                    dgvBreakDownElements.Columns.Add("Name,", "Name");
                    dgvBreakDownElements.Columns.Add("CreatedBy,", "CreatedBy");
                    dgvBreakDownElements.Columns.Add("Identifier,", "Identifier");



                    for (int i = 0; i < results.Count; i++)
                    {
                        string NameOfBDE = (string)results[i]["data"]["name"];
                        string IDofBDE = (string)results[i]["data"]["id"];
                        string CreatedBy = (string)results[i]["data"]["commonDefinitionCreatedBy"];
                        dgvBreakDownElements.Rows.Add(NameOfBDE, CreatedBy, IDofBDE);

                    }

                    statusStrip.Text = results.Count + " breakdown elements found"; 



                   


                }
                catch (SpaceException se) //Error Fetching Space
                {
                    Console.WriteLine(se); //Print the Error Message if there was a problem setting space
                    statusStrip.Text = se.Message;

                }


            }



        }

        /// <summary>
        /// Generic: Get all items of a given softtype.
        /// </summary>
        /// <param name="type">Softtype</param>
        /// <permission cref="System.Security.PermissionSet">Public Access</permission>
        public static System.Collections.Generic.List<JObject> SearchAllItemsOfType(SoftType type)
        {
            Search softType = new Search(new Uri(type.SearchAllHref));
            var results = softType.GetAll(new Uri(type.SearchAllHref));
            //Console.WriteLine(results.Count);
            return results;
        }

        private static void UpdateSoftType(SoftType type, JObject JsonPostData)
        {
            string oid = JsonPostData["$oid"]?.Value<string>();
            HttpResponseMessage response = null;
            try
            {
                response = Client.Auth?.Helper?.Put(type.UpdateHref + oid, JsonPostData);
                response.EnsureSuccessStatusCode(); //Ensure the Post was succcessfull.
                Console.WriteLine(type.Name + " Posted successfully at " + response.Headers.Location);
            }
            catch (HttpRequestException) { Console.WriteLine(ClientCore.Exceptions.CoreExceptions.GetRestResponseExceptionString(response)); }
        }


        private void btnShowElements_Click(object sender, EventArgs e)
        {

            statusStrip.Text = "Creating Web request for URI";



            string URI = txtDiagramURL.Text;
            // string myParameters = "field=value1&field2=value2";


            //WebRequest request = WebRequest.Create(URI);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";

   
           

            try
            {

            //Get the JSON string and deserialise it
             WebResponse response = request.GetResponse();
             Stream DataStream = response.GetResponseStream();
             StreamReader reader = new StreamReader(DataStream);               
             string json = reader.ReadToEnd();
             dynamic dynobject = JObject.Parse(json);     

             dgvEA_Elements.Columns.Add("Name,", "Name");
             dgvEA_Elements.Columns.Add("Type,", "Type");


                //DIAGRAM ELEMENTS
                for (int i = 0; i < dynobject["Elements"]["Element Array"].Count; i++)
                {
                     //Split up the element properties
                     string WholeDiagramURL = dynobject["Elements"]["Element Array"][i]; 
                     var DiagramURLarray = WholeDiagramURL.Split('/');
                     string[] UrlArray = DiagramURLarray[DiagramURLarray.Count()-1].Split('|');
                    
                     //Send the the screen.
                     string EleName = UrlArray[0];
                     string EleType = UrlArray[1];
                     string EleGUID = UrlArray[2];
                     dgvEA_Elements.Rows.Add(EleName, EleType);
                }
                statusStrip.Text = dynobject["Elements"]["Element Array"].Count + " diagram elements from EA were found";

                //DIAGRAM LINKS
                for (int i = 0; i < dynobject["Elements"]["Link Array"].Count; i++)
                {
                    //Split up the link properties
                    string WholeLinkURL = dynobject["Elements"]["Link Array"][i];
                    var LinkURLarray = WholeLinkURL.Split('/');
                    string[] UrlArray = LinkURLarray[LinkURLarray.Count() - 1].Split('|');

                    //Send the the screen.
                    string LinkName = UrlArray[0];
                    string LinkType = UrlArray[1];
                    string LinkGUID = UrlArray[2];
                    dgvEA_Elements.Rows.Add(LinkName, LinkType);
                }



                //Split up the element properties

                var VarURI = URI.Split('/');
                string[] UriArray = VarURI[VarURI.Count() - 1].Split('|');
            
                txtDiagramName.Text = UriArray[0];
                txtDiagramType.Text = UriArray[1];


            }

            catch(Exception ex)
            {
                statusStrip.Text = ex.Message;
            }

     



        
            


            // string DiagramGUID = (string)myresults[0]["DiagramGUID"];

        }



        private void btnSmlPreview_Click(object sender, EventArgs e)
        {
            string URL = txtDiagramURL.Text + "/SmallPreview";
            System.Diagnostics.Process.Start(URL);
        }

        private void btnLargePreview_Click(object sender, EventArgs e)
        {
            string URL = txtDiagramURL.Text + "/BigPreview";
            System.Diagnostics.Process.Start(URL);
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            string URI = txtSaS_URI.Text;
            statusStrip.Text = "Attempting to log in to " + URI;

            Client.Host = new Uri(URI); //Accessing on Port 443 (HTTPS)
            var isLoggedIn = Client.SignIn("admin@eurostep.com", "pAssw0rd", Client.Host); //Login to ShareAspace
                                                                                           //USE MY OWN CREDENTIALS


         
            string SelectedBreakdown = (dgvBreakDownElements.SelectedCells[0].Value.ToString());

            if (SelectedBreakdown == null )

            {
                statusStrip.Text = "No SaS object selected";
                return;
            }

            String Preview = null;
            if (radBtnSmallPreview.Checked == true) Preview = txtDiagramURL.Text + "/SmallPreview";
            if (radBtnLargePreview.Checked == true) Preview = txtDiagramURL.Text + "/BigPreview";

            if (Preview == null) return;



           


            if (isLoggedIn) //Is Logged In?
            {
                SoftType type;

                Client.SetWorkingSpace(Client.Auth, CurrentSpaceName);
                Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("BDABreakdownElement", out type); //Set the Search Softtype 

                JObject J = SearchSoftTypeItem(type, SelectedBreakdown, "name", StringComparison.InvariantCultureIgnoreCase);
                J["data"]["description"] = Preview;
                JObject PostData = J["data"].ToObject<JObject>();
              

                UpdateSoftType(type, PostData);
                statusStrip.Text = "OSLC Preview link saved";

            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtDiagramURL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
