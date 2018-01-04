using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace InternetArchiveApi
{
    public class Query
    {
        #region Field To Query String Mapping

        public static readonly Dictionary<QueryFields, string> FieldMap = new Dictionary<QueryFields, string>()
        {
            { QueryFields.AverageRating, "avg_rating" },
            { QueryFields.BackupLocation, "backup_location" },
            { QueryFields.BTIH, "btih" },
            { QueryFields.CallNumber, "call_number" },
            { QueryFields.Collection, "collection" },
            { QueryFields.Contributor, "contributor" },
            { QueryFields.Coverage, "coverage" },
            { QueryFields.Creator, "creator" },
            { QueryFields.Date, "date" },
            { QueryFields.Description, "description" },
            { QueryFields.Downloads, "downloads" },
            { QueryFields.ExternalIdentifier, "external-identifier" },
            { QueryFields.FoldoutCount, "foldoutcount" },
            { QueryFields.Format, "format" },
            { QueryFields.Genre, "genre" },
            { QueryFields.HeaderImage, "headerImage" },
            { QueryFields.Identifier, "identifier" },
            { QueryFields.ImageCount, "imagecount" },
            { QueryFields.IndexFlag, "indexflag" },
            { QueryFields.ItemSize, "item_size" },
            { QueryFields.Language, "language" },
            { QueryFields.LicenseUrl, "licenseurl" },
            { QueryFields.MediaType, "mediatype" },
            { QueryFields.Members, "members" },
            { QueryFields.Month, "month" },
            { QueryFields.Name, "name" },
            { QueryFields.NoIndex, "noindex" },
            { QueryFields.NumberOfReviews, "num_reviews" },
            { QueryFields.OaiUpdateDate, "oai_updatedate" },
            { QueryFields.PublicDate, "publicdate" },
            { QueryFields.Publisher, "publisher" },
            { QueryFields.RelatedExternalId, "related-external-id" },
            { QueryFields.ReviewDate, "reviewdate" },
            { QueryFields.Rights, "rights" },
            { QueryFields.ScanningCentre, "scanningcentre" },
            { QueryFields.Source, "source" },
            { QueryFields.StrippedTags, "stripped_tags" },
            { QueryFields.Subject, "subject" },
            { QueryFields.Title, "title" },
            { QueryFields.Type, "type" },
            { QueryFields.Volume, "volume" },
            { QueryFields.Week, "week" },
            { QueryFields.Year, "year" }
        };

        #endregion

        #region Query Parameters

        public int NumberOfResults { get; set; } = 50;
        public int Page { get; set; } = 1;

        QuerySort[] sortSelections;
        public QuerySort[] SortBy
        {
            get
            {
                return sortSelections;
            }
            set
            {
                if (value != null && value.Length > 3)
                    throw new ArgumentOutOfRangeException("Only 3 Sort Selections are supported");
                sortSelections = value;
            }
        }

        public QueryFields RequestFields { get; set; }

        #endregion

        public string SearchQuery { get; set; } = null;

        public string GetQueryString()
        {
            if (string.IsNullOrEmpty(SearchQuery))
                throw new ArgumentNullException("Query string must be specified.");

            var q = new StringBuilder();
            q.Append($"q={WebUtility.UrlEncode(SearchQuery)}");

            foreach (var value in Enum.GetValues(typeof(QueryFields)))
            {
                if (RequestFields.HasFlag((QueryFields)value))
                    q.Append($"&fl%5B%5D={FieldMap[(QueryFields)value]}");
            }

            if (sortSelections != null && sortSelections.Length > 0)
            {
                foreach (var sel in sortSelections)
                {
                    q.Append($"&sort%5B%5D={sel.ToString()}");
                }
            }

            q.Append($"&rows={NumberOfResults}&page={Page}&output=json");

            return q.ToString();
        }
    }

    public class QuerySort
    {
        public QueryFields Field { get; set; }
        public string CustomField { get; set; } = null;
        public bool Ascending { get; set; }
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(CustomField))
                return $"{CustomField}+{(Ascending ? "asc" : "desc")}";
            else
                return $"{Query.FieldMap[Field]}+{(Ascending ? "asc" : "desc")}";
        }
    }

    [Flags]
    public enum QueryFields : ulong
    {
        AverageRating       = 0x1,
        BackupLocation      = 0x2,
        BTIH                = 0x4,
        CallNumber          = 0x8,
        Collection          = 0x10,
        Contributor         = 0x20,
        Coverage            = 0x40,
        Creator             = 0x80,
        Date                = 0x100,
        Description         = 0x200,
        Downloads           = 0x400,
        ExternalIdentifier  = 0x800,
        FoldoutCount        = 0x1000,
        Format              = 0x2000,
        Genre               = 0x4000,
        HeaderImage         = 0x8000,
        Identifier          = 0x10000,
        ImageCount          = 0x20000,
        IndexFlag           = 0x40000,
        ItemSize            = 0x80000,
        Language            = 0x100000,
        LicenseUrl          = 0x200000,
        MediaType           = 0x400000,
        Members             = 0x800000,
        Month               = 0x1000000,
        Name                = 0x2000000,
        NoIndex             = 0x4000000,
        NumberOfReviews     = 0x8000000,
        OaiUpdateDate       = 0x10000000,
        PublicDate          = 0x20000000,
        Publisher           = 0x40000000,
        RelatedExternalId   = 0x80000000,
        ReviewDate          = 0x100000000,
        Rights              = 0x200000000,
        ScanningCentre      = 0x400000000,
        Source              = 0x800000000,
        StrippedTags        = 0x1000000000,
        Subject             = 0x2000000000,
        Title               = 0x4000000000,
        Type                = 0x8000000000,
        Volume              = 0x10000000000,
        Week                = 0x20000000000,
        Year                = 0x40000000000
    }
}
