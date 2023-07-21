using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    [SerializeField] private TrigerPlayer _trigerPlayer;

    private void OnEnable()
    {
        _trigerPlayer.PlayerCollided += OnReload;
    }

    private void OnDisable()
    {
        _trigerPlayer.PlayerCollided -= OnReload;
    }
    private void OnReload(bool inCollision)
    {
        if (inCollision == true)
        {
            var csene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(csene.name);
        }
    }
}
