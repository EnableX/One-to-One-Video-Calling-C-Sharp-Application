using System;
namespace EnableX.Models
{
    /// <summary>
    /// EnableX create room settings object model
    /// </summary>
    class RoomBodySettings
    {
        // Description / metadata of the Room 
        public string description { get; set; }
        // Quality of the video in EnableX session.
        public string quality { get; set; }
        // Type of EnableX Room
        public string mode { get; set; }
        // Total Number of Participants allowed in the Room
        public string participants { get; set; }
        // Total Duration of Room
        public string duration { get; set; }
        // room is a permanent room or scheduled for a specific duration
        public bool scheduled { get; set; }
        // If auto-recording is enabled or disabled
        public bool auto_recording { get; set; }
        // Should update if active talker
        public bool active_talker { get; set; }
        // whether wait for moderator to join a session
        public bool wait_moderator { get; set; }
        // whether room is adhoc or scheduled
        public bool adhoc { get; set; }
    }
}
