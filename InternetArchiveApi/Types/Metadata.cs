using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InternetArchiveApi.Types
{
    public class Metadata
    {
        public string identifier { get; set; }
        public string[] collection { get; set; }
        public string description { get; set; }
        public string hidden { get; set; }
        public string mediatype { get; set; }
        public string numrecentreviews { get; set; }
        public string numtopdl { get; set; }
        public string title { get; set; }
        public string publicdate { get; set; }
        public string uploader { get; set; }
        public string addeddate { get; set; }
        public string num_recent_reviews { get; set; }
        public string num_top_dl { get; set; }
        public string spotlight_identifier { get; set; }
        public string backup_location { get; set; }
        public string show_search_by_year { get; set; }

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

        public static Metadata FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Metadata>(json);
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return this.title;
        }
    }
}
