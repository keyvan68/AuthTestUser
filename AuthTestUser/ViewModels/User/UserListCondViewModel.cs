using AuthTestUser.Classes;
using AuthTestUser.Repository;
using AuthTestUser.Context;
using AuthTestUser.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTestUser.ViewModels.User
{
    public class UserListCondViewModel
    {
       
        public class UserListClass
        {
            public Guid User_ID { get; set; }
            public string User_Code { get; set; }
            public string User_Pass { get; set; }
            public string User_FullName { get; set; }

        }
        public string? User_Code { get; set; }

        public string? User_FullName { get; set; }

        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;

        public string? SortFieldName { get; set; }

        public Boolean isSortAsce { get; set; }



        //   public List<UserListClass>? UserList { get; set; }

        public UserListCondViewModel()
        {
           // UserList = new List<UserListClass>();
        }

        

        public void New()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public ResultClass<List<UserListClass>> GetAll()
        {
            ResultClass<List<UserListClass>> res = new ResultClass<List<UserListClass>>();

            ApplicationDbContext applicationDbContext = new();
            IUserRepository userRepository = new UserRepository(applicationDbContext);


            var Query = userRepository.GetAll();
            if (string.IsNullOrEmpty(User_Code) == false) Query = Query.Where(x => string.Compare(x.User_Code, User_Code) == 0);
            if (string.IsNullOrEmpty(User_FullName) == false) Query = Query.Where(x => x.User_FullName.Contains(User_FullName));

            if (this.SortFieldName != null && string.Compare(this.SortFieldName.ToLower(), "user_code") == 0) Query = Query.OrderBy(x => x.User_Code);
            if (this.SortFieldName != null && string.Compare(this.SortFieldName.ToLower(), "user_fullname") == 0) Query = Query.OrderBy(x => x.User_FullName);

            if (isSortAsce == false) Query = Query.OrderByDescending(x => x);


            PageNumber = PageNumber ?? 1;
            PageSize = PageSize ?? 10;

            int SkipRecordCount = (PageNumber.Value - 1) * PageSize.Value;

            res.RecordEffected = Query.Count();


            Query = Query.Skip(SkipRecordCount).Take(PageSize.Value);

            res.Result = Query.Select(x => new UserListClass
            {
                User_Code = x.User_Code,
                User_FullName = x.User_FullName,
                User_ID = x.User_ID,
                User_Pass = x.User_Pass
            }).ToList();


            return res;
        }
    }
}
