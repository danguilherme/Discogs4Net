using Discogs4Net.Data.Pagination;
using Discogs4Net.Model;
using Discogs4Net.Model.Release;
using Discogs4Net.Model.Release.Variations;
using System.Linq;
using System;
using Discogs4Net.Connection;

namespace Discogs4Net.Data.Service
{
    internal class MasterService : BaseService<Master>
    {
        protected internal new class Url : BaseService<Master>.Url
        {
            public class Master
            {
                public const string Retrieve = Base + "masters/{0}";
                public const string Search = Base + "database/search?type=master&q={0}";
                public const string ListVersions = Base + "masters/{0}/versions?per_page={1}&page={2}";
            }
        }

        public MasterService(Request requestConfig) : base(requestConfig) { }

        public override Master GetById(long id)
        {
            return Request.Get<Master>(String.Format(Url.Master.Retrieve, id));
        }

        public override PaginatedList<Master> Search(string query, int perPage = 50, int pageIndex = 1)
        {
            return Request.Get<SearchResult<Master>>(String.Format(Url.Master.Search, query, perPage, pageIndex));
        }

        public PaginatedList<MasterVersion> GetVersions(long masterId, int perPage = 50, int pageIndex = 1)
        {
            return Request.Get<MasterVersion.List>(String.Format(Url.Master.ListVersions, masterId, perPage, pageIndex));
        }
    }
}
