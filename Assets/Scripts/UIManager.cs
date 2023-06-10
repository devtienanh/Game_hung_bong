using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText; // Tham chiếu đến thành phần Text để hiển thị điểm số

    public GameObject gameoverPanel; // Tham chiếu đến GameObject của bảng kết thúc trò chơi

    public void SetScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt; // Cập nhật điểm với chuỗi được cung cấp
        }
    }

    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow); // Hiển thị hoặc ẩn panel kết thúc trò chơi dựa trên giá trị boolean được cung cấp
        }
    }
}
