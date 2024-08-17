namespace AdminApp.Models
{
    public class TrackInOrder
    {
        public Guid TrackId { get; set; }
        public Track? Track { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
