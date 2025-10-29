using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject commandPanel;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button skillButton;
    [SerializeField] private Button defendButton;

    private BattleManager battleManager;

    private void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();

        // ボタンのイベント登録
        attackButton.onClick.AddListener(() => OnCommandSelected("Attack"));
        skillButton.onClick.AddListener(() => OnCommandSelected("Skill"));
        defendButton.onClick.AddListener(() => OnCommandSelected("Defend"));

        commandPanel.SetActive(false);
    }

    public void ShowCommands()
    {
        commandPanel.SetActive(true);
    }

    public void HideCommands()
    {
        commandPanel.SetActive(false);
    }

    private void OnCommandSelected(string command)
    {
        HideCommands();
        battleManager.OnPlayerCommandSelected(command);
    }
}
