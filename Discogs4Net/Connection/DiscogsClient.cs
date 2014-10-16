using Discogs4Net.Data.Pagination;
using Discogs4Net.Data.Service;
using Discogs4Net.Model;
using Discogs4Net.Model.Artist;
using Discogs4Net.Model.Release;
using Discogs4Net.Model.Release.Variations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventura.uMusic.Business;

namespace Discogs4Net.Connection
{
    public class DiscogsClient
    {
        private static Request Request;

        private static ArtistService _artistService;

        private static ArtistService ArtistService
        {
            get {
                if (_artistService == null)
                    _artistService = new ArtistService(Request);
                return _artistService;
            }
        }

        private static ReleaseService _releaseService;

        private static ReleaseService ReleaseService
        {
            get
            {
                if (_releaseService == null)
                    _releaseService = new ReleaseService(Request);
                return _releaseService;
            }
        }

        private static MasterService _masterService;

        private static MasterService MasterService
        {
            get
            {
                if (_masterService == null)
                    _masterService = new MasterService(Request);
                return _masterService;
            }
        }

        public DiscogsClient(string appCode)
        {
            Request = new Request(appCode);
        }

        #region Artist

        public Artist GetArtistById(long id)
        {
            return ArtistService.GetById(id);
        }

        public PaginatedList<Artist> SearchArtist(string query, int perPage = 50, int pageIndex = 1)
        {
            return ArtistService.Search(query, perPage, pageIndex);
        }

        #endregion

        #region Release/Master

        public Release GetReleaseById(long id)
        {
            return ReleaseService.GetById(id);
        }

        public PaginatedList<ArtistRelease> GetReleasesByArtistId(long id, int perPage = 50, int pageIndex = 1)
        {
            return ReleaseService.GetByArtistId(id, perPage, pageIndex);
        }

        public Master GetMasterById(long id)
        {
            return MasterService.GetById(id);
        }

        public PaginatedList<MasterVersion> GetMasterVersions(long masterId, int perPage = 50, int pageIndex = 1)
        {
            return MasterService.GetVersions(masterId, perPage, pageIndex);
        }

        #endregion
    }
}
