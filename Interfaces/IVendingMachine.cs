namespace VendorApp.Interfaces
{
    public interface IVendingMachine
    {
        Coin InsertCoin();
        void frameandShowProductDetails();
        void dispatchProduct(int productId, Coin coin);
    }
}
