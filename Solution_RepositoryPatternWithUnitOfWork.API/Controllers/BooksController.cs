using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution_RepositoryPatternWithUnitOfWork.Core.Constants;
using Solution_RepositoryPatternWithUnitOfWork.Core.Interfaces;
using Solution_RepositoryPatternWithUnitOfWork.Core.Models;

namespace Solution_RepositoryPatternWithUnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _booksRepository;

        public BooksController(IBaseRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public ActionResult GetById()
        {
            return Ok(_booksRepository.GetById(1));
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_booksRepository.GetAll());
        }


        [HttpGet("GetByName")]
        public ActionResult GetByName()
        {
            return Ok(_booksRepository.Find(b => b.Title == "Book 1", new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthors")]
        public ActionResult GetAllWithAuthors()
        {
            return Ok(_booksRepository.FindAll(b => b.Title.Contains("Book 1"), new[] { "Author" }));
        }


        [HttpGet("GetOrdered")]
        public ActionResult GetOrdered()
        {
            return Ok(_booksRepository.FindAll(b => b.Title.Contains("Book"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public ActionResult AddOne()
        {
            return Ok(_booksRepository.Add(new Book { Title = "Test 3", AuthorId = 1 }));
        }

    }
}
