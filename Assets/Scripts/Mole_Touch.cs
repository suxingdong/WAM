using UnityEngine;
using System.Collections;
public class Mole_Touch : MonoBehaviour
{

    public AudioSource audio;
    Animator _anim;
	bool touch_possible;			//for checking AnimationState.
	public AudioClip[] audios;		//for playing each Sound.
	Mole_Manager mm;			    //for counting the CatchCount
    bool BedMole;

	void Start ()
	{
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        _anim = GetComponent<Animator> ();	
		mm =FindObjectOfType<Mole_Manager>();

	}
	
	//Mole appers
	public void Open ()
	{		
		touch_possible = true;			//Player can catch this.
		audio.clip = audios [0];			//Set Sound .
		audio.Play ();						//Play Sound .
        if (mm.Play == false)
        {
            mm.GO();
        }
	}
	
	//Mole is avoiding.
	public void Close ()
	{		
		touch_possible = false;	
	}
	
	//Perfectly, Hole is Empty.
	public IEnumerator PerfectClose ()
	{		
		touch_possible = false;	
		yield return new WaitForSeconds(Random.Range(0.5f,3.5f)); 	//Wait RandomTime.

		int A = Random.Range(0,100);

		if(A>=30){
		   BedMole=true;
		   _anim.SetBool ("BedMole",true);	
		}else{
			_anim.SetBool ("BedMole",false);	
		   BedMole=false;
		}
		_anim.SetTrigger ("Open");									//Go Again, Mole!!
	}
	
	//if you catch this mole,
	public void OnMouseDown ()
	{		
		if (touch_possible == true) {
			_anim.SetTrigger ("Touch");			        // 1.Play Catch Animation.
			touch_possible = false;				        	// 2.Prevent Double Click.
			audio.clip = audios [1];			       			// 3.Set Sound .
			audio.Play ();						       			// 4.Play Sound .
			if(mm!=null)mm.CatchCount_Up(BedMole);		// 5.Manager Count up.
		}	
	}
}
