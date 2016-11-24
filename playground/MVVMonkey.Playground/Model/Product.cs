using PropertyChanged;
using System.Collections.Generic;

namespace MVVMonkey.Playground.Model
{
    [ImplementPropertyChanged]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public static List<Product> ListAll()
        {
            var description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga";

            var products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Iphone", Image = "iphone.png", Price = 399.00M, Description = description });
            products.Add(new Product { Id = 2, Name = "Chromecast", Image = "chromecast.png", Price = 29.00M, Description = description });
            products.Add(new Product { Id = 3, Name = "Xbox One", Image = "xboxone.jpg", Price = 299.00M, Description = description });
            products.Add(new Product { Id = 4, Name = "Fitbit", Image = "fitbit.png", Price = 39.00M, Description = description });
            products.Add(new Product { Id = 5, Name = "Hololens", Image = "hololens.jpg", Price = 3000.00M, Description = description });
            return products;
        }
    }
}