using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ConsumeEventSync
    {

        // GetAll
        public void GetAllEventData() //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:51346/api/Avaliacao"); //URI  
     //           Console.WriteLine(Environment.NewLine + result);

                List<Avaliacao> model = null;
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Avaliacao>>(result);

                Console.WriteLine("Listando Todos os " + model.Count + " registros:");
                Console.Write("-------------------------- \n");
                foreach (var item in model)
                {
                    Console.Write("Id: " + item.Id + "\n");
                    Console.Write("Nome: " + item.nome + "\n");
                    Console.Write("Cidade: " + item.cidade + "\n");
                    Console.Write("Estado: " + item.estado + "\n");
                    Console.Write("Data da criação: " + item._data + "\n");
                    Console.Write("-------------------------- \n");
                }
            }

        }

        // Busca
        public void GetAllEventData_ByEventID(string id) //Get All Events Records By ID  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:51346/api/Avaliacao/" + id); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }
        }

        // Add
        public void PostEvent_data(AddAvaliacao av) //Adding Event  
        {
            using (var client = new WebClient())
            {
                /*
                AddAvaliacao avaliacao = new AddAvaliacao(); //Setting parameter to post  
                avaliacao.nome = av.nome;
                avaliacao.cidade = av.cidade;
                avaliacao.estado = av.estado;
                avaliacao.tipo = av.tipo;
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
          
                var result = client.UploadString("http://localhost:51346/api/Avaliacao", "POST", Newtonsoft.Json.JsonConvert.SerializeObject(avaliacao));
                Console.WriteLine(result);
                Console.WriteLine("Avaliação adicionada com sucesso!");
                */
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("http://localhost:51346/");
                client1.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //####### Friends Seed ########
                AddAvaliacao avaliacao = new AddAvaliacao(); //Setting parameter to post  
                avaliacao.nome = av.nome;
                avaliacao.cidade = av.cidade;
                avaliacao.estado = av.estado;
                avaliacao.tipo = av.tipo;
                //#############################

                Task<HttpResponseMessage> response = client1.PostAsJsonAsync("api/Avaliacao", avaliacao);
                if (response.Result.IsSuccessStatusCode)
                    Console.WriteLine($"Avaliação  {avaliacao.nome} incluido com sucesso!");
            }
        }

        //Edit
        public void PutEvent_data(int EventID, Avaliacao av) //Update Event  
        {
            using (var client = new WebClient())
            {
                Avaliacao avaliacao = new Avaliacao(); //Setting parameter to post  
                avaliacao.nome = av.nome;
                avaliacao.cidade = av.estado;
                avaliacao.estado = av.cidade;
                avaliacao.tipo = av.tipo;
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("http://localhost:51346/api/Avaliacao/" + EventID, "PUT", Newtonsoft.Json.JsonConvert.SerializeObject(avaliacao));
                Console.WriteLine(result);
            }
        }

        //Delete
        public void DeleteEvent_data(int EventID) //Update Event  
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("http://localhost:51346/api/Avaliacao/" + EventID, "Delete", "");
                Console.WriteLine(result);
            }
        }
    }
}
