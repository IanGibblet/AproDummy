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
    public partial class Form1 : Form
    {

        static string CurrentSpaceName = "Aprocone"; //The Current Working Space Name

        public Form1()
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
            Client.Host = new Uri("https://sas.aprocone.cfms.org.uk/api/"); //Accessing on Port 443 (HTTPS)
            var isLoggedIn = Client.SignIn("admin@eurostep.com", "pAssw0rd", Client.Host); //Login to ShareAspace
            //USE MY OWN CREDENTIALS



            if (isLoggedIn) //Is Logged In?
            {
                Console.WriteLine("Successfully Logged in as admin@eurostep.com ");
                try
                {
                    Client.SetWorkingSpace(Client.Auth, CurrentSpaceName);
                
                    //Examples------------

                    //List All Queries
                 //   foreach (var item in Client.CurrentSpace.QueriesInSpace.Queries)
                 //   {
                  //      Console.WriteLine(item.Href);
                 //   }

                  //  var obj = MySearch.SearchStudy("IanTestStudy", "name");

                  //  JObject myJobject = obj;

                 //   Client.CurrentSpace.QueriesInSpace.GetQueryByName("IanTestStudy");

                 //   txtBreakdowns.Text = obj.ToString();

                  //  string MyName =  obj["components"][""]?.Value<string>();

                //    SoftType myST;

                 //   Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("Study", out myST);
                   // string x=  myST.SearchAllHref;

                    SoftType type;                           
                    Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("BDABreakdownElement", out type); //Set the Search Softtype 
                    JObject J = SearchSoftTypeItem(type, "IanTestBreakdown", "name", StringComparison.InvariantCultureIgnoreCase);

                    string href = (string)J["data"]["id"];


                    

                    //MySearch.SearchAllStudies();



                    //SearchDemoNextPage(); //Search throug Softtype example
                    //SearchWithQueries(); //Searh through Queries Example

                    //var pVal=MySearch.GetPersonById("praj.rathore@eurostep.com");
                    //Console.WriteLine(pVal);
                    //MyUpdates.UpdateStudyWithAMN(); //Update AMN Client Two with Study Ten

                    #region Search Examples
                    //var obj=MySearch.SearchStudy("Study Twenty", "name");
                    //MySearch.SearchBDARankWeightType();
                    //MySearch.SearchAllStudies();
                    //Console.WriteLine(MySearch.GetAMNByName("AMN One"));
                    //Console.WriteLine(obj);
                    #endregion
                }
                catch (SpaceException se) //Error Fetching Space
                {
                    Console.WriteLine(se); //Print the Error Message if there was a problem setting space
                }


            }



        }

        private void btnShowElements_Click(object sender, EventArgs e)
        {


        

            string URI = "http://localhost:56901/RESTEA/IanTest/Dia_Thingswithtags|otDiagram|%7B49763E96-79D0-4690-8109-EF6AE0511259%7D";
           // string myParameters = "field=value1&field2=value2";

   

            WebClient wc = new WebClient();
            wc.Headers.Add("Accept", "application/json");
            string getpage = wc.DownloadString(URI);
            getpage.Replace("\\", "");



            EA_Diagram MyDia = JsonConvert.DeserializeObject<EA_Diagram>(getpage);


            string name = MyDia.DiagramGUID;





       



        }
    }
}
