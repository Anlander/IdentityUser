using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages.Account;

public class Register : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public Register(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty] public string? Email { get; set; }
    [BindProperty] public string? Password { get; set; }
    public string ErrorMessage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = new IdentityUser()
        {
            UserName = Email,
            Email = Email
        };
        var result = await _userManager.CreateAsync(user, Password);
        if (result.Succeeded)
        {
            return RedirectToPage("/Index");
        }

        ErrorMessage = "Something went wrong, please try again!";
        return Page();
    }
}