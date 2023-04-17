using PdfHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfHelper.Tests
{
    public class CustomDeserializePath : DeserializePath
    {
        public CustomDeserializePath(IEnumerable<FilePath> file) : base(file)
        {
        }

        public IEnumerable<FilePath> GetFile()
        {
            return File;
        }
    }
}
