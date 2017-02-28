using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour 
{
	public BlockHeadMove[] blockHeadScripts; 

	public void BeginGame()
	{
		for (int i = 0; i < blockHeadScripts.Length; i++) 
		{
			blockHeadScripts [i].startMoving = true;
		}
	}
}
