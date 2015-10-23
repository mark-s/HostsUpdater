using System;
using System.Threading.Tasks;

namespace HostsUpdaterService.Core
{
    public interface IGetFiles
    {

        Task<string> GetFileContents(Uri uri);
    }
}
