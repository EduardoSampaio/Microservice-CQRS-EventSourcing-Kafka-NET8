

using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class PostCreatedEvent : BaseEvent
    {
        public PostCreatedEvent() : base(nameof(PostCreatedEvent))
        {
        }

        public string Author { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
    }
}