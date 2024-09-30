using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zara_GestionDVD.Models;
using Zara_GestionDVD.ViewModels;

public class AccountController : Controller
{
    private readonly UserManager<Utilisateur> _userManager;
    private readonly SignInManager<Utilisateur> _signInManager;

    public AccountController(UserManager<Utilisateur> userManager, SignInManager<Utilisateur> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Page d'inscription 
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new Utilisateur
            {
                UserName = model.Courriel,
                Email = model.Courriel,
                Prenom = model.Prenom
            };

            var result = await _userManager.CreateAsync(user, model.MotDePasse);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "DVDs");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        else
        {
            // Vérifiez les erreurs du modèle et affichez-les dans la console
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }

        return View(model);
    }




    // Page de connexion
    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Courriel, model.MotDePasse, model.ResterConnecte, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "DVDs");
            }

            ModelState.AddModelError(string.Empty, "Échec de la connexion.");
        }
        return View(model);
    }

    // Déconnexion
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "DVDs");
    }
}