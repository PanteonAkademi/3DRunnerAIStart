using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
	public int score;
	public TextMeshProUGUI CoinText;

	public void AddCoin()
	{
		score++;
		CoinText.text = "Score: " + score.ToString();
	}
}
