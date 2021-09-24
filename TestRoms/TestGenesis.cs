using NUnit.Framework;
using roms;

namespace TestRoms
{
    public class GenesisTests
    {

        string genesis_filename = "C:\\Git\\csharp\\umdtools\\TestRoms\\roms\\240pTestSuite-v15-dbelec.bin";
        long genesis_filesize = 262144;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLoadFile()
        {
            Assert.Pass();
        }

    }
}
