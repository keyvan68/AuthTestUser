//using Application.Classes;
//using DataLayer.Repository;
//using DomainClasses.Context;
//using DomainClasses.Enums;
//using DomainClasses.IRepositories;
//using Application.ViewModels.Enumv;
//using System.ComponentModel.DataAnnotations;

//namespace Application.ViewModels.KhaneBehdasht
//{
//    public class KhaneBehdashtListCondViewModel
//    {
//        public class KhaneBehdashtListClass
//        {
//            public Guid KhanehBehdasht_ID { get; set; }
//            public Guid Markaz_ID { get; set; }
//            public string KhanehBehdasht_Name { get; set; }

//            public decimal KhanehBehdasht_FaselAbi { get; set; }
//            public decimal KhanehBehdasht_FaselAsf { get; set; }
//            public RostaTypeEnum RostaType { get; set; }
//            public string RostaTypeName { get; set; }
//            public Boolean KhanehBehdasht_isActive { get; set; }
//            public int KhanehBehdasht_Jameiat { get; set; }

//            public Boolean KhanehBehdasht_isAshayeri { get; set; }
//            public int Rosta_Count { get; set; }



//        }
//        public string KhanehBehdasht_Name { get; set; }

//        //public RostaTypeEnum? RostaType { get; set; }
//        public Guid Markaz_ID { get; set; }

//        public int? PageNumber { get; set; } = 1;
//        public int? PageSize { get; set; } = 10;

//        public string? SortFieldName { get; set; }

//        public Boolean isSortAsce { get; set; }

//        //public List<RostaListClass> RostaList { get; set; }

//        public KhaneBehdashtListCondViewModel()
//        {
//            //RostaList = new List<RostaListClass>();
//        }

//        public void New()
//        {
//            PageNumber = 1;
//            PageSize = 10;
//        }

//        public ResultClass<List<KhaneBehdashtListClass>> GetAll()
//        {
//            ResultClass<List<KhaneBehdashtListClass>> res = new ResultClass<List<KhaneBehdashtListClass>>();

//            ApplicationDbContext applicationDbContext = new();
//            IKhanehBehdashtRepository khanehBehdashtRepository = new KhanehBehdashtRepository(applicationDbContext);
//            IRostaRepository rostaRepository = new RostaRepository(applicationDbContext);
//            EnumViewModel EnumViewModel = new EnumViewModel();

//            var Query = khanehBehdashtRepository.GetAll().Where(x => x.Markaz_ID == this.Markaz_ID);
//            //var rosta = rostaRepository.GetAll();


//            if (string.IsNullOrEmpty(KhanehBehdasht_Name) == false) Query = Query.Where(x => string.Compare(x.KhanehBehdasht_Name, KhanehBehdasht_Name) == 0);
//            //if (RostaType != null) Query = Query.Where(x => x.RostaType == RostaType);

//            //  int markazcount = markazRepository.GetAll().Where(m => m.Markaz_ID == this.Markaz_ID).Count();


//            if (this.SortFieldName != null && string.Compare(this.SortFieldName.ToLower(), "khanehbehdasht_name") == 0) Query = Query.OrderBy(x => x.KhanehBehdasht_Name);
//            //if (this.SortFieldName != null && string.Compare(this.SortFieldName.ToLower(), "rostatype") == 0) Query = Query.OrderBy(x => x.RostaType);

//            if (isSortAsce == false) Query = Query.OrderByDescending(x => x);


//            PageNumber = PageNumber ?? 1;
//            PageSize = PageSize ?? 10;

//            int SkipRecordCount = (PageNumber.Value - 1) * PageSize.Value;

//            res.RecordEffected = Query.Count();


//            Query = Query.Skip(SkipRecordCount).Take(PageSize.Value);

//            //var temp = EnumViewModel.GetDisplayName(typeof(RostaTypeEnum),Query.SingleOrDefault().RostaType);

//            res.Result = Query.AsEnumerable().Select(x => new KhaneBehdashtListClass
//            {
//                KhanehBehdasht_ID = x.KhanehBehdasht_ID,
//                Markaz_ID = x.Markaz_ID,
//                KhanehBehdasht_Name = x.KhanehBehdasht_Name,
//                KhanehBehdasht_FaselAbi = x.KhanehBehdasht_FaselAbi,
//                KhanehBehdasht_FaselAsf = x.KhanehBehdasht_FaselAsf,
//                KhanehBehdasht_isActive = x.KhanehBehdasht_isActive,
//                KhanehBehdasht_isAshayeri = x.KhanehBehdasht_isAshayeri,
//                KhanehBehdasht_Jameiat = x.KhanehBehdasht_Jameiat,
//                RostaType = x.RostaType,
//                RostaTypeName = EnumViewModel.GetDisplayName(typeof(RostaTypeEnum), Query.FirstOrDefault().RostaType),
//                Rosta_Count = x.City_Tbls.Count() /*rostaRepository.GetAll().Where(r=>r.KhanehBehdasht_ID == x.KhanehBehdasht_ID).Count()*/ // x.Rosta_Tbls.Count()

//            }).ToList();


//            return res;
//        }
//    }
//}
