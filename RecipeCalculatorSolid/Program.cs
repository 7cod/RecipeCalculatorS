using System;

namespace RecipeCalculator
{
    internal class Program
    {
        private static readonly IWellnessDiscountService _wellnessService = new WellnessDiscountService();
        private static readonly ITaxCalculatorService _taxCalculatorService = new TaxCalculatorService();

        static void Main(string[] args)
        {
            DataRepository.Init();
            var recipeService = new Recipe(_wellnessService, _taxCalculatorService);

            var priceRecipe1 = recipeService.CalculateCost("Hamburger", "USD");
            var priceRecipe2 = recipeService.CalculateCost("Pizza", "CA");
            var priceRecipe3 = recipeService.CalculateCost("HotDog", "USD", "CA");


            Console.WriteLine($"Recipe1 -totalCost {priceRecipe1}");
            Console.WriteLine($"Recipe2 -totalCost {priceRecipe2}");
            Console.WriteLine($"Recipe3 -totalCost {priceRecipe3}");

            Console.ReadKey();

        }


    }

}

