namespace AdminApp.Models
{
    public class Order
    {   
        public Guid Id { get; set; }
        public Guid userId { get; set; }
        public User Owner { get; set; }
        public IEnumerable<TrackInOrder> TracksInOrders { get; set; }
    }
}
