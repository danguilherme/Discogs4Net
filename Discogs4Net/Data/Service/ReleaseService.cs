using Discogs4Net.Data.Pagination;
using Discogs4Net.Model;
using Discogs4Net.Model.Enumerator;
using Discogs4Net.Model.Release;
using Discogs4Net.Model.Release.Variations;
using System;
using System.Collections.Generic;

namespace Discogs4Net.Data.Service
{
    internal class ReleaseService : BaseService<Release>
    {
        #region Release
        protected new class Url : BaseService<Release>.Url
        {
            public class Release
            {
                public const string Retrieve = Base + "releases/{0}";
                public const string RetrieveByArtist = Base + "artists/{0}/releases?per_page={1}&page={2}";
            }
        }

        #region Methods

        public override Release GetById(long id)
        {
            return Request.Get<Release>(String.Format(Url.Release.Retrieve, id));
        }

        public PaginatedList<ArtistRelease> GetByArtistId(long id, int perPage = 50, int pageIndex = 1)
        {
            return Request.Get<ArtistRelease.List>(String.Format(Url.Release.RetrieveByArtist, id, perPage, pageIndex));
        }

        #endregion

        #region Load methods

        #endregion

        #endregion

        public override PaginatedList<Release> Search(string query, int perPage = 50, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }
    }
}
