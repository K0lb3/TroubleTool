using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TroubleTool
{
    static class ExePatcher
    {
        static public void PatchExe(String src, String dst, byte[] pattern, byte[] replacement)
        {
            // read original game exe
            byte[] data = File.ReadAllBytes(src);
            // find all occurences
            List<int> entries = SearchBytePattern(pattern, data);
            // patch all found occurences
            foreach (int entry in entries)
                for (int i = 0; i < replacement.Length; i++)
                    data[entry + i] = replacement[i];
            File.WriteAllBytes(dst, data);
        }

        static public List<int> SearchBytePattern(byte[] pattern, byte[] bytes)
        {
            // https://stackoverflow.com/a/283596
            List<int> positions = new List<int>();
            int patternLength = pattern.Length;
            int totalLength = bytes.Length;
            byte firstMatchByte = pattern[0];
            for (int i = 0; i < totalLength; i++)
            {
                if (firstMatchByte == bytes[i] && totalLength - i >= patternLength)
                {
                    byte[] match = new byte[patternLength];
                    Array.Copy(bytes, i, match, 0, patternLength);
                    if (match.SequenceEqual<byte>(pattern))
                    {
                        positions.Add(i);
                        i += patternLength - 1;
                    }
                }
            }
            return positions;
        }
    }
}
