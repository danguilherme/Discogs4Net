using Discogs4Net.Data.Pagination;
using Discogs4Net.Data.Service;
using Discogs4Net.Model;
using Discogs4Net.Model.Artist;
using Discogs4Net.Model.Release;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventura.uMusic.Business;

namespace Discogs4Net.Data
{
    public class DiscogsClient
    {
        private static ArtistService _artistService;

        private static ArtistService ArtistService
        {
            get {
                if (_artistService == null)
                    _artistService = new ArtistService();
                return _artistService;
            }
        }

        private static ReleaseService _releaseService;

        private static ReleaseService ReleaseService
        {
            get
            {
                if (_releaseService == null)
                    _releaseService = new ReleaseService();
                return _releaseService;
            }
        }

        public DiscogsClient(string appCode)
        {
            Request.AppCode = appCode;
        }

        public Artist GetArtistById(long id)
        {
            return ArtistService.GetById(id);
        }

        public PaginatedList<Artist> SearchArtist(string query, int perPage = 50, int pageIndex = 1)
        {
            return ArtistService.Search(query, perPage, pageIndex);
        }

        public Release GetReleaseById(long id)
        {
            return ReleaseService.GetById(id);
        }
    }
}
