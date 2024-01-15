using Clean_Arch___UnitOFWork.Core.Domain;
using Clean_Arch___UnitOFWork.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Arch___UnitOFWork.Controllers
{
    [Route("api/magazines")]
    [ApiController]
    public class MagazinesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MagazinesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //---------Get all Magazines
        [HttpGet]
        public IActionResult GetAll()
        {
            var Magazines = _unitOfWork.MagazineRepository.GetAll();
            return Ok(Magazines);
        }
        [HttpGet("{id}")]
        public IActionResult GetMagazineById(int id)
        {
            var magazine = _unitOfWork.MagazineRepository.GetById(id);
            if (magazine == null)
            {
                return NotFound();
            }

            return Ok(magazine);
        }

        //-------Adding new Magazine
        [HttpPost]
        public IActionResult AddMagazine([FromBody] Magazine magazine)
        {
            if (magazine == null)
            {
                return BadRequest();
            }

            _unitOfWork.MagazineRepository.Add(magazine);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetMagazineById), new { id = magazine.Id }, magazine);
        }

        //------Updating any magazine
        [HttpPut("{id}")]
        public IActionResult UpdateMagazine(int id, [FromBody] Magazine magazine)
        {
            if (magazine == null || id != magazine.Id)
            {
                return BadRequest("Invalid request. The Magazine ID in the URL does not match the ID in the request body.");
            }

            var existingBook = _unitOfWork.BookRepository.GetById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Name = magazine.Name;
            existingBook.Description = magazine.Description;
            existingBook.Copies = magazine.Copies;

            _unitOfWork.BookRepository.Update(existingBook);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetMagazineById), new { id = magazine.Id }, magazine);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMagazine(int id)
        {
            var magazine = _unitOfWork.MagazineRepository.GetById(id);
            if (magazine == null)
            {
                return NotFound();
            }

            _unitOfWork.MagazineRepository.Delete(id);
            _unitOfWork.SaveChanges();

            return Ok($"Magazine '{magazine.Name}' has been deleted.");
        }

        //-------------Borrowing
        [HttpPost("{id}/borrow")]
        public IActionResult BorrowMagazine(int id)
        {
            var magazine = _unitOfWork.MagazineRepository.GetById(id);
            if (magazine == null)
            {
                return NotFound();
            }

            magazine.BorrowItem();

            _unitOfWork.SaveChanges();

            return Ok(new
            {
                Message = $"Magazine '{magazine.Name}' has been returned.",
                Magazine = magazine
            });
        }

        //-----------Return a magazine
        [HttpPost("{id}/return")]
        public IActionResult ReturnMagazine(int id)
        {
            var magazine = _unitOfWork.MagazineRepository.GetById(id);
            if (magazine == null)
            {
                return NotFound();
            }

            magazine.ReturnItem();

            _unitOfWork.SaveChanges();

            return Ok(new
            {
                Message = $"Magazine '{magazine.Name}' has been returned.",
                Magazine = magazine
            });
        }


    }
}
