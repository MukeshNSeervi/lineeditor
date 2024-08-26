using LineEditor.Interface;
using LineEditor.Services;
using static LineEditor.Utilities.AppConstants;

namespace LineEditor.Stratergy;

public class CommandStratergy
{
    private static Dictionary<Command,ICommand> _commandOPs = new()
    {
        {Command.list,new ListCommand()},
        {Command.quit,new QuitCommand()},
        {Command.del,new DeleteCommand()},
        {Command.ins,new InsertCommand()},
        {Command.save,new SaveCommand()}
    };
    static CommandStratergy()
    {

    }
    public static ICommand? GetAction(Command command)
    {
        try
        {
            return command switch
            {
                Command.list => _commandOPs[Command.list],
                Command.quit => _commandOPs[Command.quit],
                Command.del  => _commandOPs[Command.del],
                Command.ins  => _commandOPs[Command.ins],
                Command.save => _commandOPs[Command.save],
                _ => null
            };
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Exception in action {ex.Message}");
        }
        return null;
    }
}