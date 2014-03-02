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
        public void GetArtistReleases()
        {
            //374434
            //http://www.discogs.com/Evanescence-Evanescence/master/374434
            var releases = client.GetReleasesByArtistId(163505);

            Assert.AreEqual(50, releases.Pagination.ItemsPerPage);
            Assert.AreEqual(50, releases.Count);

            releases = client.GetReleasesByArtistId(163505, 75);

            Assert.AreEqual(75, releases.Pagination.ItemsPerPage);
            Assert.AreEqual(75, releases.Count);
        }

        [Test]
        public void GetMaster()
        {
            //374434
            //http://www.discogs.com/Evanescence-Evanescence/master/374434
            var master = client.GetMasterById(374434);

            Assert.AreEqual(12, master.TrackList.Count, "Wrong tracks count: " + master.TrackList.Count);

            #region Tracks test

            Assert.AreEqual(1, Convert.ToInt32(master.TrackList[0].Position));
            Assert.AreEqual("What You Want", master.TrackList[0].Title);
            Assert.AreEqual("3:41", master.TrackList[0].Duration);

            Assert.AreEqual(2, Convert.ToInt32(master.TrackList[1].Position));
            Assert.AreEqual("Made Of Stone", master.TrackList[1].Title);
            Assert.AreEqual("3:34", master.TrackList[1].Duration);

            Assert.AreEqual(3, Convert.ToInt32(master.TrackList[2].Position));
            Assert.AreEqual("The Change", master.TrackList[2].Title);
            Assert.AreEqual("3:42", master.TrackList[2].Duration);

            Assert.AreEqual(4, Convert.ToInt32(master.TrackList[3].Position));
            Assert.AreEqual("My Heart Is Broken", master.TrackList[3].Title);
            Assert.AreEqual("4:29", master.TrackList[3].Duration);

            Assert.AreEqual(5, Convert.ToInt32(master.TrackList[4].Position));
            Assert.AreEqual("The Other Side", master.TrackList[4].Title);
            Assert.AreEqual("4:05", master.TrackList[4].Duration);

            Assert.AreEqual(6, Convert.ToInt32(master.TrackList[5].Position));
            Assert.AreEqual("Erase This", master.TrackList[5].Title);
            Assert.AreEqual("3:55", master.TrackList[5].Duration);

            Assert.AreEqual(7, Convert.ToInt32(master.TrackList[6].Position));
            Assert.AreEqual("Lost In Paradise", master.TrackList[6].Title);
            Assert.AreEqual("4:43", master.TrackList[6].Duration);

            Assert.AreEqual(8, Convert.ToInt32(master.TrackList[7].Position));
            Assert.AreEqual("Sick", master.TrackList[7].Title);
            Assert.AreEqual("3:30", master.TrackList[7].Duration);

            Assert.AreEqual(9, Convert.ToInt32(master.TrackList[8].Position));
            Assert.AreEqual("End Of The Dream", master.TrackList[8].Title);
            Assert.AreEqual("3:49", master.TrackList[8].Duration);

            Assert.AreEqual(10, Convert.ToInt32(master.TrackList[9].Position));
            Assert.AreEqual("Oceans", master.TrackList[9].Title);
            Assert.AreEqual("3:38", master.TrackList[9].Duration);

            Assert.AreEqual(11, Convert.ToInt32(master.TrackList[10].Position));
            Assert.AreEqual("Never Go Back", master.TrackList[10].Title);
            Assert.AreEqual("4:27", master.TrackList[10].Duration);

            Assert.AreEqual(12, Convert.ToInt32(master.TrackList[11].Position));
            Assert.AreEqual("Swimming Home", master.TrackList[11].Title);
            Assert.AreEqual("3:44", master.TrackList[11].Duration);

            #endregion

        }

        [Test]
        public void GetMasterVersions()
        {
            //374434
            //http://www.discogs.com/Evanescence-Evanescence/master/374434
            var masters = client.GetMasterVersions(374434);

            Assert.AreEqual(50, masters.Pagination.ItemsPerPage);
            Assert.AreEqual(11, masters.Count);

            masters = client.GetMasterVersions(374434, 5);

            Assert.AreEqual(5, masters.Pagination.ItemsPerPage);
            Assert.AreEqual(5, masters.Count);
        }

        [Test]
        public void GetRelease()
        {
            //http://www.discogs.com/Evanescence-Evanescence/release/3150181
            var release = client.GetReleaseById(3150181);

            Assert.AreEqual(12, release.TrackList.Count, "Wrong tracks count: " + release.TrackList.Count);

            #region Tracks test

            Assert.AreEqual(1, Convert.ToInt32(release.TrackList[0].Position));
            Assert.AreEqual("What You Want", release.TrackList[0].Title);
            Assert.AreEqual("3:41", release.TrackList[0].Duration);

            Assert.AreEqual(2, Convert.ToInt32(release.TrackList[1].Position));
            Assert.AreEqual("Made Of Stone", release.TrackList[1].Title);
            Assert.AreEqual("3:34", release.TrackList[1].Duration);

            Assert.AreEqual(3, Convert.ToInt32(release.TrackList[2].Position));
            Assert.AreEqual("The Change", release.TrackList[2].Title);
            Assert.AreEqual("3:42", release.TrackList[2].Duration);

            Assert.AreEqual(4, Convert.ToInt32(release.TrackList[3].Position));
            Assert.AreEqual("My Heart Is Broken", release.TrackList[3].Title);
            Assert.AreEqual("4:29", release.TrackList[3].Duration);

            Assert.AreEqual(5, Convert.ToInt32(release.TrackList[4].Position));
            Assert.AreEqual("The Other Side", release.TrackList[4].Title);
            Assert.AreEqual("4:05", release.TrackList[4].Duration);

            Assert.AreEqual(6, Convert.ToInt32(release.TrackList[5].Position));
            Assert.AreEqual("Erase This", release.TrackList[5].Title);
            Assert.AreEqual("3:55", release.TrackList[5].Duration);

            Assert.AreEqual(7, Convert.ToInt32(release.TrackList[6].Position));
            Assert.AreEqual("Lost In Paradise", release.TrackList[6].Title);
            Assert.AreEqual("4:43", release.TrackList[6].Duration);

            Assert.AreEqual(8, Convert.ToInt32(release.TrackList[7].Position));
            Assert.AreEqual("Sick", release.TrackList[7].Title);
            Assert.AreEqual("3:30", release.TrackList[7].Duration);

            Assert.AreEqual(9, Convert.ToInt32(release.TrackList[8].Position));
            Assert.AreEqual("End Of The Dream", release.TrackList[8].Title);
            Assert.AreEqual("3:49", release.TrackList[8].Duration);

            Assert.AreEqual(10, Convert.ToInt32(release.TrackList[9].Position));
            Assert.AreEqual("Oceans", release.TrackList[9].Title);
            Assert.AreEqual("3:38", release.TrackList[9].Duration);

            Assert.AreEqual(11, Convert.ToInt32(release.TrackList[10].Position));
            Assert.AreEqual("Never Go Back", release.TrackList[10].Title);
            Assert.AreEqual("4:27", release.TrackList[10].Duration);

            Assert.AreEqual(12, Convert.ToInt32(release.TrackList[11].Position));
            Assert.AreEqual("Swimming Home", release.TrackList[11].Title);
            Assert.AreEqual("3:44", release.TrackList[11].Duration);

            #endregion


        }
    }
}
