using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands;

public class NewPostCommand : BaseCommand
{
    public string Author { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
