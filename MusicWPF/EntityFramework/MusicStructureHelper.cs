

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

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

        public static void AddSong(int Album_ID, string name)
        {
            SONGS newSong = new SONGS();
            newSong.ID_Album = Album_ID;
            newSong.Name = name;

            try
            {
                db.SONGS.Add(new SONGS() { ID_Album = Album_ID, Name = name });
                db.SaveChanges();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("Failed to add new song", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(ex.Message, "Error");
            }            
        }
    }
}
