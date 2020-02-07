using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ōhara.Doppler.Service.IService;

namespace Ōhara.Doppler.API.Controllers
{
    [Route("api/v1/audio")]
    public class AudioController : MasterController
    {
        private readonly IAudioService _audioService;

        public AudioController(IAudioService audioService)
        {
            _audioService = audioService;
        }

        [HttpGet]
        [Route("listen/{audioFileId}")]
        [AllowAnonymous]
        public async Task<FileStreamResult> Listen(Guid audioFileId)
        {
            var streamFile =  await _audioService.Listen(audioFileId);
            return new FileStreamResult(streamFile, "audio/mpeg");
        }
    }
}