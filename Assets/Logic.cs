using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//ii arat lui cata cum functioneaza github
public class Logic : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    [ContextMenu("Increase score")]
    public void Addscore()
    {
        playerScore = playerScore + 1;
        scoreText.text= "Apples eaten:"+playerScore.ToString();
    }    
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
