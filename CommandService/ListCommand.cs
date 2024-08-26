using LineEditor.Interface;

namespace LineEditor.Services;
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