namespace signalr_hub
{
    public partial class ChatMessage
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Nickname { get; set; }
        public string Department { get; set; }
        public long? ChatGroup { get; set; }
        public string Message { get; set; }
        public string SendDate { get; set; }
    }
}
