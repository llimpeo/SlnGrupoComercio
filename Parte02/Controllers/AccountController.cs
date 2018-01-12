using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Components;
using Business.Entities;
using Business.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;

namespace Parte02.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AccountController(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        { 
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                IBCAccount Account = new BCAccount();

                var result = Account.Usuario(model);

                if (result.Succeeded)
                {
                   await RetrieveApiServiceToken(result);

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new Usuario { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }


        private async Task RetrieveApiServiceToken(UsuarioModel model)
        {
            IServiceCollection services = new ServiceCollection();
            try
            {
               
                using (var client = new HttpClient())
                {
                    string apiServicesUrl = "api/token";
          
                    client.BaseAddress = new Uri(apiServicesUrl);
                    client.DefaultRequestHeaders.Clear();

                    var keyValues = new List<KeyValuePair<string, string>>();

                    keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));
                    keyValues.Add(new KeyValuePair<string, string>("username", model.Usuario.CuentaUsuario));
                    keyValues.Add(new KeyValuePair<string, string>("password", model.Usuario.Clave));

                    var request = new HttpRequestMessage(HttpMethod.Post, apiServicesUrl);
                    request.Content = new FormUrlEncodedContent(keyValues);

                    HttpResponseMessage httpResponseMessage = await client.SendAsync(request);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var response = httpResponseMessage.Content.ReadAsStringAsync(); response.Wait();
                        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Result);

                        services.AddDistributedMemoryCache();
                        services.AddSession(options =>
                        {
                            options.Cookie.HttpOnly = true;
                            options.Cookie.Name = tokenResponse.access_token;
                            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                            options.IdleTimeout = TimeSpan.FromMinutes(5);
                            
                        });


                    }
                    else
                        services.Clear();

                    return;
                }
            }
            catch (Exception ex)
            {
                services.Clear();
            }
        }



    }
}
