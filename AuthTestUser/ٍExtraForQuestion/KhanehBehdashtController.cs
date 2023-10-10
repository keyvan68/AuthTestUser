//using Application.Classes;
//using Application.ViewModels.KhaneBehdasht;
//using Application.ViewModels.Rosta;
//using DataLayer.Classes;
//using Microsoft.AspNetCore.Mvc;

//namespace Application.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class KhanehBehdashtController : ControllerBase
//    {
//        private readonly ILogger<KhanehBehdashtController> _logger;

//        public KhanehBehdashtController(ILogger<KhanehBehdashtController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet, Route("initNew")]
//        public ResultClass<KhanehBehdashtViewModel> initNew(Guid Markaz_ID)
//        {
//            try
//            {
//                KhanehBehdashtViewModel khanehBehdashtViewModel = new KhanehBehdashtViewModel();
//                var obj = khanehBehdashtViewModel.initNew(Markaz_ID);

//                return obj;
//            }
//            catch (Exception Ex)
//            {
//                return null;
//            }
//        }

//        [HttpGet, Route("Edit")]
//        public ResultClass<KhanehBehdashtViewModel> Edit(Guid id)
//        {
//            try
//            {
//                KhanehBehdashtViewModel khanehBehdashtViewModel = new KhanehBehdashtViewModel();
//                var obj = khanehBehdashtViewModel.LoadData(id);

//                return obj;
//            }
//            catch (Exception Ex)
//            {
//                ResultClass<KhanehBehdashtViewModel> resultClass = new ResultClass<KhanehBehdashtViewModel>();
//                resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

//                return resultClass;
//            }

//        }


//        [HttpPost, Route("StoreData")]
//        public ResultClass<Boolean> StoreData(KhanehBehdashtViewModel khanehBehdashtViewModel)
//        {
//            try
//            {
//                ResultClass<Boolean> res = new ResultClass<bool>();

//                if (ModelState.IsValid)
//                {
//                    res = khanehBehdashtViewModel.StoreData();
//                }
//                else
//                {
//                    var errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
//                                        .Select(m => m.ErrorMessage).ToList();
//                    res.SetError(errors);

//                }

//                return res;
//            }
//            catch (Exception Ex)
//            {
//                ResultClass<Boolean> resultClass = new ResultClass<Boolean>();
//                resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

//                return resultClass;
//            }


//        }

//        [HttpDelete, Route("Delete")]
//        public ResultClass<Boolean> Delete(Guid id)
//        {
//            try
//            {
//                KhanehBehdashtViewModel rostaViewModel = new KhanehBehdashtViewModel();
//                var res = rostaViewModel.Delete(id);

//                return res;
//            }
//            catch (Exception Ex)
//            {
//                ResultClass<Boolean> resultClass = new ResultClass<Boolean>();
//                resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

//                return resultClass;
//            }


//        }

//        [HttpGet, Route("InitGetList")]
//        public ResultClass<KhaneBehdashtListCondViewModel> InitGetList()
//        {
//            try
//            {
//                ResultClass<KhaneBehdashtListCondViewModel> resultClass = new ResultClass<KhaneBehdashtListCondViewModel>();

//                KhaneBehdashtListCondViewModel KhaneBehdashtViewModel = new KhaneBehdashtListCondViewModel();
//                KhaneBehdashtViewModel.New();
//                resultClass.SetDefualtSuccessSystem();

//                return resultClass;


//            }
//            catch (Exception Ex)
//            {
//                ResultClass<KhaneBehdashtListCondViewModel> resultClass = new ResultClass<KhaneBehdashtListCondViewModel>();
//                resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

//                return resultClass;
//            }

//        }

//        [HttpPost, Route("GetList")]
//        public ResultClass<List<KhaneBehdashtListCondViewModel.KhaneBehdashtListClass>> GetList(KhaneBehdashtListCondViewModel KhaneBehdashtViewModel)
//        {
//            try
//            {
//                var rosta = KhaneBehdashtViewModel.GetAll();
//                return rosta;

//            }
//            catch (Exception Ex)
//            {
//                ResultClass<List<KhaneBehdashtListCondViewModel.KhaneBehdashtListClass>> resultClass = new ResultClass<List<KhaneBehdashtListCondViewModel.KhaneBehdashtListClass>>();
//                resultClass.Errors.Add(ExceptionHandlerClass.GetPersianMessage(Ex));

//                return resultClass;
//            }
//        }
//    }

//}
