using Microsoft.AspNetCore.Mvc;
using Radio_Free_Europe.Models;
using Radio_Free_Europe.Services.MainServices;
using Radio_Free_Europe.Services.MainServices.Models;


namespace Radio_Free_Europe.Controllers
{
    [Route("api")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainService service;

        public MainController(IMainService service)
        {
            this.service = service;
        }
        [HttpGet("v1/diff/{Id}")]
        public BaseResponse<DiffResults> GetDiff(long Id)
        {
            return service.GetDiff(Id);
        }
        [HttpPost("v1/diff/{Id}/left")]
        public BaseResponse setLeft(long Id, [FromBody] DiffData diffData)
        {
            return service.setLeft(Id,diffData);
        }
        [HttpPost("v1/diff/{Id}/right")]
        public BaseResponse setRight(long Id, [FromBody] DiffData Data)
        {
            return service.setRight(Id,Data);
        }
    }
}
