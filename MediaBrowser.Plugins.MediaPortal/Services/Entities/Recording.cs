﻿using System;

namespace MediaBrowser.Plugins.MediaPortal.Services.Entities
{
    public class Recording
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string Description { get; set; }
        public DateTime EndTime { get; set; }
        public string EpisodeName { get; set; }
        public string EpisodeNum { get; set; }
        public string EpisodeNumber { get; set; }
        public string EpisodePart { get; set; }
        public string FileName { get; set; }
        public string Genre { get; set; }
        public string Id { get; set; }
        public bool IsChanged { get; set; }
        public bool IsManual { get; set; }
        public bool IsRecording { get; set; }
        public int KeepUntil { get; set; }
        public DateTime KeepUntilDate { get; set; }
        public int ScheduleId { get; set; }
        public string SeriesNum { get; set; }
        public bool ShouldBeDeleted { get; set; }
        public DateTime StartTime { get; set; }
        public int StopTime { get; set; }
        public int TimesWatched { get; set; }
        public string Title { get; set; }
    }
}