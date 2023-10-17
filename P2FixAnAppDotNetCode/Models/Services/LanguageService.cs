using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Logging.Console;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// Provides services method to manage the application language
    /// </summary>
    public class LanguageService : ILanguageService
    {
        /// <summary>
        /// Set the UI language
        /// </summary>
        public void ChangeUiLanguage(HttpContext context, string language)
        {
            string culture = SetCulture(language);
            UpdateCultureCookie(context, culture);
        }

        /// <summary>
        /// Set the culture
        /// </summary>
        public string SetCulture(string language)
        {
            string culture = "en-GB";

            // TODO complete the code            
            //}
            switch (language)
            {
                case "Anglais":
                case "English":
                case "Inglés":
                    culture = "en-GB";
                    break;
                case "Français":
                case "French":
                case "Francés":
                    culture = "fr-FR";
                    break;
                case "Espagnol":
                case "Spanish":
                case "Español":
                    culture = "es-ES";
                    break;

            }
            return culture;
        }

            /// <summary>
            /// Update the culture cookie
            /// </summary>
            public void UpdateCultureCookie(HttpContext context, string culture)
        {
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
        }
    }
}
