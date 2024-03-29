﻿using Clean_Arch___UnitOFWork.Application.Interface;
using Clean_Arch___UnitOFWork.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Arch___UnitOFWork.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        //------Get all books from Library------------
        [HttpGet]
        public IActionResult GetAllBooks() 
        {
            var books = _unitOfWork.BookRepository.GetAll();
            return Ok(books);
        }

        //------Get a book by Id from Library------------
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //------Adding new book------------
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _unitOfWork.BookRepository.Add(book);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetAllBooks), new { id = book.Id }, book);
        }

        //------Update an existng book from Library------------
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null || id != book.Id)
            {
                return BadRequest("Invalid request. The book ID in the URL does not match the ID in the request body.");
            }

            var existingBook = _unitOfWork.BookRepository.GetById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Name = book.Name;
            existingBook.Description = book.Description;
            existingBook.Copies = book.Copies;

            _unitOfWork.BookRepository.Update(existingBook);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetBookById), new {id = book.Id}, book);
        }

        //------Delete a book from Library------------
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            _unitOfWork.BookRepository.Delete(id);
            _unitOfWork.SaveChanges();

            return Ok($"Book '{book.Name}' has been deleted.");
        }

        //------Borrowing------------
        [HttpPost("{id}/borrow")]
        public IActionResult BorrowBook(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            book.BorrowItem();

            _unitOfWork.SaveChanges();


            return Ok(new
            {
                Message = $"Book '{book.Name}' has been returned.",
                Book = book
            });
        }
        //------return book------------
        [HttpPost("{id}/return")]
        public IActionResult ReturnBook(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            book.ReturnItem();

            _unitOfWork.SaveChanges();

            return Ok(new
            {
                Message = $"Book '{book.Name}' has been returned.",
                Book = book
            });
        }


    }
}
