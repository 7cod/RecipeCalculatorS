using System.Collections.Generic;
using System.Linq;

namespace RecipeCalculator
{
    public class Ingridient
    {
        public Ingridient()
        {
            Measurements = new List<IngredientMeasurement>();
        }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public bool IsOrganic { get; set; }

        public FoodType FoodType { get; set; }
        public List<IngredientMeasurement> Measurements { get; set; }
    }

    public enum FoodType
    {
        Produce = 1,
        Pantry = 2,
        MeatPoultry = 3
    }

    public class CountryModel
    {
        public string CountryCode { get; set; } = string.Empty;
        public decimal TaxValue { get; set; } = 0M;
        public string Name { get; set; } = string.Empty;
        public Dictionary<string, StateTaxModel> StateTaxes { get; set; }
    }

    public class StateTaxModel
    {
        public string StateCode { get; set; }
        public decimal TaxValue { get; set; }
    }

    public class IngredientMeasurement
    {
        public int Quantity { get; set; }        
        public string Unit { get; set; }
        public string Ingredient { get; set; }
        public decimal Price { get; set; }
        public Dictionary<string, PriceUnitQuantityModel> PriceUnitQuantities { get; set; }
    }

    public class PriceUnitQuantityModel
    {
        public string code { get; set; }
        public string unitC { get; set; }
        public int quant { get; set; }
        public decimal myPrice { get; set; }

    }
}
