using LineEditor.Interface;

namespace LineEditor.Services;
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