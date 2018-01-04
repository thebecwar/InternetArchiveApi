using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InternetArchiveApi.Types
{
    public class Responseheader
    {
        public int status { get; set; }
        public int QTime { get; set; }
        public Params _params { get; set; }

        public static Responseheader FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Responseheader>(json);
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return $"Response Status: {this.status}";
        }
    }
}
