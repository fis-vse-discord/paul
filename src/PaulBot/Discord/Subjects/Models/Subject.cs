namespace PaulBot.Discord.Subjects.Models;

public class Subject
{
    public Subject(string code, string name)
    {
        Code = code;
        Name = name;
    }
    
    public int Id { get; set; }

    /// <summary>
    /// Code of the subject (eg. 4IZ101)
    /// </summary>
    public string Code { get; init; }

    /// <summary>
    /// Name of the subject (eg. "Programming")
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// ID of the mapped Discord role
    /// </summary>
    public ulong RoleId { get; set; }

    /// <summary>
    /// ID of the mapped Discord text channel
    /// </summary>
    public ulong ChannelId { get; set; }
}