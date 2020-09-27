using ID3Tag.Core.ID3v2;
using ID3Tag.Core.TagParser;
using System.Collections.Generic;

namespace ID3Tag.Core
{
    public class ID3TagObject
    {
        public ID3Type Type { get; set; }

        /// <summary>
        /// Name of the album
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Name of the artist
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// The beats per minute of the track.
        /// Only ID3v2
        /// </summary>
        public string BeatsPerMinute { get; set; }

        /// <summary>
        /// <summary>
        /// A comment to the track
        /// </summary>
        public string Comment { get; set; }

        /// The name of the composer.
        /// </summary>
        public string Composer { get; set; }

        /// <summary>
        /// The Copyright message. e.g.: 2018 ©Cr1TiKa7
        /// Only ID3v2
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// The name of the Genre.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Contains the language of the text or sung in the audio.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Contains the length of the track in milliseconds.
        /// Only ID3v2.
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// Name of the textwriter.
        /// </summary>
        public string Textwriter { get; set; }

        /// <summary>
        /// The title of the track.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Total number of tracks on the album.
        /// </summary>
        public int TotalTracks { get; set; }

        /// <summary>
        /// The track number of the file.
        /// </summary>
        public int Track { get; set; }

        /// <summary>
        /// Release year of the album/track
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// ID3v1 Extendedtags only
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// ID3v1 Extendedtags only
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// ID3v1 Extendedtags only
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// ID3v2 Frames. ID3v2 only.
        /// </summary>
        public Dictionary<string, List<ID3v2Frame>> Frames { get; set; }
    }
}
