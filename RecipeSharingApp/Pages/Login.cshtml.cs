using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeSharingApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }    

        //public IActionResult OnPost()
        //{
            //var user=Data.UsersAvailable.Users.FirstOrDefault(u=>u.Email==Email && u.Password==Password);
            //if (user!=null)
            //{
            //    HttpContext.Session.SetString("User", Email);
            //    return RedirectToPage("/Index");
            //}
            //ModelState.AddModelError(string.Empty, "Wrong email or password");
            //return Page();
        //}
    }
}
