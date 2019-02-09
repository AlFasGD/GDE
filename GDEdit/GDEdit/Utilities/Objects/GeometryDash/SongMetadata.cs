﻿using GDEdit.Utilities.Functions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace GDEdit.Utilities.Objects.GeometryDash
{
    /// <summary>Contains the metadata of a song.</summary>
    public class SongMetadata
    {
        /// <summary>The ID of the song.</summary>
        public int ID { get; set; }
        /// <summary>The title of the song.</summary>
        public string Title { get; set; }
        /// <summary>The artist of the song.</summary>
        public string Artist { get; set; }
        /// <summary>The size of the song in MB.</summary>
        public double SongSizeMB { get; set; }
        /// <summary>The URL to the song on Newgrounds.</summary>
        public string URL => $"https://www.newgrounds.com/audio/listen/{ID}";
        /// <summary>The download link of the song.</summary>
        public string DownloadLink { get; set; }

        /// <summary>Initializes a new instance of the <seealso cref="SongMetadata"/> class.</summary>
        public SongMetadata() { }

        /// <summary>Parses the data into a <seealso cref="SongMetadata"/> instance.</summary>
        /// <param name="data">The data to parse into a <seealso cref="SongMetadata"/> instance.</param>
        public static SongMetadata Parse(string data)
        {
            var s = new SongMetadata();
            s.GetSongMetadataInformation(data);
            return s;
        }

        private void GetSongMetadataParameterInformation(string key, string value, string valueType)
        {
            switch (key)
            {
                case "1": // Song ID
                    ID = ToInt32(value);
                    break;
                case "2": // Title
                    Title = value;
                    break;
                case "4": // Artist
                    Artist = value;
                    break;
                case "5": // Creator Name
                    SongSizeMB = ToInt32(value);
                    break;
                case "10": // Download Link
                    DownloadLink = value;
                    break;
                case "3": // ?
                case "7": // ?
                case "9": // ?
                    break;
                default: // Not something we care about
                    break;
            }
        }
        private void GetSongMetadataInformation(string data)
        {
            string startKeyString = "<k>";
            string endKeyString = "</k><";
            int IDStart;
            int IDEnd;
            int valueTypeStart;
            int valueTypeEnd;
            int valueStart;
            int valueEnd;
            string valueType;
            string value;
            for (int i = 0; i < data.Length;)
            {
                IDStart = data.Find(startKeyString, i, data.Length) + startKeyString.Length;
                if (IDStart <= startKeyString.Length)
                    break;
                IDEnd = data.Find(endKeyString, IDStart, data.Length);
                valueTypeStart = IDEnd + endKeyString.Length;
                valueTypeEnd = data.Find(">", valueTypeStart, data.Length);
                valueType = data.Substring(valueTypeStart, valueTypeEnd - valueTypeStart);
                valueStart = valueTypeEnd + 1;
                valueEnd = valueType[valueType.Length - 1] != '/' ? data.Find($"</{valueType}>", valueStart, data.Length) : valueStart;
                value = data.Substring(valueStart, valueEnd - valueStart);
                string s = data.Substring(IDStart, IDEnd - IDStart);
                GetSongMetadataParameterInformation(s, value, valueType);
                i = valueEnd;
            }
        }
    }
}
