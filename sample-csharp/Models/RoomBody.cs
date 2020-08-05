namespace EnableX.Models
{
    /// <summary>
    /// EnableX create room object model
    /// </summary>
    class RoomBody
    {
        // Name of Room or Topic of Meeting
        public string name { get; set; }
        // Room Owner ID of Reference
        public string owner_ref { get; set; }
        // Object with room Configuration Keys
        public RoomBodySettings settings { get; set; }
        // Object with SIP Configuration Keys
        public RoomBodySip sip { get; set; }
    }
}
