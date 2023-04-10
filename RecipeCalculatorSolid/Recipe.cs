using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator
{ 

    public interface IRecipe
    {
        decimal CalculateCost(string recipeName, string countryCode, string stateCode = null);
    }

    public class Recipe : IRecipe
    {
        private readonly IWellnessDiscountService _wellnessDiscountService;
        private readonly ITaxCalculatorService _taxCalculatorService;

        public Recipe(IWellnessDiscountService wellnessDiscountService, ITaxCalculatorService taxCalculatorService)
        {
            _wellnessDiscountService = wellnessDiscountService;
            _taxCalculatorService = taxCalculatorService;
        }
        public decimal CalculateCost(string recipeName, string countryCode, string stateCode = null)
        {
            var ingredients = DataRepository.GetRecipeByName(recipeName);
            decimal totalCost = 0;

            foreach (var ingredient in ingredients)
            {
                var priceByUnit = DataRepository.GetPriceByUnit(ingredient.Name);
                decimal price = ingredient.Price;
                if (priceByUnit != null)
                {
                    price = priceByUnit.Price;
                }
                price = _wellnessDiscountService.GetWellnessDiscount(price, ingredient.IsOrganic);
                price = _taxCalculatorService.CalculateTax(countryCode, price, ingredient.FoodType, stateCode);
                totalCost += price;
            }

            return totalCost;
        }
    }

}
