//using Discogs4Net.Data.Pagination;
//using Discogs4Net.Model.Release;
//using System;

//namespace Discogs4Net.Data.Service
//{
//    internal class MasterService : BaseService<Master>
//    {
//        protected internal new class Url : BaseService<Master>.Url
//        {
//            public class Master
//            {
//                public const string Retrieve = Base + "masters/{0}";
//                public const string Search = Base + "database/search?type=master&q={0}";
//            }
//        }

//        public override Master GetById(long id)
//        {
//            return Request.Get<Master>(String.Format(Url.Master.Retrieve, id));
//        }

//        public override PaginatedList<Master> Search(string query, int perPage = 50, int pageIndex = 1)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
