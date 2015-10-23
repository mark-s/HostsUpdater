using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace HostsUpdaterService.Core.Tests
{
    [TestFixture]
    public class WriteToHostsFileTests
    {

        private readonly string _testFilesBaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles");
        private IWriteFile _writer;

        const string BASE_HOSTS = @"#  Copyright  (c)  1993-2009  Microsoft  Corp.
#
#  This  is  a  sample  HOSTS  file  used  by  Microsoft  TCP/IP  for  Windows.
#
#  This  file  contains  the  mappings  of  IP  addresses  to  host  names.  Each
#  entry  should  be  kept  on  an  individual  line.  The  IP  address  should
#  be  placed  in  the  first  column  followed  by  the  corresponding  host  name.
#  The  IP  address  and  the  host  name  should  be  separated  by  at  least  one
#  space.
#
#  Additionally,  comments  (such  as  these)  may  be  inserted  on  individual
#  lines  or  following  the  machine  name  denoted  by  a  '#'  symbol.
#
#  For  example:
#
#            102.54.94.97          rhino.acme.com                    #  source  server
#              38.25.63.10          x.acme.com                            #  x  client  host
#  localhost  name  resolution  is  handled  within  DNS  itself.
#	127.0.0.1              localhost
#	::1                          localhost

127.0.0.1    localhost
54.249.10.88    127.0.0.1

### DNS PROXY HOSTS BELOW THIS LINE ###
";

        [SetUp]
        public void Setup()
        {
            RefreshTestFileContents();

            _writer = new WriteToHostsFile();
        }


        [Test]
        public void AppendToFile_GoodValues_JoinsUpOk()
        {
            var textToAppend = File.ReadAllText(Path.Combine(_testFilesBaseDir, "TestResponseText.txt"));

            _writer.AppendToFile(Path.Combine(_testFilesBaseDir, "TEST.txt"), "### DNS PROXY HOSTS BELOW THIS LINE ###", textToAppend);

            var resultTest = File.ReadAllText(Path.Combine(_testFilesBaseDir, "TEST.txt"));
            var addedDnsHosts = File.ReadAllText(Path.Combine(_testFilesBaseDir, "TestResponseText.txt"));

            resultTest.Should().Be(BASE_HOSTS + addedDnsHosts + Environment.NewLine);
        }


        private void RefreshTestFileContents()
        {
            var fileToOverrite = Path.Combine(_testFilesBaseDir, "TEST.txt");

            File.WriteAllText(fileToOverrite, BASE_HOSTS);

        }

    }
}
