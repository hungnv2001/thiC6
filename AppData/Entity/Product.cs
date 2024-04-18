using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Entity
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập giá trị")]
		[RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Không được chỉ chứa khoảng trắng")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập giá trị")]
		[RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Không được chỉ chứa khoảng trắng")]
		public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Số lượng hơn 1")]
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}
