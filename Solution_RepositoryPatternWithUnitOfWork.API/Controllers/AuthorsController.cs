﻿using Microsoft.AspNetCore.Http;
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
        private readonly IBaseRepository<Author> _authorsRepository;

        public AuthorsController(IBaseRepository<Author> authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        [HttpGet]
        public ActionResult GetById()
        {
            return Ok(_authorsRepository.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _authorsRepository.GetByIdAsync(1));
        }
    }
}
