using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class RecordsManager : MonoBehaviour
{
    private static string _fileName = "top5.txt";
    public Text txtPontos;
    public Text txtTop5Name1, txtTop5Score1;
    public Text txtTop5Name2, txtTop5Score2;
    public Text txtTop5Name3, txtTop5Score3;
    public Text txtTop5Name4, txtTop5Score4;
    public Text txtTop5Name5, txtTop5Score5;
    public string pathApp;

    //Método que cria o arquivo txt caso ele não exista, Void por que não retorna nada.
    private void VerifyRecordsFile()
    {
        if (!File.Exists(pathApp + _fileName)) { //Verifica se o arquivo existe, retorna true, neguei a condição, então se o arquivo não existir ele entra no IF.

            string texto = "1;Aaaaa;50\n2;Bbbbb;40\n3;Ccccc;30\n4;Ddddd;20\n5;Eeeee;10";
            System.IO.File.WriteAllText(pathApp + _fileName, texto);

        }
    }

    

    // Coloca o valor do Recorde de Pontos na tela
    private void SetGameRecordText() {
        VerifyRecordsFile();
        StreamReader streamR = new StreamReader(pathApp + _fileName);
        string[] dadosLinhaArquivo = streamR.ReadLine().Split(';');
        /* Debug.Log("Recorde antes do início");
        foreach (string item in dadosLinhaArquivo)
        {
            Debug.Log(item.ToString());
        } */
        txtPontos.text = dadosLinhaArquivo[2];
    }

    public void SetRecords(string nomeJogo, int pontuacaoJogo) {

        VerifyRecordsFile(); //Chama nosso método que cria o arquivo caso ele não exista.

        StreamReader streamR = new StreamReader(pathApp + _fileName);

        string linhaAtual;
        string linhaNova;
        string newRecords = "";
        int posicao = 1;
        string novoNome = nomeJogo;
        int novaPontuacao = pontuacaoJogo;

        while(streamR.EndOfStream == false) {

            linhaAtual = streamR.ReadLine();
            linhaNova = posicao.ToString() + ";" + novoNome + ";" + novaPontuacao.ToString();
            
            string[] dadosLinhaArquivo = linhaAtual.Split(';');

            /* Debug.Log("Recorde no Arquivo:");
            Debug.Log("Posição: " + dadosLinhaArquivo[0]);
            Debug.Log("Nome: " + dadosLinhaArquivo[1]);
            Debug.Log("Pontos: " + dadosLinhaArquivo[2]);
            
            Debug.Log("Pontuação no jogo: " + novaPontuacao.ToString()); */

            int scoreInRecords = int.Parse(dadosLinhaArquivo[2]);
            

            if (novaPontuacao < scoreInRecords) {
                
                newRecords += linhaAtual;

            } else {

                newRecords += linhaNova;
                novaPontuacao = int.Parse(dadosLinhaArquivo[2]);
                novoNome = dadosLinhaArquivo[1];

            }

            if (posicao <= 4) newRecords += "\n";
            posicao++;

            /* Debug.Log("Novo arquivo de Recordes: " + newRecords);
            Debug.Log("Pontuação para próxima linha:" + novaPontuacao.ToString());
            Debug.Log("Nome para a próxima linha:" + novoNome.ToString());

            Debug.Break(); */

        }
        streamR.Close(); //Sempre que terminarem de ler e gravar em um arquivo é necessário fecha-lo, isto evita mutios erros.

        // streamW_new.Close();

        File.Delete(pathApp + _fileName);
        System.IO.File.WriteAllText(pathApp + _fileName, newRecords);
        // File.Copy(Application.persistentDataPath + "/" + _fileNameNew, Application.persistentDataPath + "/" + _fileName);
        // File.Delete(Application.persistentDataPath + "/" + _fileNameNew);
 
        // StreamWriter streamW = new StreamWriter(Application.persistentDataPath + "/" + _fileName);
        /*Criamos um novo objeto do tipo StreamWriter, passamos o nome do nosso arquivo.
         * o true informa que deve continuar gravando no arquivo, isto quer dizer que ele não vai limpar e escrever tudo de novo.
         * Se remover o true toda vez que for gravar uma informação nosso arquivo será limpado e as informações anteriores serão perdidas.
         */
 
        // streamW.WriteLine("Nome: " + nome + "| E-mail: " + email + "| Descrição: " + descricao);
        /*Através do objeto streamW acessamos o método WriteLine e passamos os textos que queremos gravar.
         * 
         */
    }

    public string ReadRecordsFile() {
 
        string text = ""; //Criamos uma variável que vai armazenar o resultado da nossa consulta no arquivo.

        VerifyRecordsFile(); //Chamamos novamente nosso método, caso o arquivo não exista ele cria, pois se o arquivo não existir e ele tentar ler vai travar o sistema
            
        StreamReader streamR = new StreamReader(pathApp + _fileName); //Criamos um novo objeto que acessa os métods de leitura, passamos o arquivo que quremos ler.

        while(streamR.EndOfStream == false){
            text += streamR.ReadLine() + ";";
        }

        //text = streamR.ReadLine(); // Variavel Text recebe a leitura do arquivo.
        /*Neste exemplo ele vai ler apenas a primeira linha.
            * Caso queria retornar todas, basta usar.
            * 
            while(streamR.EndOfStream == false){
                text += streamR.ReadLine();
            }
            * 
            * Se for retornar todos os valores, o recomendavel é que grave cada linha em um vetor.
            */

        streamR.Close(); // Finaliza o uso do nosso arquivo.

        return text; //Retorna nossa variável com o texto do arquivo.
    }

    public void SetTop5Board(string recordsLine) {

        string[] recordsArray = recordsLine.Split(';');
        txtTop5Name1.text = recordsArray[1];
        txtTop5Score1.text = recordsArray[2];
        txtTop5Name2.text = recordsArray[4];
        txtTop5Score2.text = recordsArray[5];
        txtTop5Name3.text = recordsArray[7];
        txtTop5Score3.text = recordsArray[8];
        txtTop5Name4.text = recordsArray[10];
        txtTop5Score4.text = recordsArray[11];
        txtTop5Name5.text = recordsArray[13];
        txtTop5Score5.text = recordsArray[14];

    }

    public void ResetRecords () {

        File.Delete(pathApp + _fileName);
        VerifyRecordsFile();
        SceneManager.LoadScene ("Top5");

    }

    public void TestRecordsFile() {

        VerifyRecordsFile(); //Chamamos novamente nosso método, caso o arquivo não exista ele cria, pois se o arquivo não existir e ele tentar ler vai travar o sistema
            
        StreamReader streamR = new StreamReader(pathApp + _fileName);
        //Criamos um novo objeto que acessa os métods de leitura, passamos o arquivo que quremos ler.

        Debug.Log("Recordes:");

        int x = 1;

        while(streamR.EndOfStream == false){
            Debug.Log(x.ToString() + " - " + streamR.ReadLine());
            x++;
        }

        streamR.Close(); // Finaliza o uso do nosso arquivo.

    }

    // Start is called before the first frame update
    void Start() {

        if (SceneManager.GetActiveScene().name == "Gameplay") SetGameRecordText();
        if (SceneManager.GetActiveScene().name == "Top5") SetTop5Board(ReadRecordsFile());

    }

    // Update is called once per frame
    void Update() {
        
    }

    void Awake() {
        pathApp = Application.persistentDataPath + Path.DirectorySeparatorChar;
    }
}