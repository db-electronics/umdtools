using System;
using System.IO;

namespace roms
{
    public abstract class Rom
    {
        public string Filename { get; set; }
        public bool FileExists { get; set; }
        public long FileSize { get; set; }
        public long RomSize { get; set; }

        public byte[] RomBytes;

        protected BinaryReader RomReader;

        public Rom(string file)
        {
            Filename = file;

            // check if file exists, we could be creating a new file
            if (!File.Exists(file))
            {
                FileExists = false;
                FileSize = 0;
            }
            else
            {
                FileExists = true;
                FileInfo fi = new FileInfo(file);
                FileSize = fi.Length;
            }
        }

        ~Rom()
        {
            RomReader.Close();
            RomReader.Dispose();
        }


        public void LoadRom()
        {
            if (File.Exists(Filename))
            {
                RomReader = new BinaryReader(File.Open(Filename, FileMode.Open));
                RomSize = RomReader.BaseStream.Length;
            }
            else
            {
                RomSize = 0;
                FileExists = false;
            }
        }
        

        public void CloseRom()
        {
            RomReader.Close();
        }

        public UInt32 ReadU32(long address)
        {
            if(address <= RomReader.BaseStream.Length)
            {
                RomReader.BaseStream.Position = address;
                return RomReader.ReadUInt32();
            }
            else
            {
                return 0;
            }
        }

    }
}
