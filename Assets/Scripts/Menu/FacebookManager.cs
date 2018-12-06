using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System.Collections;

public class FacebookManager : MonoBehaviour {

    private static FacebookManager _instance;

    public static FacebookManager Instance {
        get{
            if(_instance == null){
                GameObject fbm = new GameObject("FBManager");
                fbm.AddComponent<FacebookManager>();
            }

            return _instance;
        }
    }

    public bool IsLoggedIn { get; set; }
    public string ProfileName { get; set; }
    public Sprite ProfilePic { get; set; }

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    public void FBInit() {
        if (!FB.IsInitialized) {
            FB.Init(() => {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.Log("Couldn't initialize fb!");
            }, isGameShown => {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        } else
            FB.ActivateApp();

        if (FB.IsLoggedIn)
            IsLoggedIn = true;

        if (FB.IsLoggedIn && ProfilePic == null)
            GetProfile();
    }


    public void GetProfile() {
        FB.API("/me?fields=first_name", HttpMethod.GET, GetProfileName);
        FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, GetProfilePic);
    }

    void GetProfileName(IResult result) {
        if (result.Error == null)
            ProfileName = result.ResultDictionary["first_name"].ToString();
        else 
            Debug.Log("Error in getting Username");  
    }

    void GetProfilePic(IGraphResult result) {
        if (result.Texture != null)
            ProfilePic = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        else 
            Debug.Log("Error in getting Profile pic");
    }
}

