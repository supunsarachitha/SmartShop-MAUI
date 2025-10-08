using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.MAUI.Services
{
    public class AuthService
    {
        private readonly ApiService _apiService;
        private readonly string _baseUrl;

        public AuthService(ApiService apiService, string baseUrl)
        {
            _apiService = apiService;
            _baseUrl = baseUrl;
        }

        public async Task<T> LoginAsync<T>(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));

            var url = $"{_baseUrl}/auth/login";
            var data = new { Username = username, Password = password };

            try
            {
                var response = await _apiService.PostAsync<object, T>(url, data);
                if (response == null)
                    throw new InvalidOperationException($"The API service returned a null response for URL: {url}");
                
                return response;
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using a logging framework)
                throw new ApplicationException($"An error occurred while logging in. URL: {url}", ex);
            }
        }
    }
}
