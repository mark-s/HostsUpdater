using System;
using System.IO;
using System.Linq;

namespace HostsUpdaterService.Core
{
    public class WriteToHostsFile : IWriteFile
    {
        public void AppendToFile(string fileNameToAppendTo, string divider, string textToAppend)
        {
            // get the existing hosts file as lines
            var lines = File.ReadAllLines(fileNameToAppendTo);

            // split it at the divider
            var topsection = lines.TakeWhile(line => line != divider).ToList();

            // add the divider back in
            topsection.Add(divider);

            // join the upper and new bottom in the style:
            // <EXISTING TEST>
            //     -- divider--
            // <textToAppend>

            var completeText = topsection.Aggregate((c, n) => c += Environment.NewLine + n) + Environment.NewLine + textToAppend;

            File.WriteAllText(fileNameToAppendTo, completeText + Environment.NewLine);
        }
    }
}