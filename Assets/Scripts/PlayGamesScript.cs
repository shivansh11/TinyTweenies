using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGamesScript : MonoBehaviour {
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
	}

    void SignIn() {
        Social.localUser.Authenticate(success => { });
    }

    public static void UnlockAchievement(string id) {
        Social.ReportProgress(id, 100, success => { });
    }

    public static void AddScoreToLeaderboard (string leaderboardID, long score) {
        Social.ReportScore(score, leaderboardID, success => { });
    }

    public static void ShowLeaderboard() {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard_leaderboard);
    }
}
