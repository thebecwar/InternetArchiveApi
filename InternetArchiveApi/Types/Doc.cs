using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InternetArchiveApi.Types
{
    public class Doc
    {
        public string backup_location { get; set; }
        public string btih { get; set; }
        public string[] collection { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public int downloads { get; set; }
        public string[] format { get; set; }
        public string identifier { get; set; }
        public string[] indexflag { get; set; }
        public int item_size { get; set; }
        public string mediatype { get; set; }
        public int month { get; set; }
        public DateTime[] oai_updatedate { get; set; }
        public DateTime publicdate { get; set; }
        public string[] subject { get; set; }
        public string title { get; set; }
        public int week { get; set; }
        public string year { get; set; }
        public string avg_rating { get; set; }
        public int num_reviews { get; set; }
        public DateTime reviewdate { get; set; }

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

        public static Doc FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Doc>(json);
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return this.identifier;
        }
    }
}
