using CSharpFunctionalExtensions;

namespace cqrssssinside.domain.appServices
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}