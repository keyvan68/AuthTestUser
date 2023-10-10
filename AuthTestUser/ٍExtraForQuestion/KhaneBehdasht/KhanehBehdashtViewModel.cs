//using Application.Classes;
//using DataLayer.Repository;
//using DomainClasses.Context;
//using DomainClasses.Entities;
//using DomainClasses.Enums;
//using DomainClasses.IRepositories;
//using System.ComponentModel.DataAnnotations;

//namespace Application.ViewModels.KhaneBehdasht
//{
//    public class KhanehBehdashtViewModel
//    {
//        public Guid KhanehBehdasht_ID { get; set; }
//        [Display(Name = "مرکز")]
//        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
//        public Guid Markaz_ID { get; set; }
//        [Display(Name = "نام ")]
//        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
//        public string KhanehBehdasht_Name { get; set; }
//        [Required]
//        public decimal KhanehBehdasht_FaselAbi { get; set; }
//        [Required]
//        public decimal KhanehBehdasht_FaselAsf { get; set; }
//        [Display(Name = "نوع")]
//        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
//        public RostaTypeEnum RostaType { get; set; }
//        [Required]
//        public bool KhanehBehdasht_isActive { get; set; }
//        [Display(Name = "جمعیت")]
//        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
//        public int KhanehBehdasht_Jameiat { get; set; }
//        [Required]
//        public bool KhanehBehdasht_isAshayeri { get; set; }

//        public ResultClass<KhanehBehdashtViewModel> initNew(Guid Markaz_ID)
//        {


//            ResultClass<KhanehBehdashtViewModel> RC = new ResultClass<KhanehBehdashtViewModel>();
//            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

//            IRostaRepository rostaRepository = new RostaRepository(applicationDbContext);
//            RC.Result = new KhanehBehdashtViewModel();
//            RC.Result.KhanehBehdasht_ID = Guid.NewGuid();
//            RC.Result.Markaz_ID = Markaz_ID;



//            return RC;
//        }


//        public ResultClass<bool> StoreData()
//        {
//            ResultClass<bool> RC = new ResultClass<bool>();

//            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

//            IKhanehBehdashtRepository khanehBehdashtRepository = new KhanehBehdashtRepository(applicationDbContext);
//            var khanehBehdasht = khanehBehdashtRepository.Find(KhanehBehdasht_ID);
//            if (khanehBehdasht == null)
//            {
//                khanehBehdasht = new KhanehBehdasht_tbl();
//                khanehBehdasht.KhanehBehdasht_ID = KhanehBehdasht_ID;

//                khanehBehdashtRepository.Add(khanehBehdasht);


//            }
//            else
//            {
//                khanehBehdashtRepository.Update(khanehBehdasht);
//            }
//            khanehBehdasht.Markaz_ID = Markaz_ID;
//            khanehBehdasht.KhanehBehdasht_Name = KhanehBehdasht_Name;
//            khanehBehdasht.KhanehBehdasht_FaselAbi = KhanehBehdasht_FaselAbi;
//            khanehBehdasht.KhanehBehdasht_FaselAsf = KhanehBehdasht_FaselAsf;
//            khanehBehdasht.RostaType = RostaType;
//            khanehBehdasht.KhanehBehdasht_isActive = KhanehBehdasht_isActive;
//            khanehBehdasht.KhanehBehdasht_Jameiat = KhanehBehdasht_Jameiat;
//            khanehBehdasht.KhanehBehdasht_isAshayeri = KhanehBehdasht_isAshayeri;

//            int C = applicationDbContext.SaveChanges();
//            if (C == 0)
//            {
//                RC.SetDefualtErrorSystem();
//            }
//            else
//            {
//                RC.SetDefualtSuccessSystem();
//            }

//            return RC;
//        }


//        public ResultClass<KhanehBehdashtViewModel> LoadData(Guid id)
//        {
//            ResultClass<KhanehBehdashtViewModel> RC = new ResultClass<KhanehBehdashtViewModel>();
//            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

//            IKhanehBehdashtRepository khanehBehdashtRepository = new KhanehBehdashtRepository(applicationDbContext);
//            var khanehBehdasht = khanehBehdashtRepository.Find(id);

//            RC.Result = new KhanehBehdashtViewModel
//            {
//                KhanehBehdasht_ID= id,
//                Markaz_ID = khanehBehdasht.Markaz_ID,
//                KhanehBehdasht_Name = khanehBehdasht.KhanehBehdasht_Name,
//                KhanehBehdasht_FaselAbi = khanehBehdasht.KhanehBehdasht_FaselAbi,
//                KhanehBehdasht_FaselAsf = khanehBehdasht.KhanehBehdasht_FaselAsf,
//                RostaType = khanehBehdasht.RostaType,
//                KhanehBehdasht_isActive = khanehBehdasht.KhanehBehdasht_isActive,
//                KhanehBehdasht_Jameiat = khanehBehdasht.KhanehBehdasht_Jameiat,
//                KhanehBehdasht_isAshayeri = khanehBehdasht.KhanehBehdasht_isAshayeri,
//            };


//            return RC;
//        }

//        public ResultClass<bool> Delete(Guid id)
//        {
//            ResultClass<bool> RC = new ResultClass<bool>();
//            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

//            IKhanehBehdashtRepository khanehBehdashtRepository = new KhanehBehdashtRepository(applicationDbContext);
//            var khanehBehdasht = khanehBehdashtRepository.Find(id);
//            if (khanehBehdasht != null)
//            {
//                khanehBehdashtRepository.Remove(id);
//            }

//            int C = applicationDbContext.SaveChanges();
//            if (C == 0)
//            {
//                RC.SetDefualtErrorSystem();
//            }
//            else
//            {
//                RC.SetDefualtSuccessSystem();
//            }

//            return RC;
//        }
//    }
//}
