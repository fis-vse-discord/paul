using Discord.Interactions;
using PaulBot.Discord.Subjects.Contracts;

namespace PaulBot.Discord.Subjects;

public class SubjectsInteractionsModule : InteractionModuleBase<SocketInteractionContext>
{
    private readonly ISubjectsService _service;

    public SubjectsInteractionsModule(ISubjectsService service)
    {
        _service = service;
    }
}