namespace FirstAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public static List<Product> Products { get; set; } = new List<Product>() 
        { new Product(1, "Pen", 34), new Product(2, "Pencil", 78) };

        public Product() { } //default constructor

        public Product(int id, string name, int price) //Parameterized constructor
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            //Products.Add(new Product(1, "Pen", 34));
            //Products.Add(new Product(2, "Erasor", 48));
            //Products.Add(new Product(3, "Laptop", 78));
            //Products.Add(new Product(4, "Pencil", 90));
            return Products;
        }

        public static Product GetProductById(int id)
        {
           // Products.Clear();
           // Products =GetAllProducts();

            Product p = Products.Where(x => x.Id == id).FirstOrDefault();
            return p;

        }

        public static void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public static void DeleteProduct(int id)
        {
            var p=GetProductById(id);
            Products.Remove(p);

        }

        public static void EditProduct(int id, Product p)
        {
            var oldprd = GetProductById(id);
            Products.Remove(oldprd);
            Products.Add(p);
        }

            
    }
}
