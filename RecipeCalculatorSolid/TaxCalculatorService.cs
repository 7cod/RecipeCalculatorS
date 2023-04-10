using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator
{ 
    public interface ITaxCalculatorService
    {
        decimal CalculateTax(string countryCode, decimal price, FoodType foodType, string stateCode = null);
    }
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private const decimal SalesTaxRate = 0.086m;

        public decimal CalculateTax(string countryCode, decimal price, FoodType foodType, string stateCode = null)
        {
            if (foodType == FoodType.Produce)
            {
                return price;
            }

            var taxCountry = DataRepository.GetByCode(countryCode, stateCode).TaxValue;
            var res = price * (DataRepository.GetByCode(countryCode).TaxValue / 100);
            return res;
        }
    } 
}
