using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    [SerializeField] private TrigerPlayer _trigerPlayer;

    private void OnEnable()
    {
        _trigerPlayer.PlayerCollided += Reload;
    }

    private void OnDisable()
    {
        _trigerPlayer.PlayerCollided -= Reload;
    }
    private void Reload(bool inCollision)
    {
        if (inCollision == true)
        {
            var csene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(csene.name);
        }
    }
}
