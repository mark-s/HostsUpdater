using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HostsUpdaterService.Core
{
    public class GetFile : IGetFiles
    {

        public async Task<string> GetFileContents(Uri uri)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(uri);
            }
        }

    }
}