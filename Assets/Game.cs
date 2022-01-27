using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    
    private void Start()
    {
        Subscribe();
    }
    
    private void Subscribe() => _bird.CollideWithPipe += Restart;
    private void Restart() => SceneManager.LoadScene(0);
}
