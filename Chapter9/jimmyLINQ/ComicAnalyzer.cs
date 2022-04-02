using System;
using System.Collections.Generic;
using System.Linq;

namespace jimmyLINQ
{
    class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(Comic comic)
        {
            if (Comic.Prices[comic.Issue] < 100) return PriceRange.cheap;
            return PriceRange.expensive;
        }

        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            return 
                from comic in comics
                orderby prices[comic.Issue] descending
                group comic by CalculatePriceRange(comic) into priceGroup
                select priceGroup;

        }

        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
        {
            return 
                from comic in comics
                orderby comic.Issue descending
                join review in reviews on comic.Issue equals review.Issue
                select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";
        }
    }
}