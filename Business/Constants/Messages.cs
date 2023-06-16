using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserAdded = "User has added.";
        public static string UserUpdated = "User has updated.";
        public static string UserDeleted = "Car has deleted.";

        public static string OperationClaimAdded = "Operation claim has added.";
        public static string OperationClaimUpdated = "Operation claim has updated.";
        public static string OperationClaimDeleted = "Operation claim has deleted.";

        public static string UserOperationClaimAdded = "User operation claim has added.";
        public static string UserOperationClaimUpdated = "User operation claim has updated.";
        public static string UserOperationClaimDeleted = "User operation claim has deleted.";

        public static string AuthorizationDenied = "You are not authorized.";
        public static string UserRegistered = "The user has registered.";
        public static string UserNotFound = "User not found.";
        public static string SuccessfulLogin = "Login successful.";
        public static string PasswordError = "Bad password.";
        public static string UserAlreadyExists = "The user already exists.";
        public static string AccessTokenCreated = "Access token has created.";
    }
}
