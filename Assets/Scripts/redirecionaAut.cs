using UnityEngine;
using System.Collections;

public class redirecionaAut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("redirecionando..");
		Invoke ("carregaIntroducao", 2);
	}

	public void carregaIntroducao()
	{
		Application.LoadLevel("introducao");
	}
	

}
