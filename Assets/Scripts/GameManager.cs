using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public GameObject contentConversation;
    public GameObject notificationBar;
    public GameObject rightMessagePrefab;
    public GameObject leftMessagePrefab;
    public float messageDelay = 3.0f; // Tempo de atraso entre as mensagens

    public TMP_Text statusMaria;
    public Image cabecalho;
    public Image botoesFundo;
    public Image fotoMaria;

    public Button botao1;
    public Button botao2;
    public Button botao3;

    public GameObject ButtonPanel;

    private TMP_Text textoBotao1;
    private TMP_Text textoBotao2;
    private TMP_Text textoBotao3;


    public Image background;
    public TextMeshProUGUI textMessage;

    public bool animationEnabled = false;
    public float blinkDuration = 3f;
    public float textDuration = 3f;
    public float minAlpha = 0f;
    public float maxAlpha = 1f;

    private float elapsedTime;
    private float elapsedTextTime;
    public GameObject fadeImageObject;
    public Image fadeImage;
    public TMP_Text textoFadeImage;
    public TMP_Text diaFadeImage;
    private bool reverse = false;
    private string posTransicao;

    public TMP_Text dia;
    private string novoDia;

    public GameObject telasTransicao;
    public Image notificacaoDia1;
    public Image notificacaoDia2;
    public Image notificacaoDia22;
    public Image notificacaoDia3;
    public Image notificacaoDia32;
    public Image notificacaoDia4;
    public Image notificacaoDia5;
    public Image notificacaoDia6;
    public Image notificacaoDia7;
    public Button botaoTransicao;
    public Button botaoTransicao2;
    public TMP_Text textoBotaoTransicao2;

    public AudioSource musicAudioSource;
    public Image SomOn;
    public Image SomOff;

    void Start()
    {
        //Quarta Feira 22:40
        textoBotao1 = botao1.GetComponentInChildren<TMP_Text>();
        textoBotao2 = botao2.GetComponentInChildren<TMP_Text>();
        textoBotao3 = botao3.GetComponentInChildren<TMP_Text>();

        novoDia = "Qua 22:40";
        dia.text = novoDia;

        SpriteRenderer cabecalhoSpriteRenderer = cabecalho.GetComponent<SpriteRenderer>();
        SpriteRenderer botoesFundoSpriteRenderer = botoesFundo.GetComponent<SpriteRenderer>();
        
        StartCoroutine(Chat1());
    }

    void Update()
    {

        if (animationEnabled)
        {
            //Inicio da transicao
            Debug.Log("ficando preto?");
            fadeImageObject.SetActive(true);
            elapsedTime += Time.deltaTime;

            float actualAlpha = elapsedTime / blinkDuration;
            fadeImage.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(minAlpha, maxAlpha, actualAlpha);

            if (elapsedTime > blinkDuration)
            {
                //Preto
                if (elapsedTextTime < textDuration)
                {
                    Debug.Log("Inicio");
                    elapsedTextTime += Time.deltaTime;
                    dia.text = novoDia;    
                    
                }

                else if (reverse == false)
                {
                    //voltando do preto
                    Debug.Log("Meio");
                    float temp = maxAlpha;
                    maxAlpha = minAlpha;
                    minAlpha = temp;
                    elapsedTime = 0f;
                    elapsedTextTime = 0f;
                    reverse = true;   
                    telasDeNotificacao();    
                }
                else
                {
                    //acabou
                    Debug.Log("Fim da transição");
                    animationEnabled = false;
                    reverse = false;
                    elapsedTime = 0f;
                    elapsedTextTime = 0f;
                    maxAlpha = 1f;
                    minAlpha = 0f;
                    fadeImageObject.SetActive(false);
                    if(posTransicao == "chat36"){
                        botaoTransicao.gameObject.SetActive(true);
                    } else if( posTransicao == "chat465"){
                        botaoTransicao2.gameObject.SetActive(true);
                        textoBotaoTransicao2.gameObject.SetActive(true);
                    } else if( posTransicao == "chat64"){
                        botaoTransicao2.gameObject.SetActive(true);
                        textoBotaoTransicao2.gameObject.SetActive(true);
                    } else if(posTransicao == "chat685"){
                        botaoTransicao2.gameObject.SetActive(true);
                        textoBotaoTransicao2.gameObject.SetActive(true);
                    }else if( posTransicao == "chat715"){
                        botaoTransicao2.gameObject.SetActive(true);
                        textoBotaoTransicao2.gameObject.SetActive(true);
                    } else if( posTransicao == "chat74"){
                        botaoTransicao.gameObject.SetActive(true);
                    }else if(posTransicao == "chat87"){
                        botaoTransicao2.gameObject.SetActive(true);
                        textoBotaoTransicao2.gameObject.SetActive(true);
                    } else if(posTransicao == "chat106"){
                        botaoTransicao.gameObject.SetActive(true);
                    }
                    
                    ConfigureButtonTransition();
                    ConfigureButtonTransition2();
                }
            }
        }
    }

    public IEnumerator Chat1()
    {
        Debug.Log("comecou");
        dia.text = "Qua 22:40";
        yield return createNewMessageFromYou("oiee, tudo bem?🙏");
        yield return createNewMessageFromYou("vi a foto que você postou");
        yield return createNewMessageFromYou("voltou pra cidade?");
        yield return createNewMessageFromMe("oii, tudo bem e você?");

        setButtonOptionsAndShow(
            "Sim, voltei pra ver a família nas férias", () => StartCoroutine(chat2()),
            "Cheguei ontem!", () => StartCoroutine(chat3()),
            "Sim, estou visitando minha cidadezinha", () => StartCoroutine(chat4())
        );
    }

    public IEnumerator chat2()
    {
        Debug.Log("Chat2");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Sim, voltei pra ver a família nas férias");
        yield return createNewMessageFromYou("Ah, que bom!");
        yield return createNewMessageFromYou("Faz tempo que a gente não conversa, né?");

        setButtonOptionsAndShow(
            "Faz desde que eu me mudei, na verdade", () => StartCoroutine(chat5()),
            "Nem parece que faz três anos, né?", () => StartCoroutine(chat6()),
            "Nossa, sim. Saudade da nossa amizade", () => StartCoroutine(chat7())
        );
    }

    public IEnumerator chat3()
    {
        Debug.Log("Chat3");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Cheguei ontem!");
        yield return createNewMessageFromYou("Ah, que bom!");
        yield return createNewMessageFromYou("Faz tempo que a gente não conversa, né?");

        setButtonOptionsAndShow(
            "Faz desde que eu me mudei, na verdade", () => StartCoroutine(chat5()),
            "Nem parece que faz três anos, né?", () => StartCoroutine(chat6()),
            "Nossa, sim. Saudade da nossa amizade", () => StartCoroutine(chat7())
        );
    }

    public IEnumerator chat4()
    {
        Debug.Log("Chat4");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Sim, estou visitando minha cidadezinha");
        yield return createNewMessageFromYou("Ah, que bom!");
        yield return createNewMessageFromYou("Garotão da cidade grande kkkkkkkkkkkk");

        setButtonOptionsAndShow(
            "Faz desde que eu me mudei, na verdade", () => StartCoroutine(chat5()),
            "Nem parece que faz três anos, né?", () => StartCoroutine(chat6()),
            "Nossa, sim. Saudade da nossa amizade", () => StartCoroutine(chat7())
        );
    }

    public IEnumerator chat5()
    {
        Debug.Log("Chat5");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Faz desde que eu me mudei, na verdade");
        yield return createNewMessageFromYou("A gente tava andando de bicicleta");
        yield return createNewMessageFromYou("Saudades demais da nossa infância");

        setButtonOptionsAndShow(
           "Caraca o tempo voa", () => StartCoroutine(chat8()),
           "Essa época era boa", () => StartCoroutine(chat9()),
           "Oque ja me ralei andando de bicicleta", () => StartCoroutine(chat10())
         );
    }

    public IEnumerator chat6()
    {
        Debug.Log("Chat6");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Nem parece que faz 3 anos, né");
        yield return createNewMessageFromYou("A gente tava andando de bicicleta");
        yield return createNewMessageFromYou("Saudades demais da nossa infância");

        setButtonOptionsAndShow(
          "Caraca o tempo voa", () => StartCoroutine(chat8()),
          "Essa época era boa", () => StartCoroutine(chat9()),
          "Oque ja me ralei andando de bicicleta", () => StartCoroutine(chat10())
        );
    }

    public IEnumerator chat7()
    {
        Debug.Log("Chat7");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Nossa, sim. Saudade da nossa amizade");
        yield return createNewMessageFromYou("A gente tava andando de bicicleta");
        yield return createNewMessageFromYou("Saudades demais da nossa infância");

        setButtonOptionsAndShow(
          "Caraca o tempo voa", () => StartCoroutine(chat8()),
          "Essa época era boa", () => StartCoroutine(chat9()),
          "Oque ja me ralei andando de bicicleta", () => StartCoroutine(chat10())
        );
    }

    public IEnumerator chat8()
    {
        Debug.Log("Chat8");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Caraca o tempo voa");
        yield return createNewMessageFromMe("Lembra da vez que tu caiu da bike e quebrou o braço?");
        yield return createNewMessageFromYou("Lembro que simkkkkkkk");
        yield return createNewMessageFromYou("Fiquei um mês com aquele gesso");

        setButtonOptionsAndShow(
          "Mas eai, ta fazendo facul?", () => StartCoroutine(chat14()),
          "E vc ta trabalhando no shopping ainda?", () => StartCoroutine(chat15()),
          "E a tia Rose como ela esta?", () => StartCoroutine(chat16())
        );
    }

    public IEnumerator chat9()
    {
        Debug.Log("Chat9");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Essa época era boa, a gente se divertia um monte");
        yield return createNewMessageFromMe("Lembra da vez que tu caiu da bike e quebrou o braço?");
        yield return createNewMessageFromYou("Lembro que simkkkkkkk");
        yield return createNewMessageFromYou("Fiquei um mês com aquele gesso");

       setButtonOptionsAndShow(
          "Mas eai, ta fazendo facul?", () => StartCoroutine(chat14()),
          "E vc ta trabalhando no shopping ainda?", () => StartCoroutine(chat15()),
          "E a tia Rose como ela esta?", () => StartCoroutine(chat16())
        );
    }

    public IEnumerator chat10()
    {
        Debug.Log("Chat10");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("O quanto eu ja me ralei andando de bicicleta...");
        yield return createNewMessageFromMe("Lembra da vez que tu caiu da bike e quebrou o braço?");
        yield return createNewMessageFromYou("Lembro que simkkkkkkk");
        yield return createNewMessageFromYou("Fiquei um mês com aquele gesso");

        setButtonOptionsAndShow(
          "Mas eai, ta fazendo facul?", () => StartCoroutine(chat14()),
          "E vc ta trabalhando no shopping ainda?", () => StartCoroutine(chat15()),
          "E a tia Rose como ela esta?", () => StartCoroutine(chat16())
        );
    }

    public IEnumerator chat14()
    {
        Debug.Log("Chat14");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Mas eai ta fazendo facul?");
        yield return createNewMessageFromYou("Simm, estou");
        yield return createNewMessageFromYou("To cursando veterinária");
        yield return createNewMessageFromYou("Já estou no segundo semestre");
        yield return createNewMessageFromMe("ahh que showw");

        setButtonOptionsAndShow(
        "E ta curtindo?", () => StartCoroutine(chat17()),
        "Ta cuidando dos bichos então kkkkkkkkk", () => StartCoroutine(chat18()),
        "DESATIVADO", () => StartCoroutine(chat18())
        );
    }

    public IEnumerator chat15()
    {
        Debug.Log("Chat15");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ta trabalhando no shopping ainda");
        yield return createNewMessageFromYou("Pior que não");
        yield return createNewMessageFromYou("Saí de lá faz uns 6 meses");
        yield return createNewMessageFromYou("No momento estou desempregada");

        setButtonOptionsAndShow(
        "Poxa, Lembro que vc gosta de lá", () => StartCoroutine(chat19()),
        "Certeza algo melhor", () => StartCoroutine(chat20()),
        "DESATIVADO", () => StartCoroutine(chat20())
        );
    }

    public IEnumerator chat16()
    {
        Debug.Log("Chat16");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("E a tia Rose? como ela esta?");
        yield return createNewMessageFromYou("Ela ta bemm");
        yield return createNewMessageFromYou("To com saudades de tomar um tererê contigo🥺");
        yield return createNewMessageFromMe("Nossa vdd, saudades de uma tarde com um têres com vcs");
        yield return createNewMessageFromYou("Mas e a tia Nete tá bem também?");
        yield return createNewMessageFromYou("Vi ela no restaurante lá semana passada");
        yield return createNewMessageFromMe("Ela ta bem também");
        yield return createNewMessageFromMe("Ta matando a saudade do filhokkk");
        yield return createNewMessageFromMe("Fico feliz que ela esta conseguindo manter o restaurante");
        yield return createNewMessageFromMe("Ela realmente gosta do q faz");
        yield return createNewMessageFromYou("Ela é uma querida");
        yield return createNewMessageFromYou("E cozinha bem");
        yield return createNewMessageFromYou("Mas eii, você ta livre sexta a tarde?");
        yield return createNewMessageFromYou("Pensei em tomarmos o sorvete la do Edilson que a gente tomava nos tempos de escola");
        yield return createNewMessageFromMe("MDS O EDILSON");
        yield return createNewMessageFromMe("Vamos sim pô");
        yield return createNewMessageFromMe("Q horas vc pensa em ir?");
        yield return createNewMessageFromYou("acho que lá pelas 3 é uma boa!!");
        yield return createNewMessageFromMe("por mim ta show");
        yield return createNewMessageFromYou("Marcado então!");
        yield return createNewMessageFromYou("Mas vamos conversando");
        yield return createNewMessageFromYou("Tenho que dormir agora");
        yield return createNewMessageFromYou("Boa noitee");

        setButtonOptionsAndShow(
        "Fechou então", () => StartCoroutine(chat30()),
        "Bele", () => StartCoroutine(chat31()),
        "Vamos sim, boa noite", () => StartCoroutine(chat32())
        );
    }

    public IEnumerator chat17()
    {
        Debug.Log("Chat17");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("E ta curtindo?");
        yield return createNewMessageFromYou("To sim");
        yield return createNewMessageFromYou("1 semestre não foi muito interessante");
        yield return createNewMessageFromYou("Mas agora ta tendo bastante matérias legais");
        yield return createNewMessageFromYou("E vc, como tá seu curso?");
        yield return createNewMessageFromMe("Ta show, to curtindo muito");
        yield return createNewMessageFromMe("Tem umas matéria meio, mas o resto ta bacana");
        yield return createNewMessageFromYou("Que chique");
        yield return createNewMessageFromYou("Desde pequeno isso sempre foi a sua cara");
        yield return createNewMessageFromYou("Mas eii, você ta livre sexta a tarde?");
        yield return createNewMessageFromYou("Pensei em tomarmos o sorvete la do Edilson que a gente tomava nos tempos de escola");
        yield return createNewMessageFromMe("MDS O EDILSON");
        yield return createNewMessageFromMe("Vamos sim pô");
        yield return createNewMessageFromMe("Q horas vc pensa em ir?");
        yield return createNewMessageFromYou("acho que lá pelas 3 é uma boa!!");
        yield return createNewMessageFromMe("por mim ta show");
        yield return createNewMessageFromYou("Marcado então!");
        yield return createNewMessageFromYou("Mas vamos conversando");
        yield return createNewMessageFromYou("Tenho que dormir agora");
        yield return createNewMessageFromYou("Boa noitee");

        setButtonOptionsAndShow(
        "Fechou então", () => StartCoroutine(chat30()),
        "Bele", () => StartCoroutine(chat31()),
        "Vamos sim, boa noite", () => StartCoroutine(chat32())
        );
    }

    public IEnumerator chat18()
    {
        Debug.Log("Chat18");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ta cuidandando dos bicho entaokkkkkk");
        yield return createNewMessageFromYou("Kkkkkkkk to sim");
        yield return createNewMessageFromYou("E vc, como ta no curso?)");
        yield return createNewMessageFromMe("Ta show, to curtindo muito");
        yield return createNewMessageFromMe("Tem umas matéria meio, mas o resto ta bacana");
        yield return createNewMessageFromYou("Que chique");
        yield return createNewMessageFromYou("Desde pequeno isso sempre foi a sua cara");
        yield return createNewMessageFromYou("Mas eii, você ta livre sexta a tarde?");
        yield return createNewMessageFromYou("Pensei em tomarmos o sorvete la do Edilson que a gente tomava nos tempos de escola");
        yield return createNewMessageFromMe("MDS O EDILSON");
        yield return createNewMessageFromMe("Vamos sim pô");
        yield return createNewMessageFromMe("Q horas vc pensa em ir?");
        yield return createNewMessageFromYou("acho que lá pelas 3 é uma boa!!");
        yield return createNewMessageFromMe("por mim ta show");
        yield return createNewMessageFromYou("Marcado então!");
        yield return createNewMessageFromYou("Mas vamos conversando");
        yield return createNewMessageFromYou("Tenho que dormir agora");
        yield return createNewMessageFromYou("Boa noitee");

        setButtonOptionsAndShow(
        "Fechou então", () => StartCoroutine(chat30()),
        "Bele", () => StartCoroutine(chat31()),
        "Vamos sim, boa noite", () => StartCoroutine(chat32())
        );


    }

    public IEnumerator chat19()
    {
        Debug.Log("Chat19");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Poxa, lembro que vc gostava de lá");
        yield return createNewMessageFromYou("Simm, gostava bastante!");
        yield return createNewMessageFromYou("Saí por causa de umas brigas em casa");
        yield return createNewMessageFromYou("Mas nada demais");
        yield return createNewMessageFromYou("E vc ta trabalhando?");
        yield return createNewMessageFromMe("To fazendo estágio numa agência");
        yield return createNewMessageFromMe("É sofrido, mas pelo menos to na minha área");
        yield return createNewMessageFromYou("Mas você ta gostando?");

        setButtonOptionsAndShow(
         "Simmm, to aprendendo bastante", () => StartCoroutine(chat23()),
         "Mais ou menos, estagiário é muito desvalorizado", () => StartCoroutine(chat24()),
         "DESATIVADO", () => StartCoroutine(chat24())
         );
    }

    public IEnumerator chat20()
    {
        Debug.Log("Chat20");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Certeza que vc vai achar algo melhor");
        yield return createNewMessageFromYou("Tomara que sim🙏");
        yield return createNewMessageFromYou("Saí por causa de umas brigas em casa");
        yield return createNewMessageFromYou("Mas nada demais");
        yield return createNewMessageFromYou("E vc ta trabalhando?");
        yield return createNewMessageFromMe("To fazendo estágio numa agência");
        yield return createNewMessageFromMe("É sofrido, mas pelo menos to na minha área");
        yield return createNewMessageFromYou("Mas você ta gostando?");

        setButtonOptionsAndShow(
         "Simmm, to aprendendo bastante", () => StartCoroutine(chat23()),
         "Mais ou menos, estagiário é muito desvalorizado", () => StartCoroutine(chat24()),
         "DESATIVADO", () => StartCoroutine(chat24())
         );
    }

    public IEnumerator chat23()
    {
        Debug.Log("Chat23");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Simmm, to aprendendo bastante");
        yield return createNewMessageFromYou("Mas não é muito fácil");
        yield return createNewMessageFromYou("Pior que eu entendo");
        yield return createNewMessageFromYou("Mas eii, você ta livre sexta a tarde?");
        yield return createNewMessageFromYou("Pensei em tomarmos o sorvete la do Edilson que a gente tomava nos tempos de escola");
        yield return createNewMessageFromMe("MDS O EDILSON");
        yield return createNewMessageFromMe("Vamos sim pô");
        yield return createNewMessageFromMe("Q horas vc pensa em ir?");
        yield return createNewMessageFromYou("acho que lá pelas 3 é uma boa!!");
        yield return createNewMessageFromMe("por mim ta show");
        yield return createNewMessageFromYou("Marcado então!");
        yield return createNewMessageFromYou("Mas vamos conversando");
        yield return createNewMessageFromYou("Tenho que dormir agora");
        yield return createNewMessageFromYou("Boa noitee");

        setButtonOptionsAndShow(
        "Fechou então", () => StartCoroutine(chat30()),
        "Bele", () => StartCoroutine(chat31()),
        "Vamos sim, boa noite", () => StartCoroutine(chat32())
        );
    }

    public IEnumerator chat24()
    {
        Debug.Log("Chat24");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Mais ou menos, estagiário é muito desvalorizado😭");
        yield return createNewMessageFromYou("Pior que eu entendo");
        yield return createNewMessageFromYou("Mas eii, você ta livre sexta a tarde?");
        yield return createNewMessageFromYou("Pensei em tomarmos o sorvete la do Edilson que a gente tomava nos tempos de escola");
        yield return createNewMessageFromMe("MDS O EDILSON");
        yield return createNewMessageFromMe("Vamos sim pô");
        yield return createNewMessageFromMe("Q horas vc pensa em ir?");
        yield return createNewMessageFromYou("acho que lá pelas 3 é uma boa!!");
        yield return createNewMessageFromMe("por mim ta show");
        yield return createNewMessageFromYou("Mas vamos conversando");
        yield return createNewMessageFromYou("Tenho que dormir agora");
        yield return createNewMessageFromYou("Boa noitee");

        setButtonOptionsAndShow(
        "Fechou então", () => StartCoroutine(chat30()),
        "Bele", () => StartCoroutine(chat31()),
        "Vamos sim, boa noite", () => StartCoroutine(chat32())
        );
    }

    public IEnumerator chat30()
    {
        Debug.Log("Chat30");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Fechou então");

        setButtonOptionsAndShow(
       "Nos vemos na sexta", () => StartCoroutine(chat33()),
       "Até sexta!!", () => StartCoroutine(chat34()),
       "Boa noite!!", () => StartCoroutine(chat35())
       );
    }

    public IEnumerator chat31()
    {
        Debug.Log("Chat31");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Bele");

        setButtonOptionsAndShow(
       "Nos vemos na sexta", () => StartCoroutine(chat33()),
       "Até sexta!!", () => StartCoroutine(chat34()),
       "Boa noite!!", () => StartCoroutine(chat35())
       );
    }

    public IEnumerator chat32()
    {
        Debug.Log("Chat32");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Vamos sim, boa noite");

        setButtonOptionsAndShow(
       "Nos vemos na sexta", () => StartCoroutine(chat33()),
       "Até sexta!!", () => StartCoroutine(chat34()),
       "Boa noite", () => StartCoroutine(chat35())
       );
    }

    public IEnumerator chat33()
    {
        Debug.Log("Chat33");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Nos vemos na sexta");

        textoFadeImage.text = "Muito bom rever uma amiga de infância";
        diaFadeImage.text = "Sex 13:31";
        posTransicao = "chat36";
        novoDia = "Sext 13:31";
        animationEnabled = true;
    }

    public IEnumerator chat34()
    {
        Debug.Log("Chat34");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Até sexta");

        textoFadeImage.text = "Muito bom rever uma amiga de infância";
        diaFadeImage.text = "Sex 13:31";
        posTransicao = "chat36";
        novoDia = "Sex:13:31";
        animationEnabled = true;
    }

    public IEnumerator chat35()
    {
        Debug.Log("Chat35");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Boa noite!!");

        textoFadeImage.text = "Muito bom rever uma amiga de infância";
        diaFadeImage.text = "Sex 13:31";
        posTransicao = "chat36";
        novoDia = "Sex 13:31";
        animationEnabled = true;
    }

    public IEnumerator chat36()
    {
        //sexta feira 13:30
        Debug.Log("Chat36");
        ButtonPanel.SetActive(false);

        messageDelay = 0.000001f;
        yield return createNewMessageFromYou("Oiee");
        yield return createNewMessageFromYou("As 3 então?");
        messageDelay = 2.0f;
        yield return createNewMessageFromMe("Eaii");
        yield return createNewMessageFromMe("Sim ja to com roupa de ir");
        yield return createNewMessageFromYou("Lembra onde é ne?");

        setButtonOptionsAndShow(
      "Lembro simm", () => StartCoroutine(chat40()),
      "Simm, na antiga escola né?", () => StartCoroutine(chat41()),
      "Não tenho certeza", () => StartCoroutine(chat42())
      );
    }

    public IEnumerator chat40()
    {
        Debug.Log("Chat40");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Lembro simm");
        yield return createNewMessageFromYou("Acho bom!!");

        setButtonOptionsAndShow(
      "Nunca me esqueceria daquele lugar", () => StartCoroutine(chat43()),
      "Certo certo, então eu lembro", () => StartCoroutine(chat44()),
      "Aé vdd, lembrei agora", () => StartCoroutine(chat45())
      );
    }

    public IEnumerator chat41()
    {
        Debug.Log("Chat41");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Simm la perto da nossa antiga escola né");
        yield return createNewMessageFromYou("Issooo, 2 quadras ali pra baixo");

        setButtonOptionsAndShow(
      "Nunca me esqueceria daquele lugar", () => StartCoroutine(chat43()),
      "Certo certo, então eu lembro", () => StartCoroutine(chat44()),
      "Aé vdd, lembrei agora", () => StartCoroutine(chat45())
      );
    }

    public IEnumerator chat42()
    {
        Debug.Log("Chat42");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Não tenho certeza");
        yield return createNewMessageFromYou("seu esquecido");
        yield return createNewMessageFromYou("É 2 quadras pra baixo da nossa antiga escola");

        setButtonOptionsAndShow(
      "Nunca me esqueceria daquele lugar", () => StartCoroutine(chat43()),
      "Certo certo, então eu lembro", () => StartCoroutine(chat44()),
      "Aé vdd, lembrei agora", () => StartCoroutine(chat45())
      );
    }

    public IEnumerator chat43()
    {
        Debug.Log("Chat43");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Nunca me esqueceria daquele lugar😠");
        yield return createNewMessageFromYou("Beleza, se vemos lá");
        yield return createNewMessageFromMe("Beleee");
        yield return createNewMessageFromMe("Até depois");

        textoFadeImage.text = "(SORVETE)";
        diaFadeImage.text = "Mais tarde no mesmo dia";
        posTransicao = "chat465";
        novoDia = "Sex 23:04";  
        animationEnabled = true;
    }

    public IEnumerator chat44()
    {
        Debug.Log("Chat44");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Certo certo, então eu lembro");
        yield return createNewMessageFromYou("Beleza, se vemos lá");
        yield return createNewMessageFromMe("Beleee");
        yield return createNewMessageFromMe("Até depois");

        textoFadeImage.text = "(SORVETE)";
        diaFadeImage.text = "Mais tarde no mesmo dia";
        posTransicao = "chat465";
        novoDia = "Sex 23:04";
        animationEnabled = true;
    }

    public IEnumerator chat45()
    {
        Debug.Log("Chat45");
        ButtonPanel.SetActive(false);
        
        messageDelay = 2.0f;
        yield return createNewMessageFromMe("Aé vdd, lembrei agora");
        yield return createNewMessageFromYou("Beleza, se vemos lá");
        yield return createNewMessageFromMe("Beleee");
        yield return createNewMessageFromMe("Até depois");

        textoFadeImage.text = "(SORVETE)";
        diaFadeImage.text = "Mais tarde no mesmo dia";
        posTransicao = "chat465";
        novoDia = "Sex 23:04";
        animationEnabled = true;
    }

    public IEnumerator chat465()
    {
        //Sexta 23:00
        Debug.Log("Chat46.5");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("oiee dnv");


        setButtonOptionsAndShow(
      "Bom demais matar a saudade", () => StartCoroutine(chat46()),
      "Foi demais hj, me diverti muito", () => StartCoroutine(chat47()),
      "O sorvete do Edilson ta melhor que nunca", () => StartCoroutine(chat48())
      );

    }

    public IEnumerator chat46()
    {
        Debug.Log("Chat46");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Bom demais matar a saudade");
        yield return createNewMessageFromMe("Temos que sair de novo");
        yield return createNewMessageFromYou("Simmm temos mesmo");
        yield return createNewMessageFromYou("Aproveitar as férias");
        yield return createNewMessageFromMe("Claroo");
        yield return createNewMessageFromYou("Ah, falei que meu namorado ia perguntar com quem eu saí kkkkk");
        yield return createNewMessageFromYou("Acho que ele ficou com ciúmes");

        setButtonOptionsAndShow(
      "Deve ter ficado simkkkkkk", () => StartCoroutine(chat52()),
      "Minha nossa!", () => StartCoroutine(chat53()),
      "Espero que ele nao me cacekkkkkkk", () => StartCoroutine(chat54())
      );

    }

    public IEnumerator chat47()
    {
        Debug.Log("Chat47");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Foi demais hj, me diverti muito");
        yield return createNewMessageFromMe("Temos que sair de novo");
        yield return createNewMessageFromYou("Simmm temos mesmo");
        yield return createNewMessageFromYou("Aproveitar as férias");
        yield return createNewMessageFromMe("Claroo");
        yield return createNewMessageFromYou("Ah, falei que meu namorado ia perguntar com quem eu saí kkkkk");
        yield return createNewMessageFromYou("Acho que ele ficou com ciúmes");

        setButtonOptionsAndShow(
      "Deve ter ficado simkkkkkk", () => StartCoroutine(chat52()),
      "Minha nossa!", () => StartCoroutine(chat53()),
      "Espero que ele nao me cacekkkkkkk", () => StartCoroutine(chat54())
      );

    }

    public IEnumerator chat48()
    {
        Debug.Log("Chat48");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("O sorvete do Edilson ta melhor que nunca");
        yield return createNewMessageFromMe("Temos que sair de novo");
        yield return createNewMessageFromYou("Simmm temos mesmo");
        yield return createNewMessageFromYou("Aproveitar as férias");
        yield return createNewMessageFromMe("Claroo");
        yield return createNewMessageFromYou("Ah, falei que meu namorado ia perguntar com quem eu saí kkkkk");
        yield return createNewMessageFromYou("Acho que ele ficou com ciúmes");

        setButtonOptionsAndShow(
      "Deve ter ficado simkkkkkk", () => StartCoroutine(chat52()),
      "Minha nossa!", () => StartCoroutine(chat53()),
      "Espero que ele nao me cacekkkkkkk", () => StartCoroutine(chat54())
      );
    }

    public IEnumerator chat52()
    {
        Debug.Log("Chat52");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Deve ter ficado sim kkkkkkk");
        yield return createNewMessageFromMe("Mas e vc disse oq pra ele");
        yield return createNewMessageFromYou("Falei que era um amigo de infância");
        yield return createNewMessageFromYou("Mas ele é meio ciumento mesmo, fica tranquilo");

        setButtonOptionsAndShow(
      "Entendi", () => StartCoroutine(chat55()),
      "Capazkkkkk", () => StartCoroutine(chat56()),
      "Ah tranquilo", () => StartCoroutine(chat57())

      );
    }

    public IEnumerator chat53()
    {
        Debug.Log("Chat53");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Minha nossa!");
        yield return createNewMessageFromMe("Mas e vc disse oq pra ele");
        yield return createNewMessageFromYou("Falei que era um amigo de infância");
        yield return createNewMessageFromYou("Mas ele é meio ciumento mesmo, fica tranquilo");

        setButtonOptionsAndShow(
      "Entendi", () => StartCoroutine(chat55()),
      "Capazkkkkk", () => StartCoroutine(chat56()),
      "Ah tranquilo", () => StartCoroutine(chat57())

      );
    }

    public IEnumerator chat54()
    {
        Debug.Log("Chat54");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Espero que ele nao me cace kkkkkkk");
        yield return createNewMessageFromMe("Mas e vc disse oq pra ele");
        yield return createNewMessageFromYou("Falei que era um amigo de infância");
        yield return createNewMessageFromYou("Mas ele é meio ciumento mesmo, fica tranquilo");

        setButtonOptionsAndShow(
      "Entendi", () => StartCoroutine(chat55()),
      "Capazkkkkk", () => StartCoroutine(chat56()),
      "Ah tranquilo", () => StartCoroutine(chat57())

      );
    }

    public IEnumerator chat55()
    {
        Debug.Log("Chat55");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Entendi");
        yield return createNewMessageFromMe("Se for de boas bora fazer algo domingo então?");
        yield return createNewMessageFromYou("Podemos sim");
        yield return createNewMessageFromMe("Oq acha de tomarmos aquele Têres aqui em casa?");
        yield return createNewMessageFromMe("A mãe fez a boba da torta de bolacha😋");
        yield return createNewMessageFromYou("Bah, vou ter que ta indo né");
        yield return createNewMessageFromYou("Não da pra perder essa torta");
        yield return createNewMessageFromMe("Aí simm");
        yield return createNewMessageFromMe("Domingo vemos que horas fica melhor pode ser?");
        yield return createNewMessageFromYou("Pode ser sim, daí eu vejo que horas posso");
        yield return createNewMessageFromMe("beleeee, feshowww");
        yield return createNewMessageFromYou("Então até domingo");
        yield return createNewMessageFromYou("Preciso ir dormir agora");
        yield return createNewMessageFromYou("Boa noite!");

        setButtonOptionsAndShow(
     "Vou ir também", () => StartCoroutine(chat61()),
     "Até", () => StartCoroutine(chat62()),
     "Se falemo", () => StartCoroutine(chat63())

     );
    }

    public IEnumerator chat56()
    {
        Debug.Log("Chat56");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Capaz kkk");
        yield return createNewMessageFromMe("Se for de boas bora fazer algo domingo então?");
        yield return createNewMessageFromYou("Podemos sim");
        yield return createNewMessageFromMe("Oq acha de tomarmos aquele Têres aqui em casa?");
        yield return createNewMessageFromMe("A mãe fez a boba da torta de bolacha😋");
        yield return createNewMessageFromYou("Bah, vou ter que ta indo né");
        yield return createNewMessageFromYou("Não da pra perder essa torta");
        yield return createNewMessageFromMe("Aí simm");
        yield return createNewMessageFromMe("Domingo vemos que horas fica melhor pode ser?");
        yield return createNewMessageFromYou("Pode ser sim, daí eu vejo que horas posso");
        yield return createNewMessageFromMe("beleeee, feshowww");
        yield return createNewMessageFromYou("Então até domingo");
        yield return createNewMessageFromYou("Preciso ir dormir agora");
        yield return createNewMessageFromYou("Boa noite!");

        setButtonOptionsAndShow(
     "Vou ir também", () => StartCoroutine(chat61()),
     "Até", () => StartCoroutine(chat62()),
     "Se falemo", () => StartCoroutine(chat63())

     );
    }

    public IEnumerator chat57()
    {
        Debug.Log("Chat57");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ah tranquilo");
        yield return createNewMessageFromMe("Se for de boas bora fazer algo domingo então?");
        yield return createNewMessageFromYou("Podemos sim");
        yield return createNewMessageFromMe("Oq acha de tomarmos aquele Têres aqui em casa?");
        yield return createNewMessageFromMe("A mãe fez a boba da torta de bolacha😋");
        yield return createNewMessageFromYou("Bah, vou ter que ta indo né");
        yield return createNewMessageFromYou("Não da pra perder essa torta");
        yield return createNewMessageFromMe("Aí simm");
        yield return createNewMessageFromMe("Domingo vemos que horas fica melhor pode ser?");
        yield return createNewMessageFromYou("Pode ser sim, daí eu vejo que horas posso");
        yield return createNewMessageFromMe("beleeee, feshowww");
        yield return createNewMessageFromYou("Então até domingo");
        yield return createNewMessageFromYou("Preciso ir dormir agora");
        yield return createNewMessageFromYou("Boa noite!");

        setButtonOptionsAndShow(
     "Vou ir também", () => StartCoroutine(chat61()),
     "Até", () => StartCoroutine(chat62()),
     "Se falemo", () => StartCoroutine(chat63())

     );
    }

    public IEnumerator chat61()
    {
        Debug.Log("Cha61");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Vou ir também");
        yield return createNewMessageFromMe("Boa noite");

        textoFadeImage.text = "Hoje foi um dia bom";
        diaFadeImage.text = "Dom 12:40";
        posTransicao = "chat64";
        novoDia = "Dom 12:40";
        animationEnabled = true;
    }

    public IEnumerator chat62()
    {
        Debug.Log("Cha62");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Até");
        yield return createNewMessageFromMe("Boa noite");

        textoFadeImage.text = "Hoje foi um dia bom";
        diaFadeImage.text = "Dom 12:40";
        posTransicao = "chat64";
        novoDia = "Dom 12:40";
        animationEnabled = true;
    }

    public IEnumerator chat63()
    {
        Debug.Log("Cha63");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Se falemo");
        yield return createNewMessageFromMe("Boa noite");

        textoFadeImage.text = "Hoje foi um dia bom";
        diaFadeImage.text = "Dom 12:40";
        posTransicao = "chat64";
        novoDia = "Dom 12:40";
        animationEnabled = true;
    }

    public IEnumerator chat64()
    {
        //Domingo 12:40
        Debug.Log("Cha64");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("oii");
        yield return createNewMessageFromMe("sobre o teres hj");
        yield return createNewMessageFromMe("pode as 17:00?");
        yield return createNewMessageFromYou("Oii");
        yield return createNewMessageFromYou("Pode ser mais cedo?");
        yield return createNewMessageFromYou("Não posso chegar muito tarde em casa");

        setButtonOptionsAndShow(
     "Ué pq não pode??", () => StartCoroutine(chat65()),
     "Mais cedo que 17:00?? kkkkkk", () => StartCoroutine(chat66()),
     "Pode sim", () => StartCoroutine(chat67())
     );
    }

    public IEnumerator chat65()
    {
        Debug.Log("Cha65");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ué pq não pode?",true); //apaga
        yield return createNewMessageFromMe("16:00 então?"); // reescreve com esse texto
        yield return createNewMessageFromYou("Acho que esse horário fica massa");
        yield return createNewMessageFromYou("Lá pelas 16:00 chego ai então");
        yield return createNewMessageFromYou("Fica esperto ein😠");
        yield return createNewMessageFromMe("Feshoww");

        textoFadeImage.text = "(TERES)";
        diaFadeImage.text = "Mais tarde no mesmo dia";
        posTransicao = "chat685";
        novoDia = "Dom 22:16";
        animationEnabled = true;
    }

    public IEnumerator chat66()
    {
        Debug.Log("Cha66");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Mais cedo que 17:00? kk",true); //apaga
        yield return createNewMessageFromMe("16:00 então?"); // reescreve com esse texto
        yield return createNewMessageFromYou("Acho que esse horário fica massa");
        yield return createNewMessageFromYou("Lá pelas 16:00 chego ai então");
        yield return createNewMessageFromYou("Fica esperto ein😠");
        yield return createNewMessageFromMe("Feshoww");
        
        textoFadeImage.text = "(TERES)";
        diaFadeImage.text = "Mais tarde no mesmo dia";
        posTransicao = "chat685";
        novoDia = "Dom 22:16";
        animationEnabled = true;
    }

    public IEnumerator chat67()
    {
        Debug.Log("Cha67");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("pode sim"); // NÃO APAGA
        yield return createNewMessageFromMe("16:00 então?"); // reescreve com esse texto
        yield return createNewMessageFromYou("Acho que esse horário fica massa");
        yield return createNewMessageFromYou("Lá pelas 16:00 chego ai então", true);
        yield return createNewMessageFromYou("Fica esperto ein😠");
        yield return createNewMessageFromMe("Feshoww");

        textoFadeImage.text = "(TERES)";
        diaFadeImage.text = "Mais tarde no mesmo dia";
        posTransicao = "chat685";
        novoDia = "Dom 22:16";
        animationEnabled = true;
    }

    public IEnumerator chat685()
    {
        //Domingo 22:15
        Debug.Log("Cha685");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Eai");

        setButtonOptionsAndShow(
     "Resenha demais nosso papo", () => StartCoroutine(chat68()),
     "Meu aquele teres tava muito bom", () => StartCoroutine(chat69()),
     "A mãe adorou conversar contigo ein", () => StartCoroutine(chat70())
     );
    }

    public IEnumerator chat68()
    {
        Debug.Log("Cha68");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Resenha demais nosso papo");

        novoDia = "Seg 19:36";
        animationEnabled = true;
        textoFadeImage.text = "Deve ter dormido";
        diaFadeImage.text = "Seg 19:36";
        posTransicao = "chat715";

    }
    
    public IEnumerator chat69()
    {
        Debug.Log("Cha69");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Meu aquele teres tava muito bom");

        novoDia = "Seg 19:36";
        animationEnabled = true;
        textoFadeImage.text = "Deve ter dormido";
        diaFadeImage.text = "Seg 19:36";
        posTransicao = "chat715";
    }
    
    public IEnumerator chat70()
    {
        Debug.Log("Cha70");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("A mãe adorou conversar contigo ein🥺");

        novoDia = "Seg 19:36";
        animationEnabled = true;
        textoFadeImage.text = "Deve ter dormido";
        diaFadeImage.text = "Seg 19:36";
        posTransicao = "chat715";
    }
    
    public IEnumerator chat715()
    {
        //Segunda 19:36
        Debug.Log("Cha71.5");
        ButtonPanel.SetActive(false);

        /*
        // Define a cor desejada (164, 83, 171, 255) como um objeto Color
            Color novaCor = new Color(164 / 255f, 83 / 255f, 171 / 255f, 1f);

            // Altera a cor dos objetos desejados
            botoesFundo.color = novaCor;
            cabecalho.color = novaCor;
            fotoMaria.color = novaCor;
        */

        cabecalho.GetComponent<Image>().color = new Color32(190,162,162,255);
        botoesFundo.GetComponent<Image>().color = new Color32(190,162,162,255);
        
        yield return createNewMessageFromMe("Mariaa");

        setButtonOptionsAndShow(
     "Ta tudo certo?", () => StartCoroutine(chat71()),
     "Ta viva? kkkj", () => StartCoroutine(chat72()),
     "Alooou", () => StartCoroutine(chat73())
     );
    }
    
    public IEnumerator chat71()
    {
        Debug.Log("Cha71");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ta tudo certo?");

        novoDia = "Ter 20:07";
        animationEnabled = true;
        textoFadeImage.text = "Que Vácuo   será que aconteceu algo?";
        diaFadeImage.text = "Ter 20:07";
        posTransicao = "chat74";
    }
    
    public IEnumerator chat72()
    {
        Debug.Log("Cha72");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ta viva? kkkj");

        novoDia = "Ter 20:07";
        animationEnabled = true;
        textoFadeImage.text = "Que Vácuo   será que aconteceu algo?";
        diaFadeImage.text = "Ter 20:07";
        posTransicao = "chat74";
    }
    
    public IEnumerator chat73()
    {
        Debug.Log("Cha73");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Aloou");

        novoDia = "Ter 20:07";
        animationEnabled = true;
        textoFadeImage.text = "Que Vácuo   será que aconteceu algo?";
        diaFadeImage.text = "Ter 20:07";
        posTransicao = "chat74";
    }
    
    public IEnumerator chat74()
    {
        //Terça 20:07
        Debug.Log("Cha74");
        ButtonPanel.SetActive(false);

        cabecalho.GetComponent<Image>().color = new Color32(140,115,115,255);
        botoesFundo.GetComponent<Image>().color = new Color32(140,115,115,255);

        messageDelay= 0.000001f;
        yield return createNewMessageFromYou("Oi");
        yield return createNewMessageFromYou("Desculpa não consegui responder");
        yield return createNewMessageFromYou("Ontem e hoje foi bem corrido");

        setButtonOptionsAndShow(
     "Tranquilo", () => StartCoroutine(chat75()),
     "Aconteceu alguma coisa?", () => StartCoroutine(chat79()),
     "Ah, fiquei meio preocupado", () => StartCoroutine(chat80())
     );
    }

    public IEnumerator chat75()
    {
        Debug.Log("Cha75");
        ButtonPanel.SetActive(false);

        messageDelay = 2.0f;
        yield return createNewMessageFromMe("Tranquilo");
        yield return createNewMessageFromYou("Mas e vc ta td bem?");

        setButtonOptionsAndShow(
      "To tentando aproveitar as férias", () => StartCoroutine(chat76()),
      "to bem sim", () => StartCoroutine(chat79()),
      "Ah, fiquei meio preocupado", () => StartCoroutine(chat80())
      );
    }

    public IEnumerator chat76() //Aqui vai pular pro próximo dia
    {
        Debug.Log("Cha76");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Simm, to tentando aproveitar os últimos dias de fériaskkkkkk");
        yield return createNewMessageFromYou("E vc?");
        yield return createNewMessageFromYou("To bem também");

        novoDia = "Qui 19:50";
        animationEnabled = true;
        textoFadeImage.text = "Será que ele ta com ciúmes?                         Será que aconteceu alguma coisa?";
        diaFadeImage.text = "Qui 19:50";
        posTransicao = "chat87";
    }

    public IEnumerator chat77() //Aqui vai pular pro próximo dia
    {
        Debug.Log("Cha77");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("To bem sim");
        yield return createNewMessageFromYou("E vc?");
        yield return createNewMessageFromYou("To bem também");

        novoDia = "Qui 19:50";
        animationEnabled = true;
        textoFadeImage.text = "Será que ele ta com ciúmes?                      Será que aconteceu alguma coisa?";
        diaFadeImage.text = "Qui 19:50";
        posTransicao = "chat87";
    }
    
    public IEnumerator chat78()
    {
        Debug.Log("Cha78");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("To mas fiquei meio preocupado contigo");
        yield return createNewMessageFromYou("Só tava ocupada");
        yield return createNewMessageFromYou("O José tava aqui");

        setButtonOptionsAndShow(
     "Tranquilo", () => StartCoroutine(chat84()),
     "Aconteceu alguma coisa?", () => StartCoroutine(chat85()),
     "Ah, fiquei meio preocupado", () => StartCoroutine(chat86())
     );
    }
    
    public IEnumerator chat79()
    {
        Debug.Log("Cha79");
        ButtonPanel.SetActive(false);

        messageDelay = 2.0f;
        yield return createNewMessageFromMe("Aconteceu alguma coisa?");
        yield return createNewMessageFromYou("Nada não");
        yield return createNewMessageFromYou("Só tava ocupada");
        yield return createNewMessageFromYou("O josé tava aqui");

        setButtonOptionsAndShow(
     "Tranquilo", () => StartCoroutine(chat84()),
     "Aconteceu alguma coisa?", () => StartCoroutine(chat85()),
     "Ah, fiquei meio preocupado", () => StartCoroutine(chat86())
     );
    }
    
    public IEnumerator chat80()
    {
        Debug.Log("Cha80");
        ButtonPanel.SetActive(false);

        messageDelay = 2.0f;
        yield return createNewMessageFromMe("Ah, é que eu fiquei meio preocupado");
        yield return createNewMessageFromYou("Não tem pq se preocupar comigo");

        setButtonOptionsAndShow(
     "Ok", () => StartCoroutine(chat81()),
     "Tem Certeza?", () => StartCoroutine(chat82()),
     "Mas a gente é amigo", () => StartCoroutine(chat83())
     );
    }
    
    public IEnumerator chat81()
    {
        Debug.Log("Cha81");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ok");
        yield return createNewMessageFromYou("Relaxa, ta td certo");
        yield return createNewMessageFromYou("Só tava ocupada");
        yield return createNewMessageFromYou("O José tava aqui");

        setButtonOptionsAndShow(
     "Se aconteceu algo pode me contar", () => StartCoroutine(chat85()),
     "Ele fez alguma coisa?", () => StartCoroutine(chat86()),
     "Entendi", () => StartCoroutine(chat84())
     );
    }
    
    public IEnumerator chat82()
    {
        Debug.Log("Cha82");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Tem certeza?");
        yield return createNewMessageFromYou("Relaxa, ta td certo");
        yield return createNewMessageFromYou("Só tava ocupada");
        yield return createNewMessageFromYou("O José tava aqui");

        setButtonOptionsAndShow(
     "Se aconteceu algo pode me contar", () => StartCoroutine(chat85()),
     "Ele fez alguma coisa?", () => StartCoroutine(chat86()),
     "Entendi", () => StartCoroutine(chat84())
     );
    }
    
    public IEnumerator chat83()
    {
        Debug.Log("Cha83");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Tem certeza?");
        yield return createNewMessageFromYou("Relaxa, ta td certo");
        yield return createNewMessageFromYou("Só tava ocupada");
        yield return createNewMessageFromYou("O José tava aqui");

        setButtonOptionsAndShow(
     "Se aconteceu algo pode me contar", () => StartCoroutine(chat85()),
     "Ele fez alguma coisa?", () => StartCoroutine(chat86()),
     "Entendi", () => StartCoroutine(chat84())
     );
    }

    public IEnumerator chat84() //Aqui muda de dia
    {
        Debug.Log("Cha84");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Entendi");

        novoDia = "Qui 19:50";
        animationEnabled = true;
        textoFadeImage.text = "Será que ele ta com ciúmes?                           Será que aconteceu alguma coisa?";
        diaFadeImage.text = "Qui 19:50";
        posTransicao = "chat87";
    }

    public IEnumerator chat85() //Aqui muda de dia
    {
        Debug.Log("Cha85");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Se aconteceu algo pode me contar");
        yield return createNewMessageFromYou("Pode deixar");
        yield return createNewMessageFromYou("Mas ta td bem, sério");
        yield return createNewMessageFromMe("Ta né");

        novoDia = "Qui 19:50";
        animationEnabled = true;
        textoFadeImage.text = "Será que ele ta com ciúmes?                   Será que aconteceu alguma coisa?";
        diaFadeImage.text = "Qui 19:50";
        posTransicao = "chat87";
    }
    
    public IEnumerator chat86()// Aqui muda de dia
    {
        Debug.Log("Cha86");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ele fez alguma coisa?");
        yield return createNewMessageFromYou("???");
        yield return createNewMessageFromYou("Pq vc acha isso?");
        yield return createNewMessageFromMe("Nada não");
        yield return createNewMessageFromMe("desculpa");
        yield return createNewMessageFromYou("Ta ok");

        novoDia = "Qui 19:50";
        animationEnabled = true;
        textoFadeImage.text = "Será que ele ta com ciúmes?                   Será que aconteceu alguma coisa?";
        diaFadeImage.text = "Qui 19:50";
        posTransicao = "chat87";
    }

    public IEnumerator chat87()
    {
        Debug.Log("Cha87");
        ButtonPanel.SetActive(false);

        cabecalho.GetComponent<Image>().color = new Color32(79,65,65,255);
        botoesFundo.GetComponent<Image>().color = new Color32(79,65,65,255);

        yield return createNewMessageFromMe("Oi");
   
        setButtonOptionsAndShow(
     "Como estão as coisas?", () => StartCoroutine(chat88()),
     "Eai de boa?", () => StartCoroutine(chat89()),
     "Tudo certo", () => StartCoroutine(chat90())
     );
    }

    public IEnumerator chat88()
    {
        Debug.Log("Cha88");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Como estão as coisas?");
        yield return createNewMessageFromYou("Oi");
        yield return createNewMessageFromYou("Tranquilo");
        yield return createNewMessageFromMe("Semana que vem to indo embora ja");
        yield return createNewMessageFromMe("CTa afim de sair de novo antes de eu ir?");
        yield return createNewMessageFromMe("Amanhã talvez?");
        yield return createNewMessageFromYou("Cara, amanhã eu não consigo");
        yield return createNewMessageFromYou("Foi mal");

        setButtonOptionsAndShow(
     "Ok", () => StartCoroutine(chat91()),
     "E sábado?", () => StartCoroutine(chat92()),
     "Tudo bem, podemos ver outro dia então", () => StartCoroutine(chat93())
     );
    }

    public IEnumerator chat89()
    {
        Debug.Log("Cha89");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Eai de boas?");
        yield return createNewMessageFromYou("Oi");
        yield return createNewMessageFromYou("Tranquilo");
        yield return createNewMessageFromMe("Semana que vem to indo embora ja");
        yield return createNewMessageFromMe("CTa afim de sair de novo antes de eu ir?");
        yield return createNewMessageFromMe("Amanhã talvez?");
        yield return createNewMessageFromYou("Cara, amanhã eu não consigo");
        yield return createNewMessageFromYou("Foi mal");

        setButtonOptionsAndShow(
     "Ok", () => StartCoroutine(chat91()),
     "E sábado?", () => StartCoroutine(chat92()),
     "Tudo bem, podemos ver outro dia então", () => StartCoroutine(chat93())
     );
    }

    public IEnumerator chat90()
    {
        Debug.Log("Cha90");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Tudo certo?");
        yield return createNewMessageFromYou("Oi");
        yield return createNewMessageFromYou("Tudo sim");
        yield return createNewMessageFromMe("Semana que vem to indo embora ja");
        yield return createNewMessageFromMe("CTa afim de sair de novo antes de eu ir?");
        yield return createNewMessageFromMe("Amanhã talvez?");
        yield return createNewMessageFromYou("Cara, amanhã eu não consigo");
        yield return createNewMessageFromYou("Foi mal");

        setButtonOptionsAndShow(
     "Ok", () => StartCoroutine(chat91()),
     "E sábado?", () => StartCoroutine(chat92()),
     "Tudo bem, podemos ver outro dia então", () => StartCoroutine(chat93())
     );
    }

    public IEnumerator chat91()//Dia acabou
    {
        Debug.Log("Cha91");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Ok");

        novoDia = "Qua 09:16";
        animationEnabled = true;
        textoFadeImage.text = "Tenho certreza que o josé ta privando ela";
        diaFadeImage.text = "Duas semanas depois";
        posTransicao = "chat106";
    }

    public IEnumerator chat92()
    {
        Debug.Log("Cha92");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("E sábado?");
        yield return createNewMessageFromYou("Também não");
        yield return createNewMessageFromYou("Esse fim de semana não da");

        setButtonOptionsAndShow(
     "Tudo bem", () => StartCoroutine(chat94()),
     "Pq?", () => StartCoroutine(chat95()),
     "Tem alguma coisa a ver com o José?", () => StartCoroutine(chat96())
     );
    }

    public IEnumerator chat93()
    {
        Debug.Log("Cha93");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Tudo bem, podemos ver outro dia então");
        yield return createNewMessageFromYou("Sim vamos vendo");
        yield return createNewMessageFromYou("Mas não sei se vou poder");

        setButtonOptionsAndShow(
     "Tudo bem", () => StartCoroutine(chat94()),
     "Pq?", () => StartCoroutine(chat95()),
     "Tem alguma coisa a ver com o José?", () => StartCoroutine(chat96())
     );
    }

    public IEnumerator chat94()//dia acaba
    {
        Debug.Log("Cha94");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Tudo bem");

        novoDia = "Qua 09:16";
        animationEnabled = true;
        textoFadeImage.text = "Tenho certreza que o josé ta privando ela";
        diaFadeImage.text = "Duas semanas depois";
        posTransicao = "chat106";
    }

    public IEnumerator chat95()
    {
        Debug.Log("Cha95");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Pq?");
        yield return createNewMessageFromYou("Tô ocupada com uns trabalhos da facul");
        yield return createNewMessageFromYou("Desculpa mesmo");
        yield return createNewMessageFromYou("Queria muito poder ir");
        yield return createNewMessageFromMe("Você ta diferente");
        yield return createNewMessageFromYou("To?");

        setButtonOptionsAndShow(
     "Do nada tu ficou seca", () => StartCoroutine(chat97()),
     "Sei lá vc ta estranha", () => StartCoroutine(chat98()),
     "Tenho certeza que é seu namorado", () => StartCoroutine(chat99())
     );
    }

    public IEnumerator chat96()
    {
        Debug.Log("Cha96");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Tem lguma coisa a ver com o josé?",true);
        yield return createNewMessageFromMe("Pq?");
        yield return createNewMessageFromYou("Tô ocupada com uns trabalhos da facul");
        yield return createNewMessageFromYou("Desculpa mesmo");
        yield return createNewMessageFromYou("Queria muito poder ir");
        yield return createNewMessageFromMe("Você ta diferente");
        yield return createNewMessageFromYou("To?");

        setButtonOptionsAndShow(
     "Do nada tu ficou seca", () => StartCoroutine(chat97()),
     "Sei lá vc ta estranha", () => StartCoroutine(chat98()),
     "Tenho certeza que é seu namorado", () => StartCoroutine(chat99())
     );
    }
    
    public IEnumerator chat97()
    {
        Debug.Log("Cha97");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Do nada tu ficou seca");
        yield return createNewMessageFromYou("Olha");
        yield return createNewMessageFromYou("Não sei oq vc ta pensando");
        yield return createNewMessageFromYou("Mas eu só to cansada");

        setButtonOptionsAndShow(
     "Se tu diz...", () => StartCoroutine(chat100()),
     "Olha, eu sei que tem algo errado", () => StartCoroutine(chat101()),
     "Eu quero muito te ajudar", () => StartCoroutine(chat102())
     );
    }

    public IEnumerator chat98()
    {
        Debug.Log("Cha98");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Sei la vc ta estranha");
        yield return createNewMessageFromYou("Olha");
        yield return createNewMessageFromYou("Não sei oq vc ta pensando");
        yield return createNewMessageFromYou("Mas eu só to cansada");

        setButtonOptionsAndShow(
     "Se tu diz...", () => StartCoroutine(chat100()),
     "Olha, eu sei que tem algo errado", () => StartCoroutine(chat101()),
     "Eu quero muito te ajudar", () => StartCoroutine(chat102())
     );
    }

    public IEnumerator chat99()
    {
        Debug.Log("Cha99");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Tenho certeza que teu namorado ta te controlando",true);
        yield return createNewMessageFromMe("Sei la vc ta estranha");
        yield return createNewMessageFromYou("Olha");
        yield return createNewMessageFromYou("Não sei oq vc ta pensando");
        yield return createNewMessageFromYou("Mas eu só to cansada");

        setButtonOptionsAndShow(
     "Se tu diz...", () => StartCoroutine(chat100()),
     "Olha, eu sei que tem algo errado", () => StartCoroutine(chat101()),
     "Eu quero muito te ajudar", () => StartCoroutine(chat102())
     );
    }

    public IEnumerator chat100()
    {
        Debug.Log("Cha100");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Se tu diz...");
        yield return createNewMessageFromMe("Mas eu não acredito");
        yield return createNewMessageFromYou("Mesmo se tiver algo errado vc não tem pq se meter");
        yield return createNewMessageFromYou("Não quero causar confusão com isso");

        setButtonOptionsAndShow(
     "Me deixa falar com o José", () => StartCoroutine(chat103()),
     "Eu não to me metendo por me meter", () => StartCoroutine(chat104()),
     "Isso é ridículo", () => StartCoroutine(chat105())
     );
    }

    public IEnumerator chat101()
    {
        Debug.Log("Cha101");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Olha, eu sei que tem algo errado");
        yield return createNewMessageFromYou("E se tiver??");
        yield return createNewMessageFromYou("Vc não tem pq se meter");
        yield return createNewMessageFromYou("Não quero causar confusão com isso");

        setButtonOptionsAndShow(
     "Me deixa falar com o José", () => StartCoroutine(chat103()),
     "Eu não to me metendo por me meter", () => StartCoroutine(chat104()),
     "Isso é ridículo", () => StartCoroutine(chat105())
     );
    }

     public IEnumerator chat102()
    {
        Debug.Log("Cha102");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Olha eu quero muito poder te ajudar",true);
        yield return createNewMessageFromMe("Olha, eu sei que tem algo errado");
        yield return createNewMessageFromYou("E se tiver??");
        yield return createNewMessageFromYou("Vc não tem pq se meter");
        yield return createNewMessageFromYou("Não quero causar confusão com isso");

        setButtonOptionsAndShow(
     "Me deixa falar com o José", () => StartCoroutine(chat103()),
     "Eu não to me metendo por me meter", () => StartCoroutine(chat104()),
     "Isso é ridículo", () => StartCoroutine(chat105())
     );
    }
    public IEnumerator chat103()//troca pra mãe
    {
        Debug.Log("Cha103");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Me deixa falar com o José",true);
        yield return createNewMessageFromMe("Eu não to me metendo por me meter");
        yield return createNewMessageFromMe("Mas claramente vc ta assim por causa dele");
        yield return createNewMessageFromYou("É melhor pararmos de conversar");
        yield return createNewMessageFromYou("Vai ser melhor assim");
        yield return createNewMessageFromMe("Eu entendo");
        yield return createNewMessageFromMe("Isso não ta certo");
        yield return createNewMessageFromMe("Mas de qualquer forma se precisar de algo to aqui");
        yield return createNewMessageFromMe("Se cuida");
        yield return createNewMessageFromYou("Você também");

        novoDia = "Qua 09:16";
        animationEnabled = true;
        textoFadeImage.text = "Tenho certreza que o josé ta privando ela";
        diaFadeImage.text = "Duas semanas depois";
        posTransicao = "chat106";
    }

    public IEnumerator chat104()//troca pra mãe
    {
        Debug.Log("Cha104");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Eu não to me metendo por me meter");
        yield return createNewMessageFromMe("Eu não to me metendo por me meter");
        yield return createNewMessageFromMe("Mas claramente vc ta assim por causa dele");
        yield return createNewMessageFromYou("É melhor pararmos de conversar");
        yield return createNewMessageFromYou("Vai ser melhor assim");
        yield return createNewMessageFromMe("Eu entendo");
        yield return createNewMessageFromMe("Isso não ta certo");
        yield return createNewMessageFromMe("Mas de qualquer forma se precisar de algo to aqui");
        yield return createNewMessageFromMe("Se cuida");
        yield return createNewMessageFromYou("Você também");

        novoDia = "Qua 09:16";
        animationEnabled = true;
        textoFadeImage.text = "Tenho certreza que o josé ta privando ela";
        diaFadeImage.text = "Duas semanas depois";
        posTransicao = "chat106";
    }

    public IEnumerator chat105()//troca pra mãe
    {
        Debug.Log("Cha105");
        ButtonPanel.SetActive(false);

        yield return createNewMessageFromMe("Isso é ridiculo",true);
        yield return createNewMessageFromMe("Eu não to me metendo por me meter");
        yield return createNewMessageFromMe("Mas claramente vc ta assim por causa dele");
        yield return createNewMessageFromYou("É melhor pararmos de conversar");
        yield return createNewMessageFromYou("Vai ser melhor assim");
        yield return createNewMessageFromMe("Eu entendo");
        yield return createNewMessageFromMe("Isso não ta certo");
        yield return createNewMessageFromMe("Mas de qualquer forma se precisar de algo to aqui");
        yield return createNewMessageFromMe("Se cuida");
        yield return createNewMessageFromYou("Você também");

        novoDia = "Ter 12:32";
        animationEnabled = true;
        textoFadeImage.text = "Tenho certreza que o josé ta privando ela";
        diaFadeImage.text = "Duas semanas depois";
        posTransicao = "chat106";
    }

    public IEnumerator chat106()//Ultima conversa
    {
        Debug.Log("Cha106");
        ButtonPanel.SetActive(false);

        cabecalho.GetComponent<Image>().color = new Color32(0,0,0,255);
        botoesFundo.GetComponent<Image>().color = new Color32(0,0,0,255);

        messageDelay = 0.000001f;
        yield return createNewMessageFromYou("Filho");
        messageDelay = 2.0f;
        yield return createNewMessageFromMe("Oi mãe");
        yield return createNewMessageFromYou("Preciso te mostrar essa notícia");
        yield return createNewMessageFromYou("Link da notícia");
        yield return createNewMessageFromYou("Não consigo acreditar nisso");
        yield return createNewMessageFromMe("A MARIA????");
        yield return createNewMessageFromYou("Sim filho");
        yield return createNewMessageFromYou("O namorado dela....");
        yield return createNewMessageFromYou("Sinto muito");
        yield return createNewMessageFromMe("Não não não");
        yield return createNewMessageFromMe("Não pode ser verdade");
        yield return createNewMessageFromYou("Que tragédia");
        yield return createNewMessageFromYou("Ela tava aqui com nós esses dias");
        yield return createNewMessageFromYou("Você sabia de alguma coisa?");
        yield return createNewMessageFromYou("Ela tava aqui com nós esses dias");
        yield return createNewMessageFromYou("Você sabia de alguma coisa?");
        yield return createNewMessageFromMe("Ela deu alguns indícios que ele era agresivo");
        yield return createNewMessageFromMe("Mas eu não imaginei que chegaria nesse nível");
        yield return createNewMessageFromMe("Mas eu não imaginei que chegaria nesse nível");
        yield return createNewMessageFromMe("Achei que ela não queria ajuda");
        yield return createNewMessageFromYou("Talvez ela estivesse com medo de pedir ajuda");
        yield return createNewMessageFromMe("Eu sabia mãe...");
        yield return createNewMessageFromMe("Mas fiquei com medo de me intrometer");
        yield return createNewMessageFromMe("Eu devia ter feito alguma coisa");
        yield return createNewMessageFromMe("Ela não merecia");
        yield return createNewMessageFromMe("Preciso de um tempo para processar isso tudo");
        yield return createNewMessageFromYou("Se precisar de apoio estou aqui filho");
        yield return createNewMessageFromMe("Te amo, mãe");
        yield return createNewMessageFromYou("Também te amo filho");

    }

    //AQUI COMEÇA OS CREDITOS

    

    //Cria as mensagens
    public IEnumerator createNewMessageFromMe(string mensagem, bool vaiSerDeletada=false)
    {
        yield return waitSecondsAndCreateDialogChat(rightMessagePrefab, mensagem, vaiSerDeletada);
    }

    public IEnumerator createNewMessageFromYou(string mensagem, bool vaiSerDeletada=false)
    {
        yield return waitSecondsAndCreateDialogChat(leftMessagePrefab, mensagem, vaiSerDeletada);
    }

    public IEnumerator waitSecondsAndCreateDialogChat(GameObject prefab, string mensagem, bool vaiSerDeletada=false)
    {
        yield return new WaitForSeconds(messageDelay);

        GameObject newMessage = Instantiate(prefab, contentConversation.transform);

        newMessage.transform.localScale = new Vector3(1f, 1f, 1f);
        GameObject textMessage = newMessage.transform.Find("MessagePanel/MessageText").gameObject;
        Debug.Log(textMessage);
        TMP_Text textMeshPro = textMessage.GetComponent<TMP_Text>();
        textMeshPro.text = mensagem;

        if (vaiSerDeletada) {
            yield return new WaitForSeconds(messageDelay);
            textMeshPro.text = "🚫 Esta mensagem foi apagada";
        }

    }

    public void setButtonOptionsAndShow(string messageButton1, UnityAction actionButton1,
                                        string messageButton2, UnityAction actionButton2,
                                        string messageButton3, UnityAction actionButton3)
    {

        textoBotao1.text = messageButton1;
        botao1.onClick.RemoveAllListeners();
        botao1.onClick.AddListener(actionButton1);

        textoBotao2.text = messageButton2;
        botao2.onClick.RemoveAllListeners();
        botao2.onClick.AddListener(actionButton2);

        textoBotao3.text = messageButton3;
        botao3.onClick.RemoveAllListeners();
        botao3.onClick.AddListener(actionButton3);

        ButtonPanel.SetActive(true);

        if(messageButton3 == "DESATIVADO"){
            botao3.gameObject.SetActive(false);
        } else{
            botao3.gameObject.SetActive(true);
        }
    }
    
    public void telasDeNotificacao(){
        if(posTransicao == "chat36"){
            notificacaoDia2.gameObject.SetActive(true);
        }else if(posTransicao == "chat465"){
            notificacaoDia22.gameObject.SetActive(true);
        }else if(posTransicao == "chat64"){
            notificacaoDia3.gameObject.SetActive(true);
        }else if(posTransicao == "chat685") {
            notificacaoDia32.gameObject.SetActive(true);
        }else if(posTransicao == "chat715"){
            notificacaoDia4.gameObject.SetActive(true);
        }else if(posTransicao == "chat74"){
            notificacaoDia5.gameObject.SetActive(true);
        }else if(posTransicao == "chat87"){
            notificacaoDia6.gameObject.SetActive(true);
        }else if(posTransicao == "chat106"){
            notificacaoDia7.gameObject.SetActive(true);
        }
    }

    
    public void OnBotaoTransicaoClick()
    {      
        botaoTransicao.gameObject.SetActive(false);

        if(posTransicao == "chat36")
        {
            notificacaoDia2.gameObject.SetActive(false);
            StartCoroutine(chat36());
        } else if(posTransicao == "chat74"){
            notificacaoDia5.gameObject.SetActive(false);
            StartCoroutine(chat74());
        }else if(posTransicao == "chat106"){
            notificacaoDia7.gameObject.SetActive(false);
            StartCoroutine(chat106());
        }
        
    }

    public void ConfigureButtonTransition()
    {
        botaoTransicao.onClick.RemoveAllListeners();
        botaoTransicao.onClick.AddListener(OnBotaoTransicaoClick);
    }

    public void OnBotaoTransicao2Click(){

        botaoTransicao2.gameObject.SetActive(false);
        if(posTransicao == "chat465")
        {
            notificacaoDia22.gameObject.SetActive(false);
            textoBotaoTransicao2.gameObject.SetActive(false);
            StartCoroutine(chat465());
        } else if( posTransicao == "chat64"){
            notificacaoDia3.gameObject.SetActive(false);
            textoBotaoTransicao2.gameObject.SetActive(false);
            StartCoroutine(chat64());
        }else if(posTransicao == "chat685"){
            notificacaoDia32.gameObject.SetActive(false);
            textoBotaoTransicao2.gameObject.SetActive(false);
            StartCoroutine(chat685());
        }else if(posTransicao == "chat715"){
            notificacaoDia4.gameObject.SetActive(false);
            textoBotaoTransicao2.gameObject.SetActive(false);
            StartCoroutine(chat715());
        } else if(posTransicao == "chat87"){
            notificacaoDia6.gameObject.SetActive(false);
            textoBotaoTransicao2.gameObject.SetActive(false);
            StartCoroutine(chat87());
        }
    }

    public void ConfigureButtonTransition2()
    {
        botaoTransicao2.onClick.RemoveAllListeners();
        botaoTransicao2.onClick.AddListener(OnBotaoTransicao2Click);
    }
    
    public void ToggleMusic()
    {
        if (musicAudioSource.isPlaying)
        {
            musicAudioSource.Pause();
            SomOn.gameObject.SetActive(false);
            SomOff.gameObject.SetActive(true);
        }
        else
        {
            musicAudioSource.Play();
            SomOff.gameObject.SetActive(false);
            SomOn.gameObject.SetActive(true);
        }
    }
}
