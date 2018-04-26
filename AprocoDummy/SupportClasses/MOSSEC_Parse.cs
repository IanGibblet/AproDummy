using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AprocoDummy.SupportClasses
{
    class MOSSEC_Parse
    {


        public void ParseMossecFromFile(string PathToFile)
        {




            XDocument document = XDocument.Load(@PathToFile);

            string ArchitectureName = GetNameOfArchitecture(document);

            PostToCreationFactor(document, ArchitectureName);







        }



        public void PostToCreationFactor(XDocument document, string Filename)
        {

            using (var client = new HttpClient())
            {

                //http://localhost:56901/SPC/PackageBuilder/ThisIsView|otPackage|%7B3E48D885-F7C8-4ba2-9DE0-AC749905FE0E%7D


                // HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:56901/SPC/PackageBuilder/ThisIsView|otPackage|%7B3E48D885-F7C8-4ba2-9DE0-AC749905FE0E%7D");

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:56901/SPC/PackageBuilder/" + Filename);


                


                byte[] bytes;
                bytes = System.Text.Encoding.ASCII.GetBytes(document.ToString());
                request.ContentType = "text/xml; encoding='utf-8'";

                request.ContentLength = bytes.Length;
                request.Method = "POST";

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();

                HttpWebResponse response;

                response = (HttpWebResponse)request.GetResponse();


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();

                }



            }



        }


        public string GetNameOfArchitecture(XDocument document)
        {

            var ArchiName = from m in document.Descendants("Architecture")
                            select m.Attribute("ID").Value;


           

            //We only want the first one but I only know how to get it from a loop.
            //Loop once then exit.
         foreach(var lv1 in ArchiName)
            {

                return lv1;

            }


            return "";
        }





    }

}
