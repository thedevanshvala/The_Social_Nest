using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class FirebaseAuthService
{
  private readonly string _apiKey = "AIzaSyDYBDT9RgfkGobd41c0wR0xEbmCrUCPlzU"; // Replace with your Firebase API Key
  private readonly HttpClient _httpClient;

  public FirebaseAuthService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<string> RegisterUserAsync(string email, string password)
  {
    try
    {
      var requestBody = new
      {
        email,
        password,
        returnSecureToken = true
      };

      var response = await _httpClient.PostAsync(
          $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={_apiKey}",
          new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
      );

      if (!response.IsSuccessStatusCode)
      {
        var errorResponse = await response.Content.ReadAsStringAsync();
        return "Error: " + errorResponse;
      }

      var result = await response.Content.ReadAsStringAsync();
      dynamic data = JsonConvert.DeserializeObject(result);
      return data.localId; // Firebase UID
    }
    catch (Exception ex)
    {
      return "Error: " + ex.Message;
    }
  }

  public async Task<string> LoginUserAsync(string email, string password)
  {
    try
    {
      var requestBody = new
      {
        email,
        password,
        returnSecureToken = true
      };

      var response = await _httpClient.PostAsync(
          $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={_apiKey}",
          new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
      );

      if (!response.IsSuccessStatusCode)
      {
        var errorResponse = await response.Content.ReadAsStringAsync();
        return "Error: " + errorResponse;
      }

      var result = await response.Content.ReadAsStringAsync();
      dynamic data = JsonConvert.DeserializeObject(result);
      return data.idToken; // Firebase ID token
    }
    catch (Exception ex)
    {
      return "Error: " + ex.Message;
    }
  }

  public async Task<string> SendPasswordResetEmailAsync(string email)
  {
    try
    {
      var requestBody = new
      {
        requestType = "PASSWORD_RESET",
        email
      };

      var response = await _httpClient.PostAsync(
          $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={_apiKey}",
          new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
      );

      if (!response.IsSuccessStatusCode)
      {
        var errorResponse = await response.Content.ReadAsStringAsync();
        return "Error: " + errorResponse;
      }

      return "Success: Password reset email sent.";
    }
    catch (Exception ex)
    {
      return "Error: " + ex.Message;
    }
  }
}
