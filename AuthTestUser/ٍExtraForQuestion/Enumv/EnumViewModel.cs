//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace Application.ViewModels.Enumv
//{
//    public class EnumViewModel
//    {
//        public string Name { get; set; }
//        public int Code { get; set; }


//        public string GetDisplayName(Type EnumIns, object Value)
//        {
//            string displayName = "";
//            foreach (var item in Enum.GetValues(EnumIns))
//            {
//                var displayAttribute = EnumIns
//                    .GetField(item.ToString())
//                    .GetCustomAttributes(typeof(DisplayAttribute), false)
//                    .SingleOrDefault() as DisplayAttribute;

//                displayName = displayAttribute != null ? displayAttribute.Name : item.ToString();


//                if (item.ToString() == Value.ToString())
//                {
//                    return displayName;
//                }
//            }


//            return displayName;
//        }    https://stackoverflow.com/questions/36071987/linq-ef-include-with-select-new-type-lost-included


//        public List<EnumViewModel> GetAll(Type EnumIns)
//        {
//            Dictionary<string, string> dic = new Dictionary<string, string>();

//            List<EnumViewModel> list = new List<EnumViewModel>();


//            foreach (var item in Enum.GetValues(EnumIns))
//            {
//                var displayAttribute = EnumIns
//                    .GetField(item.ToString())
//                    .GetCustomAttributes(typeof(DisplayAttribute), false)
//                    .SingleOrDefault() as DisplayAttribute;

//                var displayName = displayAttribute != null ? displayAttribute.Name : item.ToString();
//                int number = (int)item;

//                //int number = int

//                EnumViewModel enumViewModel = new EnumViewModel();
//                enumViewModel.Name = displayName;
//                enumViewModel.Code = number;



//                list.Add(enumViewModel);
//            }


//            return list;
//        }
//    }
//}
