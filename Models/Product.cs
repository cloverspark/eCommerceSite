using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models
{
    public class Product
    {
        /// <summary>
        /// A salable Product 
        /// </summary>
        public class Product
        {
            [Key]//primary key
            public int ProductID { get; set; }
            /// <summary>
            /// Product name
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Product retail price
            /// </summary>
            public double Price { get; set; }
            /// <summary>
            /// type of product
            /// </summary>
            public string Catagory { get; set; }
        }
}
