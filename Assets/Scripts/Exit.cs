using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Image[] heartImages;
    private int m_currentPlayer;
    private float m_heartFill;
    private float m_totalheartFill;
    void OnTriggerEnter(Collider other)
    {
        m_heartFill = other.gameObject.GetComponent<BlockHeadMove>().heartFillAmount;
        heartImages[m_currentPlayer].fillAmount = m_heartFill;
        m_totalheartFill += m_heartFill;
        m_currentPlayer += 1;
        if(m_currentPlayer == heartImages.Length)
        {
            FinishGame();
        }

    }
    public Image endHeart;
    public GameObject endScreen;
    void FinishGame()
    {
        endScreen.SetActive(true);
        endHeart.fillAmount = m_totalheartFill / heartImages.Length;
        print("Game Finished");
    }

}
