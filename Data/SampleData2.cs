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
                ProvinceCode="CA",
                ProvinceName="British Columbia",
            },
            new Province() {
                ProvinceCode="ON",
                ProvinceName="British Columbia",
            },
        };

        return Provinces;
    }

    public static List<City> Getcities(ApplicationDbContext context) {
        List<City> cities = new List<City>() {
            new City {
                CityName = "Langley",
                Population = 10000,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
            },
            new City {
                CityName = "Abbotsford",
                Population = 88,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
            },
            new City {
                CityName = "Burnaby",
                Population = 213213,
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
            },
        };

        return cities;
    }
}
}
