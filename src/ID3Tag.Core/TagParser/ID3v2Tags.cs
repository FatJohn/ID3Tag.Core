namespace ID3Tag.Core.TagParser
{
    //I took all the informations about how ID3v2 works from this website: http://id3.org/id3v2.4.0-structure

    public class ID3v2Tags
    {
        //Frame Header MajorVersion 2
        public static readonly string TITLE_HEADER_V2 = "TT2";
        public static readonly string ARTIST_HEADER_V2 = "TP1";
        public static readonly string ALBUM_HEADER_V2 = "TAL";
        public static readonly string YEAR_HEADER_V2 = "TYE";
        public static readonly string TRACK_HEADER_V2 = "TRK";
        public static readonly string GENRE_HEADER_V2 = "TCO";
        public static readonly string COMMENT_HEADER_V2 = "COM";

        //Frame Header MajorVersion 3/4
        //URL to all frame headers: http://id3.org/id3v2.4.0-frames

        public static readonly string COMMENT_HEADER_V34 = "COMM";
        public static readonly string ALBUM_HEADER_V34 = "TALB";
        public static readonly string BPM_HEADER_V34 = "TBPM";
        public static readonly string GENRE_HEADER_V34 = "TCON";
        public static readonly string COMPOSER_HEADER_V34 = "TCON";
        public static readonly string COPYRIGHT_HEADER_V34 = "TCOP";
        public static readonly string TEXTWRITER_HEADER_V34 = "TEXT";
        public static readonly string TITLE_HEADER_V34 = "TIT2";
        public static readonly string LANGUAGE_HEADER_V34 = "TLAN";
        public static readonly string LENGTH_HEADER_V34 = "TLEN";
        public static readonly string ARTIST_HEADER_V34 = "TPE1";
        public static readonly string TRACK_HEADER_V34 = "TRCK";
        public static readonly string YEAR_HEADER_V34 = "TYER";
    }
}
