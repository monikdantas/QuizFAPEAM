using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class responder : MonoBehaviour {

	public int idTema;

	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;
	public Text respostaE;

	public string[] perguntas;
	public string[] alternativas;
	public string[] corretas;

	private string[] perguntas_respondidas = new string[6];
	private int contador_respondidas = 0;
	private int idPergunta;
	private float acertos;
	private float questoes;
	private float media;
	private int notaFinal;

	// Use this for initialization
	void Start () {
		idTema = PlayerPrefs.GetInt ("idTema");
		idPergunta = 0;
		questoes = perguntas.Length;

		proximaPergunta();
	}


	void proximaPergunta(){
		//idPergunta ++;
		int inicio = 0;
		int termino = 0;
		int idAl;
		int verificador = 1;
		string amostra;
		int aux = 1;
		int ind = 0;
		int comparar = 0;
		
		string[] alternativas_pergunta = new string[5];
		string[] alternativas_final = new string[5];
		string[] alternativas_especificas = new string[4];

		int[] idAleatorio = new int[] {0,1,2,3,4,5};
		
		while(verificador == 1){
			idAl = idAleatorio[Random.Range(0, 6)];

			idPergunta = idAl;

		//	print (PlayerPrefs.GetInt("acertosPerg"+idTema.ToString()+idAl.ToString()));

			if ((PlayerPrefs.GetInt("acertosPerg"+idTema.ToString()+idAl.ToString()))==1){
				verificador = 1;
				int contador = 0;
				for(int i=0; i < 6; i++){
					if(PlayerPrefs.GetInt("acertosPerg"+idTema.ToString()+i.ToString()) == 1){
						contador++;
					}
				}
				if (contador == 6){
					break;
				}
			}else{
				verificador = 0;
			}
		//	print ("Passou");
		}
		
		inicio = (idPergunta * 3) + idPergunta;
		termino = inicio +3;

		if (verificador == 0) {

			for (int i = inicio; i <= termino; i++) {
				alternativas_especificas [ind] = alternativas [i];
				ind++;
			}
			
			alternativas_pergunta [0] = corretas [idPergunta];

			for (int i=0; aux < 5; i++) {
				int cont = 0;

				amostra = alternativas_especificas [Random.Range (0, 4)]; // Um numero a mais do tamanho do array
				for (int j =0; j < aux; j++) {
					if (amostra == alternativas_pergunta [j]) {
						cont++;
					}
				}
				
				if (cont == 0) {
					alternativas_pergunta [aux] = amostra;
					aux++;
				}
			}
			
			aux = 0;
			int amostra2;
			
			for (int k=0; aux < 5; k++) {
				int cont = 0;
				amostra2 = Random.Range (0, 5); // Um numero a mais do tamanho do array

				if (alternativas_final [amostra2] != null) {
					cont++;
				}
				if (cont == 0) {
					alternativas_final [amostra2] = alternativas_pergunta [aux];
					aux++;
				}
			}
			
			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativas_final [0];
			respostaB.text = alternativas_final [1];
			respostaC.text = alternativas_final [2];
			respostaD.text = alternativas_final [3]; 
			respostaE.text = alternativas_final [4]; 
		
		}else {
			Application.LoadLevel("temas");
			//Application.LoadLevel("notaFinal");	 

		
		}
	}


	public void resposta(Text alternativa){
		if (alternativa.gameObject.GetComponent<Text> ().text == corretas [idPergunta]) {

			PlayerPrefs.SetInt("acertosPerg"+idTema.ToString()+idPergunta.ToString(),1);

			acertos = PlayerPrefs.GetInt ("acertos" + idTema.ToString ()) + 1;;

			print("Salvo -> "+PlayerPrefs.GetInt("acertosPerg"+idTema.ToString()));
			print("Acertos -> "+acertos);
			media = 10 * (acertos/questoes);
			notaFinal = Mathf.RoundToInt(media); // Calcula a media com base no percentual de acertos
			print ("nota "+notaFinal);
		
			if(notaFinal > PlayerPrefs.GetInt("notaFinal"+idTema.ToString())){
				PlayerPrefs.SetInt("notaFinal"+idTema.ToString(),notaFinal);
				PlayerPrefs.SetInt("acertos"+idTema.ToString(),(int)acertos);
			}
			
			PlayerPrefs.SetInt("notaFinalTemp"+idTema.ToString(),notaFinal);
			PlayerPrefs.SetInt("acertosTemp"+idTema.ToString(),(int)acertos);

			Application.LoadLevel("telaSucesso");
		//	contador_respondidas ++;
		} else {
			Application.LoadLevel("telaErro");
		}
		//proximaPergunta();
	}
}
