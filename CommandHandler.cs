using LineEditor.Interface;
using LineEditor.Stratergy;
using static LineEditor.Utilities.AppConstants;
public class CommandHandler 
{
    private static List<string>? currentArgs = new();
    /// <summary>
    /// A non-zero index based arguments
    /// </summary>
    /// <param name="index">Get index-1 position value</param>
    /// <returns></returns>
    public static string? GetNthArgument(int index)
    {
        try
        {
            return currentArgs?[index-1];
        }
        catch(ArgumentOutOfRangeException exe)
        {
            Console.WriteLine($"Argument Missing Excepiton {exe.Message}");
        }
        return null; 
    }
    public static string? GetAllFromNthIndex(int index)
    {
        try
        {   
            index = index -1;
            return string.Join(" ",currentArgs?[index..]!);
        }
        catch(Exception exe)
        {
            Console.WriteLine($"Argument Missing Excepiton {exe.Message}");
        }
        return null;
        
    }
    public void ProcessInputCommand(string? currentComman)
    {
        currentArgs = currentComman?.Split(' ').ToList();
        if(currentArgs != null && Enum.TryParse(currentArgs[0],out Command cmd))
        {
            ICommand? command = CommandStratergy.GetAction(cmd);
            command?.Execute();
        }
        else
        {
            Console.WriteLine("Invalid command");
        }
    }
    public void ProcessCommands(string[] commands)
    {
        int i=0;
        while(i < commands.Length)
        {
            string currentComman = commands[i];
            if(currentComman.Equals("quit",StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            ProcessInputCommand(currentComman);
            i++;
        }
    }
    public void RunEditor(string[] initialCommands)
    {
        if(initialCommands.Length > 0)
        {
            ProcessCommands(initialCommands);
            return;
        }
        while(true)
        {
            Console.Write(">> ");
            string? input = Console.ReadLine();
            ProcessInputCommand(input);
        }
    }
}