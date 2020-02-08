using MessagePack;

namespace Ōhara.Doppler.Framework.Middlewares.ExceptionHandler.DTOs
{
    [MessagePackObject]
    public class RequestErrorRequestOutputDto
    {
        [Key(0)] public string Message { get; set; }

        [Key(1)] public bool IsSuccessful { get; set; }

        [Key(2)] public int ExceptionStatusCode { get; set; }
    }
}