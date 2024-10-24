namespace TwitterApi.Entity
{
    public class Feedback
    {
        public enum FeedbackType { Like, Dislike }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime Date {  get; set; }
        public FeedbackType Type { get; set; }
    }
}
