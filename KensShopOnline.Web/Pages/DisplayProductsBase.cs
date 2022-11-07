using KensShopOnline.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace KensShopOnline.Web.Pages
{
    public class DisplayProductsBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
