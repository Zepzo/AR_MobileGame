using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class AuthManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registerButton;
    [SerializeField] private TextMeshProUGUI statusText;

    private FirebaseAuth auth;

    private void Start()
    {
        InitializeFirebase();

        loginButton.onClick.AddListener(() => HandleAuth(isLogin: true));
        registerButton.onClick.AddListener(() => HandleAuth(isLogin: false));

        SetButtonsInteractable(false);
    }

    private async void InitializeFirebase()
    {
        var dependencyStatus = await FirebaseApp.CheckAndFixDependenciesAsync();
        if (dependencyStatus == DependencyStatus.Available)
        {
            auth = FirebaseAuth.DefaultInstance;
            statusText.text = "Firebase is ready.";
            SetButtonsInteractable(true);
        }
        else
        {
            statusText.text = "Firebase setup failed: " + dependencyStatus;
            Debug.LogError("Firebase setup failed: " + dependencyStatus);
        }
    }

    private async void HandleAuth(bool isLogin)
    {
        if (!ValidateInputs()) return;

        string email = emailInput.text;
        string password = passwordInput.text;

        try
        {
            FirebaseUser user;

            if (isLogin)
            {
                var result = await auth.SignInWithEmailAndPasswordAsync(email, password);
                user = result.User;

                // Check if email is verified
                if (!user.IsEmailVerified)
                {
                    statusText.text = "Please verify your email before logging in.\nA new verification email has been sent.";
                    await user.SendEmailVerificationAsync();
                    auth.SignOut();
                    return;
                }

                statusText.text = $"Logged in as: {user.Email}";
            }
            else
            {
                var result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
                user = result.User;

                await user.SendEmailVerificationAsync();
                statusText.text = $"Account created: {user.Email}\nVerification email sent.";
                Debug.Log($"Verification email sent to: {user.Email}");
            }
        }
        catch (System.Exception ex)
        {
            statusText.text = isLogin ? "Login failed." : "Registration failed.";
            Debug.LogError("Auth error: " + ex);
        }
    }

    private bool ValidateInputs()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            statusText.text = "Enter both email and password.";
            return false;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            statusText.text = "Invalid email format.";
            return false;
        }

        if (password.Length < 6)
        {
            statusText.text = "Password must be at least 6 characters.";
            return false;
        }

        return true;
    }

    private void SetButtonsInteractable(bool isEnabled)
    {
        loginButton.interactable = isEnabled;
        registerButton.interactable = isEnabled;
    }
}
