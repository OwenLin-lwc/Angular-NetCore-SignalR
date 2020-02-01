namespace signalr_hub.Models
{
    public class Message
    {
        public string Type { get; set; }
        public string UserGroup { get; set; }
        public string Payload { get; set; }
    }
}
