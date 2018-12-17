
using System.Collections.Generic;
using System.Linq;

namespace MusicWPF
{
    /// <summary>
    /// Static helper for EF 
    /// </summary>
    public static class MusicStructureHelper
    {
        static MusicDB db = null;

        public static void InitializeDB()
        {
            db = new MusicDB();
        }

        public static List<ARTISTS> GetArtists()
        {
            return db.ARTISTS.ToList();
        }

        public static List<ALBUMS> GetArtistsAlbums(int Artist_ID)
        {
            return db.ALBUMS.Where(x => x.ID_Artist == Artist_ID).ToList();
        }

        public static List<SONGS> GetAlbumsSongs(int Album_ID)
        {
            return db.SONGS.Where(x => x.ID_Album == Album_ID).ToList();
        }
    }
}
