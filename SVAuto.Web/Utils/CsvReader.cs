using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SVAuto.Web.Utils
{
    public class CsvReader<T>
    {
        public delegate T CreateItem(string[] columns, string[] csvHeaders);

        public static IEnumerable<T> GetModelFromFile(string filePath, string[] requiredHeaders, CreateItem createItem)
        {
            if (!File.Exists(filePath))
            {
                throw new CsvFileNotFoundException($"{filePath}");
            }

            var headers = GetHeaders(filePath, requiredHeaders);

            return File.ReadAllLines(filePath)
                .Skip(1) // Skip header
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .Select(columns => createItem(columns, headers))
                .Where(x => x != null);
        }

        private static string[] GetHeaders(string filePath, string[] requiredHeaders)
        {
            string[] headers = File.ReadLines(filePath).First().Split(',');

            if (headers.Length < requiredHeaders.Length)
            {
                throw new NoRequiredHeadersException();
            }

            foreach (var rHeader in requiredHeaders)
            {
                if (!headers.Contains(rHeader))
                {
                    throw new NoRequiredHeadersException($"Does not contain required header {rHeader}");
                }
            }

            return headers;
        }
    }
}
