﻿using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BusinessLayer
{
    public class UserBusiness:IUserBusiness
    {
        IUserRepository userRepo;
        public UserBusiness(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public UserModel UserRegistration(UserModel model)
        {
            var result = userRepo.UserRegistration(model);
            return result;
        }

        public UserModel UserLogin(LoginModel login)
        {
            var result = userRepo.UserLogin(login);
            return result;
        }

        public string ForgotUserPassword(string email)
        {
            var result = userRepo.ForgotUserPassword(email);
            return result;
        }

        public string ResetUserPassword(LoginModel reset)
        {
            var result = userRepo.ResetUserPassword(reset);
            return result;
        }
    }
}
