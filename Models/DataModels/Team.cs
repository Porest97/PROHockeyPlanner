using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROHockeyPlanner.Models.DataModels
{
    public class Team
    {
        public int Id { get; set; }

        [Display(Name = "Age")]
        public int? AgeCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("AgeCategoryId")]
        public AgeCategory AgeCategory { get; set; }

        [Display(Name = "Club")]
        public int? ClubId { get; set; }
        [Display(Name = "Club")]
        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public string TeamName { get { return string.Format("{0} {1} ", AgeCategory, Club); } }
    }
}