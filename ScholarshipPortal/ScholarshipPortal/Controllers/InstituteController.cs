using Microsoft.AspNetCore.Mvc;
using InstituteScholarshipPortal.Models;
using System.Linq;

namespace InstituteScholarshipPortal.Controllers
{
    public class InstituteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstituteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===================== REGISTER =====================

        public IActionResult Register()
        {
            return View(new InstituteRegistration());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(InstituteRegistration model)
        {
            if (ModelState.IsValid)
            {
                _context.Institutes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

        // ===================== LOGIN =====================

        public IActionResult Login()
        {
            return View(new InstituteLoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(InstituteLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var institute = _context.Institutes
                .FirstOrDefault(x => x.InstituteCode == model.InstituteCode &&
                                     x.Password == model.Password);

            if (institute == null)
            {
                ViewBag.Error = "Invalid Institute Code or Password.";
                return View(model);
            }

            // Save InstituteName in SESSION
            HttpContext.Session.SetString("InstituteName", institute.InstituteName);

            return RedirectToAction("Dashboard");
        }

        // ===================== DASHBOARD =====================

        public IActionResult Dashboard()
        {
            var name = HttpContext.Session.GetString("InstituteName");

            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Login");

            ViewBag.InstituteName = name;

            return View();
        }

        // ===================== LOGOUT =====================

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // ===================== VIEW PROFILE =====================

        public IActionResult ViewProfile()
        {
            var name = HttpContext.Session.GetString("InstituteName");

            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Login");

            var institute = _context.Institutes
                .FirstOrDefault(x => x.InstituteName == name);

            return View(institute);
        }
        public IActionResult EditProfile()
        {
            var name = HttpContext.Session.GetString("InstituteName");

            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Login");

            var institute = _context.Institutes
                .FirstOrDefault(x => x.InstituteName == name);

            return View(institute);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(InstituteRegistration model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existing = _context.Institutes
                .FirstOrDefault(x => x.InstituteId == model.InstituteId);

            if (existing == null)
                return NotFound();

            // Update fields
            existing.InstituteName = model.InstituteName;
            existing.InstituteCode = model.InstituteCode;
            existing.DISECode = model.DISECode;
            existing.State = model.State;
            existing.District = model.District;
            existing.Location = model.Location;
            existing.InstituteType = model.InstituteType;
            existing.YearAdmissionStarted = model.YearAdmissionStarted;
            existing.Address = model.Address;

            existing.AffiliatedUniversityState = model.AffiliatedUniversityState;
            existing.UniversityBoardName = model.UniversityBoardName;
            existing.EstablishmentCertificate = model.EstablishmentCertificate;
            existing.AffiliationCertificate = model.AffiliationCertificate;

            existing.PrincipalName = model.PrincipalName;
            existing.MobileNumber = model.MobileNumber;
            existing.Telephone = model.Telephone;

            existing.Password = model.Password;
            existing.ConfirmPassword = model.ConfirmPassword;
            existing.SecurityQuestion = model.SecurityQuestion;
            existing.SecurityAnswer = model.SecurityAnswer;

            // Save changes
            _context.SaveChanges();

            return RedirectToAction("ViewProfile");
        }

    }
}
