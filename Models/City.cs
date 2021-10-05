using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code1st.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int Population { get; set; }

        public string ProvinceCode { get; internal set; }

        [ForeignKey("ProvinceCode")]
        public Province Province { get; set; }
    }
}