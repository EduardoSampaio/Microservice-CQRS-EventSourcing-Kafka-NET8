namespace Post.Cmd.Api.Commands;

public class RemoveCommentCommand
{
    public Guid CommentId { get; set; }
    public string Username { get; set; }
}
