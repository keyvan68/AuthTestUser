
using AuthTestUser.GenericRepository;
using AuthTestUser.Context;
using AuthTestUser.Entities;
using AuthTestUser.IRepositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AuthTestUser.Repository
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        protected readonly ApplicationDbContext ApplicatiobContex;
        
       

        public UserRepository(ApplicationDbContext ApplicatiobContex) : base(ApplicatiobContex)
        {
            this.ApplicatiobContex = ApplicatiobContex;
        }

       

        public IQueryable<User> GetAll()
        {
            return GetAllWithOutCond();
        }






























    }
}
