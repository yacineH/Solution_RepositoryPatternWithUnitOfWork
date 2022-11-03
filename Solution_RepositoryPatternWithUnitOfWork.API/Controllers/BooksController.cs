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
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }


        [HttpGet("GetByName")]
        public ActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "Book 1", new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthors")]
        public ActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("Book 1"), new[] { "Author" }));
        }


        [HttpGet("GetOrdered")]
        public ActionResult GetOrdered()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("Book"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public ActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Test 3", AuthorId = 1 });
            _unitOfWork.Complete();
            return Ok(book);
        }

    }
}
