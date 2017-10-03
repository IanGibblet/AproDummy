using ClientCore;
using ClientCore.Exceptions;
using ClientCore.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace DevelopmentCoreTest
{
    /// <summary>
    /// Demonstrate BDA Object Searc Capabilities in ShareAspace
    /// </summary>
    /// <permission cref="System.Security.PermissionSet">Public Access</permission>
    public class MySearch
    {
        /// <summary>
        /// Search Study in ShareAspace
        /// </summary>
        /// <param name="searchTerm">Search String (id/Name)</param>
        /// <param name="searchOn">Search on property such as id, name etc.</param>
        /// <returns>JSON response from ShareAspace</returns>
        /// <permission cref="System.Security.PermissionSet">Public Access</permission>
        public static JObject SearchStudy(string searchTerm, string searchOn)
        {
            SoftType type;
            Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("Study", out type); //Set the Search Softtype 
            return SearchSoftTypeItem(type, searchTerm, searchOn, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Genric function to search any Softtype
        /// </summary>
        /// <param name="type">Type of the Softtype to be searched</param>
        /// <param name="searchTerm">Search string</param>
        /// <param name="searchOn">Softtype Property</param>
        /// <returns>JSON Search/Get response from ShareAspace</returns>
        /// <permission cref="System.Security.PermissionSet">Public Access</permission>
        public static JObject SearchSoftTypeItem(SoftType type, string searchTerm, string searchOn, StringComparison caseSensitivity)
        {
            Console.WriteLine("Searching for all "+type.Name+" with " + searchOn + ": " + searchTerm + " \nSearch URI:" + type.SearchAllHref);
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
            catch (HttpRequestException) { throw new SearchException("Failed to Get item."); }
            catch (System.Net.WebException) { throw new ConnectionException("Unable to connect to the remote server. A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond. Please ensure there is a working internet connection and the host name provided is correct."); }
            catch (JsonReaderException) { throw new SearchException("The Request response is invalid JSON"); } //The requested space cannot be found            
            catch (UriFormatException) { throw new SearchException("Some invalid URI encountered"); }
            return null;
        }

        /// <summary>
        /// Get All the Studies from ShareAspace
        /// </summary>
        /// <permission cref="System.Security.PermissionSet">Public Access</permission>
        /// <remarks>Print the result in a for loop to see the Object inside</remarks>
        public static void SearchAllStudies()
        {
            SoftType type;
            Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("Study", out type); //Set the Search Softtype 
            var results=SearchAllItemsOfType(type); //The results contains Study JSON for all the studies 
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

        /// <summary>
        /// Get Associative Model Network By Name
        /// </summary>
        /// <param name="searchTerm">AMN Name</param>
        /// <returns>JSON search result</returns>
        /// <permission cref="System.Security.PermissionSet">Public Access</permission>
        public static JObject GetAMNByName(string searchTerm)
        {
            SoftType type;
            Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("BDAAMN", out type); //Set the Search Softtype 
            return SearchSoftTypeItem(type, searchTerm, "name", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Get Person by ID
        /// </summary>
        /// <param name="searchTerm">Id of the Person</param>
        /// <returns>JSON response for a person from ShareAspace Server</returns>
        /// <permission cref="System.Security.PermissionSet">Public Access</permission>
        public static JObject GetPersonById(string searchTerm)
        {
            SoftType type;
            Client.CurrentSpace.SoftTypes.SoftTypeDictionary.TryGetValue("Person", out type); //Set the Search Softtype 
            return SearchSoftTypeItem(type, searchTerm, "id", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
