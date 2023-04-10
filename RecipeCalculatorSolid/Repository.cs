using System.Collections.Generic;
using System.Linq;

namespace RecipeCalculator
{
    public static class DataRepository
    {
        public static void Init()
        {
            PopulateCountries();
            PopulateRecipes();
            PopulatePrices();
        }

        public static Dictionary<string, CountryModel> _countries = new Dictionary<string, CountryModel>();

        public static Dictionary<string, List<Ingridient>> _recipes = new Dictionary<string, List<Ingridient>>();

        public static Dictionary<string, IngredientMeasurement> _prices = new Dictionary<string, IngredientMeasurement>();

        private static void PopulateCountries()
        {
            _countries.Add("USD", new CountryModel { CountryCode = "USD", TaxValue = 0.086M, Name = "United States",
                StateTaxes = new Dictionary<string, StateTaxModel>
                {
                    { "CA", new StateTaxModel { StateCode = "CA", TaxValue = 0.085M } },
                    { "NY", new StateTaxModel { StateCode = "NY", TaxValue = 0.089M } },
                }
            });

            _countries.Add("CA",
            new CountryModel { CountryCode = "CA", TaxValue = 8.5M, Name = "Canada" });
        }

        private static void PopulateRecipes()
        {
            _recipes.Add("Pizza", new List<Ingridient>
            {
                new Ingridient { Name = "Garlic", Price = 0.67m, IsOrganic = true, FoodType = FoodType.Produce },
                new Ingridient { Name = "Corn", Price = 0.87m, IsOrganic = true, FoodType = FoodType.Produce },
                new Ingridient { Name = "pasta", Price = 0.31m, IsOrganic = false }
             });

            _recipes.Add("Hamburger", new List<Ingridient>
            {
                new Ingridient { Name = "Garlic", Price = 0.67m, IsOrganic = false, FoodType = FoodType.Produce },
                new Ingridient { Name = "Corn", Price = 0.87m, IsOrganic = false, FoodType = FoodType.Produce },
                new Ingridient { Name = "pasta", Price = 0.31m, IsOrganic = false, FoodType = FoodType.Pantry }
             });

            _recipes.Add("HotDog", new List<Ingridient>
            {
                new Ingridient { Name = "Garlic", Price = 0.67m, IsOrganic = true, FoodType = FoodType.Produce },
                new Ingridient { Name = "Corn", Price = 0.87m, IsOrganic = true, FoodType = FoodType.Produce },
                new Ingridient { Name = "pasta", Price = 0.31m, IsOrganic = false, FoodType = FoodType.Pantry }
             });

        }

        private static void PopulatePrices() 
        {
            _prices.Add("Garlic", new IngredientMeasurement{ Quantity = 1, Unit = "clove", Ingredient = "Garlic", Price = 0.67m , 
                PriceUnitQuantities = new Dictionary<string, PriceUnitQuantityModel> 
                {
                    { "Garlic", new PriceUnitQuantityModel { code = "Garlic", unitC = "clove", quant = 2, myPrice = 2.5m} }
                }
            } );
            _prices.Add("Corn", new IngredientMeasurement { Quantity = 1, Unit = "cup", Ingredient = "Corn", Price = 0.87m });
            _prices.Add("Pasta", new IngredientMeasurement { Quantity = 1, Unit = "ounce", Ingredient = "Pasta", Price = 0.31m });
        }

        public static CountryModel GetByCode(string countryCode, string stateCode = null)
        {
            var country = _countries
            .Where(x => x.Key.Contains(countryCode))
            .Select(x => x.Value)
            .FirstOrDefault();

            if (country != null && stateCode != null && country.StateTaxes != null && country.StateTaxes.ContainsKey(stateCode))
            {
                country.TaxValue = country.StateTaxes[stateCode].TaxValue;
            }
            return country;
        }

        public static List<Ingridient> GetRecipeByName(string recipeName)
        {
            return _recipes
             .Where(x => x.Key.Contains(recipeName))
             .Select(x => x.Value)
             .FirstOrDefault();
        }

        public static IngredientMeasurement GetPriceByUnit(string name)
        {
            var prices = _prices
             .Where(x => x.Key.Contains(name))
             .Select(x => x.Value)
             .FirstOrDefault();
            
            if (prices != null && name != null && prices.PriceUnitQuantities != null && prices.PriceUnitQuantities.ContainsKey(name))
            {
                prices.Price = prices.PriceUnitQuantities[name].quant * prices.PriceUnitQuantities[name].myPrice;
            }
            return prices;
        }
    }
}
