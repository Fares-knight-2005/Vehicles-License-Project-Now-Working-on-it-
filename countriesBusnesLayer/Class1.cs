using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CountriesDBLayer;

namespace countriesBusnesLayer
{
    public class Country
    {
        public int CountryID { get; private set; }

        public string CountryName { get; set; }

        public Country(int id, string name)
        {
            CountryID = id;
            CountryName = name;
        }

        public static DataTable GetCountryList()
        {
            return CountriesDBLayer.Class1.GetAllCountries();
        }

        public static Country Find(int id)
        {
            string countryName = string.Empty;
            if (!CountriesDBLayer.Class1.FindCountryByCountryID(ref countryName, id))
                return null;

            return new Country(id, countryName);
        }
        public static Country Find(string countryName)
        {
            int ID = 0;

            if(!CountriesDBLayer.Class1.FindCountryByCountryName(countryName, ref ID))
                return null;

            return new Country(ID, countryName);
        }
    }
}
