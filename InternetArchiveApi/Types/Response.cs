using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InternetArchiveApi.Types
{
    public class Response
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public Doc[] docs { get; set; }
        public static Response FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Response>(json);
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return $"Response: Found {numFound} items";
        }
    }
}
