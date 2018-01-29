using System.Text;

namespace ComLibRegUtil.CRutil.Data
{
    public class Config
    {
        public readonly string LibraryOrigin;
        public readonly string LibraryDestination;
        public readonly string OutputFileName;

        public Config(string libraryOrigin, string libraryDestination, string outputFileName)
        {
            LibraryOrigin = libraryOrigin;
            LibraryDestination = libraryDestination;
            OutputFileName = outputFileName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("LibraryOrigin:");
            sb.AppendLine(LibraryOrigin);
            sb.Append("LibraryDestination:");
            sb.AppendLine(LibraryDestination);
            sb.Append("OutputFileName:");
            sb.Append(OutputFileName);
            return sb.ToString();
        }
    }
}