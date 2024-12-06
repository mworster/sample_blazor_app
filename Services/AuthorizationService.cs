using Microsoft.AspNetCore.Components;

public class AuthorizationService
{
    private readonly NavigationManager _navigationManager;
    private bool _isAuthenticated = false;

    public bool IsLoggedIn
    {
        get { return _isAuthenticated; }
        set
        {
            _isAuthenticated = value;
            if(!_isAuthenticated)
            {
                _navigationManager.NavigateTo("/login", true);
            }
        }
    }

    public AuthorizationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        _isAuthenticated = true;
        return true;
    }

    public Task LogoutAsync()
    {
        _isAuthenticated = false;
        return Task.CompletedTask;
    }
}