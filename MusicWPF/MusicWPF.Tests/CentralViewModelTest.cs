using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusicWPF.Tests
{
    /// <summary>
    /// Summary description for CentralViewModelTest
    /// </summary>
    [TestClass]
    public class CentralViewModelTest
    {
        private CentralViewModel centralVM;

        public CentralViewModelTest()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void InitializeCentralMVVM_Always_ReturnMoreThanOneArtist()
        {
            centralVM = new CentralViewModel();
            Assert.AreNotEqual(centralVM.Items.Count, 0);
        }

        public void RefreshClicked_Always_ReturnMoreThanOneArtist()
        {
            centralVM = new CentralViewModel();
            centralVM.RefreshClicked();
            Assert.AreNotEqual(centralVM.Items.Count, 0);
        }
    }
}
