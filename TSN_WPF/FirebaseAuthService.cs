using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using System;
using System.Threading.Tasks;

public class FirebaseAuthService
{
    private FirebaseAuthClient authClient;

    public FirebaseAuthService()
    {
        var config = new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyDYBDT9RgfkGobd41c0wR0xEbmCrUCPlzU",
            AuthDomain = "thesocialnest-a6ab6.firebaseapp.com", // Replace with your Firebase Auth domain
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()  // Ensure EmailProvider is added
            },
            UserRepository = new FileUserRepository("FirebaseAuth.json") // Optional for session persistence
        };

        authClient = new FirebaseAuthClient(config);
    }

    public async Task<string> RegisterUserAsync(string email, string password)
    {
        try
        {
            var auth = await authClient.CreateUserWithEmailAndPasswordAsync(email, password);
            return auth.User.Uid;
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
            var auth = await authClient.SignInWithEmailAndPasswordAsync(email, password);
            return auth.User.Uid;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
}
