using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands;

public class AddCommentCommand : BaseCommand
{
    public string Comment { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
