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

        [JsonExtensionData]
        private Dictionary<string, Newtonsoft.Json.Linq.JToken> CustomFields { get; set; }
        public T GetCustomField<T>(string key)
        {
            if (CustomFields != null && CustomFields.ContainsKey(key))
            {
                return CustomFields[key].ToObject<T>();
            }
            return default(T);
        }
        public string[] GetCustomFields()
        {
            if (CustomFields != null)
            {
                return CustomFields.Keys.ToArray();
            }
            return new string[0];
        }

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
