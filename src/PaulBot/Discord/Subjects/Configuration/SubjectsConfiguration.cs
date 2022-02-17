namespace PaulBot.Discord.Subjects.Configuration;

public class SubjectsConfiguration
{
    public const string Section = "Subjects";
    
    /// <summary>
    /// ID of the text channels category, in which the text channel should be placed to
    /// </summary>
    public ulong TextChannelsCategoryId { get; set; }
}