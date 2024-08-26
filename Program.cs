// See https://aka.ms/new-console-template for more information
using LineEditor.Services;
namespace LineEditor;

public class LineEditor
{
    public static void Main(string[] args)
    {
        string? fileName = ArgsHelper.GetFileName(args);
        if(fileName == null)
        {
            Console.WriteLine("Please Pass FileName");
            return ;
        }
        FileService fileService = FileService.GetInstance();
        if(fileService.Initalize(fileName))
        {
            new CommandHandler().RunEditor(args[1..]);
        }
    }
}



