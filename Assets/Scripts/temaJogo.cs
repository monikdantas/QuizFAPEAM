using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class temaJogo : MonoBehaviour {

    public Button btnPlay;
	public Button[] btnTema;
    public Text txtNomeTema;
    public GameObject infoTema;
    public Text txtInfoTema;
    public GameObject estrela1;
	public GameObject estrela2;
	public GameObject estrela3;

	public string[] nomeTema;
	public int numeroQuestoes;
	private int idTema;


	// Use this for initialization
	void Start () {
		idTema = 0;
		txtNomeTema.text = nomeTema[idTema];
		txtInfoTema.text = "Você acertou X de X questões";
		infoTema.SetActive (false);
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);
		btnPlay.interactable = false;
	
		int contador_todos = 0;

		for (int j=1; j < 7; j++) {
			int contador_tema = 0;
			for (int i=0; i < 6; i++) {
				if (PlayerPrefs.GetInt ("acertosPerg" + j.ToString () + i.ToString ()) == 1) {
					contador_tema++;
				}
			}
			if (contador_tema == 6) {
				contador_todos++;
				btnTema[j-1].interactable = false;
			}
		}
		if (contador_todos == 6){
			Application.LoadLevel ("telaFinal");
		}
	
	}

	public void selecioneTema (int i) {
		idTema = i;
		PlayerPrefs.SetInt ("idTema", idTema);
		txtNomeTema.text = nomeTema [idTema];

		int notaFinal = PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ());
		int acertos = PlayerPrefs.GetInt ("acertos" + idTema.ToString ());;

		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);

		if (notaFinal == 10) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);
		} else if (notaFinal >= 7) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false);
		} else if (notaFinal >= 3) {
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);
		}


		txtInfoTema.text = "Você acertou "+acertos.ToString()+" de "+numeroQuestoes.ToString()+" questões";
		infoTema.SetActive (true);
		btnPlay.interactable = true;
	
	}

	public void jogar(){
		Application.LoadLevel ("T"+idTema.ToString());

	}
}
