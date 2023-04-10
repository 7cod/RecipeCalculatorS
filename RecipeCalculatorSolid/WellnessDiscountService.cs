namespace RecipeCalculator
{
    public interface IWellnessDiscountService
    {
        decimal GetWellnessDiscount(decimal price, bool isOrganic);
    }

    public class WellnessDiscountService : IWellnessDiscountService
    {
        private const decimal DISCOUNTPERCENTAGE = 0.05m;
        public decimal GetWellnessDiscount(decimal price, bool isOrganic)
        {
            if (!isOrganic)
                return price;

            var discountedPrice = price * (DISCOUNTPERCENTAGE / 100);
            return price - discountedPrice;
        }
    }
}
