using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	int rupee_count = 0;
	int key_count = 0;
	int bomb_count = 0;
	int heart_count = 6;
    int getset = 0;

    public GameObject GameOverPane;
    public GameObject WinPane;

    //Rupees
    public void AddRupees(int num_rupees){
		rupee_count += num_rupees;
        if (rupee_count >= 19)
        {
            WinPane.SetActive(true);
        }
	}

	public int GetRupees(){
		return rupee_count;
	}

	public void SubtractRupees(int num_rupees){
		if ((rupee_count - num_rupees < 0)) {
			//can not use bombs
		} else {
			rupee_count -= num_rupees;
		}
	}

	//Hearts
	public void AddHearts(int num_hearts){
		if ((heart_count + num_hearts >= 6)) {
			heart_count = 6;
		} else {
			heart_count += num_hearts;
		}
	}

	public void SubtractHearts(int num_hearts){
		if ((heart_count - num_hearts <= 0)) {
			GameOverPane.SetActive (true);
			//game Over
		} else {
			heart_count -= num_hearts;
		}
	}

	public int GetHearts(){
		return heart_count;
	}

	//Keys
	public void AddKeys(int num_keys){
		key_count += num_keys;
	}

	public void SubtractKeys(int num_keys){
		if ((key_count - num_keys < 0)) {
			//can not opeon the door
		} else {
			key_count -= num_keys;
		}
	}

	public int GetKeys(){
		return key_count;
	}

	//Bombs
	public void AddBombs(int num_bombs){
		bomb_count += num_bombs;
	}

	public void SubtractBombs(int num_boms){
		if ((bomb_count - num_boms < 0)) {
			//can not use bombs
		} else {
			bomb_count -= num_boms;
		}
	}

	public int GetBombs(){
		return bomb_count;
	}



}
