using System;
using System.Linq;
using System.Collections.Generic;
using Code1st.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Code1st.Data
{

 public class SampleData2 {
  public static void Initialize(IApplicationBuilder app) { 
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
      var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
      context.Database.EnsureCreated();

      // Look for any Provinces.
      if (context.Provinces.Any()) {
          return;   // DB has already been seeded
      }

      var provinces = GetProvinces().ToArray();
      context.Provinces.AddRange(provinces);
      context.SaveChanges();

      var cities = Getcities(context).ToArray();
      context.Cities.AddRange(cities);
      context.SaveChanges();
    }
  }

    public static List<Province> GetProvinces() {
        List<Province> Provinces = new List<Province>() {
            new Province() {
                ProvinceCode="BC",
                ProvinceName="British Columbia",
            },
            new Province() {
                ProvinceCode="AB",
                ProvinceName="Alberta",
            },
            new Province() {
                ProvinceCode="ON",
                ProvinceName="Ontario",
            }
        };

        return Provinces;
    }

    public static List<City> Getcities(ApplicationDbContext context) {
        List<City> cities = new List<City>() {
            new City {
                CityName = "Vancouver",
                Population = 1350000,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
            },
            new City {
                CityName = "Abbotsford",
                Population = 456742,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
            },
            new City {
                CityName = "Burnaby",
                Population = 635555,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
            },
            new City {
                CityName = "Toronto",
                Population = 10000000,
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
            },
            new City {
                CityName = "Mississagua",
                Population = 30,
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
            },
            new City {
                CityName = "Ottowa",
                Population = 40,
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
            },
            new City {
                CityName = "Calgary",
                Population = 50,
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
            },
            new City {
                CityName = "Medicine Hat",
                Population = 60,
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
            },
            new City {
                CityName = "Red Deer",
                Population = 70,
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
            },
        };

        return cities;
    }
}
}
