﻿using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]

    public class BookController : Controller
    {
        private readonly IBookBusiness bookbusiness;

        public BookController(IBookBusiness bookbusiness)
        {
            this.bookbusiness = bookbusiness;
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>

        [HttpPost]
        //[Route("addBooks")]
        public IActionResult AddBooks(BookModel book)
        {
            try
            {
                var result = this.bookbusiness.AddBooks(book);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Data Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Error While Adding Book" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Gets all book.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        //[Route("getAllRecord")]
        public IActionResult GetAllBook()
        {
            try
            {
                IEnumerable<BookModel> getResult = this.bookbusiness.GetAllBook();
                if (getResult != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Data Retrived Succesfully", Data = getResult });
                }
                return this.BadRequest(new { Status = false, Message = "Error While Retriving Book Data" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Books the image upload.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("uploadImage/{bookId}")]
        public IActionResult BookImageUpload(IFormFile image, int bookId)
        {
            try
            {
                var book = this.bookbusiness.Image(image, bookId);
                if (book != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Image Uploaded Succesfully", Data = book });
                }
                return this.NotFound(new { Status = false, Message = "Error While Uploading Book Image" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Updates the book by adding.
        /// </summary>
        /// <param name="bookCount">The book count.</param>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("addBookCount/{bookCount}/{bookId}")]
        public IActionResult UpdateBookByAdding(int bookCount, int bookId)
        {
            try
            {
                var book = this.bookbusiness.UpdateBooksByAdding(bookCount, bookId);
                if (book != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Count Updated Succesfully", Data = book });
                }
                return this.BadRequest(new { Status = false, Message = "Error While Updating Book Count" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Updates the book by deleting.
        /// </summary>
        /// <param name="bookCount">The book count.</param>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>

        [HttpPut]
        [Route("deleteBookCount/{bookCount}/{bookId}")]
        public IActionResult UpdateBookByDeleting(int bookCount, int bookId)
        {
            try
            {
                var book = this.bookbusiness.UpdateBooksByDeleting(bookCount, bookId);
                if (book != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Count Updated Succesfully", Data = book });
                }
                return this.BadRequest(new { Status = false, Message = "Error While Updating Book Count" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
    }
}
