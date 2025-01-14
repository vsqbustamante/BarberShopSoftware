using BarberShopSoftware.Server.Models;
using BarberShopSoftware.Server.DTO;
using BarberShopSoftware.Server.Data;
using iText.Kernel.Pdf;
using iText.Layout.Element;



namespace BarberShopSoftware.Server.Services
{
    public interface IProductService
    {
        Product AddProduct(ProductDTO productDTO);
        List<Product> GetAllProducts();
        byte[] GenerateInventoryPdf();
    }

    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();

        public Product AddProduct(ProductDTO productDTO)
        {
            var product = new Product
            {
                Id = _products.Count + 1,
                Name = productDTO.Name,
                Stock = productDTO.Stock,
                Price = productDTO.Price
            };
            _products.Add(product);
            return product;
        }

        public List<Product> GetAllProducts() => _products;

        public byte[] GenerateInventoryPdf()
        {
            using var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new iText.Layout.Document(pdf);

            document.Add(new Paragraph("Inventory Report"));

            foreach (var product in _products)
            {
                document.Add(new Paragraph($"Name: {product.Name}, Stock: {product.Stock}, Price: {product.Price:C}"));
            }

            document.Close();
            return stream.ToArray();
        }
    }
}