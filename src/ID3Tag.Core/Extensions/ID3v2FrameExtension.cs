using System;
using System.IO;
using System.Text;

namespace ID3Tag.Core.ID3v2
{
    public static class ID3v2FrameExtension
    {
        public static string GetText(this ID3v2Frame frame, bool useEncoding)
        {
            int i = 0;
            Encoding charEncoding = Encoding.Unicode;
            if (!useEncoding)
            {
                i = 3;
            }

            StringBuilder stringBuilder = new StringBuilder();
            byte encoding;

            for (int j = i; j < frame.FrameContent.Length; j++)
            {
                //If byte value is 0 skip it else you get string like 'T E S T ' instea of 'TEST'
                if (frame.FrameContent[j] == 0)
                {
                    continue;
                }

                if (j == 0)
                {
                    encoding = frame.FrameContent[j];
                }
                else
                {
                    stringBuilder.Append(Convert.ToChar(frame.FrameContent[j]));
                }
            }
            return stringBuilder.ToString();
        }

        public static ID3v2Chapter GetChapter(this ID3v2Frame frame)
        {
            var bytes = new byte[4];
            var startIndex = 0;
            var endIndex = 0;
            var encoding = GetEncoding(0);
            byte[] endingBytes;

            // 讀取 Chapter
            var chapter = new ID3v2Chapter();
            endingBytes = GetEndingBytes(0);
            endIndex = FindIndex(frame.FrameContent, startIndex, endingBytes);
            chapter.Id = encoding.GetString(frame.FrameContent, 0, endIndex - startIndex);

            startIndex = endIndex + endingBytes.Length;

            Buffer.BlockCopy(frame.FrameContent, startIndex, bytes, 0, bytes.Length);
            startIndex += bytes.Length;
            Array.Reverse(bytes);
            chapter.StartTime = BitConverter.ToInt32(bytes, 0);

            Buffer.BlockCopy(frame.FrameContent, startIndex, bytes, 0, bytes.Length);
            startIndex += bytes.Length;
            Array.Reverse(bytes);
            chapter.EndTime = BitConverter.ToInt32(bytes, 0);

            Buffer.BlockCopy(frame.FrameContent, startIndex, bytes, 0, bytes.Length);
            startIndex += bytes.Length;
            Array.Reverse(bytes);
            chapter.StartOffset = BitConverter.ToInt32(bytes, 0);

            Buffer.BlockCopy(frame.FrameContent, startIndex, bytes, 0, bytes.Length);
            startIndex += bytes.Length;
            Array.Reverse(bytes);
            chapter.EndOffset = BitConverter.ToInt32(bytes, 0);

            if (startIndex >= frame.FrameContent.Length)
            {
                return chapter;
            }

            // 讀取 Tit2
            var tit2 = new ID3v2ChapterTit();

            Buffer.BlockCopy(frame.FrameContent, startIndex, bytes, 0, bytes.Length);
            startIndex += bytes.Length;
            tit2.Id = encoding.GetString(bytes);

            Buffer.BlockCopy(frame.FrameContent, startIndex, bytes, 0, bytes.Length);
            startIndex += bytes.Length;
            Array.Reverse(bytes);
            tit2.Size = BitConverter.ToInt32(bytes, 0);

            Buffer.BlockCopy(frame.FrameContent, startIndex, tit2.Flags, 0, tit2.Flags.Length);
            startIndex += tit2.Flags.Length;

            tit2.Encoding = frame.FrameContent[startIndex];
            startIndex += 1;

            encoding = GetEncoding(tit2.Encoding);
            endingBytes = GetEndingBytes(tit2.Encoding);
            endIndex = FindIndex(frame.FrameContent, startIndex, endingBytes);
            tit2.Information = encoding.GetString(frame.FrameContent, startIndex, endIndex - startIndex);

            startIndex = endIndex + endingBytes.Length;

            chapter.Tit2 = tit2;

            if (startIndex >= frame.FrameContent.Length)
            {
                return chapter;
            }

            // 讀取 Tit3
            var tit3 = new ID3v2ChapterTit();

            Buffer.BlockCopy(frame.FrameContent, startIndex, bytes, 0, bytes.Length);
            startIndex += bytes.Length;
            tit3.Id = encoding.GetString(bytes);

            Buffer.BlockCopy(frame.FrameContent, startIndex, bytes, 0, bytes.Length);
            startIndex += bytes.Length;
            Array.Reverse(bytes);
            tit3.Size = BitConverter.ToInt32(bytes, 0);

            Buffer.BlockCopy(frame.FrameContent, startIndex, tit2.Flags, 0, tit2.Flags.Length);
            startIndex += tit2.Flags.Length;

            tit3.Encoding = frame.FrameContent[startIndex];
            startIndex += 1;

            encoding = GetEncoding(tit2.Encoding);
            endingBytes = GetEndingBytes(tit2.Encoding);
            endIndex = FindIndex(frame.FrameContent, startIndex, endingBytes);
            tit3.Information = encoding.GetString(frame.FrameContent, startIndex, endIndex - startIndex);

            chapter.Tit3 = tit3;

            return chapter;
        }

        private static int FindIndex(byte[] haystack, int startIndex, byte[] needle)
        {
            for (int i = startIndex; i <= haystack.Length - needle.Length; i++)
            {
                if (Match(haystack, needle, i))
                {
                    return i;
                }
            }
            return -1;
        }

        private static bool Match(byte[] haystack, byte[] needle, int start)
        {
            if (needle.Length + start > haystack.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < needle.Length; i++)
                {
                    if (needle[i] != haystack[i + start])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private static Encoding GetEncoding(int encodingType)
        {
            if (encodingType == 0)
            {
                return Encoding.GetEncoding("iso-8859-1");
            }

            if (encodingType == 1)
            {
                return Encoding.Unicode;
            }

            return null;
        }

        internal static byte[] GetEndingBytes(int encodingType)
        {
            return new byte[GetSplitterLength(encodingType)];
        }

        private static int GetSplitterLength(int encodingType)
        {
            if (encodingType == 0)
            {
                return 1;
            }

            if (encodingType == 1)
            {
                return 2;
            }
            
            return -1;
        }
    }
}
