﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.Repository.Data;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _dbContext;

        public BuggyController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("notfound")] //GET : api/buggy/notfound
        public ActionResult GetNotFoundRequest() 
        {
            var product =_dbContext.Products.Find(100);

            if (product is null) 
                return NotFound(new ApiResponse(404));

            return Ok(product);
        }

        [HttpGet("servererror")] // GET : api/buggy/servererror
        public ActionResult GetServerError() 
        {
            var product = _dbContext.Products.Find(100);
            var productToReturn=product.ToString(); // It will throw Exception [NullReferenceException]

            return Ok(productToReturn);
        }

        [HttpGet("badrequest")] // GET : api/buggy/badrequest

        public ActionResult GetBadResult() 
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")] // GET : api/buggy/badrequest/five
        public ActionResult GetBadRequest(int id) //Validation Error
        {
            return Ok();
        }

        [HttpGet("unauthorized")]  // GET : api/buggy/badrequest/unauthorized
        public ActionResult GetUnAuthorizedError()
        {
            return Unauthorized(new ApiResponse(401));
        }
    }
}
