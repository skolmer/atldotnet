﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATL.AudioData;

namespace ATL.test.IO.MetaData
{
    [TestClass]
    public class MIDI
    {
        string notEmptyFile = "MID/ROQ.MID";

        [TestMethod]
        public void TagIO_R_MIDI()
        {
            ConsoleLogger log = new ConsoleLogger();

            string location = TestUtils.GetResourceLocationRoot() + notEmptyFile;
            AudioDataManager theFile = new AudioDataManager( AudioData.AudioDataIOFactory.GetInstance().GetDataReader(location) );

            readExistingTagsOnFile(theFile);
        }
        

        private void readExistingTagsOnFile(AudioDataManager theFile, int nbPictures = 2)
        {
            Assert.IsTrue(theFile.ReadFromFile(null, true));

            Assert.IsNotNull(theFile.NativeTag);
            Assert.IsTrue(theFile.NativeTag.Exists);

            // Supported fields
            Assert.AreEqual("The Music Shoppe - Path to God/base/Midi of the Week/The Music Shoppe/http://cctr.umkc.edu/user/dschmid/midiweek.htm/816 373.1710", theFile.NativeTag.Comment);
        }
    }
}