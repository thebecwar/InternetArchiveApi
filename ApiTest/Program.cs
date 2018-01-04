using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetArchiveApi;

namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            InternetArchive archive = new InternetArchive();
            //var item = archive.GetItem("apple_ii_library_4am");

            var query = new Query();
            query.SearchQuery = "collection:apple_ii_library_4am";
            query.NumberOfResults = 100;
            query.Page = 1;
            query.RequestFields = QueryFields.Identifier | QueryFields.Title;

            var result = archive.RunQuery(query);
            
        }
    }
}
