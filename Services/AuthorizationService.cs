using Microsoft.AspNetCore.Components;
using Blazored.SessionStorage;

// Ok... this is all terrible. 
//  The plan was to map all the passwords to a DB, but due to a lack of resources
//  i.e. I wasn't allowed to make a back end service on my account to access the DB
//  I setup, I didn't have a lot of options so I just stuck the user id and pass in
//  a local session.
//  
//  ...don't look at me like that. I know what I did.

public class AuthorizationService
{
    private readonly NavigationManager _navigationManager;
    private bool _isAuthenticated = false;
    private string storedUsername;
    private string storedPassword;

    private readonly ISessionStorageService _sessionStorage;

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

    public AuthorizationService(NavigationManager navigationManager, ISessionStorageService sessionStorage)
    {
        _navigationManager = navigationManager;
        _sessionStorage = sessionStorage;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        _isAuthenticated = false;
        if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            storedUsername = await _sessionStorage.GetItemAsync<string>("username");
            storedPassword = await _sessionStorage.GetItemAsync<string>("password");
            if(username == storedUsername && password == storedPassword)
                _isAuthenticated = true;
        }
        return _isAuthenticated;
    }

    public Task LogoutAsync()
    {
        _isAuthenticated = false;
        return Task.CompletedTask;
    }
}