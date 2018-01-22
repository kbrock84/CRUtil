using System.Text;

namespace ComLibRegUtil
{
    public class ConfigData
    {
        public readonly string LibraryOrigin;
        public readonly string LibraryDestination;
        public readonly string OutputFileName;

        public ConfigData(string libraryOrigin, string libraryDestination, string outputFileName)
        {
            this.LibraryOrigin = libraryOrigin;
            this.LibraryDestination = libraryDestination;
            this.OutputFileName = outputFileName;
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