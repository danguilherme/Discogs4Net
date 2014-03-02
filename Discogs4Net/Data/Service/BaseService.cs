using Discogs4Net.Data;
using Discogs4Net.Data.Pagination;
using Discogs4Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discogs4Net.Data.Service
{
    internal abstract class BaseService<Entity> where Entity : Model.Model
    {
        protected internal class Url
        {
            public const string Base = "http://api.discogs.com/";
        }

        protected Request Request { get; private set; }

        public BaseService()
        {
            Request = new Request();
        }

        /// <summary>
        /// Get an entity instance by its ID
        /// </summary>
        /// <param name="id">The id of the object</param>
        /// <returns>The object from service</returns>
        public abstract Entity GetById(long id);

        /// <summary>
        /// Searches for the entity this service exposes
        /// </summary>
        /// <returns>A paginated list of the entities found</returns>
        public abstract PaginatedList<Entity> Search(string query, int perPage = 50, int pageIndex = 1);
    }
}
