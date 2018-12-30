using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MusicWPF.Tests
{
    [TestClass]
    public class AddItemViewModelTest
    {
        AddSongViewModel sut;
        
        static ALBUMS selectedAlbum { get; set; }

        public AddItemViewModelTest()
        {
            MusicStructureHelper.InitializeDB();
            sut = new AddSongViewModel();
        }

        #region contrustor tests

        /// <summary>
        /// Checks if AddItemCommand has been 
        /// successfully initialized
        /// </summary>
        [TestMethod]
        public void InitializeAddSong_Always_HasCommandInitialized()
        {
            Assert.IsNotNull(sut.AddItemCommand);
            Assert.IsInstanceOfType(sut.AddItemCommand, typeof(RelayCommand));
        }

        [TestMethod]
        public void InitializeAddSong_Always_HasAtLeastOneArtist()
        {
            Assert.IsTrue(sut.ParentArtists.Count > 0, "No artists in database");
        }

        [TestMethod]
        public void InitializeAddSong_Always_AlbumsAreInitialized()
        {
            Assert.IsNotNull(sut.ParentAlbums);
        }

        #endregion

        [TestMethod]
        public void CallAddItem_WithSelectedAlbumSet_SongWasAdded()
        {
            sut.SelectedArtist = sut.ParentArtists[0];
            selectedAlbum = sut.SelectedAlbum = sut.ParentAlbums[0];
            sut.SongName = "TestSong";

            int songsCounter = sut.SelectedAlbum.SONGS.Count;
            
            sut.AddItemCommand.Execute(null);
            Assert.AreNotEqual(sut.SelectedAlbum.SONGS.Count, songsCounter);
        }

        /// <summary>
        /// Removes unnecessary song added in <see cref="CallAddItem_WithSelectedAlbumSet_SongWasAdded"/>
        /// </summary>
        [ClassCleanup]
        public static void CleanUp()
        {
            MusicStructureHelper.RemoveSong(selectedAlbum.ID, "TestSong");
        }
    }
}
