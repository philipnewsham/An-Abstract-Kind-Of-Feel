using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Image[] heartImages;
    private int m_currentPlayer;
    void OnTriggerEnter(Collider other)
    {
        heartImages[m_currentPlayer].fillAmount = other.gameObject.GetComponent<BlockHeadMove>().heartFillAmount;
        m_currentPlayer += 1;
        if(m_currentPlayer == heartImages.Length)
        {
            FinishGame();
        }

    }

    void FinishGame()
    {
        print("Game Finished");
    }

}
