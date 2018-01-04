using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using InternetArchiveApi.Types;


namespace InternetArchiveApi
{
    public class InternetArchive
    {
        public bool UseHttps { get; set; } = true;

        private string Scheme => $"http{(this.UseHttps ? "s" : "")}";

        public Rootobject GetItem(string id)
        {
            Rootobject result = null;
            string url = $"{Scheme}://archive.org/metadata/{id}";
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                result = Rootobject.FromJson(json);
            }
            return result;
        }

        public Response RunQuery(Query queryObj)
        {
            Response result = null;
            string query = queryObj.GetQueryString();
            string url = $"{Scheme}://archive.org/advancedsearch.php?{query}";
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                result = Rootobject.FromJson(json)?.response;
            }
            return result;
        }
    }
}
