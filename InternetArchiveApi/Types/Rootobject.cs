using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InternetArchiveApi.Types
{
    public class Rootobject
    {
        public Responseheader responseHeader { get; set; }
        public Response response { get; set; }
        public int created { get; set; }
        public string d1 { get; set; }
        public string d2 { get; set; }
        public string dir { get; set; }
        public File[] files { get; set; }
        public int files_count { get; set; }
        public bool is_collection { get; set; }
        public int item_size { get; set; }
        public Metadata metadata { get; set; }
        public string server { get; set; }
        public int uniq { get; set; }
        public string[] workable_servers { get; set; }

        public static Rootobject FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Rootobject>(json);
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string GetFileUrl(File f, bool useHttps = true)
        {
            if (String.IsNullOrEmpty(this.d1) || String.IsNullOrEmpty(this.dir) || f == null || String.IsNullOrEmpty(f.name))
                return null;
            return $"http{(useHttps ? "s" : "")}://{this.d1}{this.dir}/{f.name}";
        }
        public string GetAltFileUrl(File f, bool useHttps = true)
        {
            if (String.IsNullOrEmpty(this.d2) || String.IsNullOrEmpty(this.dir) || f == null || String.IsNullOrEmpty(f.name))
                return null;
            return $"http{(useHttps ? "s" : "")}://{this.d2}{this.dir}/{f.name}";
        }
    }
}
