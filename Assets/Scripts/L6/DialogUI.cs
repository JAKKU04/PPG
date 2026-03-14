using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public static DialogUI Instance;

    public GameObject panel;
    public TextMeshProUGUI dialogText;
    public Transform optionsParent;
    public Button optionButtonPrefab;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void StartDialog(DialogData dialog)
    {
        panel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialogText.text = dialog.npcText;

        foreach (Transform child in optionsParent)
            Destroy(child.gameObject);

        foreach (var option in dialog.options)
        {
            Button btn = Instantiate(optionButtonPrefab, optionsParent);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = option.optionText;

            btn.onClick.AddListener(() =>
            {
                if (option.nextDialog != null)
                    StartDialog(option.nextDialog);
                else
                    EndDialog();
            });
        }
    }

    public void EndDialog()
    {
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
