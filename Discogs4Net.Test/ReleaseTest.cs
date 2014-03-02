using System;
using Discogs4Net.Data;
using Discogs4Net.Model.Artist;
using NUnit.Framework;
using System.Linq;
using Discogs4Net.Model.Enumerator;

namespace Discogs4Net.Test
{
    [TestFixture]
    public class ReleaseTest
    {
        private DiscogsClient client;

        [TestFixtureSetUp]
        public void SetUp()
        {
            client = new DiscogsClient("uMusic/0.0.1");
        }

        [Test]
        public void GetRelease()
        {
            //http://www.discogs.com/Evanescence-Evanescence/release/3150181
            var release = client.GetReleaseById(3150181);
        }
    }
}
