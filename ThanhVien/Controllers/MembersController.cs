using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ThanhVien.Models.DataModels;
using ThanhVien.Models.ViewModels;


namespace ThanhVien.Controllers
{
    public class MembersController : Controller
    {
        public static readonly List<Member> members = new List<Member>();

        public IActionResult Index()
        {
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModels register)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = register.Username,
                    FullName = register.FullName,
                    Email = register.Email,
                    Password = register.Password,
                    Phone = register.Phone,
                    Birthday = register.Birthday
                };

                members.Add(m);

                return RedirectToAction("Index");
            }
            else
            {
                return View(register);
            }
        }
    }
}

