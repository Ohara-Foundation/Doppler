using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Ōhara.Doppler.Service.IService;

namespace Ōhara.Doppler.Service.Service
{
    public class AudioService : IAudioService
    {
        private readonly HttpClient _client;

        public AudioService()
        {
            _client = new HttpClient();
        }

        public async Task<Stream> Listen(Guid audioFileId)
        {
            // ToDo: Fix This...
            // Sample Audio File Link For Stream
            var urlBlob = "http://www.hochmuth.com/mp3/Bloch_Prayer.mp3";
            return await _client.GetStreamAsync(urlBlob);
        }

        ~AudioService()
        {
            _client?.Dispose();
        }   
    }
}