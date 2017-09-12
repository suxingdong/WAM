using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {
	
	public AudioClip[] Sound;
    public AudioSource audio;

    //0 - 두더지 등장할 때의 소리
    //1 - 나쁜 두더지 잡힐때의 소리
    //2 - 좋은 두더지 잡힐때의 소리

    public void SoundPlay(int Sound_Number){
      if(audio ==null)
        {
            audio = GetComponent<AudioSource>();
         }

        audio.clip = Sound[Sound_Number];		
		audio.Play();
	}
}
