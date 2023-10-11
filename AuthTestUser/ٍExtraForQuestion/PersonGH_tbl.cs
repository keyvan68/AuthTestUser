using DomainClasses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Entities
{
    public class PersonGH_tbl
    {
        [Key]
        public Guid PersonGH_ID { get; set; }
        public Guid Person_ID { get; set; }
        public VersionEnum VersionEnum { get; set; }
        public int Year_Year { get; set; }
        
        public MonthEnum Month { get; set; }
        
        public Guid Markaz_ID { get; set; }
        [Required]
        public EstekhdamiTypeEnum EstekhdamiType { get; set; }
        [Required]
        public  PersonTypeEnum PersonType { get; set; }
        [MaxLength(350)]
        [Required]
        public string PersonGH_Info { get; set; }

        [Required]
        public CalcHoghoghTypeEnum CalcHoghoghType { get; set; }

        public string PersonGH_OtherDataByJSON { get; set; }

        public EntryTypeEnum EntryType { get; set; }

        //[ForeignKey("Markaz_ID")]
        public Markaz_tbl Markaz_Tbl { get; set; }
        [ForeignKey("Year_Year")]
        public Year_tbl Year_Tbl { get; set; }

        [ForeignKey("Person_ID")]
        public Person_tbl Person_Tbl { get; set; }
        public decimal Zarib { get; set; }


        public virtual ICollection<PersonGHKJ_tbl> PersonGHKJ_Tbl { get; set; }
        public virtual ICollection<PersonGHRosta_tbl> PersonGHRosta_Tbl { get; set; }
        public virtual ICollection<PersonGHAmel_tbl> PersonGHAmel_Tbl { get; set; }

        public virtual ICollection<PersonGHPayment_tbl> PersonGHPayment_Tbl { get; set; }

        public virtual ICollection<PersonGHBitoteh_tbl> PersonGHBitoteh_Tbls { get; set; }





    }
}
