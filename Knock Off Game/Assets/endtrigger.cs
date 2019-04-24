using UnityEngine;

public class endtrigger : MonoBehaviour
{
    public GameManage gameManage;
    private void OnTriggerEnter(Collider other)
    {
        gameManage.CompleteLevel();
    }
}
