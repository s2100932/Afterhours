using UnityEngine;

public class PitfallLogic : MonoBehaviour
{
    
    [Header("Optional UI")]
    public GameObject gameOverUI;

     [Header("Reference to the Player")]
    public Transform player;

    private bool gameOver = false;
    void OnTriggerExit(Collider other)
    {
        if (gameOver) return;

        if (other.CompareTag("Player"))
        {
            GameOver();
        }
    }
    
    public void GameOver()
    {
        gameOver = true;

        Debug.Log("GAME OVER!");

       
        Rigidbody prb = player.GetComponent<Rigidbody>();
        if (prb != null)
            prb.linearVelocity = Vector3.zero;

      
        Rigidbody erb = GetComponent<Rigidbody>();
        if (erb != null)
            erb.linearVelocity = Vector3.zero;

        
        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        // Optional: Restart after 2 seconds
        // Invoke(nameof(RestartScene), 2f);
    }

}
