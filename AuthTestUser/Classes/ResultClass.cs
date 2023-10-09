using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTestUser.Classes
{
    public class ResultClass<T>
    {
        public T Result { get; set; }

        public List<string> Errors { get; set; }

        public string responseText { get; set; }

        public int? RecordEffected { get; set; }

        public Boolean isSuccsed
        {
            get
            {
                return Errors.Count == 0;
            }
        }

        public void SetDefualtSuccessSystem()
        {
            responseText = "عملیات با موفقیت انجام شد";
        }


        public void SetDefualtErrorSystem()
        {
            responseText = "خطای سیستمی";

            this.Errors.Add(responseText);
        }

        public void SetError(List<string> ErrorMessages)
        {
            if (ErrorMessages == null || ErrorMessages.Count == 0)
            {
                SetDefualtErrorSystem();
                return;
            }
            this.Errors = ErrorMessages;

            responseText = string.Join(";", ErrorMessages.ToArray());

        }


        public ResultClass()
        {

            Errors = new List<string>();
        }
    }
}
