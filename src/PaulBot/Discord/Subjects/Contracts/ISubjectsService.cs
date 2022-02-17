using PaulBot.Discord.Subjects.Models;

namespace PaulBot.Discord.Subjects.Contracts;

public interface ISubjectsService
{
    /// <summary>
    /// Create a new subjects with managed role and text channel with setup permissions
    /// </summary>
    /// <param name="code">Code of the subject</param>
    /// <param name="name">Name of the subject</param>
    /// <returns></returns>
    Task<Subject> CreateSubject(string code, string name);

    /// <summary>
    /// Delete a subject and associated role (+ channel if specified) 
    /// </summary>
    /// <param name="code">Code of the subject that should be deleted</param>
    /// <param name="deleteTextChannel">Whether the associated text channel should be deleted as well</param>
    /// <returns></returns>
    Task<Subject> DeleteSubject(string code, bool deleteTextChannel = false);
}