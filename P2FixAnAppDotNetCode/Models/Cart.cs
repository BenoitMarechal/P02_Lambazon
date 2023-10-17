using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        //Change:  private cartLine
        public List<CartLine> cartLines = new List<CartLine>();
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => cartLines;
        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method
            
            if (FindProductInCartLines(product.Id) != null)
            {
                CartLine foundLine = cartLines.Find(line => line.Product.Id == product.Id);
                int newQuantity = foundLine.Quantity + quantity;
                foundLine.Quantity = newQuantity;   
            }          
            else
            {
                CartLine newLine = new CartLine { OrderLineId = cartLines.Count, Product = product, Quantity = quantity };
                cartLines.Add(newLine);
            }
            // DONE
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {

            // TODO implement the method
            double result = 0.0;
            foreach (CartLine line in GetCartLineList())
            {
                result=result+(line.Quantity * line.Product.Price);
            }   

            return result;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            int numberOfProducts = 0;

            foreach (CartLine line in GetCartLineList())
            {
                numberOfProducts = numberOfProducts + line.Quantity;
            }
            if(numberOfProducts > 0)
            {
                double averageValue = (GetTotalValue() / numberOfProducts);
                return averageValue;
            }
            else
            {
                return 0.0;
            }

                
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)  
        {
            // TODO implement the method

            CartLine foundLine = cartLines.Find(line => line.Product.Id == productId);
            if (foundLine != null) { return foundLine.Product; }
            else
            {
                return null;
            }
        } //DONE, test OK

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
