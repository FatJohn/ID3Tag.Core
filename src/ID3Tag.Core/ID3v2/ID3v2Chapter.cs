namespace ID3Tag.Core.ID3v2
{
    public class ID3v2Chapter
    {
        public string Id { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int StartOffset { get; set; }

        public int EndOffset { get; set; }

        public ID3v2ChapterTit Tit2 { get; set; }

        public ID3v2ChapterTit Tit3 { get; set; }
    }
}
