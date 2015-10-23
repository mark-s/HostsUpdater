using System;
using HostsUpdater.ConsoleApp.Properties;
using HostsUpdaterService.Core;

namespace HostsUpdater.ConsoleApp
{
    internal class Program
    {
        private static IGetFiles _getter;

        private static void Main(string[] args)
        {
            _getter = new GetFile();

            var uri = new Uri(Resources.BaseURI + Resources.ID);

            var hostsText =  _getter.GetFileContents(uri);

            // update the etc/hosts
            var updater = new WriteToHostsFile();
            updater.AppendToFile(Resources.HostsFile, Resources.Divider, hostsText.Result);


        }
    }

}
