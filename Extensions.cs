using System.IO;
public static class Extensions
{
    public static List<string>? TryFileReadLines(this string fileName)
    {
        try
        {
            return File.ReadAllLines(fileName).ToList();
        }
        catch(FileNotFoundException )
        {
            Console.WriteLine("File not found");
        }
        catch(DirectoryNotFoundException)
        {
            Console.WriteLine("Path Not found");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error occured while loading file {ex.Message} {ex.GetType()}");
        }
        return null;
    }
}
