namespace ID3Tag.Core.ID3v2
{
    public class ID3v2ChapterTit
    {
        public string Id { get; set; }

        public int Size { get; set; }

        // 2 bytes
        public byte[] Flags { get; } = new byte[2];

        public byte Encoding { get; set; }

        public string Information { get; set; }
    }
}
