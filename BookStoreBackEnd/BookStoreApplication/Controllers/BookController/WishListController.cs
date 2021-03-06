﻿using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class WishListController : Controller
    {
        private readonly IWishListBusiness wishBusinsess;

        public WishListController(IWishListBusiness wishBusinsess)
        {
            this.wishBusinsess = wishBusinsess;

        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>

        [HttpPost]
        //[Route("addBooks")]
        public IActionResult AddItems([FromBody] WishlistModel addItem)
        {
            try
            {
                var result = this.wishBusinsess.AddItems(addItem);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Books Added in Wishlist Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Error While Adding Book in Wishlist" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Gets all item.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetAllBookFromWishList(int userId)
        {
            try
            {
                IEnumerable<WishBookResponse> getResult = this.wishBusinsess.GetAllBookFromWishList(userId);
                if (getResult != null)
                {
                    return this.Ok(new { Status = true, Message = "WishList Data Retrive Successfully", Data = getResult });
                }
                return this.NotFound(new { Status = false, Message = "Error Occur While Retriving WishList Data" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Deletes the book from wishlist.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>

        [HttpDelete]
        [Route("{wishListId}")]
        public IActionResult DeleteBookFromWishlist(int wishListId)
        {
            try
            {
                var delete = this.wishBusinsess.DeleteBooksFromWishlist(wishListId);
                if (delete != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Removed From Wishlist SuccesFully", Data = delete });
                }
                return this.NotFound(new { Status = false, Message = "Error While Removing Book From Wishlit" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

    }
}
