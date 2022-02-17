using PaulBot.Discord.Subjects.Contracts;
using PaulBot.Discord.Subjects.Models;

namespace PaulBot.Discord.Subjects.Services;

public class SubjectsService : ISubjectsService
{
    public Task<Subject> CreateSubject(string code, string name)
    {
        throw new NotImplementedException();
    }

    public Task<Subject> DeleteSubject(string code, bool deleteTextChannel = false)
    {
        throw new NotImplementedException();
    }
}