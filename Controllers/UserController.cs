using Microsoft.AspNetCore.Mvc;
using Purchase.Models;

namespace Purchase.Controllers
{
    public class UserController : Controller
    {
        private static Dictionary<string, (string Password, int LastAttemps, DateTime? BlockTime)> _users = new Dictionary<string, (string Password, int LastAttemps, DateTime? BlockTime)>
        {
            { "admin", ("password", 0, null) }

        };

        private static Dictionary<string, int> _ipLastAttemps = new Dictionary<string, int>();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel userModel)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            if (_ipLastAttemps.TryGetValue(ip, out int failedAttempts) && failedAttempts >= 3)
            {
                var blockTime = _users.GetValueOrDefault(ip, ("", 0, null)).BlockTime;
                if (blockTime.HasValue && blockTime > DateTime.Now)
                {
                    return RedirectToAction("Blocked");
                }
                else
                {
                    _ipLastAttemps.Remove(ip);
                    _users[ip] = (_users.GetValueOrDefault(ip, ("", 0, null)).Password, _users.GetValueOrDefault(ip, ("", 0, null)).LastAttemps, null);
                }
            }

            if (_users.TryGetValue(userModel.UserName, out var user) && user.Password == userModel.Password)
            {
                _ipLastAttemps.Remove(ip);
                _users[ip] = (_users.GetValueOrDefault(ip, ("", 0, null)).Password, 0, null);

                return RedirectToAction("Success");
            }
            else
            {
                if (_ipLastAttemps.ContainsKey(ip))
                {
                    _ipLastAttemps[ip]++;
                    _users[ip] = (_users.GetValueOrDefault(ip, ("", 0, null)).Password, _users.GetValueOrDefault(ip, ("", 0, null)).LastAttemps + 1, _users.GetValueOrDefault(ip, ("", 0, null)).BlockTime);
                }
                else
                {
                    _ipLastAttemps[ip] = 1;
                    _users[ip] = (_users.GetValueOrDefault(ip, ("", 0, null)).Password, 1, null);
                }

                if (_ipLastAttemps[ip] >= 3)
                {
                    _users[ip] = (_users.GetValueOrDefault(ip, ("", 0, null)).Password, _users.GetValueOrDefault(ip, ("", 0, null)).LastAttemps, DateTime.Now.AddMinutes(5));
                    return RedirectToAction("Blocked");
                }

                return RedirectToAction("Error");
            }
        }

        public IActionResult Blocked()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var blockTime = _users.GetValueOrDefault(ip, ("", 0, null)).BlockTime;
            if (blockTime.HasValue && blockTime > DateTime.Now)
            {
                return View();
            }
            else
            {
                _ipLastAttemps.Remove(ip);
                _users[ip] = (_users.GetValueOrDefault(ip, ("", 0, null)).Password, _users.GetValueOrDefault(ip, ("", 0, null)).LastAttemps, null);
                return RedirectToAction("Login");
            }
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
