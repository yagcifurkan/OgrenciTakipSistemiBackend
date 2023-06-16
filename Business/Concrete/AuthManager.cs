using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Castle.Core.Resource;
using Core.Entities.Concrete;
using Core.Utilities.Helpers.StudentNumber;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly IStudentNumberHelper _studentNumberHelper;

        public AuthManager(ITokenHelper tokenHelper, IUserService userService,
            IUserOperationClaimService userOperationClaimService, ITeacherService teacherService,
            IStudentService studentService, IStudentNumberHelper studentNumberHelper)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
            _teacherService = teacherService;
            _studentService = studentService;
            _studentNumberHelper = studentNumberHelper;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheckResult = _userService.GetByEmail(userForLoginDto.Email);
            if (!userToCheckResult.Success)
            {
                return new ErrorDataResult<User>(userToCheckResult.Message);
            }

            var userToCheck = userToCheckResult.Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> RegisterForTeacher(TeacherForRegisterDto teacherForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var newUser = new User
            {
                Email = teacherForRegisterDto.Email,
                FirstName = teacherForRegisterDto.FirstName,
                LastName = teacherForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(newUser);

            var user = _userService.GetByEmail(newUser.Email).Data;
            _userOperationClaimService.AddTeacherClaim(user);

            var newTeacher = new Teacher { UserId = user.Id, Faculty = teacherForRegisterDto.Faculty, Department = teacherForRegisterDto.Department };
            _teacherService.Add(newTeacher);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> RegisterForStudent(StudentForRegisterDto studentForRegisterDto)
        {
            var studentNumber = _studentNumberHelper.Generate();
            var studentEmail = $"{studentForRegisterDto.FirstName.ToLower()}.{studentForRegisterDto.LastName.ToLower()}@ogr.dpu.edu.tr";

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(studentNumber, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = studentEmail,
                FirstName = studentForRegisterDto.FirstName,
                LastName = studentForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            _userOperationClaimService.AddStudentClaim(user);

            var student = new Student { UserId = user.Id, StudentNumber = studentNumber, Faculty = studentForRegisterDto.Faculty, Department = studentForRegisterDto.Department };
            _studentService.Add(student);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var user = _userService.GetByEmail(email);

            if (!user.Success)
            {
                return new ErrorResult(user.Message);
            }

            if (user.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);

            if (!claims.Success)
            {
                return new ErrorDataResult<AccessToken>(claims.Message);
            }

            var accessToken = _tokenHelper.CreateToken(user, claims.Data);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        [SecuredOperation("teacher,student")]
        public IResult IsAuthenticated(string userEmail, List<string> requiredRoles)
        {
            if (requiredRoles != null)
            {
                var user = _userService.GetByEmail(userEmail).Data;
                var userClaims = _userService.GetClaims(user).Data;
                var doesUserHaveRequiredRoles = requiredRoles.All(role => userClaims.Select(userClaim => userClaim.Name).Contains(role));

                if (!doesUserHaveRequiredRoles)
                {
                    return new ErrorResult(Messages.AuthorizationDenied);
                }
            }

            return new SuccessResult();
        }
    }
}
