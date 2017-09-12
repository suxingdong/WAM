using UnityEngine;
using System.Collections;

public class Mole_Manager : MonoBehaviour {

	public GUIText catchcount_txt;
	public GUIText _time_txt;
    public AudioSource audio;
    [HideInInspector]
	public int Bed_Count;
	[HideInInspector]
	public int Good_Count;

	public float limitTime = 20f;
	public GameObject End_GUI;
    public GUIText Final_BedCount;
    public GUIText Final_GoodCount;
    public GUIText Final_Score;
    public GameObject Red_Screen;

    public AudioClip GoSound;
    [HideInInspector]
    public bool Play;
	bool End;
		
	void Update () {
		
		//if Game isn't End,
		if(limitTime>=0 && End==false && Play==true){
			catchcount_txt.text = string.Format("{0}",Bed_Count);   //Write CatchCount to GUIText.
			limitTime-=Time.deltaTime;								  //Time flow.
			_time_txt.text = string.Format("{0:N2}",limitTime);		  //Write LimitTime to GUIText.	
		//if Time is over,
		}

        if(limitTime<=0 && End==false){
			_time_txt.text = "0";	
			Game_End();													
		}
	}

    //First Mole Open
    public void GO()
    {
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        Play = true;
        audio.clip = GoSound;
        audio.Play();
    }

    //Function from Mole Script.
	public void CatchCount_Up(bool Bed){

        if (Bed)
        {
            Bed_Count += 1;
        }
        else if (Bed == false)
        {
            Good_Count += 1;
            Red_Screen.SetActive(false);
            Fade f = Red_Screen.GetComponent<Fade>();
            f.FadeIn_ing = true;
            Red_Screen.SetActive(true);
        }
	}

    //Time Limit Finished
	public void Game_End(){
		End=true;
        Final_BedCount.text = string.Format("{0}", Bed_Count);                     //Write Final Bed_Count to GUIText.
        Final_GoodCount.text = string.Format("{0}", Good_Count);                   //Write Final Good_Count to GUIText.
        Final_Score.text = string.Format("{0}", Bed_Count*100 + Good_Count*-1000); //Final Score calculate
		End_GUI.SetActive(true);
	}

}
