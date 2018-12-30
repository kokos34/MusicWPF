using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusicWPF.Tests
{
    [TestClass]
    public class MusicItemViewModelTest
    {
        [TestMethod]
        public void InitializeArtist_Always_HasAtLeastOneAlbum()
        {
            var musicItemVM = new MusicItemViewModel(ItemTypeEnum.Artist, "Test artist", 1);
            Assert.IsNotNull(musicItemVM.Children);
            Assert.IsTrue(musicItemVM.Children.Count > 0, "There are no albums for the artist");
        }

        [TestMethod]
        public void InitializeAlbum_Always_HasAtLeastOneSong()
        {
            var musicItemVM = new MusicItemViewModel(ItemTypeEnum.Album, "Test album", 1);
            Assert.IsNotNull(musicItemVM.Children);
            Assert.IsTrue(musicItemVM.Children.Count > 0, "There are no songs in this album");
        }

        [TestMethod]
        public void InitializeSong_Always_HasNoChildren()
        {
            var musicItemVM = new MusicItemViewModel(ItemTypeEnum.Song, "Test song", 1);
            Assert.IsNotNull(musicItemVM.Children);
            Assert.IsTrue(musicItemVM.Children.Count == 0, "There are child elements for song");
        }
    }
}
