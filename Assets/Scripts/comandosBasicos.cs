using UnityEngine;
using System.Collections;

public class comandosBasicos : MonoBehaviour {

	/*public int SceneId;
	public float delay;*/
    public void carregaCena(string nomeCena) {
        Application.LoadLevel(nomeCena);
    }

	public void resetarPontuacoes(){
		PlayerPrefs.DeleteAll ();
	}

	public void redirecionar()
	{
		Invoke ("carregaIntroducao", 2);
	}
	
	public void carregaIntroducao()
	{
		Application.LoadLevel("introducao");
	}

/*	IEnumerator Start()
	{
		yield return new WaitForSeconds (delay);
		//Debug.Log (Application.loadedLevel);
		Application.LoadLevel (SceneId);
	}*/
}
