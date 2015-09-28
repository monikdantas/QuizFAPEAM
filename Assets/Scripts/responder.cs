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
	public Text infoRespostas;

	public string[] perguntas;
	public string[] alternativas;
	public string[] corretas;

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
		
		string amostra;
		int aux = 1;

		string[] alternativas_pergunta = new string[5];
		string[] alternativas_final = new string[5];

		alternativas_pergunta[0] = corretas[idPergunta];


		for (int i=0 ; aux < 5; i++){
			int cont = 0;
			amostra = alternativas[Random.Range(0, 64)]; // Um numero a mais do tamanho do array
			//print (i+" - "+amostra+" - "+aux);
			for(int j =0 ; j < aux; j++){
				if (amostra == alternativas_pergunta[j]){
				//	print("Repetido");
					cont++;
				}
			}
		
			if (cont == 0){
				alternativas_pergunta[aux] = amostra;
				print("Inseriu "+ alternativas_pergunta[aux]);
				aux++;
			}
		}

		aux = 0;
		int amostra2;

		for(int k=0 ; aux < 5; k++){
			int cont = 0;
			amostra2 = Random.Range(0, 5); // Um numero a mais do tamanho do array
		//	print (k+" - "+amostra2+" - "+aux);
		//	print (alternativas_final[amostra2]);

			if (alternativas_final[amostra2] != null){
			//	print("Repetido");
				cont++;
			}
		
			if (cont == 0){
				alternativas_final[amostra2] = alternativas_pergunta[aux];
				aux++;
			}
		}

		pergunta.text = perguntas [idPergunta];
		respostaA.text = alternativas_final [0];
		respostaB.text = alternativas_final [1];
		respostaC.text = alternativas_final [2];
		respostaD.text = alternativas_final [3]; 
		respostaE.text = alternativas_final [4]; 

		infoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";
	}

	public void resposta(Text alternativa){
		//Debug.Log ( alternativa.gameObject.GetComponent<Text>().text);

		//Debug.Log ( corretas[idPergunta]);
		if(alternativa.gameObject.GetComponent<Text>().text == corretas[idPergunta]){
			acertos += 1;
		}
		proximaPergunta();
	}

	void proximaPergunta(){
		idPergunta ++;

		if (idPergunta <= (questoes - 1)) {

			string amostra;
			int aux = 1;
			
			string[] alternativas_pergunta = new string[5];
			string[] alternativas_final = new string[5];
			
			alternativas_pergunta[0] = corretas[idPergunta];

			print ("______________________________");
			
			for (int i=0 ; aux < 5; i++){
				int cont = 0;
				amostra = alternativas[Random.Range(0, 64)]; // Um numero a mais do tamanho do array
				//print (i+" - "+amostra+" - "+aux);
				for(int j =0 ; j < aux; j++){
					if (amostra == alternativas_pergunta[j]){
						//	print("Repetido");
						cont++;
					}
				}
				
				if (cont == 0){
					alternativas_pergunta[aux] = amostra;
					print("Inseriu "+ alternativas_pergunta[aux]);
					//print("Inseriu "+ alternativas_pergunta[aux]);
					aux++;
				}
			}
			
			aux = 0;
			int amostra2;
			
			for(int k=0 ; aux < 5; k++){
				int cont = 0;
				amostra2 = Random.Range(0, 5); // Um numero a mais do tamanho do array
				//	print (k+" - "+amostra2+" - "+aux);
				//	print (alternativas_final[amostra2]);
				
				if (alternativas_final[amostra2] != null){
					//	print("Repetido");
					cont++;
				}
				
				if (cont == 0){
					alternativas_final[amostra2] = alternativas_pergunta[aux];
					//print("Inseriu"+ alternativas_pergunta[aux]);
					aux++;
				}
			}
			
			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativas_final [0];
			respostaB.text = alternativas_final [1];
			respostaC.text = alternativas_final [2];
			respostaD.text = alternativas_final [3]; 
			respostaE.text = alternativas_final [4]; 
		
			infoRespostas.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas.";
		} else {

			media = 10 * (acertos/questoes);
			notaFinal = Mathf.RoundToInt(media); // Calcula a media com base no percentual de acertos
			print (notaFinal);
			if(notaFinal > PlayerPrefs.GetInt("notaFinal"+idTema.ToString())){
				PlayerPrefs.SetInt("notaFinal"+idTema.ToString(),notaFinal);
				PlayerPrefs.SetInt("acertos"+idTema.ToString(),(int)acertos);
			}

			PlayerPrefs.SetInt("notaFinalTemp"+idTema.ToString(),notaFinal);
			PlayerPrefs.SetInt("acertosTemp"+idTema.ToString(),(int)acertos);

			Application.LoadLevel("notaFinal");	 // Arredonda a media
		
		}
	
	}

}
