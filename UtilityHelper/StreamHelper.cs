﻿using System.IO;

namespace Utility
{
    public static class StreamHelper
    {
        public static MemoryStream ToMemoryStream(this string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static void OverWriteFile(this Stream stream, string path)
        {
            using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileStream.SetLength(0);
            stream.CopyTo(fileStream);
        }

        public static void OverWriteFile(this FileInfo fileInfo, string contents)
        {
            using FileStream fileStream = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using MemoryStream memoryStream = ToMemoryStream(contents);
            fileStream.SetLength(0);
            memoryStream.CopyTo(fileStream);
        }

        public static FileStream ToFileStream(this string path)
        {
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return stream;
        }   
        
        public static string ToString(this Stream stream)
        {
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text;
        }
    }
}