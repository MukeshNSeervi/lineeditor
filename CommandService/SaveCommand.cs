using LineEditor.Interface;

namespace LineEditor.Services;

public class SaveCommand : ICommand
{
    public void Execute()
    {
        FileService.GetInstance().Save();
        
    }
}