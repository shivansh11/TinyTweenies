using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class FacebookScript : MonoBehaviour {

    public GameObject FBNameText;
    public GameObject FBUserImage;
    public GameObject FBButton;
    public GameObject GiftButton;
    public GameObject NoInternerText;
    public GameObject InvitePanel;
    public GameObject RewardPanel;

    public void Awake() {
        if (!PlayerPrefs.HasKey("Invited"))
            PlayerPrefs.SetInt("Invited", 0);

        FacebookManager.Instance.FBInit();

        if (FB.IsLoggedIn && Application.internetReachability != NetworkReachability.NotReachable) {
            if (FacebookManager.Instance.ProfilePic == null)
                FacebookManager.Instance.GetProfile();
            DisplayProfileName();
            DisplayProfilePic();
        } else {
            StartCoroutine("CheckForAlreadyLoggedIn");
        }
    }

    IEnumerator CheckForAlreadyLoggedIn() {
        //This body will only execute when the user already did a login previously and has reopened the app.
        yield return new WaitForSeconds(1.0f);
        if (FB.IsLoggedIn && Application.internetReachability != NetworkReachability.NotReachable) {
            FacebookManager.Instance.GetProfile();
            DisplayProfileName();
            DisplayProfilePic();
        } else {
            FBButton.SetActive(true);
        }
    }

    #region Login / Logout
    public void FacebookLogin() {
        if (Application.internetReachability == NetworkReachability.NotReachable)
            NoInternerText.GetComponent<TextFader>().Fade();
        else {
            var permissions = new List<string>() { "public_profile", "email", "user_friends" };
            FB.LogInWithReadPermissions(permissions, AuthCallback);
        }
        
    }

    private void AuthCallback(ILoginResult result) {
        if (FB.IsLoggedIn) {
            FacebookManager.Instance.IsLoggedIn = true;
            FBButton.SetActive(false);
            FacebookManager.Instance.GetProfile();
            DisplayProfileName();
            DisplayProfilePic();
        }
    }

    void DisplayProfileName() {
        if (FacebookManager.Instance.ProfileName != null) {
            FBNameText.GetComponent<Text>().text = FacebookManager.Instance.ProfileName;
            FBNameText.SetActive(true);
        } else {
            StartCoroutine("WaitForProfileName");
        }
    }

    void DisplayProfilePic() {
        if (FacebookManager.Instance.ProfilePic != null) {
            FBUserImage.GetComponent<Image>().sprite = FacebookManager.Instance.ProfilePic;
            FBUserImage.SetActive(true);
            if (PlayerPrefs.GetInt("Invited") == 0)
                GiftButton.SetActive(true);
        } else {
            StartCoroutine("WaitForProfilePic");
        }
    }

    public void FacebookLogout() {
        FB.LogOut();
    }
    #endregion

    IEnumerator WaitForProfileName() {
        while (FacebookManager.Instance.ProfileName == null)
            yield return null;

        FBNameText.GetComponent<Text>().text = FacebookManager.Instance.ProfileName;
        FBNameText.SetActive(true);
    }

    IEnumerator WaitForProfilePic() {
        while (FacebookManager.Instance.ProfilePic == null)
            yield return null;

        FBUserImage.GetComponent<Image>().sprite = FacebookManager.Instance.ProfilePic;
        FBUserImage.SetActive(true);
        if (PlayerPrefs.GetInt("Invited") == 0)
            GiftButton.SetActive(true);
    }

    public void AppRequest() {
        int invites = 0;
        InvitePanel.SetActive(false);
        FB.AppRequest("Bring them in!", null, null, null, null, null, null, delegate (IAppRequestResult result) {
            if (result.Error == null) {
               invites = result.To.Count();
                if (invites >= 5) {
                    PlayerPrefs.SetInt("Invited", 1);
                    RewardPanel.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);
                    RewardPanel.SetActive(true);
                    RewardPanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
                    GiftButton.SetActive(false);
                }
            }
        });
    }
}