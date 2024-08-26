using LineEditor.Interface;
namespace LineEditor.Services;

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