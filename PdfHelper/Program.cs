namespace PdfHelper;

public class Program
{
    static void Main(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            Console.WriteLine("Must receive path of target pdf file to extract its content.");
        }
    }
}