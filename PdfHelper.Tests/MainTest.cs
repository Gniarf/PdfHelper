using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfHelper.Tests
{
    public class MainTest
    {
        [Fact]
        public void TestMainArgsNull()
        {
            string[] args = new string[] { };
            Program.Main(args);
        }
        [Fact]
        public void TestMainArgsNotNull()
        {
            string[] args = new string[] { @"C:\Users\AN\proj\test\appconfig.json" };
            Program.Main(args);
        }
    }
}
