using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogData dialog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogUI.Instance.StartDialog(dialog);
        }
    }
}
