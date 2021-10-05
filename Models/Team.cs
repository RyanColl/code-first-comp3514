using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Code1st.Models
{
    public class Team
    {
        [Key]
        public string TeamName { get; set; }
        public string City { get; set; }
        public List<Player> Players {get; set;}
        
        public Team()
        {

        }
    }
}