public class ArgsHelper
{
    public static string? GetFileName(string[] args)
    {
        if(args.Length >= 1 && !string.IsNullOrEmpty(args[0]))
        {
            return args[0];
        }
        return null;
    }
}