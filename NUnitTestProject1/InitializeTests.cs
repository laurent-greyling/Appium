using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace NUnitTestProject1
{
    [SetUpFixture]
    public class InitializeTests
    {
        [OneTimeSetUp]
        public void TestMethod1()
        {
            // Start Windows Application Driver when not started
            if (!Process.GetProcessesByName("WinAppDriver").Any())
            {
                using (var process = Process.Start(GetWinAppDriverPath()))
                {
                    if (process == null)
                    {
                        throw new InvalidOperationException("Could not start windows application driver");
                    }
                }
            }
        }

        private string GetWinAppDriverPath()
        {
            return Environment.ExpandEnvironmentVariables(@"%ProgramFiles(x86)%\Windows Application Driver\WinAppDriver.exe");
        }
    }
}
