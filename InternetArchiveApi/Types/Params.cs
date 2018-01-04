using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InternetArchiveApi.Types
{
    public class Params
    {
        public string query { get; set; }
        public string qin { get; set; }
        public string fields { get; set; }
        public string wt { get; set; }
        public string rows { get; set; }
        public string jsonwrf { get; set; }
        public int start { get; set; }

        public static Params FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Params>(json);
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return this.query;
        }
    }
}
