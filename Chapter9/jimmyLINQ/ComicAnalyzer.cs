using System;
using System.Collections.Generic;
using System.Linq;

namespace jimmyLINQ
{
    public static class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal> prices)
        {
            if (prices[comic.Issue] < 100) return PriceRange.cheap;
            return PriceRange.expensive;
        }

        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {

            var temp =
                comics
                .OrderBy(comic => prices[comic.Issue])
                .GroupBy(comic => CalculatePriceRange(comic, prices));

            var temp2 = from comic in comics
                        orderby prices[comic.Issue] // descending
                        group comic by CalculatePriceRange(comic, prices) into priceGroup
                        select priceGroup;

            return temp;

        }

        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
        {
            var temp1 = 
                comics
                .OrderBy(comic => comic.Issue)
                .Join(
                    reviews,
                    review => review.Issue,
                    comic => comic.Issue,
                    (comic, review) => $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";

            var temp2 =
                from comic in comics
                orderby comic.Issue //descending
                join review in reviews on comic.Issue equals review.Issue
                select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";


            return temp1;
                
        }
    }
}