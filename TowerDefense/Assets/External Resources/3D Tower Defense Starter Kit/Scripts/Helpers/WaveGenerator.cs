/*  This file is part of the "3D Tower Defense Starter Kit" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//custom wave editor window
public class WaveGenerator : MonoBehaviour
{
	[SerializeField]
	WaveManager waveScript;  //manager reference
	
	
	static void Init()
	{
		
	}
	
	
	void OnStart()
	{
		GameObject wavesGO = GameObject.Find("Wave Manager");
		waveScript = wavesGO.GetComponent<WaveManager>();
		
		
		for (int x = 0; x < 10; x++) 
		{
			//create new wave option
			WaveOptions newWave = new WaveOptions();
			//initialize first row / creep of the new wave
			newWave.enemyPrefab.Add(null);
			int enemyCount = (x + 10) + x * 2;
			newWave.enemyCount.Add(enemyCount);
			newWave.path.Add(null);
			//add new wave option to wave list
			waveScript.options.Add(newWave);
		}
		
	}
}