using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution_RepositoryPatternWithUnitOfWork.Core.Interfaces;
using Solution_RepositoryPatternWithUnitOfWork.Core.Models;
using System.Threading.Tasks;

namespace Solution_RepositoryPatternWithUnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetById()
        {
            return Ok(_unitOfWork.Authors.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(1));
        }
    }
}
