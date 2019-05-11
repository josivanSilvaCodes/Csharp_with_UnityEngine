using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Networking;
using System.Xml;
using System;

public class POST_Form : MonoBehaviour
{
    private const string pMeuEmail = "josivan.engenharia@gmail.com"; // Colque seu email de cadastro do PagSeguro aqui
    private const string pMeuToken = "3004EC118BFE4455A2F983437C8Axxxx"; // tem que trocar para o seu token correto

    private string transactionCode = "";

    void Start()
    {
        PostForm();
    }


    //[HttpPost]
    public void PostForm()
    {
        string uri = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout";    //URI de checkout.

        System.Collections.Specialized.NameValueCollection postData = 
            new System.Collections.Specialized.NameValueCollection(); //Conjunto de parâmetros/formData.

        postData.Add("email", pMeuEmail);
        postData.Add("token", pMeuToken);
        postData.Add("currency", "BRL");
        postData.Add("itemId1", "0001");
        postData.Add("itemDescription1", "ProdutoPagSeguroI");
        postData.Add("itemAmount1", "3.00");
        postData.Add("itemQuantity1", "1");
        postData.Add("itemWeight1", "200");
        //postData.Add("date", "2019 - 02 - 05T15: 46:12.000 - 02:00");
        postData.Add("reference", "REF1234");
        postData.Add("senderName", "Jose Comprador");
        postData.Add("senderAreaCode", "44");
        postData.Add("senderPhone", "999999999");
        postData.Add("senderEmail", "comprador@uol.com.br");
        postData.Add("shippingAddressRequired", "false");

        string xmlString = null; //String que receberá o XML de retorno.

        using (WebClient wc = new WebClient())  //Webclient faz o post para o servidor de pagseguro.
        {            
            wc.Headers[HttpRequestHeader.ContentType] = 
                "application/x-www-form-urlencoded";  //Informa header sobre URL.

            var result = wc.UploadValues(uri, postData); //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
            xmlString = Encoding.ASCII.GetString(result);  //Obtém string do XML.
        }

        XmlDocument xmlDoc = new XmlDocument(); //Cria documento XML.
        xmlDoc.LoadXml(xmlString); //Carrega documento XML por string.
        var code = xmlDoc.GetElementsByTagName("code")[0]; //Obtém código de transação (Checkout).

        Debug.Log(code.InnerText);

        transactionCode = code.InnerText;
        var date = xmlDoc.GetElementsByTagName("date")[0];  //Obtém data de transação (Checkout).

        var paymentUrl = string.Concat(
            "https://pagseguro.uol.com.br/v2/checkout/payment.html?code=",
            code.InnerText);    //Monta a URL para pagamento.

        //CheckTransaction();
    }

    //[HttpPost]
    public void CheckTransaction()
    {
        string uri =
        "https://ws.sandbox.pagseguro.uol.com.br/v2/transactions/?&email=josivan.engenharia@gmail.com&token=3004EC118BFE4455A2F983437C8A56C0&initialDate=2018-10-20T15:20";
        HttpWebRequest request = 
            (HttpWebRequest)HttpWebRequest.Create(uri); //Classe que irá fazer a requisição GET.

        request.Method = "GET"; //Método do webrequest.        
        string xmlString = null; //String que vai armazenar o xml de retorno.

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) //Obtém resposta do servidor.
        {
            using (Stream dataStream = response.GetResponseStream())  //Cria stream para obter retorno.
            {
                using (StreamReader reader = new StreamReader(dataStream)) //Lê stream.
                {
                    xmlString = reader.ReadToEnd(); //Xml convertido para string.
                    XmlDocument xmlDoc = new XmlDocument();  //Cria xml document para facilitar acesso ao xml.
                    xmlDoc.LoadXml(xmlString); //Carrega xml document através da string com XML.
                    var status = xmlDoc.GetElementsByTagName("status")[0]; //Busca elemento status do XML.
                    reader.Close();  //Fecha reader.
                    dataStream.Close();  //Fecha stream.                    

                    Debug.Log(xmlString);
                    Debug.Log(status.InnerText);

                    /*if (status.InnerText == "3") //Verifica status de retorno.  3 = Pago.
                    {
                        Debug.Log("Pago.");
                    }
                    else //Outros resultados diferentes de 3.
                    {
                        Debug.Log("Pendente.");
                    }*/
                }
            }
        }
    }

    private static bool TrustCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
    {
        return true; // all Certificates are accepted
    }
}
 
 
