using Microsoft.AspNetCore.Identity;
using ServerHostedWasm.Shared;

namespace ServerHostedWasm.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ShoppingCart MyCart { get; set; } = new ShoppingCart();
    }
}