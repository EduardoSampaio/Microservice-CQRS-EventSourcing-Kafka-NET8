using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands;

public class EditCommentCommand: BaseCommand
{
    public Guid CommentId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
