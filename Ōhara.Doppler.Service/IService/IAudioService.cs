using System;
using System.IO;
using System.Threading.Tasks;

namespace Ōhara.Doppler.Service.IService
{
    public interface IAudioService
    {
        Task<Stream> Listen(Guid audioFileId);
    }
}