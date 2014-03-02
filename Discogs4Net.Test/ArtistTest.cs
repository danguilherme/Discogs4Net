using System;
using Discogs4Net.Data;
using Discogs4Net.Model.Artist;
using NUnit.Framework;
using System.Linq;
using Discogs4Net.Model.Enumerator;

namespace Discogs4Net.Test
{
    [TestFixture]
    public class ArtistTest
    {
        private DiscogsClient client;

        [TestFixtureSetUp]
        public void SetUp()
        {
            client = new DiscogsClient("uMusic/0.0.1");
        }

        [Test]
        public void GetArtist()
        {
            var artist = client.GetArtistById(163505);

            Assert.IsNotNull(artist);
            Assert.AreEqual("Evanescence", artist.Name);
            Assert.AreEqual("Evanescence is an American rock band founded in Little Rock, Arkansas in 1995 by singer/pianist Amy Lee and guitarist Ben Moody. After recording private albums, the band released their first full-length album, Fallen, on Wind-up Records in 2003. Fallen sold more than 17 million copies worldwide and helped the band win two Grammy Awards and seven nominations, as well as scoring No. 6 in CBS's \"Top Bestselling Albums of the Last 10 Years\" (2008). A year later, Evanescence released their first live album, Anywhere but Home, which sold more than one million copies worldwide. In 2006, the band released their second studio album, The Open Door, which sold more than five million copies.\r\n" +
                "The line-up of the group has changed several times: David Hodges leaving in 2002, co-founder Moody left in 2003 (mid-tour), bassist Will Boyd in 2006, followed by guitarist John LeCompt and drummer Rocky Gray in 2007. The last two changes led to a hiatus, with temporary band members contributing to tour performances. Billboard ranked Evanescence No. 71 on the Best Artists of the Decade chart.\r\n" +
                "Announced in June 2009, the newest line-up of the band eventually returned with Evanescence, their self-titled third studio album, released on October 11, 2011. It debuted at No. 1 on the Billboard 200 chart with 127,000 copies in sales. According to Examiner.com, the album also debuted at No. 1 on four other different Billboard charts; the Rock Albums, Digital Albums, Alternative Albums, and the Hard Rock Albums charts. The first single, \"What You Want\", was released on August 9, 2011. The second single, \"My Heart Is Broken\", was sent to radio stations in October 31, 2011. The band is currently on tour in promotion of their new album with other bands including The Pretty Reckless and Fair to Midland.\n", artist.Profile);
            Assert.AreEqual(8, artist.Members.Count, "Members count is incorrect: " + artist.Members.Count);

            #region Artist members test
            artist.Members.OrderBy(x => x.Name);

            Assert.AreEqual("Amy Lee", artist.Members[0].Name);
            Assert.AreEqual(true, artist.Members[0].IsActive);

            Assert.AreEqual("Ben Moody", artist.Members[1].Name);
            Assert.AreEqual(false, artist.Members[1].IsActive);

            Assert.AreEqual("David Hodges", artist.Members[2].Name);
            Assert.AreEqual(false, artist.Members[2].IsActive);

            Assert.AreEqual("John LeCompt", artist.Members[3].Name);
            Assert.AreEqual(false, artist.Members[3].IsActive);

            Assert.AreEqual("Rocky Gray", artist.Members[4].Name);
            Assert.AreEqual(false, artist.Members[4].IsActive);

            Assert.AreEqual("Terry Balsamo", artist.Members[5].Name);
            Assert.AreEqual(true, artist.Members[5].IsActive);

            Assert.AreEqual("Troy McLawhorn", artist.Members[6].Name);
            Assert.AreEqual(true, artist.Members[6].IsActive);

            Assert.AreEqual("Will Boyd", artist.Members[7].Name);
            Assert.AreEqual(false, artist.Members[7].IsActive);
            #endregion

            Assert.AreEqual(4, artist.ExternalUrls.Count, "URLs count is incorrect: " + artist.ExternalUrls.Count);

            #region External urls test

            artist.ExternalUrls.OrderBy(x => x.Url);

            Assert.AreEqual("http://www.evanescence.com", artist.ExternalUrls[0].Url);
            Assert.AreEqual(ExternalUrlTypes.ArtistWebsite, artist.ExternalUrls[0].Type);

            Assert.AreEqual("http://www.myspace.com/evanescence", artist.ExternalUrls[1].Url);
            Assert.AreEqual(ExternalUrlTypes.MySpace, artist.ExternalUrls[1].Type);

            Assert.AreEqual("http://www.youtube.com/evanescencevideo", artist.ExternalUrls[2].Url);
            Assert.AreEqual(ExternalUrlTypes.YouTube, artist.ExternalUrls[2].Type);

            Assert.AreEqual("http://twitter.com/evanescence", artist.ExternalUrls[3].Url);
            Assert.AreEqual(ExternalUrlTypes.Twitter, artist.ExternalUrls[3].Type);
            #endregion

            Assert.AreNotEqual(0, artist.Images.Count, "There's no images: " + artist.Images.Count);
        }

        [Test]
        public void SearchArtist()
        {
            var artists = client.SearchArtist("Evanescence");

            Assert.IsNotNull(artists);
            Assert.AreEqual(10, artists.Count);
        }

        [Test]
        public void SearchArtistWithPaging()
        {
            var artists = client.SearchArtist("Evanescence", 5);

            Assert.IsNotNull(artists);
            Assert.AreEqual(5, artists.Count);
        }

        [Test]
        public void ArtistClear()
        {
            var artist = client.GetArtistById(2930569);

            Assert.IsNotNull(artist);
            Assert.AreEqual("The Who", artist.Name);
        }

        [Test]
        public void ArtistProfileFix()
        {
            var artist = client.GetArtistById(8760);

            Assert.IsNotNull(artist);
            Assert.AreEqual("Madonna", artist.Name);
            Assert.IsNotNull(artist.Profile);
        }
    }
}
