﻿using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyemail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getuserdetailbyemail")]
        public IActionResult GetUserDetailByEmail(string userEmail)
        {
            var result = _userService.GetUserDetailByEmail(userEmail);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}

