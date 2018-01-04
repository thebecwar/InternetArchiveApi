using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InternetArchiveApi.Types
{
    public class File
    {
        public string name { get; set; }
        public string source { get; set; }
        public string btih { get; set; }
        public string mtime { get; set; }
        public string size { get; set; }
        public string md5 { get; set; }
        public string crc32 { get; set; }
        public string sha1 { get; set; }
        public string format { get; set; }
        public string rotation { get; set; }

        public static File FromJson(string json)
        {
            return JsonConvert.DeserializeObject<File>(json);
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return this.name;
        }
    }
}
