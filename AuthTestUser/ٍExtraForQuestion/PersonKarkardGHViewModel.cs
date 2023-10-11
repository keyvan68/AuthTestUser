using Application.Classes;
using Application.ViewModels.Enumv;
using DataLayer.Repository;
using DomainClasses.Context;
using DomainClasses.Entities;
using DomainClasses.Enums;
using DomainClasses.IRepositories;
using Microsoft.EntityFrameworkCore;
using static Application.ViewModels.Markaz.MarkazListCondViewModel;
using static Application.ViewModels.PersonGH.PersonGHV22ViewModel;

namespace Application.ViewModels
{
    public class PersonKarkardGHViewModel
    {
        public class PersonKarkardGHClass
        {
            public Guid PersonGH_ID { get; set; }
            public int Year_Year { get; set; }
            public MonthEnum Month { get; set; }
            public string MonthName { get; set; }
            //public PersonTypeGroupEnum? PersonTypeGroup { get; set; }
            public Guid City_ID { get; set; }
            public VersionEnum VersionEnum { get; set; }
            public string VersionName { get; set; }
            public Guid? Person_ID { get; set; }
            public string Person_Name { get; set; }
            public string Markaz_Name { get; set; }
            public string Person_No { get; set; }
        }
        public int? Year_Year { get; set; }
        public MonthEnum? Month { get; set; }
        
        public PersonTypeGroupEnum? PersonTypeGroup { get; set; }
        public Guid? City_ID { get; set; }
        public VersionEnum? VersionEnum { get; set; }
        public Guid? Person_ID { get; set; }
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
        public void New()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public ResultClass<List<PersonKarkardGHClass>> GetAll()
        {
            ResultClass<List<PersonKarkardGHClass>> res = new ResultClass<List<PersonKarkardGHClass>>();

            ApplicationDbContext applicationDbContext = new();


            PersonGHRepository personGHRepository = new PersonGHRepository(applicationDbContext);
            MarkazRepository markazRepository = new MarkazRepository(applicationDbContext);
            EnumViewModel enumViewModel = new EnumViewModel();
            /*.Include(x=>x.Person_Tbl).Include(x=>x.Markaz_Tbl).AsQueryable()*/
            var Query = personGHRepository.GetAll().Include(p=>p.Person_Tbl).Include(p=>p.Markaz_Tbl).AsQueryable();
            
            if (Year_Year != null) Query = Query.Where(x => x.Year_Year == Year_Year);
            if (Month != null) Query = Query.Where(x => x.Month == Month);
            if (City_ID != null) Query = Query.Where(x => x.Markaz_Tbl.Bakhsh_Tbl.City_ID == City_ID);
            if (VersionEnum != null) Query = Query.Where(x => x.VersionEnum == VersionEnum);
            if (Person_ID != null) Query = Query.Where(x => x.Person_ID == Person_ID);
            if (PersonTypeGroup != null)
            {
                var enums = PersonTypeGroupEnumClass.GetPersonTypeCode(PersonTypeGroup.Value);
                Query = Query.Where(x => enums.Contains(x.PersonType));
            }

            PageNumber =PageNumber ?? 1;
            PageSize = PageSize ?? 10;

            int SkipRecordCount = (PageNumber.Value - 1) * PageSize.Value;

            res.RecordEffected = Query.Count();
            Query = Query.Skip(SkipRecordCount).Take(PageSize.Value);

            res.Result = Query.AsEnumerable().Select(x => new PersonKarkardGHClass
            {
                PersonGH_ID=x.PersonGH_ID,
                Year_Year=x.Year_Year,
                City_ID=x.Markaz_Tbl.Bakhsh_Tbl.City_ID,
                VersionEnum=x.VersionEnum,
                VersionName =enumViewModel.GetDisplayName(typeof(VersionEnum), x.VersionEnum),
                Month=x.Month,
                MonthName="month"/*enumViewModel.GetDisplayName(typeof(MonthEnum),x.Month)*/,   
                Person_Name=x.Person_Tbl.Person_Name + " " +x.Person_Tbl.Person_Family,
                Markaz_Name = x.Markaz_Tbl.Markaz_Name,
                Person_No = x.Person_Tbl.Person_No,
                Person_ID=x.Person_ID


            }).ToList();


            return res;
        }
    }
}
