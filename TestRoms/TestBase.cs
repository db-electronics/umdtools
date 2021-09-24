using NUnit.Framework;
using System;
using roms;

namespace TestRoms
{
    public class Tests
    {
        string genesis_filename = "C:\\Git\\csharp\\umdtools\\TestRoms\\roms\\240pTestSuite-v15-dbelec.bin";
        long genesis_filesize = 262144;
        UInt32 genesis_sega = 0x41474553;
        long genesis_tmss_addr = 0x100;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFileName()
        {
            GenesisRom genesisrom = new GenesisRom(genesis_filename);
            Assert.AreEqual(genesis_filename, genesisrom.Filename);
        }

        [Test]
        public void TestFileExists()
        {
            GenesisRom genesisrom = new GenesisRom(genesis_filename);
            Assert.True(genesisrom.FileExists);
        }

        [Test]
        public void TestFileNotExists()
        {
            GenesisRom genesisrom = new GenesisRom("paprium.bin");
            Assert.False(genesisrom.FileExists);
        }

        [Test]
        public void TestFileSize()
        {
            GenesisRom genesisrom = new GenesisRom(genesis_filename);
            Assert.AreEqual(genesis_filesize, genesisrom.FileSize);
        }

        [Test]
        public void TestLoadRomSize()
        {
            GenesisRom genesisrom = new GenesisRom(genesis_filename);
            genesisrom.LoadRom();

            Assert.AreEqual(genesis_filesize, genesisrom.RomSize);
            genesisrom.CloseRom();
        }

        [Test]
        public void TestReadRomValue()
        {
            GenesisRom genesisrom = new GenesisRom(genesis_filename);
            genesisrom.LoadRom();

            Assert.AreEqual(genesis_sega, genesisrom.ReadU32(genesis_tmss_addr));
            genesisrom.CloseRom();
        }

    }
}