﻿using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterAndLoginApp.Services
{
    public class SecurityService
    {
        List<UserModel> knownUsers = new List<UserModel>();

        SecurityDAO securityDAO = new SecurityDAO();

        public SecurityService()
        {


/*            knownUsers.Add(new UserModel { Id = 0, UserName = "BillGates", Password = "bigbucks" });

            knownUsers.Add(new UserModel { Id = 1, UserName = "MarieCurie", Password = "radioactive" });

            knownUsers.Add(new UserModel { Id = 2, UserName = "WatsonCrick", Password = "dna" });

            knownUsers.Add(new UserModel { Id = 3, UserName = "AlexanderFlemming", Password = "penicillin" });*/
        }

        public bool IsValid(UserModel user)
        {
            /*            return knownUsers.Any(x => x.UserName == user.UserName && x.Password == user.Password);*/
            return securityDAO.FindUserByNameAndPassword(user);

        }
        public bool IsValid(RegisterationModel user)
        {
            return securityDAO.InsertUser(user);

        }

    }
}