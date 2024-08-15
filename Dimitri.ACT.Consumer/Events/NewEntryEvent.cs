using Dimitri.ACT.Core.Entities;
using Dimitri.ACT.Core.Helpers;
using MassTransit;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Dimitri.ACT.Consumer.Events
{
    public class NewEntryEvent : IConsumer<Entry>
    {
        private static HttpClient _entryClient = HttpClientConfiguration.EntryClient();
        public Task Consume(ConsumeContext<Entry> context)
        {
            Console.WriteLine($"Novo lançamento: {context.Message.EntryType}  {context.Message.Total}");

            Entry entry = new()
            {
                EntryType = context.Message.EntryType,
                Total = context.Message.Total,
            };

            var jsonContent = JsonConvert.SerializeObject(entry);
            var body = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _entryClient.PostAsync("/entry", body);

            return Task.CompletedTask;
        }
    }
}
