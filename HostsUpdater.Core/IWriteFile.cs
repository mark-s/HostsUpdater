namespace HostsUpdaterService.Core
{
    public interface IWriteFile
    {
        void AppendToFile(string fileNameToAppendTo, string appendAfter, string textToAppend);
    }
}