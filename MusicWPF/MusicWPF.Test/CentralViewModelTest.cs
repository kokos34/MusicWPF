using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
//using System.Data.Entity;

namespace MusicWPF.Test
{
    [TestFixture]
    public class CentralViewModelTest
    {
        [Test]
        public void GetArtists_Always_ExpectAtLeastOneArtist()
        {
            var CentralVM = new CentralViewModel();
            Assert.That(CentralVM.Items.Count, Is.AtLeast(1));
        }
    }
}
