using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using LootLocker.Requests;

public class Leaderboard : MonoBehaviour
{
    int leaderboardID = 19961;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    string leaderboardKey = "globalHighscore";
    // Start is called before the first frame update
    void Start()
    {
    }

    public IEnumerator SubmitScoreRoutine(int scoreToUpload) {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardKey, (response) => {
            if (response.success) {
                Debug.Log("Successfully uploaded score");
                done = true;
            } else {
                Debug.Log("Failed");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator FetchTopHighScoresRoutine() {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) => {
            if (response.success) {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++) {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "") {
                        tempPlayerNames += members[i].player.name;
                    } else {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            } else {
                Debug.Log("Failed");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
