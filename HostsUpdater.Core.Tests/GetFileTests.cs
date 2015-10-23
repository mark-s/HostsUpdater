using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace HostsUpdaterService.Core.Tests
{
    [TestFixture]
    public class GetFileTests
    {
        private IGetFiles _getter;

        private readonly string _testFilesBaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles");

        private const string TEST_URL = @"http://www.google.com/robots.txt";

        [SetUp]
        public void Setup()
        {
            _getter = new GetFile();
        }

        [Test]
        public void GetFileContents_GoodURI_OpensAndReadsOK()
        {
            var result = _getter.GetFileContents(new Uri(TEST_URL)).Result;

            result.Should().Be(File.ReadAllText(Path.Combine(_testFilesBaseDir, "robots.txt")));
        }


        [Test]
        public async void GetFileContents_GoodURI_ReadsAllLines()
        {
            var result = await _getter.GetFileContents(new Uri(TEST_URL));

            var lineCount = result.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

            lineCount.Should().Be((File.ReadAllLines(Path.Combine(_testFilesBaseDir, "robots.txt")).Length));
        }

    }
}
