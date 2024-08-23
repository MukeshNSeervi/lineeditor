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
        return command switch
        {
            Command.list => _commandOPs[Command.list],
            Command.quit => _commandOPs[Command.quit],
            Command.del => _commandOPs[Command.del],
            Command.ins => _commandOPs[Command.ins],
            Command.save => _commandOPs[Command.save],
            _ => null
        };
    }
}
public class QuitCommand : ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    } 
}
public class ListCommand : ICommand
{
    public void Execute()
    {
        List<string>? fileData = FileService.GetInstance().GetFileData();
        for(int i=1;i<=fileData?.Count;i++)
        {
            Console.WriteLine($"{i} : {fileData[i-1]}");
        }
    }
}
public class DeleteCommand : ICommand
{
    public void Execute()
    {
        
        if(!int.TryParse(CommandHandler.GetNthArgument(2),out int index))
        {
            Console.WriteLine("Please enter a line number to delete");
            return;
        }
        if(index > FileService.GetInstance().GetFileLength())
        {
            Console.WriteLine("Please enter a valid line number");
            return;
        }
        FileService.GetInstance().RemoveAt(index);
    }
}
public class InsertCommand : ICommand
{
    public void Execute()
    {
        if(!int.TryParse(CommandHandler.GetNthArgument(2),out int index))
        {
            Console.WriteLine("Invalid insert index");
            return ;
        }
        if(index > (FileService.GetInstance().GetFileLength() + 1))
        {
            index++;
        }
        string? data = CommandHandler.GetAllFromNthIndex(3);
        if(data == null)
        {
            Console.WriteLine("Invalid data to insert");
            return;
        }
        FileService.GetInstance().InsertAt(index,data);
    }
}
public class SaveCommand : ICommand
{
    public void Execute()
    {
        FileService.GetInstance().Save();
        
    }
}