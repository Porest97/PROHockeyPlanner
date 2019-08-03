using System.ComponentModel.DataAnnotations;

namespace PROHockeyPlanner.Models.DataModels
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name="Country")]
        public string CountryName { get; set; }

        [Display(Name = "#")]
        public string CountryCode { get; set; }
    }
}