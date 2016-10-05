﻿using System.Collections.Generic;

namespace MediaBrowser.Plugins.MediaPortal.Services.Entities
{
    public class WebVideoStream
    {
        public string Codec { get; set; }
        public decimal DisplayAspectRatio { get; set; }
        public string DisplayAspectRatioString { get; set; }
        public bool Interlaced { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ID { get; set; }
        public int Index { get; set; }
        public int? StreamOrder { get; set; }
    }

    public class WebAudioStream
    {
        public string Language { get; set; }
        public string LanguageFull { get; set; }
        public int Channels { get; set; }
        public string Codec { get; set; }
        public string Title { get; set; }
        public int ID { get; set; }
        public int Index { get; set; }
        public int? StreamOrder { get; set; }
    }

    public class WebSubtitleStream
    {
        public string Codec { get; set; }
        public string Language { get; set; }
        public string LanguageFull { get; set; }
        public int ID { get; set; }
        public int Index { get; set; }
        public int? StreamOrder { get; set; }
        public string Filename { get; set; }
    }

    public class WebMediaInfo
    {
        // general properties
        public long Duration { get; set; } // in milliseconds
        public string Container { get; set; }

        // codecs
        public List<WebVideoStream> VideoStreams { get; set; }
        public List<WebAudioStream> AudioStreams { get; set; }
        public List<WebSubtitleStream> SubtitleStreams { get; set; }
    }
}
