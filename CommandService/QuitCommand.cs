using LineEditor.Interface;
namespace LineEditor.Services;
public class QuitCommand : ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    } 
}