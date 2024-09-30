using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zara_GestionDVD.Data;
using Zara_GestionDVD.Models;

namespace Zara_GestionDVD.Controllers
{
    [Authorize]
    public class DVDsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly string _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "errorLog.txt");

        public DVDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Méthode pour enregistrer les logs d'erreur
        private void LogError(string message)
        {
            var logMessage = $"{DateTime.Now}: {message}{Environment.NewLine}";
            System.IO.File.AppendAllText(_logFilePath, logMessage);
        }

        // GET: DVDs
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = GetCategories();
            
            return View(await _context.DVDs.ToListAsync());
        }

        // GET: DVDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                LogError("ID du DVD est nul dans la méthode Details.");
                return NotFound();
            }

            var dVD = await _context.DVDs.FirstOrDefaultAsync(m => m.Id == id);
            if (dVD == null)
            {
                LogError($"Aucun DVD trouvé avec l'ID {id} dans la méthode Details.");
                return NotFound();
            }

            return View(dVD);
        }
        // GET: DVDs/Create
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories(); // Charger les catégories
            return View();
        }

        // POST: DVDs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitreFrancais,TitreOriginal,AnneeSortie,Categorie,DerniereMiseAJour,DerniereMiseAJourPar,DescriptionSuppléments,Duree,EstDVDOriginal,Format,LanguesDisponibles,NombreDisques,NomProducteur,NomRealisateur,ActeursPrincipaux,ResumeFilm,SousTitresDisponibles,PropriétaireId,EmprunteurId,VersionEtendue,VisibleATous")] DVD dVD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dVD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = GetCategories(); // Recharger les catégories en cas d'erreur
            return View(dVD);
        }
        private List<SelectListItem> GetCategories()
        {
            return new List<SelectListItem>
    {
        new SelectListItem { Value = "Action", Text = "Action" },
        new SelectListItem { Value = "Adolescent", Text = "Adolescent" },
        new SelectListItem { Value = "Biographie", Text = "Biographie" },
        new SelectListItem { Value = "Cape et d'épée", Text = "Cape et d'épée" },
        new SelectListItem { Value = "Catastrophe", Text = "Catastrophe" },
        new SelectListItem { Value = "Chronique", Text = "Chronique" },
        new SelectListItem { Value = "Comédie de mœurs", Text = "Comédie de mœurs" },
        new SelectListItem { Value = "Comédie d'horreur", Text = "Comédie d'horreur" },
        new SelectListItem { Value = "Comédie dramatique", Text = "Comédie dramatique" },
        new SelectListItem { Value = "Comédie fantaisiste", Text = "Comédie fantaisiste" },
        new SelectListItem { Value = "Comédie musicale", Text = "Comédie musicale" },
        new SelectListItem { Value = "Comédie policière", Text = "Comédie policière" },
        new SelectListItem { Value = "Comédie satirique", Text = "Comédie satirique" },
        new SelectListItem { Value = "Comédie sentimentale", Text = "Comédie sentimentale" },
        new SelectListItem { Value = "Comédie", Text = "Comédie" },
        new SelectListItem { Value = "Criminel", Text = "Criminel" },
        new SelectListItem { Value = "Danse", Text = "Danse" },
        new SelectListItem { Value = "Dessins animés", Text = "Dessins animés" },
        new SelectListItem { Value = "Documentaire", Text = "Documentaire" },
        new SelectListItem { Value = "Drame de guerre", Text = "Drame de guerre" },
        new SelectListItem { Value = "Drame de mœurs", Text = "Drame de mœurs" },
        new SelectListItem { Value = "Drame d'horreur", Text = "Drame d'horreur" },
        new SelectListItem { Value = "Drame judiciaire", Text = "Drame judiciaire" },
        new SelectListItem { Value = "Drame musical", Text = "Drame musical" },
        new SelectListItem { Value = "Drame poétique", Text = "Drame poétique" },
        new SelectListItem { Value = "Drame policier", Text = "Drame policier" },
        new SelectListItem { Value = "Drame psychologique", Text = "Drame psychologique" },
        new SelectListItem { Value = "Drame sentimental", Text = "Drame sentimental" },
        new SelectListItem { Value = "Drame social", Text = "Drame social" },
        new SelectListItem { Value = "Drame", Text = "Drame" },
        new SelectListItem { Value = "Espionnage", Text = "Espionnage" },
        new SelectListItem { Value = "Expérimental", Text = "Expérimental" },
        new SelectListItem { Value = "Fantastique", Text = "Fantastique" },
        new SelectListItem { Value = "Film à sketches", Text = "Film à sketches" },
        new SelectListItem { Value = "Film d'animation", Text = "Film d'animation" },
        new SelectListItem { Value = "Film d'art martial", Text = "Film d'art martial" },
        new SelectListItem { Value = "Historique", Text = "Historique" },
        new SelectListItem { Value = "Horreur", Text = "Horreur" },
        new SelectListItem { Value = "Humoristique", Text = "Humoristique" },
        new SelectListItem { Value = "Marionnettes", Text = "Marionnettes" },
        new SelectListItem { Value = "Mélodrame", Text = "Mélodrame" },
        new SelectListItem { Value = "Musical", Text = "Musical" },
        new SelectListItem { Value = "Road movie", Text = "Road movie" },
        new SelectListItem { Value = "Romantique", Text = "Romantique" },
        new SelectListItem { Value = "Science-fiction", Text = "Science-fiction" },
        new SelectListItem { Value = "Série policière", Text = "Série policière" },
        new SelectListItem { Value = "Série TV", Text = "Série TV" },
        new SelectListItem { Value = "Spectacle d'humour", Text = "Spectacle d'humour" },
        new SelectListItem { Value = "Spectacle musical", Text = "Spectacle musical" },
        new SelectListItem { Value = "Suspense", Text = "Suspense" },
        new SelectListItem { Value = "Western", Text = "Western" }
    };
        }

        // GET: DVDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                LogError("ID du DVD est nul dans la méthode Edit (GET).");
                return NotFound();
            }

            var dVD = await _context.DVDs.FindAsync(id);
            if (dVD == null)
            {
                LogError($"Aucun DVD trouvé avec l'ID {id} dans la méthode Edit (GET).");
                return NotFound();
            }
            ViewBag.Categories = GetCategories();
            return View(dVD);
        }

        // POST: DVDs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TitreFrancais,TitreOriginal,AnneeSortie,Categorie,DerniereMiseAJour,DerniereMiseAJourPar,DescriptionSuppléments,Duree,EstDVDOriginal,Format,LanguesDisponibles,NombreDisques,NomProducteur,NomRealisateur,ActeursPrincipaux,ResumeFilm,SousTitresDisponibles,PropriétaireId,EmprunteurId,VersionEtendue,VisibleATous")] DVD dVD)
        {
            if (id != dVD.Id)
            {
                LogError($"L'ID du DVD ne correspond pas dans la méthode Edit (POST) : attendu {id}, reçu {dVD.Id}.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dVD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVDExists(dVD.Id))
                    {
                        LogError($"Aucune entrée trouvée lors de la mise à jour du DVD avec l'ID {dVD.Id} dans la méthode Edit (POST).");
                        return NotFound();
                    }
                    else
                    {
                        LogError($"Erreur de concurrence lors de la mise à jour du DVD avec l'ID {dVD.Id} dans la méthode Edit (POST).");
                        throw; // Relancer l'exception après l'avoir loguée
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = GetCategories();
            return View(dVD);
        }

        // Méthode pour vérifier si un DVD existe
        private bool DVDExists(int id)
        {
            return _context.DVDs.Any(e => e.Id == id);
        }

        // GET: DVDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                LogError("ID du DVD est nul dans la méthode Delete (GET).");
                return NotFound();
            }

            var dVD = await _context.DVDs.FirstOrDefaultAsync(m => m.Id == id);
            if (dVD == null)
            {
                LogError($"Aucun DVD trouvé avec l'ID {id} dans la méthode Delete (GET).");
                return NotFound();
            }

            return View(dVD);
        }

        // POST: DVDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dVD = await _context.DVDs.FindAsync(id);
            if (dVD == null)
            {
                LogError($"Aucun DVD trouvé avec l'ID {id} lors de la tentative de suppression dans la méthode DeleteConfirmed (POST).");
                return NotFound();
            }

            _context.DVDs.Remove(dVD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}