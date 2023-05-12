using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfHelper.Models
{
    public class PdfClobal
    {
        public string Name { get; set; }= string.Empty;
        public List<PagePdf> pagePdfs {  get; set; } = new List<PagePdf>();
    }
}
