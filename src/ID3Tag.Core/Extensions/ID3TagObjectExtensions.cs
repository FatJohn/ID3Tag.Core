using ID3Tag.Core.ID3v2;
using System.Collections.Generic;
using System.Text;

namespace ID3Tag.Core
{
    public static class ID3TagObjectExtensions
    {
        /// <summary>
        /// Allows you to get the content of a frame by yourself
        /// </summary>
        /// <param name="frameKey">Framekeys: http://id3.org/id3v2.4.0-frames </param>
        /// <param name="useEncoding">If the framekey has an encoding set this value to true. Default value is false</param>
        /// <returns></returns>

        public static string GetText(this ID3TagObject id3TagObject, string frameKey, bool useEncoding)
        {
            if (id3TagObject.Frames == null)
            {
                return string.Empty;
            }

            if (!id3TagObject.Frames.ContainsKey(frameKey))
            {
                return string.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            var frameList = id3TagObject.Frames[frameKey];
            foreach (var frame in frameList)
            {
                stringBuilder.AppendLine(frame.GetText(useEncoding));
            }

            return stringBuilder.ToString();
        }

        public static List<ID3v2Chapter> GetChapters(this ID3TagObject id3TagObject)
        {
            if (id3TagObject.Frames == null)
            {
                return null;
            }

            const string chapKey = "CHAP";
            if (!id3TagObject.Frames.ContainsKey(chapKey))
            {
                return null;
            }

            var result = new List<ID3v2Chapter>();
            var frameList = id3TagObject.Frames[chapKey];
            foreach (var frame in frameList)
            {
                var chapter = frame.GetChapter();
                if (chapter != null)
                {
                    result.Add(chapter);
                }
            }

            return result;
        }
    }
}
