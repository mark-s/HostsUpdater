using System;
using System.IO;
using HostsUpdater.ConsoleApp.Properties;
using HostsUpdaterService.Core;

namespace HostsUpdater.ConsoleApp
{
    internal class Program
    {
        private static IGetFiles _getter;

        private static void Main(string[] args)
        {
            
            var hostsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");

            _getter = new GetFile();

            var uri = new Uri(Resources.BaseURI + Resources.ID);

            var hostsText =  _getter.GetFileContents(uri);

            // update the etc/hosts
            var updater = new WriteToHostsFile();
            updater.AppendToFile(hostsFile, Resources.Divider, hostsText.Result);


        }
    }

}
