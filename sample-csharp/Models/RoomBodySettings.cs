using System;
namespace EnableX.Models
{
    /// <summary>
    /// EnableX create room settings object model
    /// </summary>
    class RoomBodySettings
    {
        // room is a permanent room or scheduled for a specific duration
        public bool scheduled { get; set; }
        // whether room is adhoc or scheduled
        public bool adhoc { get; set; }
        // Total Number of moderators allowed in the Room
        public string moderators { get; set; }
        // Total Number of Participants allowed in the Room
        public string participants { get; set; }
        // Total Duration of Room
        public string duration { get; set; }
        // Quality of the video in EnableX session.
        public string quality { get; set; }
        // If auto-recording is enabled or disabled
        public bool auto_recording { get; set; }

    }
}