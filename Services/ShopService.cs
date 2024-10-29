using Shop.Models;

namespace Shop.Services;

public class ShopService
{
    static IList<Product> _products = new List<Product>
    {
          new Product
                {
                    Id = 1,
                    Name = "Aer proaspăt din Munții Carpați",
                    ProductionDate = new DateTime(2024, 4, 1),
                    ExpirationDate = new DateTime(2124, 4, 1),
                    Manufacturer = "Nature Air Inc.",
                    Country = "Romania"
                },
                new Product
                {
                    Id = 2,
                    Name = "Pachetul de Scuze - varianta premium",
                    ProductionDate = new DateTime(2024, 3, 15),
                    ExpirationDate = new DateTime(2040, 3, 15),
                    Manufacturer = "S.C. Scuză-Mă S.R.L.",
                    Country = "Moldova"
                },
                new Product
                {
                    Id = 3,
                    Name = "Bomboane cu gust de vacanță",
                    ProductionDate = new DateTime(2024, 6, 1),
                    ExpirationDate = new DateTime(2025, 6, 1),
                    Manufacturer = "Relax & Chill S.A.",
                    Country = "Spania"
                },
                new Product
                {
                    Id = 4,
                    Name = "Pijamale de birou pentru ședințe online",
                    ProductionDate = new DateTime(2024, 1, 1),
                    ExpirationDate = new DateTime(2026, 1, 1),
                    Manufacturer = "ComfortWear",
                    Country = "Italia"
                },
                new Product
                {
                    Id = 5,
                    Name = "Plante care dau like-uri la postări",
                    ProductionDate = new DateTime(2024, 9, 1),
                    ExpirationDate = new DateTime(2026, 9, 1),
                    Manufacturer = "GreenThumb",
                    Country = "Olanda"
                },
                new Product
                {
                    Id = 6,
                    Name = "Ceai anti-lene",
                    ProductionDate = new DateTime(2024, 2, 10),
                    ExpirationDate = new DateTime(2025, 2, 10),
                    Manufacturer = "EnergieBoost",
                    Country = "Japonia"
                },
                new Product
                {
                    Id = 7,
                    Name = "Stickere motivaționale pentru frigider",
                    ProductionDate = new DateTime(2024, 5, 10),
                    ExpirationDate = new DateTime(2030, 5, 10),
                    Manufacturer = "Mindset Masters",
                    Country = "Suedia"
                }
    };

    public IList<Product> GetAllProducts()
    {
        return _products;
    }

    public Product FindById(uint id)
    {
        var book = _products.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            throw new Exception("Product not found");
        }

        return book;
    }

    public Product FindByObject(Product product)
    {
        var foundedProduct = _products.FirstOrDefault(b => b.Id == product.Id);

        if (foundedProduct == null)
        {
            throw new Exception("Product not found");
        }

        return foundedProduct;
    }

    public void DeleteById(uint id)
    {
        _products.Remove(FindById(id));
    }

    public void Update(Product updatedProduct)
    {
        Product product = FindByObject(updatedProduct);

        product.Name = updatedProduct.Name;
        product.ProductionDate = updatedProduct.ProductionDate;
        product.ExpirationDate = updatedProduct.ExpirationDate;
        product.Manufacturer = updatedProduct.Manufacturer;
        product.Country = updatedProduct.Country;
    }

    public void Create(Product product)
    {
        uint lastId = 1;

        if (_products.Count == 0)
        {
            lastId = _products.Last().Id;
        }

        product.Id = lastId + 1;

        _products.Add(product);
    }
}