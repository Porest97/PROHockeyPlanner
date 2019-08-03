using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROHockeyPlanner.Models.DataModels
{
    public class Referee
    {
        public int Id { get; set; }

        [Display(Name = "Person")]
        public int? PersonId { get; set; }
        [Display(Name = "Person")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public string RefNumber { get; set; }

        [Display(Name = "RefCategory")]
        public int? RefCategoryId { get; set; }
        [Display(Name = "RefCategory")]
        [ForeignKey("RefCategoryId")]
        public RefCategory RefCategory { get; set; }

        [Display(Name = "RefType")]
        public int? RefTypeId { get; set; }
        [Display(Name = "RefType")]
        [ForeignKey("RefTypeId")]
        public RefType RefType { get; set; }

        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        [Display(Name = "District")]
        [ForeignKey("DistrictId")]
        public District District { get; set; }
                       
    }
}
