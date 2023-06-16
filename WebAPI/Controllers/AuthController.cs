using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success) return BadRequest(userToLogin.Message);

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                result.Message = userToLogin.Message;
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("registerforteacher")]
        public ActionResult RegisterForTeacher(TeacherForRegisterDto teacherForRegisterDto)
        {
            var userExists = _authService.UserExists(teacherForRegisterDto.Email);
            if (!userExists.Success) return BadRequest(userExists.Message);

            var registerResult = _authService.RegisterForTeacher(teacherForRegisterDto, teacherForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (result.Success)
            {
                result.Message = registerResult.Message;
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("registerforstudent")]
        public ActionResult RegisterForStudent(StudentForRegisterDto studentForRegisterDto)
        {
            var registerResult = _authService.RegisterForStudent(studentForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (result.Success)
            {
                result.Message = registerResult.Message;
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("isauthenticated")]
        public ActionResult IsAuthenticated(string userEmail, string requiredRoles)
        {
            var requiredRolesList = !string.IsNullOrEmpty(requiredRoles)
                ? requiredRoles.Split(',').ToList()
                : null;

            var result = _authService.IsAuthenticated(userEmail, requiredRolesList);
            if (result.Success) return Ok(result);

            return Unauthorized(result.Message);
        }
    }
}
