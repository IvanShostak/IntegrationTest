namespace LearningLogging.Helpers.Entities.Product;

public class ResponseProduct : global::Product
{
    public ResponseProduct(string title, string description, float price) : base(title, description, price)
    {
    }

    public void AssertProduct(global::Product product)
    {
        AssertHelper.AssertEqual(Title, product.Title, "Title");
        AssertHelper.AssertEqual(Description, product.Description, "Description");
        AssertHelper.AssertEqual(Price, product.Price, "Price");
    }
}
