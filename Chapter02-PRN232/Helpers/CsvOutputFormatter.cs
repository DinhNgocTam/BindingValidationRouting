using System.Text;
using BusinessObjects;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Chapter02_PRN232.Helpers
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(IEnumerable<Festival>).IsAssignableFrom(type)
                || typeof(Festival).IsAssignableFrom(type);
        }

        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context,
            Encoding selectedEncoding
        )
        {
            var response = context.HttpContext.Response;
            var festivals =
                context.Object as IEnumerable<Festival>
                ?? new List<Festival> { context.Object as Festival };
           await using var writer = new StreamWriter(response.Body, selectedEncoding, leaveOpen : true);
            foreach (var f in festivals)
            {
                await writer.WriteLineAsync($"{f.Id},{f.Name},{f.Province},{f.Date:yyyy-MM-dd}");
            }
        }
    }
}
