using System;
using Discogs4Net.Data;
using Discogs4Net.Model.Artist;
using NUnit.Framework;
using System.Linq;
using Discogs4Net.Model.Enumerator;
using Discogs4Net.Connection;

namespace Discogs4Net.Test
{
    [TestFixture]
    public class OAuthTest
    {
        private DiscogsClient client;

        [TestFixtureSetUp]
        public void SetUp()
        {
            client = new DiscogsClient("uMusic/0.0.1");
        }

        [Test]
        public void GetProtectedInfo()
        {
            // make request to identity test
        }
    }
}
