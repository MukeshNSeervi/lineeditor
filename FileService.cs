namespace LineEditor.Services;

public class FileService
{
    private static Lazy<FileService> instance = new Lazy<FileService>(() => new FileService());
    private string _filePath = null!;
    private List<string>? _fileData;
    private FileService()
    {
        
    }
    public bool Initalize(string filePath)
    {
        try
        {
            _filePath = filePath;
            _fileData = filePath.TryFileReadLines()?.ToList();
            return _fileData?.Count > 0;
        }
        catch(Exception)
        {
            
        }
        return false;
        
    }
    public int? GetFileLength()
    {
        return _fileData?.Count;
    }
    public static FileService GetInstance()
    {
        return instance.Value;
    }
    internal List<string>? GetFileData()
    {
        return _fileData;
    }
    internal void RemoveAt(int index)
    {
        _fileData?.RemoveAt(index-1);
    }
    internal void InsertAt(int index,string data)
    {
        if(_fileData?.Count < index)
        {
            _fileData.Add(data);
        }
        else
        {
            _fileData?.Insert(index -1 ,data);
        }
    }
    internal void Save()
    {
        if(_fileData != null)
        {
            File.WriteAllLines(_filePath,_fileData.ToArray());
        }
        
    }
}