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

        private void button1_Click(object sender, EventArgs e)
        {

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
                    dgvBreakDownElements.Columns.Add("Type,", "Type");



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
             WebResponse response = request.GetResponse();

             Stream DataStream = response.GetResponseStream();
             StreamReader reader = new StreamReader(DataStream);
                
             string json = reader.ReadToEnd();
             
             //Fix the extra characters that are added to the JSON string   
             json = AprocoDummy.SupportClasses.AproSupport.FixJSonString(json);

             //Deserialise   
             dynamic dynobject = JObject.Parse(json);

                string DiagramName = (string)dynobject["DiagramName"];
                string DiagramType = (string)dynobject["DiagramType"];
             



                dgvEA_Elements.Columns.Add("Name,", "Name");
                dgvEA_Elements.Columns.Add("Type,", "Type");


                //For every element in the element dictionary
                for (int i = 0; i < dynobject["ElementDictionary"].Count; i++)
                {
                    string EleName = (string)dynobject["ElementDictionary"][i]["Key"];
                    string EleType = (string)dynobject["ElementDictionary"][i]["Value"];
                    string EleGUID = (string)dynobject["ElementDictionary"][i]["Value"];

                    dgvEA_Elements.Rows.Add(EleName, EleType);
                }

                statusStrip.Text = dynobject["ElementDictionary"].Count + " diagram elements from EA were found";

                List<string> ListEleName = new List<string>();

                txtDiagramName.Text = DiagramName;
                txtDiagramType.Text = DiagramType;


            }

            catch(Exception ex)
            {
                statusStrip.Text = ex.Message;
            }

     



        
            


            // string DiagramGUID = (string)myresults[0]["DiagramGUID"];

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
