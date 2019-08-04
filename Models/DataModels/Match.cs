using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROHockeyPlanner.Models.DataModels
{
    public class Match
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public int? MatchCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("MatchCategoryId")]
        public MatchCategory MatchCategory { get; set; }

        [Display(Name = "Age")]
        public int? AgeCategoryId { get; set; }
        [Display(Name = "Age")]
        [ForeignKey("AgeCategoryId")]
        public AgeCategory AgeCategory { get; set; }

        [Display(Name = "Game #")]
        public string GameNumber { get; set; }

        [Display(Name = "Date&Time")]
        public DateTime? GameDateTime { get; set; }

        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        [Display(Name = "Home Team")]
        public int? TeamId { get; set; }
        [Display(Name = "Home Team")]
        [ForeignKey("TeamId")]
        public Team HomeTeam { get; set; }

        [Display(Name = "Away Team")]
        public int? TeamId1 { get; set; }
        [Display(Name = "Away Team")]
        [ForeignKey("TeamId1")]
        public Team AwayTeam { get; set; }


        public int? HomeTeamScore { get; set; }

        public int? AwayTeamScore { get; set; }

        [Display(Name = "Score")]
        public string Result { get { return string.Format("{0} {1} {2}", HomeTeamScore, "-", AwayTeamScore); } }

        [Display(Name = "HD")]
        public int? RefereeId { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("RefereeId")]
        public Referee HD1 { get; set; }

        [Display(Name = "HD")]
        public int? RefereeId1 { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("RefereeId1")]
        public Referee HD2 { get; set; }

        [Display(Name = "LD")]
        public int? RefereeId2 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("RefereeId2")]
        public Referee LD1 { get; set; }

        [Display(Name = "LD")]
        public int? RefereeId3 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("RefereeId3")]
        public Referee LD2 { get; set; }

        [Display(Name = "Status")]
        public int? MatchStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("MatchStatusId")]
        public MatchStatus MatchStatus { get; set; }
    }
}
